using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SQLite;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using fastJSON;
using System.Diagnostics;

namespace Задание
{
    public partial class PersonalSettings : DevExpress.XtraEditors.XtraUserControl
    {
        ErrorCollector errorCollector = new ErrorCollector();
        public static PersonalSettings personalSettings;
        public string StyleName = "";

        public PersonalSettings()
        {
            JSON.Parameters.UseUTCDateTime = false;
            JSON.Parameters.UseExtensions = false;
            JSON.Parameters.UseEscapedUnicode = false;
            JSON.Parameters.EnableAnonymousTypes = true;
            JSON.Parameters.IgnoreCaseOnDeserialize = true;
            JSON.Parameters.IgnoreUnderscopeOnDeserialize = true;

            InitializeComponent();
            personalSettings = this;

            DXErrorProvider.GetErrorIcon += DXErrorProvider_GetErrorIcon;

            if (StyleName == "Office 2016 Black")
                cbStyle.SelectedText = "Черная тема";
            else if (StyleName == "Office 2016 Dark")
                cbStyle.SelectedText = "Темная тема";
            else if (StyleName == "Office 2016 Colorful")
                cbStyle.SelectedText = "Светлая тема";
            else if (StyleName == "Seven Classic")
                cbStyle.SelectedText = "Без темы";
        }

        void DXErrorProvider_GetErrorIcon(GetErrorIconEventArgs e)
        {
            if (e.ErrorType == ErrorType.User1)
            {
                e.ErrorIcon = Properties.Resources.icon_error;
            }
        }

        public void LoadData()
        {
            LoadTitles();
            LoadHeadPosition();
            LoadUserPosition();
            LoadDivisions();
        }

        #region "Load Titles"
        private void LoadTitles()
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM Title";
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbHeadAuthorTitle.Properties.Items.Add(dr["Name"].ToString());
                        cbAuthorTitle.Properties.Items.Add(dr["Name"].ToString());
                    }
                }
                else
                {
                    conn.Close();
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region "Load Positions"
        private void LoadUserPosition()
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM PositionUser";
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbAuthorPosition.Properties.Items.Add(dr["Name"].ToString());
                    }
                }
                else
                {
                    conn.Close();
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadHeadPosition()
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM PositionHead";
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbHeadAuthorPosition.Properties.Items.Add(dr["Name"].ToString());
                    }
                }
                else
                {
                    conn.Close();
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region "Load Divisions"
        private void LoadDivisions()
        {
            try
            {
                cbHeadAuthorDivision.Properties.Items.Clear();
                cbAuthorDivision.Properties.Items.Clear();

                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM Divisions WHERE Level = 0";
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbHeadAuthorDivision.Properties.Items.Add(dr["Name"].ToString());
                        cbAuthorDivision.Properties.Items.Add(dr["Name"].ToString());
                    }
                    conn.Close();
                }
                else
                {
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "LoadDivisions()", false);
            }
        }

        private void cbHeadAuthorDivision_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                cbHeadAuthorService.Properties.Items.Clear(); cbHeadAuthorService.Text = string.Empty;
                cbHeadAuthorLine.Properties.Items.Clear(); cbHeadAuthorLine.Text = string.Empty;

                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM Divisions WHERE Level = 1 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @KeyID)";
                comm.Parameters.AddWithValue("@KeyID", cbHeadAuthorDivision.Text.Trim());
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbHeadAuthorService.Properties.Items.Add(dr["Name"].ToString());
                    }
                    conn.Close();
                }
                else
                {
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "cbHeadAuthorDivision_EditValueChanged()", false);
            }
        }

        private void cbHeadAuthorService_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                cbHeadAuthorLine.Properties.Items.Clear(); cbHeadAuthorLine.Text = string.Empty;

                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM Divisions WHERE Level = 2 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @KeyID)";
                comm.Parameters.AddWithValue("@KeyID", cbHeadAuthorService.Text.Trim());
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbHeadAuthorLine.Properties.Items.Add(dr["Name"].ToString());
                    }
                    conn.Close();
                }
                else
                {
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "cbHeadAuthorService_EditValueChanged()", false);
            }
        }

        private void cbAuthorDivision_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                cbAuthorService.Properties.Items.Clear(); cbAuthorService.Text = string.Empty;
                cbAuthorLine.Properties.Items.Clear(); cbAuthorLine.Text = string.Empty;
                cbAuthorDepartment.Properties.Items.Clear(); cbAuthorDepartment.Text = string.Empty;
                cbAuthorOffice.Properties.Items.Clear(); cbAuthorOffice.Text = string.Empty;

                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM Divisions WHERE Level = 1 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @Name AND Level = 0)";
                comm.Parameters.AddWithValue("@Name", cbAuthorDivision.Text.Trim());
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbAuthorService.Properties.Items.Add(dr["Name"].ToString());
                    }
                    conn.Close();
                }
                else
                {
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "cbAuthorDivision_EditValueChanged()", false);
            }
        }

        private void cbAuthorService_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                cbAuthorLine.Properties.Items.Clear(); cbAuthorLine.Text = string.Empty;
                cbAuthorDepartment.Properties.Items.Clear(); cbAuthorDepartment.Text = string.Empty;
                cbAuthorOffice.Properties.Items.Clear(); cbAuthorOffice.Text = string.Empty;

                if (!AuthorLine())
                {
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    conn.Open();
                    var comm = conn.CreateCommand();
                    comm.CommandText = "SELECT * FROM Divisions WHERE Level = 3 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @Name AND Level = 1 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @DivName AND Level = 0))";
                    comm.Parameters.AddWithValue("@Name", cbAuthorService.Text.Trim());
                    comm.Parameters.AddWithValue("@DivName", cbAuthorDivision.Text.Trim());
                    var dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cbAuthorDepartment.Properties.Items.Add(dr["Name"].ToString());
                        }
                    }
                    else
                    {
                        conn.Close();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "cbAuthorService_EditValueChanged()", false);
            }
        }

        private bool AuthorLine()
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM Divisions WHERE Level = 2 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @Name AND Level = 1 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @DivName AND Level = 0))";
                comm.Parameters.AddWithValue("@Name", cbAuthorService.Text.Trim());
                comm.Parameters.AddWithValue("@DivName", cbAuthorDivision.Text.Trim());
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbAuthorLine.Properties.Items.Add(dr["Name"].ToString());
                    }
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "AuthorLine()", false);
                return false;
            }
        }

        private void cbAuthorLine_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                cbAuthorDepartment.Properties.Items.Clear(); cbAuthorDepartment.Text = string.Empty;
                cbAuthorOffice.Properties.Items.Clear(); cbAuthorOffice.Text = string.Empty;

                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM Divisions WHERE Level = 3 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @Name AND Level = 2 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @SrvName AND Level = 1 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @DivName AND Level = 0)))";
                comm.Parameters.AddWithValue("@Name", cbAuthorLine.Text.Trim());
                comm.Parameters.AddWithValue("@SrvName", cbAuthorService.Text.Trim());
                comm.Parameters.AddWithValue("@DivName", cbAuthorDivision.Text.Trim());
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbAuthorDepartment.Properties.Items.Add(dr["Name"].ToString());
                    }
                }
                else
                {
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "cbAuthorLine_EditValueChanged()", false);
            }
        }

        private void cbAuthorDepartment_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                cbAuthorOffice.Properties.Items.Clear(); cbAuthorOffice.Text = string.Empty;

                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                if (cbAuthorLine.Text != string.Empty)
                {
                    comm.CommandText = "SELECT * FROM Divisions WHERE Level = 4 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @Name AND Level = 3 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @LineName AND Level = 2 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @SrvName AND Level = 1)))";
                    comm.Parameters.AddWithValue("@Name", cbAuthorDepartment.Text.Trim());
                    comm.Parameters.AddWithValue("@LineName", cbAuthorLine.Text.Trim());
                    comm.Parameters.AddWithValue("@SrvName", cbAuthorService.Text.Trim());
                }
                else
                {
                    comm.CommandText = "SELECT * FROM Divisions WHERE Level = 4 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @Name AND Level = 3 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @SrvName AND Level = 1 AND KeyID = (SELECT ID FROM Divisions WHERE Name = @DivName AND Level = 0)))";
                    comm.Parameters.AddWithValue("@Name", cbAuthorDepartment.Text.Trim());
                    comm.Parameters.AddWithValue("@SrvName", cbAuthorService.Text.Trim());
                    comm.Parameters.AddWithValue("@DivName", cbAuthorDivision.Text.Trim());
                }
                
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbAuthorOffice.Properties.Items.Add(dr["Name"].ToString());
                    }
                }
                else
                {
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "cbAuthorDepartment_EditValueChanged()", false);
            }
        }
        #endregion

        public void LoadUserSettings()
        {
            tbAuthorSurname.Text = UserSettings.SettingsList[0].UserSurname;
            tbAuthorName.Text = UserSettings.SettingsList[0].UserName;
            tbAuthorSecondName.Text = UserSettings.SettingsList[0].UserSecondName;
            cbAuthorPosition.Text = UserSettings.SettingsList[0].UserPosition;
            cbAuthorTitle.Text = UserSettings.SettingsList[0].UserTitle;
            tbAuthorWorkPlace.Text = UserSettings.SettingsList[0].UserComputer;
            tbAuthorPhone.Text = UserSettings.SettingsList[0].UserPhone;
            tbAuthorSurnameDative.Text = UserSettings.SettingsList[0].UserSurnameDative;
            tbAuthorNameDative.Text = UserSettings.SettingsList[0].UserNameDative;
            tbAuthorSecondNameDative.Text = UserSettings.SettingsList[0].UserSecondNameDative;

            cbAuthorDivision.Text = UserSettings.SettingsList[0].UserDivision;
            cbAuthorService.Text = UserSettings.SettingsList[0].UserService;
            cbAuthorLine.Text = UserSettings.SettingsList[0].UserLine;
            cbAuthorDepartment.Text = UserSettings.SettingsList[0].UserDepartment;
            cbAuthorOffice.Text = UserSettings.SettingsList[0].UserOffice;
        }

        public void LoadHeadSettings()
        {
            tbHeadAuthorSurname.Text = UserSettings.SettingsList[0].HeadSurname;
            tbHeadAuthorName.Text = UserSettings.SettingsList[0].HeadName;
            tbHeadAuthorSecondName.Text = UserSettings.SettingsList[0].HeadSecondName;
            cbHeadAuthorPosition.Text = UserSettings.SettingsList[0].HeadPosition;
            cbHeadAuthorTitle.Text = UserSettings.SettingsList[0].HeadTitle;
            tbHeadAuthorSurnameDative.Text = UserSettings.SettingsList[0].HeadSurnameDative;
            tbHeadAuthorNameDative.Text = UserSettings.SettingsList[0].HeadNameDative;
            tbHeadAuthorSecondNameDative.Text = UserSettings.SettingsList[0].HeadSecondNameDative;

            cbHeadAuthorDivision.Text = UserSettings.SettingsList[0].HeadDivision;
            cbHeadAuthorService.Text = UserSettings.SettingsList[0].HeadService;
            cbHeadAuthorLine.Text = UserSettings.SettingsList[0].HeadLine;
        }

        private void Loading()
        {
            Application.Run(new ApplyTheme());
        }

        private void cbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStyle.Text == "Черная тема")
            {
                try
                {
                    var thread = new Thread(new ThreadStart(Loading));
                    thread.Start();
                    Thread.Sleep(1000);

                    MainForm.mainForm.SkinManager.LookAndFeel.SkinName = "Office 2016 Black";
                    recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(38, 38, 38);
                    KeyControl.keyControl.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(38, 38, 38);
                    HeadApproveSettings.headApproveSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(38, 38, 38);
                    HeadAcceptSettings.headAcceptSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(38, 38, 38);
                    EventSettings.eventSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(38, 38, 38);
                    BaseEventSettings.baseEventSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(38, 38, 38);
                    BlankControl.blankControl.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(38, 38, 38);

                    thread.Abort();
                }
                catch (ThreadAbortException ex)
                {
                    errorCollector.ApplicationEvent(0, 1, ex.Message, "", true);
                }
            }
            else if (cbStyle.Text == "Темная тема")
            {
                try
                {
                    var thread = new Thread(new ThreadStart(Loading));
                    thread.Start();
                    Thread.Sleep(1000);

                    MainForm.mainForm.SkinManager.LookAndFeel.SkinName = "Office 2016 Dark";
                    recentItemControl.Appearances.RecentItemControl.BackColor = Color.DimGray;
                    KeyControl.keyControl.recentItemControl.Appearances.RecentItemControl.BackColor = Color.DimGray;
                    HeadApproveSettings.headApproveSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.DimGray;
                    HeadAcceptSettings.headAcceptSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.DimGray;
                    EventSettings.eventSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.DimGray;
                    BaseEventSettings.baseEventSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.DimGray;
                    BlankControl.blankControl.recentItemControl.Appearances.RecentItemControl.BackColor = Color.DimGray;

                    thread.Abort();
                }
                catch (ThreadAbortException ex)
                {
                    errorCollector.ApplicationEvent(0, 1, ex.Message, "", true);
                }
            }
            else if (cbStyle.Text == "Светлая тема")
            {
                try
                {
                    Thread thread = new Thread(new ThreadStart(Loading));
                    thread.Start();
                    Thread.Sleep(1000);

                    MainForm.mainForm.SkinManager.LookAndFeel.SkinName = "Office 2016 Colorful";
                    recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(240, 240, 240);
                    KeyControl.keyControl.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(240, 240, 240);
                    HeadApproveSettings.headApproveSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(240, 240, 240);
                    HeadAcceptSettings.headAcceptSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(240, 240, 240);
                    EventSettings.eventSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(240, 240, 240);
                    BaseEventSettings.baseEventSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(240, 240, 240);
                    BlankControl.blankControl.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(240, 240, 240);

                    thread.Abort();
                }
                catch (ThreadAbortException ex)
                {
                    errorCollector.ApplicationEvent(0, 1, ex.Message, "", true);
                }
            }
            else if (cbStyle.Text == "Без темы")
            {
                try
                {
                    Thread thread = new Thread(new ThreadStart(Loading));
                    thread.Start();
                    Thread.Sleep(1000);

                    MainForm.mainForm.SkinManager.LookAndFeel.SkinName = "Seven Classic";
                    recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(241, 241, 241);
                    KeyControl.keyControl.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(241, 241, 241);
                    HeadApproveSettings.headApproveSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(241, 241, 241);
                    HeadAcceptSettings.headAcceptSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(241, 241, 241);
                    EventSettings.eventSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(241, 241, 241);
                    BaseEventSettings.baseEventSettings.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(241, 241, 241);
                    BlankControl.blankControl.recentItemControl.Appearances.RecentItemControl.BackColor = Color.FromArgb(241, 241, 241);

                    thread.Abort();
                }
                catch (ThreadAbortException ex)
                {
                    errorCollector.ApplicationEvent(0, 1, ex.Message, "", true);
                }
            }
        }

        private void chbAutoLogout_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAutoLogout.Checked)
                tbTimer.Enabled = true;
            else
            {
                tbTimer.Enabled = false;
                tbTimer.Text = string.Empty;
            }
        }

        private string ConvertToDative(string Text, string Option)
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT Dative FROM " + Option + " WHERE Name = @Name";
                comm.Parameters.AddWithValue("@Name", Text);
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    string s = "";
                    while (dr.Read())
                    {
                        s = dr["Dative"].ToString();
                    }
                    conn.Close();
                    return s;
                }
                else
                {
                    conn.Close();
                    return Text;
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                return Text;
            }
        }

        private void btnPersSettingsSave_Click(object sender, EventArgs e)
        {
            List<UserSettingsControls> controls = new List<UserSettingsControls>();
            controls.Add(new UserSettingsControls { control = tbAuthorSurname, Flag = false });
            controls.Add(new UserSettingsControls { control = tbAuthorName, Flag = false });
            controls.Add(new UserSettingsControls { control = tbAuthorSecondName, Flag = false });
            controls.Add(new UserSettingsControls { control = tbAuthorSurnameDative, Flag = false });
            controls.Add(new UserSettingsControls { control = tbAuthorNameDative, Flag = false });
            controls.Add(new UserSettingsControls { control = tbAuthorSecondNameDative, Flag = false });
            controls.Add(new UserSettingsControls { control = cbAuthorPosition, Flag = false });
            controls.Add(new UserSettingsControls { control = cbAuthorTitle, Flag = false });
            controls.Add(new UserSettingsControls { control = cbAuthorDivision, Flag = false });
            controls.Add(new UserSettingsControls { control = cbAuthorService, Flag = false });
            controls.Add(new UserSettingsControls { control = cbAuthorDepartment, Flag = false });
            controls.Add(new UserSettingsControls { control = tbAuthorPhone, Flag = false });
            controls.Add(new UserSettingsControls { control = tbAuthorWorkPlace, Flag = false });

            if (ValidateUserSettingsFields(controls))
            {
                UserSettings.SettingsList[0].UserSurname = tbAuthorSurname.Text.Trim();
                UserSettings.SettingsList[0].UserName = tbAuthorName.Text.Trim();
                UserSettings.SettingsList[0].UserSecondName = tbAuthorSecondName.Text.Trim();
                UserSettings.SettingsList[0].UserSurnameDative = tbAuthorSurnameDative.Text.Trim();
                UserSettings.SettingsList[0].UserNameDative = tbAuthorNameDative.Text.Trim();
                UserSettings.SettingsList[0].UserSecondNameDative = tbAuthorSecondNameDative.Text.Trim();
                UserSettings.SettingsList[0].UserPosition = cbAuthorPosition.Text.Trim();
                UserSettings.SettingsList[0].UserTitle = cbAuthorTitle.Text.Trim();
                UserSettings.SettingsList[0].UserPositionDative = ConvertToDative(cbAuthorPosition.Text.Trim(), "PositionUser");
                UserSettings.SettingsList[0].UserTitleDative = ConvertToDative(cbAuthorTitle.Text.Trim(), "Title");

                UserSettings.SettingsList[0].UserDivision = cbAuthorDivision.Text.Trim();
                UserSettings.SettingsList[0].UserService = cbAuthorService.Text.Trim();
                UserSettings.SettingsList[0].UserLine = cbAuthorLine.Text.Trim();
                UserSettings.SettingsList[0].UserDepartment = cbAuthorDepartment.Text.Trim();
                UserSettings.SettingsList[0].UserOffice = cbAuthorOffice.Text.Trim();

                UserSettings.SettingsList[0].UserPhone = tbAuthorPhone.Text.Trim();
                UserSettings.SettingsList[0].UserComputer = tbAuthorWorkPlace.Text.Trim();

                if (MainForm.mainForm.LoadSettings)
                {
                    Task.task.LoadUserSettings();
                }

                if (SavePersonalSettings())
                {
                    XtraMessageBox.Show("Настройки были успешно сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                XtraMessageBox.Show("Заполните все необходимые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHeadSettingsSave_Click(object sender, EventArgs e)
        {
            List<UserSettingsControls> controls = new List<UserSettingsControls>();
            controls.Add(new UserSettingsControls { control = tbHeadAuthorSurname, Flag = false });
            controls.Add(new UserSettingsControls { control = tbHeadAuthorName, Flag = false });
            controls.Add(new UserSettingsControls { control = tbHeadAuthorSecondName, Flag = false });
            controls.Add(new UserSettingsControls { control = tbHeadAuthorSurnameDative, Flag = false });
            controls.Add(new UserSettingsControls { control = tbHeadAuthorNameDative, Flag = false });
            controls.Add(new UserSettingsControls { control = tbHeadAuthorSecondNameDative, Flag = false });
            controls.Add(new UserSettingsControls { control = cbHeadAuthorPosition, Flag = false });
            controls.Add(new UserSettingsControls { control = cbHeadAuthorTitle, Flag = false });
            controls.Add(new UserSettingsControls { control = cbHeadAuthorDivision, Flag = false });
            controls.Add(new UserSettingsControls { control = cbHeadAuthorService, Flag = false });
            controls.Add(new UserSettingsControls { control = cbHeadAuthorLine, Flag = false });

            if (ValidateUserSettingsFields(controls))
            {
                UserSettings.SettingsList[0].HeadSurname = tbHeadAuthorSurname.Text.Trim();
                UserSettings.SettingsList[0].HeadName = tbHeadAuthorName.Text.Trim();
                UserSettings.SettingsList[0].HeadSecondName = tbHeadAuthorSecondName.Text.Trim();
                UserSettings.SettingsList[0].HeadSurnameDative = tbHeadAuthorSurnameDative.Text.Trim();
                UserSettings.SettingsList[0].HeadNameDative = tbHeadAuthorNameDative.Text.Trim();
                UserSettings.SettingsList[0].HeadSecondNameDative = tbHeadAuthorSecondNameDative.Text.Trim();
                UserSettings.SettingsList[0].HeadPosition = cbHeadAuthorPosition.Text.Trim();
                UserSettings.SettingsList[0].HeadTitle = cbHeadAuthorTitle.Text.Trim();
                UserSettings.SettingsList[0].HeadPositionDative = ConvertToDative(cbHeadAuthorPosition.Text.Trim(), "PositionHead");
                UserSettings.SettingsList[0].HeadTitleDative = ConvertToDative(cbHeadAuthorTitle.Text.Trim(), "Title");

                UserSettings.SettingsList[0].HeadDivision = cbHeadAuthorDivision.Text.Trim();
                UserSettings.SettingsList[0].HeadService = cbHeadAuthorService.Text.Trim();
                UserSettings.SettingsList[0].HeadLine = cbHeadAuthorLine.Text.Trim();

                if (MainForm.mainForm.LoadSettings)
                {
                    Task.task.LoadUserSettings();
                }

                if (SavePersonalSettings())
                {
                    XtraMessageBox.Show("Настройки были успешно сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                XtraMessageBox.Show("Заполните все необходимые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProgramSettingsSave_Click(object sender, EventArgs e)
        {
            if (SaveCommonSettings())
            {
                var dialog = XtraMessageBox.Show("Для активации выбранных настроек необходим перезапуск программы!\r\nВыполнить перезапуск сейчас?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    MainForm.mainForm.Close();
                    Process.Start(Application.StartupPath + "\\Задание.exe");
                }
            }
        }

        private bool SaveCommonSettings()
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionUserData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "UPDATE Users SET LoadSettings = @LoadSettings, LoadAnimation = @LoadAnimation, AllowDisconnect = @AllowDisconnect, DisconnectTimeout = @DisconnectTimeout, Theme = @Theme WHERE ID = @ID";
                comm.Parameters.AddWithValue("@ID", MainForm.mainForm.UserID);
                if (chbDataLoad.Checked)
                    comm.Parameters.AddWithValue("@LoadSettings", 0);
                else
                    comm.Parameters.AddWithValue("@LoadSettings", 1);

                if (chbWindowAnimation.Checked)
                    comm.Parameters.AddWithValue("@LoadAnimation", 0);
                else
                    comm.Parameters.AddWithValue("@LoadAnimation", 1);

                if (chbAutoLogout.Checked)
                    comm.Parameters.AddWithValue("@AllowDisconnect", 1);
                else
                    comm.Parameters.AddWithValue("@AllowDisconnect", 0);

                if (tbTimer.Text != string.Empty)
                    comm.Parameters.AddWithValue("@DisconnectTimeout", Convert.ToInt32(tbTimer.Text));
                else
                    comm.Parameters.AddWithValue("@DisconnectTimeout", 0);

                if (cbStyle.Text == "Черная тема")
                    comm.Parameters.AddWithValue("@Theme", "Office 2016 Black");
                else if (cbStyle.Text == "Темная тема")
                    comm.Parameters.AddWithValue("@Theme", "Office 2016 Dark");
                else if (cbStyle.Text == "Светлая тема")
                    comm.Parameters.AddWithValue("@Theme", "Office 2016 Colorful");
                else if (cbStyle.Text == "Без темы")
                    comm.Parameters.AddWithValue("@Theme", "Seven Classic");

                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "SaveCommonSettings()", false);
                return false;
            }
        }

        private bool SavePersonalSettings()
        {
            string json = JSON.Instance.ToJSON(UserSettings.SettingsList);
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionUserData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "UPDATE UserData SET UserData = @UserData WHERE UserID = @UserID";
                comm.Parameters.AddWithValue("@UserData", json);
                comm.Parameters.AddWithValue("@UserID", MainForm.mainForm.UserID);
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "SavePersonalSettings()", false);
                return false;
            }
        }

        private bool ValidateUserSettingsFields(List<UserSettingsControls> controls)
        {
            foreach (var item in controls)
            {
                if (item.control.Text == string.Empty || item.control.Text.Length == 0)
                {
                    item.Flag = false;
                    dxErrorProvider.SetError(item.control, "Необходимо заполнить это поле", ErrorType.User1);
                }
                else
                {
                    item.Flag = true;
                    dxErrorProvider.SetError(item.control, "");
                }
            }

            if (controls.Where(x => x.Flag == false).Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        class UserSettingsControls
        {
            public BaseEdit control { get; set; }
            public bool Flag { get; set; }
        }
    }
}
