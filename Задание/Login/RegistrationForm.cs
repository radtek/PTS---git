using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using DevExpress.XtraEditors;
using Cyriller;
using fastJSON;

namespace Задание
{
    public partial class RegistrationForm : DevExpress.XtraEditors.XtraForm
    {
        #region "Declaration"

        public static RegistrationForm registrationForm;
        string userConnString = "Data Source=Data\\UserData.db;Version=3;";
        string dictConnString = "Data Source=Data\\Dictionary.db;Version=3;";

        Crypt crypt = new Crypt();
        CyrName convertName = new CyrName();
        string userLogin = "";
        string userPassword = "";
        bool Flag = false;

        #endregion        

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            LoadTitles();
            LoadUserPositions();
            LoadHeadPositions();
            LoadUserDivision();
            LoadHeadDivision();
        }

        #region "Form Closing"
        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (navigationFrame1.SelectedPageIndex >= 2 && navigationFrame1.SelectedPageIndex < 7)
            {
                var dialog = XtraMessageBox.Show("Вы точно хотите прервать процедуру регистрации?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        SQLiteConnection conn = new SQLiteConnection(userConnString);
                        conn.Open();
                        SQLiteCommand comm = conn.CreateCommand();
                        comm.CommandText = "DELETE FROM Users WHERE Login = @Login";
                        comm.Parameters.AddWithValue("@Login", userLogin);
                        comm.ExecuteNonQuery();
                        conn.Close();

                        e.Cancel = false;
                    }
                    catch (SQLiteException ex)
                    {
                        XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }
        #endregion

        private void tbAdminAccess_EditValueChanged(object sender, EventArgs e)
        {
            if (tbAdminAccess.Text.Trim() == "!QAZ1qaz")
                cbAdmin.Visible = true;
            else
                cbAdmin.Visible = false;
        }

        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {
            tbAdminAccess.Visible = true;
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                tbUserPassword.Properties.PasswordChar = '\0';
                tbUserPasswordRepit.Properties.PasswordChar = '\0';
            }
            else
            {
                tbUserPassword.Properties.PasswordChar = char.Parse("●");
                tbUserPasswordRepit.Properties.PasswordChar = char.Parse("●");
            }
        }

        #region "Navigation"
        private void btnStartRegistartion_Click(object sender, EventArgs e)
        {
            if (cbAdmin.Checked)
                Flag = true;
            else
                Flag = false;

            navigationFrame1.SelectNextPage();
        }

        private void btnNextFirstPage_Click(object sender, EventArgs e)
        {
            CreateNewUser();
        }

        private void btnNextSecondPage_Click(object sender, EventArgs e)
        {
            if (tbUserSurname.Text != "" && 
                tbUserName.Text != "" && 
                tbUserSecondName.Text != "" && 
                cbUserPosition.Text != "" && 
                cbUserTitle.Text != "" && 
                tbUserWorkStation.Text != "" && 
                tbUserPhone.Text != "")
            {
                navigationFrame1.SelectNextPage();
            }
        }

        private void btnBackSecondPage_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectPrevPage();
        }

        private void btnNextThirdPage_Click(object sender, EventArgs e)
        {
            if (cbUserDivision.EditValue != null && cbUserService.EditValue != null)
            {
                navigationFrame1.SelectNextPage();
            }
        }

        private void btnBackThirdPage_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectPrevPage();
        }

        private void btnNextFifthPage_Click(object sender, EventArgs e)
        {
            if (tbHeadSurname.Text != "" && 
                tbHeadName.Text != "" && 
                tbHeadSecondName.Text != "" && 
                cbHeadPosition.Text != "" && 
                cbHeadTitle.Text != "" && 
                cbHeadDivision.EditValue != null && 
                cbHeadService.EditValue != null)
            {
                navigationFrame1.SelectNextPage();
                ConvertUserSettings();
            }
        }

        private void btnBackFifthPage_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectPrevPage();            
        }

        private void btnNextSixthPage_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectNextPage();
            ConvertHeadSettings();
        }

        private void btnBackSixthPage_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectPrevPage();
        }

        private void btnNextSeventhPage_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectNextPage();
        }

        private void btnBackSeventhPage_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectPrevPage();
        }

        private void btnFinishRegistration_Click(object sender, EventArgs e)
        {
            JsonSettings();
        }
        #endregion

        #region "Create New User"
        private void CreateNewUser()
        {
            if (tbUserLogin.Text != "")
            {
                if (tbUserLogin.Text.Length >= 3)
                {
                    using (var conn = new SQLiteConnection(userConnString))
                    {
                        conn.Open();
                        using (var comm = new SQLiteCommand("SELECT * FROM Users WHERE Login = @Login", conn))
                        {
                            comm.Parameters.AddWithValue("@Login", tbUserLogin.Text.Trim());
                            using (var dr = comm.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    XtraMessageBox.Show("Такой пользователь уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbUserLogin.Text = "";
                                    tbUserLogin.Focus();
                                }
                                else
                                {
                                    if (tbUserPassword.Text != "")
                                    {
                                        if (tbUserPasswordRepit.Text != "")
                                        {
                                            if (tbUserPassword.Text.Length >= 6)
                                            {
                                                if (tbUserPassword.Text.Trim() == tbUserPasswordRepit.Text.Trim())
                                                {
                                                    try
                                                    {
                                                        SQLiteConnection connection = new SQLiteConnection(userConnString);
                                                        connection.Open();
                                                        SQLiteCommand command = connection.CreateCommand();
                                                        command.CommandText = "INSERT INTO Users " +
                                                                              "(Login, Password, Flag, LoadSettings, LoadAnimation, AllowDisconnect, DisconnectTimeout, Theme)" +
                                                                              "VALUES " +
                                                                              "(@Login, @Password, @Flag, @LoadSettings, @LoadAnimation, @AllowDisconnect, @DisconnectTimeout, @Theme)";
                                                        command.Parameters.AddWithValue("@Login", tbUserLogin.Text.Trim());
                                                        command.Parameters.AddWithValue("@Password", crypt.Encrypt(tbUserPassword.Text.Trim()));
                                                        command.Parameters.AddWithValue("@Flag", Flag);
                                                        command.Parameters.AddWithValue("@LoadSettings", true);
                                                        command.Parameters.AddWithValue("@LoadAnimation", true);
                                                        command.Parameters.AddWithValue("@AllowDisconnect", false);
                                                        command.Parameters.AddWithValue("@DisconnectTimeout", 0);
                                                        command.Parameters.AddWithValue("@Theme", "Office 2016 Colorful");
                                                        command.ExecuteNonQuery();
                                                        connection.Close();

                                                        userLogin = tbUserLogin.Text.Trim();
                                                        userPassword = tbUserPassword.Text.Trim();

                                                        navigationFrame1.SelectNextPage();
                                                    }
                                                    catch (SQLiteException ex)
                                                    {
                                                        XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                }
                                                else
                                                {
                                                    XtraMessageBox.Show("Введенные пароли не совпадают! Повторите ввод!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    tbUserPassword.Text = "";
                                                    tbUserPasswordRepit.Text = "";
                                                    tbUserPassword.Focus();
                                                }
                                            }
                                            else
                                            {
                                                XtraMessageBox.Show("Минимальная длина пароля - 6 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                tbUserPassword.Text = "";
                                                tbUserPasswordRepit.Text = "";
                                                tbUserPassword.Focus();
                                            }
                                        }
                                        else
                                        {
                                            XtraMessageBox.Show("Поле повтор пароля не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            tbUserPasswordRepit.Focus();
                                        }
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("Поле пароль не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        tbUserPassword.Focus();
                                    }
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Логин не может быть короче трех символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbUserLogin.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Поле логин не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUserLogin.Focus();
            }
        }
        #endregion
        #region "Dative Changing"
        private void linkUserPosition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDativeForm changeDativeForm = new ChangeDativeForm(linkUserPosition.Text);
            changeDativeForm.ShowDialog();

            if (changeDativeForm.DialogResult == DialogResult.OK)
            {
                linkUserPosition.Text = changeDativeForm.ReturnData();
            }
        }

        private void linkUserTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDativeForm changeDativeForm = new ChangeDativeForm(linkUserTitle.Text);
            changeDativeForm.ShowDialog();

            if (changeDativeForm.DialogResult == DialogResult.OK)
            {
                linkUserTitle.Text = changeDativeForm.ReturnData();
            }
        }

        private void linkUserSurname_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDativeForm changeDativeForm = new ChangeDativeForm(linkUserSurname.Text);
            changeDativeForm.ShowDialog();

            if (changeDativeForm.DialogResult == DialogResult.OK)
            {
                linkUserSurname.Text = changeDativeForm.ReturnData();
            }
        }

        private void linkUserName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDativeForm changeDativeForm = new ChangeDativeForm(linkUserName.Text);
            changeDativeForm.ShowDialog();

            if (changeDativeForm.DialogResult == DialogResult.OK)
            {
                linkUserName.Text = changeDativeForm.ReturnData();
            }
        }

        private void linkUserSecondName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDativeForm changeDativeForm = new ChangeDativeForm(linkUserSecondName.Text);
            changeDativeForm.ShowDialog();

            if (changeDativeForm.DialogResult == DialogResult.OK)
            {
                linkUserSecondName.Text = changeDativeForm.ReturnData();
            }
        }

        private void linkHeadPosition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDativeForm changeDativeForm = new ChangeDativeForm(linkHeadPosition.Text);
            changeDativeForm.ShowDialog();

            if (changeDativeForm.DialogResult == DialogResult.OK)
            {
                linkHeadPosition.Text = changeDativeForm.ReturnData();
            }
        }

        private void linkHeadTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDativeForm changeDativeForm = new ChangeDativeForm(linkHeadTitle.Text);
            changeDativeForm.ShowDialog();

            if (changeDativeForm.DialogResult == DialogResult.OK)
            {
                linkHeadTitle.Text = changeDativeForm.ReturnData();
            }
        }

        private void linkHeadSurname_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDativeForm changeDativeForm = new ChangeDativeForm(linkHeadSurname.Text);
            changeDativeForm.ShowDialog();

            if (changeDativeForm.DialogResult == DialogResult.OK)
            {
                linkHeadSurname.Text = changeDativeForm.ReturnData();
            }
        }

        private void linkHeadName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDativeForm changeDativeForm = new ChangeDativeForm(linkHeadName.Text);
            changeDativeForm.ShowDialog();

            if (changeDativeForm.DialogResult == DialogResult.OK)
            {
                linkHeadName.Text = changeDativeForm.ReturnData();
            }
        }

        private void linkHeadSecondName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDativeForm changeDativeForm = new ChangeDativeForm(linkHeadSecondName.Text);
            changeDativeForm.ShowDialog();

            if (changeDativeForm.DialogResult == DialogResult.OK)
            {
                linkHeadSecondName.Text = changeDativeForm.ReturnData();
            }
        }
        #endregion
        #region "Load User Data"
        private void LoadUserDivision()
        {
            try
            {
                string query = "SELECT * FROM Divisions WHERE Level = 0";
                var conn = new SQLiteConnection(dictConnString);
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbUserDivision.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        private void cbUserDivision_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Divisions WHERE Level = 1 AND KeyID = @KeyID";
                var conn = new SQLiteConnection(dictConnString);
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbUserDivision.GetColumnValue("ID").ToString()));
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbUserService.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbUserService_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Divisions WHERE Level = 2 AND KeyID = @KeyID";
                SQLiteConnection conn = new SQLiteConnection(dictConnString);
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbUserService.GetColumnValue("ID").ToString()));
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                if (dataTable.Rows.Count > 0)
                {
                    cbUserLine.Enabled = true;
                    cbUserLine.Properties.DataSource = dataTable;
                }
                else
                {
                    cbUserLine.Enabled = false;

                    try
                    {
                        string query1 = "SELECT * FROM Divisions WHERE Level = 3 AND KeyID = @KeyID";
                        SQLiteConnection conn1 = new SQLiteConnection(dictConnString);
                        SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
                        conn1.Open();
                        SQLiteDataAdapter da1 = new SQLiteDataAdapter(cmd1);
                        cmd1.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbUserService.GetColumnValue("ID").ToString()));
                        var dataTable1 = new DataTable();
                        da1.Fill(dataTable1);
                        conn1.Close();
                        da1.Dispose();
                        if (dataTable1.Rows.Count > 0)
                        {
                            cbUserDepartment.Enabled = true;
                            cbUserOffice.Enabled = true;
                            cbUserDepartment.Properties.DataSource = dataTable1;
                        }
                        else
                        {
                            cbUserDepartment.EditValue = null;
                            cbUserOffice.EditValue = null;
                            cbUserDepartment.Enabled = false;
                            cbUserOffice.Enabled = false;
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbUserLine_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string query1 = "SELECT * FROM Divisions WHERE Level = 3 AND KeyID = @KeyID";
                SQLiteConnection conn1 = new SQLiteConnection(dictConnString);
                SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
                conn1.Open();
                SQLiteDataAdapter da1 = new SQLiteDataAdapter(cmd1);
                cmd1.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbUserLine.GetColumnValue("ID").ToString()));
                var dataTable1 = new DataTable();
                da1.Fill(dataTable1);
                conn1.Close();
                da1.Dispose();
                if (dataTable1.Rows.Count > 0)
                {
                    cbUserDepartment.Enabled = true;
                    cbUserOffice.Enabled = true;
                    cbUserDepartment.Properties.DataSource = dataTable1;
                }
                else
                {
                    cbUserDepartment.EditValue = null;
                    cbUserOffice.EditValue = null;
                    cbUserDepartment.Enabled = false;
                    cbUserOffice.Enabled = false;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbUserDepartment_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Divisions WHERE Level = 4 AND KeyID = @KeyID";
                SQLiteConnection conn = new SQLiteConnection(dictConnString);
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbUserDepartment.GetColumnValue("ID").ToString()));
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                if (dataTable.Rows.Count > 0)
                {
                    cbUserOffice.Enabled = true;
                    cbUserOffice.Properties.DataSource = dataTable;
                }
                else
                {
                    cbUserOffice.EditValue = null;
                    cbUserOffice.Enabled = false;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region "Load Head Data"
        private void LoadHeadDivision()
        {
            try
            {
                string query = "SELECT * FROM Divisions WHERE Level = 0";
                var conn = new SQLiteConnection(dictConnString);
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbHeadDivision.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        private void cbHeadDivision_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Divisions WHERE Level = 1 AND KeyID = @KeyID";
                var conn = new SQLiteConnection(dictConnString);
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbHeadDivision.GetColumnValue("ID").ToString()));
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbHeadService.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbHeadService_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Divisions WHERE Level = 2 AND KeyID = @KeyID";
                SQLiteConnection conn = new SQLiteConnection(dictConnString);
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbHeadService.GetColumnValue("ID").ToString()));
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                if (dataTable.Rows.Count > 0)
                {
                    cbHeadLine.Enabled = true;
                    cbHeadLine.Properties.DataSource = dataTable;
                }
                else
                {
                    cbHeadLine.EditValue = null;
                    cbHeadLine.Enabled = false;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region "Load Dictionary"
        private void LoadTitles()
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(dictConnString);
                conn.Open();
                SQLiteCommand comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM Title";
                SQLiteDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbUserTitle.Properties.Items.Add(dr["Name"].ToString());
                        cbHeadTitle.Properties.Items.Add(dr["Name"].ToString());
                    }
                }
                else
                {
                    dr.Close();
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserPositions()
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(dictConnString);
                conn.Open();
                SQLiteCommand comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM PositionUser";
                SQLiteDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbUserPosition.Properties.Items.Add(dr["Name"].ToString());
                    }
                }
                else
                {
                    dr.Close();
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHeadPositions()
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(dictConnString);
                conn.Open();
                SQLiteCommand comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM PositionHead";
                SQLiteDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbHeadPosition.Properties.Items.Add(dr["Name"].ToString());
                    }
                }
                else
                {
                    dr.Close();
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region "Convert to dative user and head settings"
        private void ConvertUserSettings()
        {
            labelUserWarning.Text = string.Format("{0}, проверьте, правильно ли изменены внесенные вами данные в дательном падеже!", tbUserName.Text.UppercaseFirst());

            labelUserPosition.Text = cbUserPosition.Text;
            labelUserTitle.Text = cbUserTitle.Text;
            labelUserSurname.Text = tbUserSurname.Text;
            labelUserName.Text = tbUserName.Text;
            labelUserSecondName.Text = tbUserSecondName.Text;

            try
            {
                SQLiteConnection conn = new SQLiteConnection(dictConnString);
                conn.Open();
                SQLiteCommand comm = conn.CreateCommand();
                comm.CommandText = "SELECT Dative FROM PositionUser WHERE Name = @Name";
                comm.Parameters.AddWithValue("@Name", cbUserPosition.Text);
                SQLiteDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        linkUserPosition.Text = dr["Dative"].ToString();
                    }
                }
                else
                {
                    dr.Close();
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                SQLiteConnection conn = new SQLiteConnection(dictConnString);
                conn.Open();
                SQLiteCommand comm = conn.CreateCommand();
                comm.CommandText = "SELECT Dative FROM Title WHERE Name = @Name";
                comm.Parameters.AddWithValue("@Name", cbUserTitle.Text);
                SQLiteDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        linkUserTitle.Text = dr["Dative"].ToString();
                    }
                }
                else
                {
                    dr.Close();
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string userFullName = string.Format("{0} {1} {2}", tbUserSurname.Text.Trim(), tbUserName.Text.Trim(), tbUserSecondName.Text.Trim());
            CyrResult userConvertResult = new CyrResult(convertName.Decline(userFullName, 3, 0));
            String userDativeResult = userConvertResult.Дательный.ToString();
            String[] splitUserResult = userDativeResult.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            linkUserSurname.Text = splitUserResult[0];
            linkUserName.Text = splitUserResult[1];
            linkUserSecondName.Text = splitUserResult[2];
        }

        private void ConvertHeadSettings()
        {
            labelHeadWarning.Text = string.Format("{0}, проверьте, правильно ли изменены внесенные вами данные в дательном падеже!", tbUserName.Text.UppercaseFirst());

            labelHeadPosition.Text = cbHeadPosition.Text;
            labelHeadTitle.Text = cbHeadTitle.Text;
            labelHeadSurname.Text = tbHeadSurname.Text;
            labelHeadName.Text = tbHeadName.Text;
            labelHeadSecondName.Text = tbHeadSecondName.Text;

            try
            {
                SQLiteConnection conn = new SQLiteConnection(dictConnString);
                conn.Open();
                SQLiteCommand comm = conn.CreateCommand();
                comm.CommandText = "SELECT Dative FROM PositionHead WHERE Name = @Name";
                comm.Parameters.AddWithValue("@Name", cbHeadPosition.Text);
                SQLiteDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        linkHeadPosition.Text = dr["Dative"].ToString();
                    }
                }
                else
                {
                    dr.Close();
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                SQLiteConnection conn = new SQLiteConnection(dictConnString);
                conn.Open();
                SQLiteCommand comm = conn.CreateCommand();
                comm.CommandText = "SELECT Dative FROM Title WHERE Name = @Name";
                comm.Parameters.AddWithValue("@Name", cbHeadTitle.Text);
                SQLiteDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        linkHeadTitle.Text = dr["Dative"].ToString();
                    }
                }
                else
                {
                    dr.Close();
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string headFullName = string.Format("{0} {1} {2}", tbHeadSurname.Text.Trim(), tbHeadName.Text.Trim(), tbHeadSecondName.Text.Trim());
            CyrResult headConvertResult = new CyrResult(convertName.Decline(headFullName, 3, 0));
            String headDativeResult = headConvertResult.Дательный.ToString();
            String[] splitHeadResult = headDativeResult.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            linkHeadSurname.Text = splitHeadResult[0];
            linkHeadName.Text = splitHeadResult[1];
            linkHeadSecondName.Text = splitHeadResult[2];
        }
        #endregion
        #region "Finish Registration"
        private void JsonSettings()
        {
            List<Settings> userSettings = new List<Settings>();
            userSettings.Add(new Settings 
            { 
                UserSurname = tbUserSurname.Text.Trim().UppercaseFirst(),
                UserName = tbUserName.Text.Trim().UppercaseFirst(),
                UserSecondName = tbUserSecondName.Text.Trim().UppercaseFirst(),
                UserPosition = cbUserPosition.Text, 
                UserTitle = cbUserTitle.Text,
                UserComputer = tbUserWorkStation.Text,
                UserPhone = tbUserPhone.Text,
                UserDivision = cbUserDivision.Text,
                UserService = cbUserService.Text,
                UserLine = cbUserLine.Text,
                UserDepartment = cbUserDepartment.Text,
                UserOffice = cbUserOffice.Text,
                HeadSurname = tbHeadSurname.Text.Trim().UppercaseFirst(),
                HeadName = tbHeadName.Text.Trim().UppercaseFirst(),
                HeadSecondName = tbHeadSecondName.Text.Trim().UppercaseFirst(),
                HeadPosition = cbHeadPosition.Text,
                HeadTitle = cbHeadTitle.Text,
                HeadDivision = cbHeadDivision.Text,
                HeadService = cbHeadService.Text,
                HeadLine = cbHeadLine.Text,

                UserSurnameDative = linkUserSurname.Text.Trim().UppercaseFirst(),
                UserNameDative = linkUserName.Text.Trim().UppercaseFirst(),
                UserSecondNameDative = linkUserSecondName.Text.Trim().UppercaseFirst(),
                UserPositionDative = linkUserPosition.Text,
                UserTitleDative = linkUserTitle.Text,
                HeadSurnameDative = linkHeadSurname.Text.Trim().UppercaseFirst(),
                HeadNameDative = linkHeadName.Text.Trim().UppercaseFirst(),
                HeadSecondNameDative = linkHeadSecondName.Text.Trim().UppercaseFirst(),
                HeadPositionDative = linkHeadPosition.Text,
                HeadTitleDative = linkHeadTitle.Text
            });

            string json = JSON.Instance.ToJSON(userSettings);
            
            if (json != string.Empty)
                CreateNewUserSettings(json);
        }

        private void CreateNewUserSettings(string _userSettings)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(userConnString))
                {
                    SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Users WHERE Login = @Login", conn);
                    comm.Parameters.AddWithValue("@Login", userLogin);
                    conn.Open();
                    using (SQLiteDataReader dr = comm.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                try
                                {
                                    SQLiteCommand command = new SQLiteCommand("INSERT INTO UserData (UserID, UserData) VALUES (@UserID, @UserData)", conn);
                                    command.Parameters.AddWithValue("@UserID", Convert.ToInt32(dr["ID"].ToString()));
                                    command.Parameters.AddWithValue("@UserData", _userSettings);
                                    command.ExecuteNonQuery();
                                }
                                catch (SQLiteException ex)
                                {
                                    XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            dr.Close();
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string message = string.Format("{0} {1} {2}, Ваша учетная запись была успешно создана!", tbUserSurname.Text.UppercaseFirst(), tbUserName.Text.UppercaseFirst(), tbUserSecondName.Text.UppercaseFirst());
            XtraMessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoginForm.loginForm.tbLogin.Text = userLogin;
            LoginForm.loginForm.tbPassword.Text = userPassword;
            LoginForm.loginForm.btnLogin.PerformClick();
            this.Close();
        }
        #endregion

        class Settings
        {
            public string UserSurname { get; set; }
            public string UserName { get; set; }
            public string UserSecondName { get; set; }
            public string UserPosition { get; set; }
            public string UserTitle { get; set; }
            public string UserComputer { get; set; }
            public string UserPhone { get; set; }
            public string UserDivision { get; set; }
            public string UserService { get; set; }
            public string UserLine { get; set; }
            public string UserDepartment { get; set; }
            public string UserOffice { get; set; }
            public string HeadSurname { get; set; }
            public string HeadName { get; set; }
            public string HeadSecondName { get; set; }
            public string HeadPosition { get; set; }
            public string HeadTitle { get; set; }
            public string HeadDivision { get; set; }
            public string HeadService { get; set; }
            public string HeadLine { get; set; }

            public string UserSurnameDative { get; set; }
            public string UserNameDative { get; set; }
            public string UserSecondNameDative { get; set; }
            public string UserPositionDative { get; set; }
            public string UserTitleDative { get; set; }
            public string HeadSurnameDative { get; set; }
            public string HeadNameDative { get; set; }
            public string HeadSecondNameDative { get; set; }
            public string HeadPositionDative { get; set; }
            public string HeadTitleDative { get; set; }
        }
    }
}
