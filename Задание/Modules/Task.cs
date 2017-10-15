using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using DevExpress.XtraEditors;
using System.IO;
//using Novacode;
using Spire.Doc;
using Spire.Doc.Fields;
using Spire.Doc.Documents;
//
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using System.Drawing.Imaging;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.Utils.Win;

namespace Задание
{
    public partial class Task : DevExpress.XtraEditors.XtraUserControl
    {
        #region "Declaration"
        public static Task task;
        ErrorCollector errorCollector = new ErrorCollector();
        public int taskMode = 0;
        public string qrText = "";
        List<Bitmap> img = new List<Bitmap>();
        List<Markers> markers = new List<Markers>();
        public List<TaskControls> controls = new List<TaskControls>();
        string ColorPattern = "";
        #endregion

        #region "Load Title"
        private void LoadTitle()
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
                        cbHeadApproveTitle.Properties.Items.Add(dr["Name"].ToString());
                        cbHeadAcceptTitle.Properties.Items.Add(dr["Name"].ToString());
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
        #region "Load Position"
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
                        cbHeadAcceptPosition.Properties.Items.Add(dr["Name"].ToString());
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
                string query = "SELECT * FROM Divisions WHERE Level = 0";
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbHeadAcceptDivision.Properties.DataSource = dataTable;
                cbHeadAuthorDivision.Properties.DataSource = dataTable;
                cbAuthorDivision.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region "HeadAuthor load depts"
        private void cbHeadAuthorDivision_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Divisions WHERE Level = 1 AND KeyID = @KeyID";
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbHeadAuthorDivision.GetColumnValue("ID").ToString()));
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbHeadAuthorService.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbHeadAuthorService_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Divisions WHERE Level = 2 AND KeyID = @KeyID";
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbHeadAuthorService.GetColumnValue("ID").ToString()));
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbHeadAuthorLine.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region "HeadAccept load depts"
        private void cbHeadAcceptDivision_EditValueChanged(object sender, EventArgs e)
        {
            if (cbHeadAcceptDivision.EditValue != null)
            {
                try
                {
                    string query = "SELECT * FROM Divisions WHERE Level = 1 AND KeyID = @KeyID";
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbHeadAcceptDivision.GetColumnValue("ID").ToString()));
                    conn.Open();
                    var da = new SQLiteDataAdapter(cmd);
                    var dataTable = new DataTable();
                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose();
                    cbHeadAcceptService.Properties.DataSource = dataTable;
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
        }
        #endregion
        #region "Author load depts"
        private void cbAuthorDivision_EditValueChanged(object sender, EventArgs e)
        {
            cbAuthorService.EditValue = null;
            cbAuthorLine.EditValue = null;
            cbAuthorDepartment.EditValue = null;
            cbAuthorOffice.EditValue = null;

            if (cbAuthorDivision.Text != string.Empty)
            {
                try
                {
                    string query = "SELECT * FROM Divisions WHERE Level = 1 AND KeyID = @KeyID";
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbAuthorDivision.GetColumnValue("ID").ToString()));
                    conn.Open();
                    var da = new SQLiteDataAdapter(cmd);
                    var dataTable = new DataTable();
                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose();
                    cbAuthorService.Properties.DataSource = dataTable;
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void cbAuthorService_EditValueChanged(object sender, EventArgs e)
        {
            cbAuthorLine.EditValue = null;
            cbAuthorDepartment.EditValue = null;
            cbAuthorOffice.EditValue = null;

            if (cbAuthorService.Text != string.Empty)
            {
                try
                {
                    string query = "SELECT * FROM Divisions WHERE Level = 2 AND KeyID = @KeyID";
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbAuthorService.GetColumnValue("ID").ToString()));
                    conn.Open();
                    var da = new SQLiteDataAdapter(cmd);
                    var dataTable = new DataTable();
                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose();
                    if (dataTable.Rows.Count > 0)
                    {
                        cbAuthorLine.Properties.DataSource = dataTable;
                    }
                    else
                    {
                        try
                        {
                            string query1 = "SELECT * FROM Divisions WHERE Level = 3 AND KeyID = @KeyID";
                            SQLiteConnection conn1 = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
                            conn1.Open();
                            SQLiteDataAdapter da1 = new SQLiteDataAdapter(cmd1);
                            cmd1.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbAuthorService.GetColumnValue("ID").ToString()));
                            var dataTable1 = new DataTable();
                            da1.Fill(dataTable1);
                            conn1.Close();
                            da1.Dispose();
                            if (dataTable1.Rows.Count > 0)
                            {
                                cbAuthorDepartment.Properties.DataSource = dataTable1;
                            }
                        }
                        catch (SQLiteException ex)
                        {
                            XtraMessageBox.Show(ex.Message.ToString());
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void cbAuthorLine_EditValueChanged(object sender, EventArgs e)
        {
            cbAuthorDepartment.EditValue = null;
            cbAuthorOffice.EditValue = null;

            if (cbAuthorLine.Text != string.Empty)
            {
                try
                {
                    string query = "SELECT * FROM Divisions WHERE Level = 3 AND KeyID = @KeyID";
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbAuthorLine.GetColumnValue("ID").ToString()));
                    conn.Open();
                    var da = new SQLiteDataAdapter(cmd);
                    var dataTable = new DataTable();
                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose();
                    cbAuthorDepartment.Properties.DataSource = dataTable;
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void cbAuthorDepartment_EditValueChanged(object sender, EventArgs e)
        {
            cbAuthorOffice.EditValue = null;

            if (cbAuthorDepartment.Text != string.Empty)
            {
                try
                {
                    string query = "SELECT * FROM Divisions WHERE Level = 4 AND KeyID = @KeyID";
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbAuthorDepartment.GetColumnValue("ID").ToString()));
                    conn.Open();
                    var da = new SQLiteDataAdapter(cmd);
                    var dataTable = new DataTable();
                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose();
                    cbAuthorOffice.Properties.DataSource = dataTable;
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
        }
        #endregion
        #region "Load Events list"
        public void LoadEventsList()
        {
            try
            {
                string query = "SELECT * FROM Events";
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbEventType.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbEventType_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(cbEventType.GetColumnValue("IsDetalization")) == true)
            {
                chbBaseDetalization.Enabled = true;
            }
            else
            {
                chbBaseDetalization.Enabled = false;
                dtBaseDetalization1StartDT.Text = string.Empty;
                dtBaseDetalization2StartDT.Text = string.Empty;
                dtBaseDetalization3StartDT.Text = string.Empty;
                dtBaseDetalization1FinishDT.Text = string.Empty;
                dtBaseDetalization2FinishDT.Text = string.Empty;
                dtBaseDetalization3FinishDT.Text = string.Empty;
                chbDetalization1.Checked = false;
                chbDetalization2.Checked = false;
                chbDetalization3.Checked = false;
            }
        }
        #endregion
        #region "Load Courts and Judges"
        public void LoadBaseCourts()
        {
            try
            {
                string query = "SELECT * FROM Courts";
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbBaseCourt.Properties.DataSource = dataTable;
                cbBaseNotificationCourt.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        public void LoadBaseJudges()
        {
            if (cbBaseCourt.Text != string.Empty)
            {
                try
                {
                    string query = "SELECT * FROM Judges WHERE CourtID = @CourtID";
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourtID", Convert.ToInt32(cbBaseCourt.GetColumnValue("ID").ToString()));
                    conn.Open();
                    var da = new SQLiteDataAdapter(cmd);
                    var dataTable = new DataTable();
                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose();
                    cbBaseJudge.Properties.DataSource = dataTable;
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void cbBaseCourt_EditValueChanged(object sender, EventArgs e)
        {
            if (cbBaseCourt.Text != string.Empty)
            {
                try
                {
                    string query = "SELECT * FROM Judges WHERE CourtID = @CourtID";
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourtID", Convert.ToInt32(cbBaseCourt.GetColumnValue("ID").ToString()));
                    conn.Open();
                    var da = new SQLiteDataAdapter(cmd);
                    var dataTable = new DataTable();
                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose();
                    cbBaseJudge.Properties.DataSource = dataTable;
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void cbBaseNotificationCourt_EditValueChanged(object sender, EventArgs e)
        {
            if (cbBaseNotificationCourt.EditValue != null)
            {
                try
                {
                    string query = "SELECT * FROM Judges WHERE CourtID = @CourtID";
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourtID", Convert.ToInt32(cbBaseNotificationCourt.GetColumnValue("ID").ToString()));
                    conn.Open();
                    var da = new SQLiteDataAdapter(cmd);
                    var dataTable = new DataTable();
                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose();
                    cbBaseNotificationJudge.Properties.DataSource = dataTable;
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
        }
        #endregion
        #region "Load Event Places"
        private void LoadEventPlaces()
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT Name FROM EventPlace";
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbEventPlace.Properties.Items.Add(dr["Name"].ToString());
                    }
                }
                else
                {
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region "Load Cases and Articles"
        public void LoadCases()
        {
            cbBaseCaseTypeFirst.Text = string.Empty;
            cbBaseCaseTypeSecond.Text = string.Empty;
            cbBaseCaseTypeFirst.Properties.Items.Clear();
            cbBaseCaseTypeSecond.Properties.Items.Clear();

            try
            {
                SQLiteConnection conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                SQLiteCommand comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM EventCase";
                SQLiteDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbBaseCaseTypeFirst.Properties.Items.Add(dr["Name"].ToString());
                        cbBaseCaseTypeSecond.Properties.Items.Add(dr["Name"].ToString());
                    }
                    conn.Close();
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

        public void LoadArticles()
        {
            cbBaseCaseArticleNoFirst.Text = string.Empty;
            cbBaseCaseArticleNoSecond.Text = string.Empty;
            cbBaseCaseArticleNoFirst.Properties.Items.Clear();
            cbBaseCaseArticleNoSecond.Properties.Items.Clear();

            try
            {
                SQLiteConnection conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                SQLiteCommand comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM EventArticle";
                SQLiteDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbBaseCaseArticleNoFirst.Properties.Items.Add(dr["Name"].ToString());
                        cbBaseCaseArticleNoSecond.Properties.Items.Add(dr["Name"].ToString());
                    }
                    conn.Close();
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
        #region "Load Events"
        public void LoadEventType()
        {
            try
            {
                string query = "SELECT * FROM EventIdentifierType";
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbEventIdentifierType.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region "Load Countries List"
        private void LoadObjectCountries()
        {
            if (!File.Exists("Data\\Countries.xml"))
            {
                XtraMessageBox.Show("Отсутствует файл базы данных, обратитесь к разработчику!", "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("Data\\Countries.xml");

                    foreach (DataRow item in ds.Tables[1].Rows)
                    {
                        cbObjectCountry.Properties.Items.Add(item[1].ToString());
                    }
                }
                catch (System.Security.SecurityException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
        }
        #endregion
        #region "Load Approve And Accept Heads"
        private void LoadHeadApprove()
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM HeadApprove";
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbHeadApproveSurname.Properties.Items.Add(dr["Surname"].ToString());
                        cbHeadApprovePosition.Properties.Items.Add(dr["Position"].ToString());
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

        private void cbHeadApproveSurname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM HeadApprove WHERE Surname = @Surname";
                comm.Parameters.AddWithValue("@Surname", cbHeadApproveSurname.Text.Trim());
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbHeadApproveName.Text = dr["Name"].ToString();
                        cbHeadApproveSecondName.Text = dr["SecondName"].ToString();
                        cbHeadApprovePosition.Text = dr["Position"].ToString();
                        cbHeadApproveTitle.Text = dr["Title"].ToString();
                    }
                }
                else
                {
                    cbHeadApproveName.Text = string.Empty;
                    cbHeadApproveSecondName.Text = string.Empty;
                    cbHeadApprovePosition.Text = string.Empty;
                    cbHeadApproveTitle.Text = string.Empty;
                    conn.Close();
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        public void LoadHeadAccept()
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM HeadAccept";
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbHeadAcceptSurname.Properties.Items.Add(dr["Surname"].ToString());
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

        private void cbHeadAcceptSurname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM HeadAccept WHERE Surname = @Surname";
                comm.Parameters.AddWithValue("@Surname", cbHeadAcceptSurname.Text.Trim());
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbHeadAcceptName.Text = dr["Name"].ToString();
                        cbHeadAcceptSecondName.Text = dr["SecondName"].ToString();
                        cbHeadAcceptPosition.Text = dr["Position"].ToString();
                        cbHeadAcceptTitle.Text = dr["Title"].ToString();
                        cbHeadAcceptDivision.EditValue = cbHeadAcceptDivision.Properties.GetKeyValueByDisplayText(dr["Division"].ToString());
                        cbHeadAcceptService.EditValue = cbHeadAcceptService.Properties.GetKeyValueByDisplayText(dr["Service"].ToString());
                    }
                }
                else
                {
                    cbHeadAcceptName.Text = string.Empty;
                    cbHeadAcceptSecondName.Text = string.Empty;
                    cbHeadAcceptPosition.Text = string.Empty;
                    cbHeadAcceptTitle.Text = string.Empty;
                    cbHeadAcceptDivision.Text = string.Empty;
                    cbHeadAcceptService.Text = string.Empty;
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
        #region "Load User Settings"
        public void LoadUserSettings()
        {            
            tbHeadAuthorSurname.Text = UserSettings.SettingsList[0].HeadSurname;
            tbHeadAuthorName.Text = UserSettings.SettingsList[0].HeadName;
            tbHeadAuthorSecondName.Text = UserSettings.SettingsList[0].HeadSecondName;
            cbHeadAuthorPosition.Text = UserSettings.SettingsList[0].HeadPosition;
            cbHeadAuthorTitle.Text = UserSettings.SettingsList[0].HeadTitle;
            cbHeadAuthorDivision.EditValue = cbHeadAuthorDivision.Properties.GetKeyValueByDisplayText(UserSettings.SettingsList[0].HeadDivision);
            cbHeadAuthorService.EditValue = cbHeadAuthorService.Properties.GetKeyValueByDisplayText(UserSettings.SettingsList[0].HeadService);
            cbHeadAuthorLine.EditValue = cbHeadAuthorLine.Properties.GetKeyValueByDisplayText(UserSettings.SettingsList[0].HeadLine);

            tbAuthorSurname.Text = UserSettings.SettingsList[0].UserSurname;
            tbAuthorName.Text = UserSettings.SettingsList[0].UserName;
            tbAuthorSecondName.Text = UserSettings.SettingsList[0].UserSecondName;
            tbDocumentAuthor.Text = UserSettings.SettingsList[0].UserName.Substring(0, 1) + "." + UserSettings.SettingsList[0].UserSecondName.Substring(0, 1) + ". " + UserSettings.SettingsList[0].UserSurname;
            tbDocumentWorkStation.Text = UserSettings.SettingsList[0].UserComputer;
            tbAuthorPhone.Text = UserSettings.SettingsList[0].UserPhone;
            tbDocumentAuthorPhone.Text = UserSettings.SettingsList[0].UserPhone;
            cbAuthorPosition.Text = UserSettings.SettingsList[0].UserPosition;
            cbAuthorTitle.Text = UserSettings.SettingsList[0].UserTitle;

            cbAuthorDivision.EditValue = cbAuthorDivision.Properties.GetKeyValueByDisplayText(UserSettings.SettingsList[0].UserDivision);
            cbAuthorService.EditValue = cbAuthorService.Properties.GetKeyValueByDisplayText(UserSettings.SettingsList[0].UserService);
            cbAuthorLine.EditValue = cbAuthorLine.Properties.GetKeyValueByDisplayText(UserSettings.SettingsList[0].UserLine);
            cbAuthorDepartment.EditValue = cbAuthorDepartment.Properties.GetKeyValueByDisplayText(UserSettings.SettingsList[0].UserDepartment);
            cbAuthorOffice.EditValue = cbAuthorOffice.Properties.GetKeyValueByDisplayText(UserSettings.SettingsList[0].UserOffice);
        }
        #endregion
        #region "Load Markers"
        private void LoadMarkers()
        {
            markers.Clear();
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionTemplateData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM Markers";
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        markers.Add(new Markers
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Tag = dr["Tag"].ToString(),
                            Caption = dr["Caption"].ToString(),
                            BeforeSymbol = dr["BeforeSymbol"].ToString(),
                            AfterSymbol = dr["AfterSymbol"].ToString(),
                            QRFirstChar = Convert.ToBoolean(dr["QRFirstChar"]),
                            QRToUpper = Convert.ToBoolean(dr["QRToUpper"]),
                            QRToDative = Convert.ToBoolean(dr["QRToDative"]),
                            TextFirstChar = Convert.ToBoolean(dr["TextFirstChar"]),
                            TextToUpper = Convert.ToBoolean(dr["TextToUpper"]),
                            TextToDative = Convert.ToBoolean(dr["TextToDative"])
                        });
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
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "LoadMarkers()", false);
            }
        }

        public class Markers
        {
            public int ID { get; set; }
            public string Tag { get; set; }
            public string Caption { get; set; }
            public string BeforeSymbol { get; set; }
            public string AfterSymbol { get; set; }
            public bool QRFirstChar { get; set; }
            public bool QRToUpper { get; set; }
            public bool QRToDative { get; set; }
            public bool TextFirstChar { get; set; }
            public bool TextToUpper { get; set; }
            public bool TextToDative { get; set; }

            public string Value { get; set; }
            public string ValueDative { get; set; }
            
            public string TextValue
            {
                get
                {
                    if (Value != string.Empty && ValueDative != string.Empty)
                    {
                        if (TextToDative == true)
                        {
                            if (TextFirstChar == true)
                            {
                                if (TextToUpper == true)
                                    return BeforeSymbol + ToUpper(ValueDative).Substring(0, 1) + AfterSymbol;
                                else
                                    return BeforeSymbol + ValueDative.Substring(0, 1) + AfterSymbol;
                            }
                            else
                            {
                                if (TextToUpper == true)
                                    return BeforeSymbol + ToUpper(ValueDative) + AfterSymbol;
                                else
                                    return BeforeSymbol + ValueDative + AfterSymbol;
                            }
                        }
                        else
                        {
                            if (TextFirstChar == true)
                            {
                                if (TextToUpper == true)
                                    return BeforeSymbol + ToUpper(Value).Substring(0, 1) + AfterSymbol;
                                else
                                    return BeforeSymbol + Value.Substring(0, 1) + AfterSymbol;
                            }
                            else
                            {
                                if (TextToUpper == true)
                                    return BeforeSymbol + ToUpper(Value) + AfterSymbol;
                                else
                                    return BeforeSymbol + Value + AfterSymbol;
                            }
                        }
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }

            public string QRValue
            {
                get
                {
                    if (QRToDative == true)
                    {
                        if (QRFirstChar == true)
                        {
                            if (QRToUpper == true)
                                return ToUpper(ValueDative).Substring(0, 1);
                            else
                                return ValueDative.Substring(0, 1);
                        }
                        else
                        {
                            if (QRToUpper == true)
                                return ToUpper(ValueDative);
                            else
                                return ValueDative;
                        }
                    }
                    else
                    {
                        if (QRFirstChar == true)
                        {
                            if (QRToUpper == true)
                                return ToUpper(Value).Substring(0, 1);
                            else
                                return Value.Substring(0, 1);
                        }
                        else
                        {
                            if (QRToUpper == true)
                                return ToUpper(Value);
                            else
                                return Value;
                        }
                    }
                }
            }
        }

        public static string ToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                //throw new ArgumentException("");
                return string.Empty;
            }

            if (input.Length > 1)
            {
                return input.First().ToString().ToUpper() + input.Substring(1);
            }
            else
            {
                return input.First().ToString().ToUpper();
            }
        }
        #endregion
        #region "Load Color"
        private void LoadColorCrimeItem()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM ColorCrimeItem";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    cbColorCrimeItem.Properties.Items.Add(dr["Name"].ToString());
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadColorCrimePlace()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM ColorCrimePlace";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    cbColorCrimePlace.Properties.Items.Add(dr["Name"].ToString());
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadColorCrimeSubject()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM ColorCrimeSubject";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    cbColorCrimeSubject.Properties.Items.Add(dr["Name"].ToString());
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadColorCrimeTarget()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM ColorCrimeTarget";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    cbColorCrimeTarget.Properties.Items.Add(dr["Name"].ToString());
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadColorEvent()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM ColorEvent";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    cbColorEvent.Properties.Items.Add(dr["Name"].ToString());
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadColorObject()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM ColorObject";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    cbColorObject.Properties.Items.Add(dr["Name"].ToString());
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadColorRoleObject()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM ColorRoleObject";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    cbColorRoleObject.Properties.Items.Add(dr["Name"].ToString());
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadColorPattern()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM ColorPattern";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    //ccbColorPattern.Properties.Items.Add(dr["Name"].ToString());
                                    ccbColorPattern.Properties.Items.Add(dr["Name"].ToString(), CheckState.Unchecked, true);
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        public Task()
        {
            InitializeComponent();
            task = this;

            DXErrorProvider.GetErrorIcon += DXErrorProvider_GetErrorIcon;
        }

        void DXErrorProvider_GetErrorIcon(GetErrorIconEventArgs e)
        {
            if (e.ErrorType == ErrorType.User1)
                e.ErrorIcon = Properties.Resources.icon_error;
        }

        public void LoadData()
        {
            LoadDivisions();
            LoadTitle();
            LoadUserPosition();
            LoadHeadPosition();
            LoadEventType();
            LoadObjectCountries();
            LoadHeadApprove();
            LoadHeadAccept();
            LoadEventsList();
            LoadEventPlaces();
            LoadBaseCourts();
            LoadCases();
            LoadArticles();
            LoadMarkers();
            LoadColorCrimeItem();
            LoadColorCrimePlace();
            LoadColorCrimeSubject();
            LoadColorCrimeTarget();
            LoadColorEvent();
            LoadColorObject();
            LoadColorRoleObject();
            LoadColorPattern();
        }

        #region "Controls with buttons"
        private void tbAccessoryOwnerAddress_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Edit")
            {
                AddressForm addressForm = new AddressForm("accessory");
                addressForm.ShowDialog();

                if (addressForm.DialogResult == DialogResult.Yes)
                    tbAccessoryOwnerAddress.Text = Address.Data("accessory");
            }
            else if (e.Button.Caption == "Clear")
            {
                tbAccessoryOwnerAddress.Text = string.Empty;
                Address.accessory.Clear();
            }
        }

        private void tbObjectWorkAddress_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Edit")
            {
                AddressForm addressForm = new AddressForm("work");
                addressForm.ShowDialog();

                if (addressForm.DialogResult == DialogResult.Yes)
                    tbObjectWorkAddress.Text = Address.Data("work");
            }
            else if (e.Button.Caption == "Clear")
            {
                tbObjectWorkAddress.Text = string.Empty;
                Address.work.Clear();
            }
        }

        private void tbObjectHomeAddress_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Edit")
            {
                AddressForm addressForm = new AddressForm("home");
                addressForm.ShowDialog();

                if (addressForm.DialogResult == DialogResult.Yes)
                    tbObjectHomeAddress.Text = Address.Data("home");
            }
            else if (e.Button.Caption == "Clear")
            {
                tbObjectHomeAddress.Text = string.Empty;
                Address.home.Clear();
            }
        }

        private void tbEventCount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "24 часа")
                tbEventCount.Text = "1";
            else if (e.Button.Caption == "48 часов")
                tbEventCount.Text = "2";
            else if (e.Button.Caption == "20 суток")
                tbEventCount.Text = "20";
            else if (e.Button.Caption == "30 суток")
                tbEventCount.Text = "30";
        }

        private void tbEventReferenceNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Выбрать")
            {
                ReferenceMenu refMenu = new ReferenceMenu();
                if (refMenu.ShowDialog() == DialogResult.OK)
                {
                    tbEventReferenceNo.Text = refMenu.GetCaption;
                }
            }
        }

        private void tbAccessoryOwnerAddress_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddressForm addressForm = new AddressForm("accessory");
            addressForm.ShowDialog();

            if (addressForm.DialogResult == DialogResult.Yes)
                tbAccessoryOwnerAddress.Text = Address.Data("accessory");
        }

        private void tbObjectWorkAddress_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddressForm addressForm = new AddressForm("work");
            addressForm.ShowDialog();

            if (addressForm.DialogResult == DialogResult.Yes)
                tbObjectWorkAddress.Text = Address.Data("work");
        }

        private void tbObjectHomeAddress_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddressForm addressForm = new AddressForm("home");
            addressForm.ShowDialog();

            if (addressForm.DialogResult == DialogResult.Yes)
                tbObjectHomeAddress.Text = Address.Data("home");
        }
        #endregion
        #region "Event purpose type controls"
        private void chbAccessoryTypeIndividual_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAccessoryTypeIndividual.Checked)
            {
                chbAccessoryTypeEntity.Checked = false;
                chbAccessoryTypeOther.Checked = false;

                labelAccessoryName.Text = "Фамилия, имя, отчество";
                labelAccessoryName.Location = new Point(46, 319);
                tbAccessoryOwnerFullName.Enabled = true;
                tbAccessoryOwnerAddress.Enabled = true;
                dtAccessoryOwnerBirthDT.Enabled = true;
            }

            if (!chbAccessoryTypeIndividual.Checked && !chbAccessoryTypeEntity.Checked && !chbAccessoryTypeOther.Checked)
            {
                chbAccessoryTypeIndividual.Checked = true;
            }
        }

        private void chbAccessoryTypeEntity_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAccessoryTypeEntity.Checked)
            {
                chbAccessoryTypeIndividual.Checked = false;
                chbAccessoryTypeOther.Checked = false;

                labelAccessoryName.Text = "Организация";
                labelAccessoryName.Location = new Point(103, 319);
                tbAccessoryOwnerFullName.Enabled = true;
                tbAccessoryOwnerAddress.Enabled = true;
                dtAccessoryOwnerBirthDT.Enabled = false;
            }

            if (!chbAccessoryTypeIndividual.Checked && !chbAccessoryTypeEntity.Checked && !chbAccessoryTypeOther.Checked)
            {
                chbAccessoryTypeEntity.Checked = true;
            }
        }

        private void chbAccessoryTypeOther_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAccessoryTypeOther.Checked)
            {
                chbAccessoryTypeIndividual.Checked = false;
                chbAccessoryTypeEntity.Checked = false;

                tbAccessoryOwnerFullName.Enabled = false;
                tbAccessoryOwnerAddress.Enabled = false;
                dtAccessoryOwnerBirthDT.Enabled = false;

                tbAccessoryOwnerFullName.Text = string.Empty;
                tbAccessoryOwnerAddress.Text = string.Empty;
                dtAccessoryOwnerBirthDT.Text = string.Empty;
            }

            if (!chbAccessoryTypeIndividual.Checked && !chbAccessoryTypeEntity.Checked && !chbAccessoryTypeOther.Checked)
            {
                chbAccessoryTypeOther.Checked = true;
            }
        }
        #endregion
        #region "Point Type editing mask controls"
        private void cbEventIdentifierType_EditValueChanged(object sender, EventArgs e)
        {
            if (cbEventIdentifierType.EditValue != null)
            {
                tbEventIdentifierPoint.Text = "";
                tbEventIdentifierPoint.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                //tbEventIdentifierPoint.Properties.Mask.EditMask = cbEventIdentifierType.GetColumnValue("Mask").ToString();
                try
                {
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    conn.Open();
                    var comm = conn.CreateCommand();
                    comm.CommandText = "SELECT Name FROM MaskType WHERE Caption = @Caption";
                    comm.Parameters.AddWithValue("@Caption", cbEventIdentifierType.GetColumnValue("Mask").ToString());
                    var dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            tbEventIdentifierPoint.Properties.Mask.EditMask = dr["Name"].ToString();
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
        }

        private void tbEventIdentifierPoint_EditValueChanged(object sender, EventArgs e)
        {
            if (cbEventIdentifierType.Text == string.Empty && !cbEventIdentifierType.IsPopupOpen)
            {
                var dialog = XtraMessageBox.Show("Выберите тип точки контроля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialog == DialogResult.OK)
                {
                    cbEventIdentifierType.Focus();
                    cbEventIdentifierType.ShowPopup();
                    tbEventIdentifierPoint.Text = string.Empty;
                }
            }
        }
        #endregion
        #region "Progress bar controls"
        private void pbEventPurpose_EditValueChanged(object sender, EventArgs e)
        {
            int i = tbEventPurpose.Text.Length;
            pbEventPurpose.EditValue = i;
        }

        private void pbEventOrient_EditValueChanged(object sender, EventArgs e)
        {
            int i = tbEventOrient.Text.Length;
            pbEventOrient.EditValue = i;
        }
        #endregion
        #region "Add and remove second case"
        private void btnAddSecondCase_Click(object sender, EventArgs e)
        {
            if (!cbBaseCaseTypeSecond.Visible && !tbBaseCaseNameSecond.Visible && !tbBaseCaseNoSecond.Visible && !cbBaseCaseArticleNoSecond.Visible)
            {
                cbBaseCaseTypeSecond.Enabled = true;
                //tbBaseCaseNameSecond.Enabled = true;
                tbBaseCaseNoSecond.Enabled = true;
                cbBaseCaseArticleNoSecond.Enabled = true;

                cbBaseCaseTypeSecond.Visible = true;
                tbBaseCaseNameSecond.Visible = true;
                tbBaseCaseNoSecond.Visible = true;
                cbBaseCaseArticleNoSecond.Visible = true;
                labelBaseCaseTypeSecond.Visible = true;
                labelBaseCaseNameSecond.Visible = true;
                labelBaseCaseNoSecond.Visible = true;
                labelBaseCaseArticleNoSecond.Visible = true;

                btnAddSecondCase.Text = "Удалить второе дело";
                btnAddSecondCase.Image = Properties.Resources.AddItem_16x16;
            }
            else
            {
                cbBaseCaseTypeSecond.Enabled = false;
                tbBaseCaseNameSecond.Enabled = false;
                tbBaseCaseNoSecond.Enabled = false;
                cbBaseCaseArticleNoSecond.Enabled = false;

                cbBaseCaseTypeSecond.Visible = false;
                tbBaseCaseNameSecond.Visible = false;
                tbBaseCaseNoSecond.Visible = false;
                cbBaseCaseArticleNoSecond.Visible = false;
                labelBaseCaseTypeSecond.Visible = false;
                labelBaseCaseNameSecond.Visible = false;
                labelBaseCaseNoSecond.Visible = false;
                labelBaseCaseArticleNoSecond.Visible = false;

                btnAddSecondCase.Text = "Добавить второе дело";
                btnAddSecondCase.Image = Properties.Resources.DeleteList_16x16;

                cbBaseCaseTypeSecond.Text = string.Empty;
                tbBaseCaseNameSecond.Text = string.Empty;
                tbBaseCaseNoSecond.Text = string.Empty;
                cbBaseCaseArticleNoSecond.Text = string.Empty;
            }
        }
        #endregion
        #region "Unspecified object name and work controls depending from data base"
        private void btnObjectNoPerson_Click(object sender, EventArgs e)
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM ObjectUnspecified WHERE UnspecifiedType = 1";
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tbObjectSurname.Text = dr["Name"].ToString();
                        tbObjectName.Text = dr["Name"].ToString();
                        tbObjectSecondName.Text = dr["Name"].ToString();
                        dtObjectBirthDT.Text = string.Empty;
                        cbObjectCountry.Text = string.Empty;
                        cbObjectSex.Text = string.Empty;
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
        private void btnObjectNoWork_Click(object sender, EventArgs e)
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM ObjectUnspecified WHERE UnspecifiedType = 2";
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tbObjectWorkPosition.Text = dr["Name"].ToString();
                        tbObjectWorkName.Text = dr["Name"].ToString();
                        tbObjectWorkAddress.Text = dr["Name"].ToString();
                        tbObjectHomeAddress.Text = dr["Name"].ToString();
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
        #region "Detalization controls"
        private void chbBaseDetalization_CheckedChanged(object sender, EventArgs e)
        {
            if (chbBaseDetalization.Checked)
            {
                popupDetalization.Enabled = true;
            }
            else
            {
                popupDetalization.Enabled = false;
                popupDetalization.Text = string.Empty;
            }
        }

        private void chbDetalization1_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDetalization1.Checked)
            {
                dtBaseDetalization1StartDT.Enabled = true;
                dtBaseDetalization1FinishDT.Enabled = true;
            }
            else
            {
                dtBaseDetalization1StartDT.Enabled = false;
                dtBaseDetalization1FinishDT.Enabled = false;
                dtBaseDetalization1StartDT.Text = string.Empty;
                dtBaseDetalization1FinishDT.Text = string.Empty;
            }

            if (!chbDetalization1.Checked && chbDetalization2.Checked)
            {
                chbDetalization2.Checked = false;
                chbDetalization3.Checked = false;

                dtBaseDetalization2StartDT.Text = string.Empty;
                dtBaseDetalization2FinishDT.Text = string.Empty;
                dtBaseDetalization3StartDT.Text = string.Empty;
                dtBaseDetalization3FinishDT.Text = string.Empty;
            }
        }

        private void chbDetalization2_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbDetalization1.Checked && chbDetalization2.Checked)
            {
                XtraMessageBox.Show("Выберите сначала первый период!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chbDetalization2.Checked = false;
            }

            if (chbDetalization2.Checked)
            {
                dtBaseDetalization2StartDT.Enabled = true;
                dtBaseDetalization2FinishDT.Enabled = true;
            }
            else
            {
                dtBaseDetalization2StartDT.Enabled = false;
                dtBaseDetalization2FinishDT.Enabled = false;
                dtBaseDetalization2StartDT.Text = string.Empty;
                dtBaseDetalization2FinishDT.Text = string.Empty;
            }

            if (!chbDetalization2.Checked && chbDetalization3.Checked)
            {
                chbDetalization3.Checked = false;

                dtBaseDetalization3StartDT.Text = string.Empty;
                dtBaseDetalization3FinishDT.Text = string.Empty;
            }
        }

        private void chbDetalization3_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbDetalization2.Checked && chbDetalization3.Checked)
            {
                XtraMessageBox.Show("Выберите сначала второй период!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chbDetalization3.Checked = false;
            }

            if (chbDetalization3.Checked)
            {
                dtBaseDetalization3StartDT.Enabled = true;
                dtBaseDetalization3FinishDT.Enabled = true;
            }
            else
            {
                dtBaseDetalization3StartDT.Enabled = false;
                dtBaseDetalization3FinishDT.Enabled = false;
                dtBaseDetalization3StartDT.Text = string.Empty;
                dtBaseDetalization3FinishDT.Text = string.Empty;
            }
        }

        private void dtBaseDetalization1StartDT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBaseDetalization1StartDT.Text != string.Empty && dtBaseDetalization1FinishDT.Text != string.Empty)
            {
                if (DateTime.Parse(dtBaseDetalization1StartDT.Text) > DateTime.Parse(dtBaseDetalization1FinishDT.Text))
                {
                    XtraMessageBox.Show("Дата и время окончания детализации не может быть раньше даты и времени начала!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtBaseDetalization1StartDT.Text = string.Empty;
                    dtBaseDetalization1FinishDT.Text = string.Empty;
                }
            }

            if (dtBaseDetalization1StartDT.Text != string.Empty)
            {
                popupDetalization.Text = "";
            }
        }

        private void dtBaseDetalization1FinishDT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBaseDetalization1StartDT.Text != string.Empty && dtBaseDetalization1FinishDT.Text != string.Empty)
            {
                if (DateTime.Parse(dtBaseDetalization1FinishDT.Text) < DateTime.Parse(dtBaseDetalization1StartDT.Text))
                {
                    XtraMessageBox.Show("Дата и время окончания детализации не может быть раньше даты и времени начала!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtBaseDetalization1StartDT.Text = string.Empty;
                    dtBaseDetalization1FinishDT.Text = string.Empty;
                }
            }
        }

        private void dtBaseDetalization2StartDT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBaseDetalization2StartDT.Text != string.Empty && dtBaseDetalization2FinishDT.Text != string.Empty)
            {
                if (DateTime.Parse(dtBaseDetalization2StartDT.Text) > DateTime.Parse(dtBaseDetalization2FinishDT.Text))
                {
                    XtraMessageBox.Show("Дата и время окончания детализации не может быть раньше даты и времени начала!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtBaseDetalization2StartDT.Text = string.Empty;
                    dtBaseDetalization2FinishDT.Text = string.Empty;
                }
            }
        }

        private void dtBaseDetalization2FinishDT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBaseDetalization2StartDT.Text != string.Empty && dtBaseDetalization2FinishDT.Text != string.Empty)
            {
                if (DateTime.Parse(dtBaseDetalization2FinishDT.Text) < DateTime.Parse(dtBaseDetalization2StartDT.Text))
                {
                    XtraMessageBox.Show("Дата и время окончания детализации не может быть раньше даты и времени начала!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtBaseDetalization2StartDT.Text = string.Empty;
                    dtBaseDetalization2FinishDT.Text = string.Empty;
                }
            }
        }

        private void dtBaseDetalization3StartDT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBaseDetalization3StartDT.Text != string.Empty && dtBaseDetalization3FinishDT.Text != string.Empty)
            {
                if (DateTime.Parse(dtBaseDetalization3StartDT.Text) > DateTime.Parse(dtBaseDetalization3FinishDT.Text))
                {
                    XtraMessageBox.Show("Дата и время окончания детализации не может быть раньше даты и времени начала!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtBaseDetalization3StartDT.Text = string.Empty;
                    dtBaseDetalization3FinishDT.Text = string.Empty;
                }
            }
        }

        private void dtBaseDetalization3FinishDT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBaseDetalization3StartDT.Text != string.Empty && dtBaseDetalization3FinishDT.Text != string.Empty)
            {
                if (DateTime.Parse(dtBaseDetalization3FinishDT.Text) < DateTime.Parse(dtBaseDetalization3StartDT.Text))
                {
                    XtraMessageBox.Show("Дата и время окончания детализации не может быть раньше даты и времени начала!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtBaseDetalization3StartDT.Text = string.Empty;
                    dtBaseDetalization3FinishDT.Text = string.Empty;
                }
            }
        }

        private void popupDetalization_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (chbDetalization1.Checked && chbDetalization2.Checked && chbDetalization3.Checked)
            {
                popupDetalization.Text = "П1: " + dtBaseDetalization1StartDT.Text + "-" + dtBaseDetalization1FinishDT.Text + "; " + "П2: " + dtBaseDetalization2StartDT.Text + "-" + dtBaseDetalization2FinishDT.Text + "; " + "П3: " + dtBaseDetalization3StartDT.Text + "-" + dtBaseDetalization3FinishDT.Text + ";";
            }
            else if (chbDetalization1.Checked && chbDetalization2.Checked && !chbDetalization3.Checked)
            {
                popupDetalization.Text = "П1: " + dtBaseDetalization1StartDT.Text + "-" + dtBaseDetalization1FinishDT.Text + "; " + "П2: " + dtBaseDetalization2StartDT.Text + "-" + dtBaseDetalization2FinishDT.Text + ";";
            }
            else if (chbDetalization1.Checked && !chbDetalization2.Checked && !chbDetalization3.Checked)
            {
                popupDetalization.Text = "П1: " + dtBaseDetalization1StartDT.Text + "-" + dtBaseDetalization1FinishDT.Text;
            }
            else if (!chbDetalization1.Checked && !chbDetalization2.Checked && !chbDetalization3.Checked)
            {
                popupDetalization.EditValue = null;
            }
        }
        #endregion
        #region "Progress bars controls"
        private void tbEventPurpose_EditValueChanged(object sender, EventArgs e)
        {
            int i = tbEventPurpose.Text.Length;
            pbEventPurpose.EditValue = i;
        }

        private void tbEventOrient_EditValueChanged(object sender, EventArgs e)
        {
            int i = tbEventOrient.Text.Length;
            pbEventOrient.EditValue = i;
        }
        #endregion
        #region "Base Case selected index changed"
        private void cbBaseCaseTypeFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBaseCaseTypeFirst.SelectedItem.ToString() == "ДОР")
                tbBaseCaseNameFirst.Enabled = true;
            else
                tbBaseCaseNameFirst.Enabled = false; tbBaseCaseNameFirst.Text = string.Empty;
        }

        private void cbBaseCaseTypeSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBaseCaseTypeSecond.SelectedItem.ToString() == "ДОР")
                tbBaseCaseNameSecond.Enabled = true;
            else
                tbBaseCaseNameSecond.Enabled = false; tbBaseCaseNameSecond.Text = string.Empty;
        }
        #endregion
        #region "CheckedComboBoxEdit Validate"
        private void ccbColorPattern_EditValueChanged(object sender, EventArgs e)
        {
            ColorPattern = string.Empty;
            foreach (var item in ccbColorPattern.Properties.Items.GetCheckedValues().ToArray())
            {
                ColorPattern += item.ToString() + "|";
            }
        }

        private void ccbColorPattern_Popup(object sender, EventArgs e)
        {
            //var popup = (IPopupControl)sender;
            //var control = popup.PopupWindow.Controls.OfType<PopupContainerControl>().First().Controls.OfType<CheckedListBoxControl>().First();
            //control.ItemCheck += control_ItemCheck;
        }

        int j = 1;
        private void control_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            //var checkedListBoxControl = (CheckedListBoxControl)sender;
            //var current = checkedListBoxControl.Items[e.Index];

            //if (e.State == CheckState.Checked)
            //{
            //    if (j > 4)
            //    {
            //        var dialog = XtraMessageBox.Show("Максимально можно выбрать только 4 пункта!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        if (dialog == System.Windows.Forms.DialogResult.OK)
            //        {
            //            current.InvertCheckState();
            //        }
            //    }
            //    else
            //    {
            //        j++;
            //    }
            //}
            //else
            //{
            //    if (j <= 4)
            //    {
            //        j--;
            //    }
            //}
        }
        #endregion
        #region "Clear Form"
        public void ClearForm()
        {
            cbHeadApproveSurname.Text = string.Empty;
            cbHeadApproveName.Text = string.Empty;
            cbHeadApproveSecondName.Text = string.Empty;
            cbHeadApprovePosition.Text = string.Empty;
            cbHeadApproveTitle.Text = string.Empty;
            cbHeadAcceptSurname.Text = string.Empty;
            cbHeadAcceptName.Text = string.Empty;
            cbHeadAcceptSecondName.Text = string.Empty;
            cbHeadAcceptPosition.Text = string.Empty;
            cbHeadAcceptTitle.Text = string.Empty;
            cbHeadAcceptDivision.EditValue = null;
            cbHeadAcceptService.EditValue = null;
            cbEventType.EditValue = null;
            tbEventIdentifierPoint.Text = string.Empty;
            cbEventIdentifierType.EditValue = null;
            cbEventPlace.EditValue = null;
            tbEventCount.Text = string.Empty;
            dtEventStartDT.Text = string.Empty;
            tbEventPurpose.Text = string.Empty;
            tbEventOrient.Text = string.Empty;
            tbEventReferenceNo.Text = string.Empty;
            cbEventLongStorage.Text = string.Empty;
            tbAccessoryOwnerFullName.Text = string.Empty;
            tbAccessoryOwnerAddress.Text = string.Empty;
            dtAccessoryOwnerBirthDT.Text = string.Empty;
            chbAccessoryTypeIndividual.Checked = true;
            cbBaseCourt.EditValue = null;
            cbBaseJudge.EditValue = null;
            tbBaseResolutionNo.Text = string.Empty;
            dtBaseResolutionStartDT.Text = string.Empty;
            tbBaseResolutionCount.Text = string.Empty;
            chbDetalization3.Checked = false;
            chbDetalization2.Checked = false;
            chbDetalization1.Checked = false;
            chbBaseDetalization.Checked = false;
            cbBaseNotificationCourt.EditValue = null;
            cbBaseNotificationJudge.EditValue = null;
            tbBaseNotificationNo.Text = string.Empty;
            dtBaseNotificationStartDT.Text = string.Empty;
            cbBaseCaseTypeFirst.Text = string.Empty;
            tbBaseCaseNameFirst.Text = string.Empty;
            tbBaseCaseNoFirst.Text = string.Empty;
            cbBaseCaseArticleNoFirst.Text = string.Empty;
            cbBaseCaseTypeSecond.Text = string.Empty;
            tbBaseCaseNameSecond.Text = string.Empty;
            tbBaseCaseNoSecond.Text = string.Empty;
            cbBaseCaseArticleNoSecond.Text = string.Empty;
            tbObjectSurname.Text = string.Empty;
            tbObjectName.Text = string.Empty;
            tbObjectSecondName.Text = string.Empty;
            dtObjectBirthDT.Text = string.Empty;
            cbObjectCountry.Text = string.Empty;
            cbObjectSex.Text = string.Empty;
            tbObjectWorkPosition.Text = string.Empty;
            tbObjectWorkName.Text = string.Empty;
            tbObjectWorkAddress.Text = string.Empty;
            tbObjectHomeAddress.Text = string.Empty;
            cbColorEvent.Text = string.Empty;
            cbColorObject.Text = string.Empty;
            cbColorCrimeSubject.Text = string.Empty;
            cbColorCrimeItem.Text = string.Empty;
            cbColorCrimeTarget.Text = string.Empty;
            cbColorCrimePlace.Text = string.Empty;
            cbColorRoleObject.Text = string.Empty;
            tbDocumentSerialNo.Text = string.Empty;
            dtDocumentDoneDT.Text = string.Empty;

            if (cbBaseCaseTypeSecond.Visible == true)
            {
                btnAddSecondCase.PerformClick();
            }

            for (int i = 0; i < ccbColorPattern.Properties.Items.Count; i++)
            {
                ccbColorPattern.Properties.Items[i].CheckState = CheckState.Unchecked;
            }

        }
        #endregion

        #region "Begin DocX + QR"
        public void UpdateFields()
        {
            //markers.Find(x => x.Tag == "").Value = ""; markers.Find(x => x.Tag == "").ValueDative = "";
            markers.Find(x => x.Tag == "{0}").Value = cbHeadApproveSurname.Text.Trim(); markers.Find(x => x.Tag == "{0}").ValueDative = cbHeadApproveSurname.Text.Trim();
            markers.Find(x => x.Tag == "{1}").Value = cbHeadApproveName.Text.Trim(); markers.Find(x => x.Tag == "{1}").ValueDative = cbHeadApproveName.Text.Trim();
            markers.Find(x => x.Tag == "{2}").Value = cbHeadApproveSecondName.Text.Trim(); markers.Find(x => x.Tag == "{2}").ValueDative = cbHeadApproveSecondName.Text.Trim();
            markers.Find(x => x.Tag == "{3}").Value = cbHeadApprovePosition.Text.Trim(); markers.Find(x => x.Tag == "{3}").ValueDative = cbHeadApprovePosition.Text.Trim();
            markers.Find(x => x.Tag == "{4}").Value = cbHeadApproveTitle.Text.Trim(); markers.Find(x => x.Tag == "{4}").ValueDative = cbHeadApproveTitle.Text.Trim();
            markers.Find(x => x.Tag == "{5}").Value = cbHeadAcceptSurname.Text.Trim(); markers.Find(x => x.Tag == "{5}").ValueDative = SelectDativeFromDb("SurnameDative", "Surname", "HeadAccept", cbHeadAcceptSurname.Text.Trim());
            markers.Find(x => x.Tag == "{6}").Value = cbHeadAcceptName.Text.Trim(); markers.Find(x => x.Tag == "{6}").ValueDative = SelectDativeFromDb("NameDative", "Name", "HeadAccept", cbHeadAcceptName.Text.Trim());
            markers.Find(x => x.Tag == "{7}").Value = cbHeadAcceptSecondName.Text.Trim(); markers.Find(x => x.Tag == "{7}").ValueDative = SelectDativeFromDb("SecondNameDative", "SecondName", "HeadAccept", cbHeadAcceptSecondName.Text.Trim());
            markers.Find(x => x.Tag == "{8}").Value = cbHeadAcceptPosition.Text.Trim(); markers.Find(x => x.Tag == "{8}").ValueDative = SelectDativeFromDb("Dative", "Name", "PositionHead", cbHeadAcceptPosition.Text.Trim());
            markers.Find(x => x.Tag == "{9}").Value = cbHeadAcceptTitle.Text.Trim(); markers.Find(x => x.Tag == "{9}").ValueDative = SelectDativeFromDb("Dative", "Name", "Title", cbHeadAcceptTitle.Text.Trim());
            markers.Find(x => x.Tag == "{10}").Value = cbHeadAcceptDivision.Text.Trim(); markers.Find(x => x.Tag == "{10}").ValueDative = cbHeadAcceptDivision.Text.Trim();
            markers.Find(x => x.Tag == "{11}").Value = cbHeadAcceptService.Text.Trim(); markers.Find(x => x.Tag == "{11}").ValueDative = cbHeadAcceptService.Text.Trim();
            markers.Find(x => x.Tag == "{12}").Value = tbHeadAuthorSurname.Text.Trim(); markers.Find(x => x.Tag == "{12}").ValueDative = SelectDativeFromUserSettings(0, 0);
            markers.Find(x => x.Tag == "{13}").Value = tbHeadAuthorName.Text.Trim(); markers.Find(x => x.Tag == "{13}").ValueDative = SelectDativeFromUserSettings(1, 0);
            markers.Find(x => x.Tag == "{14}").Value = tbHeadAuthorSecondName.Text.Trim(); markers.Find(x => x.Tag == "{14}").ValueDative = SelectDativeFromUserSettings(2, 0);
            markers.Find(x => x.Tag == "{15}").Value = cbHeadAuthorPosition.Text.Trim(); markers.Find(x => x.Tag == "{15}").ValueDative = SelectDativeFromUserSettings(4, 0);
            markers.Find(x => x.Tag == "{16}").Value = cbHeadAuthorTitle.Text.Trim(); markers.Find(x => x.Tag == "{16}").ValueDative = SelectDativeFromUserSettings(3, 0);
            markers.Find(x => x.Tag == "{17}").Value = cbHeadAuthorDivision.Text.Trim(); markers.Find(x => x.Tag == "{17}").ValueDative = cbHeadAuthorDivision.Text.Trim();
            markers.Find(x => x.Tag == "{18}").Value = cbHeadAuthorService.Text.Trim(); markers.Find(x => x.Tag == "{18}").ValueDative = cbHeadAuthorService.Text.Trim();
            markers.Find(x => x.Tag == "{19}").Value = cbHeadAuthorLine.Text.Trim(); markers.Find(x => x.Tag == "{19}").ValueDative = cbHeadAuthorLine.Text.Trim();
            markers.Find(x => x.Tag == "{20}").Value = tbAuthorSurname.Text.Trim(); markers.Find(x => x.Tag == "{20}").ValueDative = SelectDativeFromUserSettings(0, 1);
            markers.Find(x => x.Tag == "{21}").Value = tbAuthorName.Text.Trim(); markers.Find(x => x.Tag == "{21}").ValueDative = SelectDativeFromUserSettings(1, 1);
            markers.Find(x => x.Tag == "{22}").Value = tbAuthorSecondName.Text.Trim(); markers.Find(x => x.Tag == "{22}").ValueDative = SelectDativeFromUserSettings(2, 1);
            markers.Find(x => x.Tag == "{23}").Value = cbAuthorPosition.Text.Trim(); markers.Find(x => x.Tag == "{23}").ValueDative = SelectDativeFromUserSettings(4, 1);
            markers.Find(x => x.Tag == "{24}").Value = cbAuthorTitle.Text.Trim(); markers.Find(x => x.Tag == "{24}").ValueDative = SelectDativeFromUserSettings(3, 1);
            markers.Find(x => x.Tag == "{25}").Value = tbAuthorPhone.Text.Trim(); markers.Find(x => x.Tag == "{25}").ValueDative = tbAuthorPhone.Text.Trim();
            markers.Find(x => x.Tag == "{26}").Value = cbAuthorDivision.Text.Trim(); markers.Find(x => x.Tag == "{26}").ValueDative = cbAuthorDivision.Text.Trim();
            markers.Find(x => x.Tag == "{27}").Value = cbAuthorService.Text.Trim(); markers.Find(x => x.Tag == "{27}").ValueDative = cbAuthorService.Text.Trim();
            markers.Find(x => x.Tag == "{28}").Value = cbAuthorLine.Text.Trim(); markers.Find(x => x.Tag == "{28}").ValueDative = cbAuthorLine.Text.Trim();
            markers.Find(x => x.Tag == "{29}").Value = cbAuthorDepartment.Text.Trim(); markers.Find(x => x.Tag == "{29}").ValueDative = cbAuthorDepartment.Text.Trim();
            markers.Find(x => x.Tag == "{30}").Value = cbAuthorOffice.Text.Trim(); markers.Find(x => x.Tag == "{30}").ValueDative = cbAuthorOffice.Text.Trim();
            markers.Find(x => x.Tag == "{31}").Value = cbEventType.GetColumnValue("Caption").ToString(); markers.Find(x => x.Tag == "{31}").ValueDative = cbEventType.GetColumnValue("OfficialName").ToString();
            markers.Find(x => x.Tag == "{32}").Value = cbEventIdentifierType.Text.Trim(); markers.Find(x => x.Tag == "{32}").ValueDative = cbEventIdentifierType.Text.Trim();
            markers.Find(x => x.Tag == "{33}").Value = tbEventIdentifierPoint.Text.Trim(); markers.Find(x => x.Tag == "{33}").ValueDative = tbEventIdentifierPoint.Text.Trim();
            markers.Find(x => x.Tag == "{34}").Value = cbEventPlace.Text.Trim(); markers.Find(x => x.Tag == "{34}").ValueDative = cbEventPlace.Text.Trim();
            markers.Find(x => x.Tag == "{35}").Value = tbEventCount.Text.Trim(); markers.Find(x => x.Tag == "{35}").ValueDative = tbEventCount.Text.Trim();
            markers.Find(x => x.Tag == "{36}").Value = dtEventStartDT.Text.Trim(); markers.Find(x => x.Tag == "{36}").ValueDative = dtEventStartDT.Text.Trim();
            markers.Find(x => x.Tag == "{37}").Value = tbEventPurpose.Text.Trim(); markers.Find(x => x.Tag == "{37}").ValueDative = tbEventPurpose.Text.Trim();
            markers.Find(x => x.Tag == "{38}").Value = tbEventOrient.Text.Trim(); markers.Find(x => x.Tag == "{38}").ValueDative = tbEventOrient.Text.Trim();
            markers.Find(x => x.Tag == "{39}").Value = tbEventReferenceNo.Text.Trim(); markers.Find(x => x.Tag == "{39}").ValueDative = tbEventReferenceNo.Text.Trim();
            markers.Find(x => x.Tag == "{40}").Value = cbEventLongStorage.Text.Trim(); markers.Find(x => x.Tag == "{40}").ValueDative = cbEventLongStorage.Text.Trim();
            markers.Find(x => x.Tag == "{41}").Value = tbAccessoryOwnerFullName.Text.Trim(); markers.Find(x => x.Tag == "{41}").ValueDative = tbAccessoryOwnerFullName.Text.Trim();
            markers.Find(x => x.Tag == "{42}").Value = tbAccessoryOwnerAddress.Text.Trim(); markers.Find(x => x.Tag == "{42}").ValueDative = tbAccessoryOwnerAddress.Text.Trim();
            markers.Find(x => x.Tag == "{43}").Value = dtAccessoryOwnerBirthDT.Text.Trim(); markers.Find(x => x.Tag == "{43}").ValueDative = dtAccessoryOwnerBirthDT.Text.Trim();
            markers.Find(x => x.Tag == "{44}").Value = cbBaseCourt.Text.Trim(); markers.Find(x => x.Tag == "{44}").ValueDative = cbBaseCourt.Text.Trim();
            markers.Find(x => x.Tag == "{45}").Value = cbBaseJudge.Text.Trim(); markers.Find(x => x.Tag == "{45}").ValueDative = cbBaseJudge.Text.Trim();
            markers.Find(x => x.Tag == "{46}").Value = tbBaseResolutionNo.Text.Trim(); markers.Find(x => x.Tag == "{46}").ValueDative = tbBaseResolutionNo.Text.Trim();
            markers.Find(x => x.Tag == "{47}").Value = dtBaseResolutionStartDT.Text.Trim(); markers.Find(x => x.Tag == "{47}").ValueDative = dtBaseResolutionStartDT.Text.Trim();
            markers.Find(x => x.Tag == "{48}").Value = tbBaseResolutionCount.Text.Trim(); markers.Find(x => x.Tag == "{48}").ValueDative = tbBaseResolutionCount.Text.Trim();
            markers.Find(x => x.Tag == "{49}").Value = dtBaseDetalization1StartDT.Text.Trim(); markers.Find(x => x.Tag == "{49}").ValueDative = dtBaseDetalization1StartDT.Text.Trim();
            markers.Find(x => x.Tag == "{50}").Value = dtBaseDetalization1FinishDT.Text.Trim(); markers.Find(x => x.Tag == "{50}").ValueDative = dtBaseDetalization1FinishDT.Text.Trim();
            markers.Find(x => x.Tag == "{51}").Value = dtBaseDetalization2StartDT.Text.Trim(); markers.Find(x => x.Tag == "{51}").ValueDative = dtBaseDetalization2StartDT.Text.Trim();
            markers.Find(x => x.Tag == "{52}").Value = dtBaseDetalization2FinishDT.Text.Trim(); markers.Find(x => x.Tag == "{52}").ValueDative = dtBaseDetalization2FinishDT.Text.Trim();
            markers.Find(x => x.Tag == "{53}").Value = dtBaseDetalization3StartDT.Text.Trim(); markers.Find(x => x.Tag == "{53}").ValueDative = dtBaseDetalization3StartDT.Text.Trim();
            markers.Find(x => x.Tag == "{54}").Value = dtBaseDetalization3FinishDT.Text.Trim(); markers.Find(x => x.Tag == "{54}").ValueDative = dtBaseDetalization3FinishDT.Text.Trim();
            markers.Find(x => x.Tag == "{55}").Value = cbBaseCaseTypeFirst.Text.Trim(); markers.Find(x => x.Tag == "{55}").ValueDative = cbBaseCaseTypeFirst.Text.Trim();
            markers.Find(x => x.Tag == "{56}").Value = tbBaseCaseNameFirst.Text.Trim(); markers.Find(x => x.Tag == "{56}").ValueDative = tbBaseCaseNameFirst.Text.Trim();
            markers.Find(x => x.Tag == "{57}").Value = tbBaseCaseNoFirst.Text.Trim(); markers.Find(x => x.Tag == "{57}").ValueDative = tbBaseCaseNoFirst.Text.Trim();
            markers.Find(x => x.Tag == "{58}").Value = cbBaseCaseArticleNoFirst.Text.Trim(); markers.Find(x => x.Tag == "{58}").ValueDative = cbBaseCaseArticleNoFirst.Text.Trim();
            markers.Find(x => x.Tag == "{59}").Value = cbBaseCaseTypeSecond.Text.Trim(); markers.Find(x => x.Tag == "{59}").ValueDative = cbBaseCaseTypeSecond.Text.Trim();
            markers.Find(x => x.Tag == "{60}").Value = tbBaseCaseNameSecond.Text.Trim(); markers.Find(x => x.Tag == "{60}").ValueDative = tbBaseCaseNameSecond.Text.Trim();
            markers.Find(x => x.Tag == "{61}").Value = tbBaseCaseNoSecond.Text.Trim(); markers.Find(x => x.Tag == "{61}").ValueDative = tbBaseCaseNoSecond.Text.Trim();
            markers.Find(x => x.Tag == "{62}").Value = cbBaseCaseArticleNoSecond.Text.Trim(); markers.Find(x => x.Tag == "{62}").ValueDative = cbBaseCaseArticleNoSecond.Text.Trim();
            markers.Find(x => x.Tag == "{63}").Value = cbBaseNotificationCourt.Text.Trim(); markers.Find(x => x.Tag == "{63}").ValueDative = cbBaseNotificationCourt.Text.Trim();
            markers.Find(x => x.Tag == "{64}").Value = cbBaseNotificationJudge.Text.Trim(); markers.Find(x => x.Tag == "{64}").ValueDative = cbBaseNotificationJudge.Text.Trim();
            markers.Find(x => x.Tag == "{65}").Value = tbBaseNotificationNo.Text.Trim(); markers.Find(x => x.Tag == "{65}").ValueDative = tbBaseNotificationNo.Text.Trim();
            markers.Find(x => x.Tag == "{66}").Value = dtBaseNotificationStartDT.Text.Trim(); markers.Find(x => x.Tag == "{66}").ValueDative = dtBaseNotificationStartDT.Text.Trim();
            markers.Find(x => x.Tag == "{67}").Value = tbObjectSurname.Text.Trim(); markers.Find(x => x.Tag == "{67}").ValueDative = tbObjectSurname.Text.Trim();
            markers.Find(x => x.Tag == "{68}").Value = tbObjectName.Text.Trim(); markers.Find(x => x.Tag == "{68}").ValueDative = tbObjectName.Text.Trim();
            markers.Find(x => x.Tag == "{69}").Value = tbObjectSecondName.Text.Trim(); markers.Find(x => x.Tag == "{69}").ValueDative = tbObjectSecondName.Text.Trim();
            markers.Find(x => x.Tag == "{70}").Value = dtObjectBirthDT.Text.Trim(); markers.Find(x => x.Tag == "{70}").ValueDative = dtObjectBirthDT.Text.Trim();
            markers.Find(x => x.Tag == "{71}").Value = cbObjectCountry.Text.Trim(); markers.Find(x => x.Tag == "{71}").ValueDative = cbObjectCountry.Text.Trim();
            markers.Find(x => x.Tag == "{72}").Value = cbObjectSex.Text.Trim(); markers.Find(x => x.Tag == "{72}").ValueDative = cbObjectSex.Text.Trim();
            markers.Find(x => x.Tag == "{73}").Value = tbObjectWorkPosition.Text.Trim(); markers.Find(x => x.Tag == "{73}").ValueDative = tbObjectWorkPosition.Text.Trim();
            markers.Find(x => x.Tag == "{74}").Value = tbObjectWorkName.Text.Trim(); markers.Find(x => x.Tag == "{74}").ValueDative = tbObjectWorkName.Text.Trim();
            markers.Find(x => x.Tag == "{75}").Value = tbObjectWorkAddress.Text.Trim(); markers.Find(x => x.Tag == "{75}").ValueDative = tbObjectWorkAddress.Text.Trim();
            markers.Find(x => x.Tag == "{76}").Value = tbObjectHomeAddress.Text.Trim(); markers.Find(x => x.Tag == "{76}").ValueDative = tbObjectHomeAddress.Text.Trim();
            markers.Find(x => x.Tag == "{77}").Value = cbColorEvent.Text.Trim(); markers.Find(x => x.Tag == "{77}").ValueDative = cbColorEvent.Text.Trim();
            markers.Find(x => x.Tag == "{78}").Value = cbColorObject.Text.Trim(); markers.Find(x => x.Tag == "{78}").ValueDative = cbColorObject.Text.Trim();
            markers.Find(x => x.Tag == "{79}").Value = cbColorCrimeSubject.Text.Trim(); markers.Find(x => x.Tag == "{79}").ValueDative = cbColorCrimeSubject.Text.Trim();
            markers.Find(x => x.Tag == "{80}").Value = cbColorCrimeItem.Text.Trim(); markers.Find(x => x.Tag == "{80}").ValueDative = cbColorCrimeItem.Text.Trim();
            markers.Find(x => x.Tag == "{81}").Value = cbColorCrimeTarget.Text.Trim(); markers.Find(x => x.Tag == "{81}").ValueDative = cbColorCrimeTarget.Text.Trim();
            markers.Find(x => x.Tag == "{82}").Value = cbColorCrimePlace.Text.Trim(); markers.Find(x => x.Tag == "{82}").ValueDative = cbColorCrimePlace.Text.Trim();
            markers.Find(x => x.Tag == "{83}").Value = cbColorRoleObject.Text.Trim(); markers.Find(x => x.Tag == "{83}").ValueDative = cbColorRoleObject.Text.Trim();
            markers.Find(x => x.Tag == "{84}").Value = ColorPattern; markers.Find(x => x.Tag == "{84}").ValueDative = ColorPattern;
            markers.Find(x => x.Tag == "{85}").Value = tbDocumentSerialNo.Text.Trim(); markers.Find(x => x.Tag == "{85}").ValueDative = tbDocumentSerialNo.Text.Trim();
            markers.Find(x => x.Tag == "{86}").Value = tbDocumentWorkStation.Text.Trim(); markers.Find(x => x.Tag == "{86}").ValueDative = tbDocumentWorkStation.Text.Trim();
            markers.Find(x => x.Tag == "{87}").Value = tbDocumentAuthor.Text.Trim(); markers.Find(x => x.Tag == "{87}").ValueDative = tbDocumentAuthor.Text.Trim();
            markers.Find(x => x.Tag == "{88}").Value = tbDocumentAuthorPhone.Text.Trim(); markers.Find(x => x.Tag == "{88}").ValueDative = tbDocumentAuthorPhone.Text.Trim();
            markers.Find(x => x.Tag == "{89}").Value = tbDocumentPrivacyRank.Text.Trim(); markers.Find(x => x.Tag == "{89}").ValueDative = tbDocumentPrivacyRank.Text.Trim();
            markers.Find(x => x.Tag == "{90}").Value = tbDocumentOrderNo.Text.Trim(); markers.Find(x => x.Tag == "{90}").ValueDative = tbDocumentOrderNo.Text.Trim();
            markers.Find(x => x.Tag == "{91}").Value = tbDocumentPageCount.Text.Trim(); markers.Find(x => x.Tag == "{91}").ValueDative = tbDocumentPageCount.Text.Trim();
            markers.Find(x => x.Tag == "{92}").Value = dtDocumentDoneDT.Text.Trim(); markers.Find(x => x.Tag == "{92}").ValueDative = dtDocumentDoneDT.Text.Trim();
        }

        public void UpdateDoc()
        {
            using (var doc = new Spire.Doc.Document(Application.StartupPath + "\\Data\\Templates\\templ.docx", Spire.Doc.FileFormat.Docx))
            {
                doc.Replace("{100}", ControlPanel.controlPanel.taskNo, false, false);

                qrText = string.Empty;

                #region "Split Object Work Information"
                string ObjectWorkPosition = markers.Find(x => x.Tag == "{73}").Value;
                string ObjectWorkName = markers.Find(x => x.Tag == "{74}").Value;
                string ObjectWorkAddress = markers.Find(x => x.Tag == "{75}").Value;
                string ObjectHomeAddress = markers.Find(x => x.Tag == "{76}").Value;

                try
                {
                    using (var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData))
                    {
                        conn.Open();
                        using (var comm = conn.CreateCommand())
                        {
                            comm.CommandText = "SELECT Name FROM ObjectUnspecified WHERE UnspecifiedType = 2";
                            using (var dr = comm.ExecuteReader())
                            {
                                if (dr.HasRows)
                                    while (dr.Read())
                                    {
                                        if (ObjectWorkPosition == dr["Name"].ToString() && ObjectWorkName == dr["Name"].ToString() && ObjectWorkAddress == dr["Name"].ToString() && ObjectHomeAddress == dr["Name"].ToString())
                                        {
                                            doc.Replace("{73}", "Место работы и жительства не установлено", false, false);
                                            doc.Replace("{74}", "", false, false);
                                            doc.Replace("{75}", "", false, false);
                                            doc.Replace("{76}", "", false, false);
                                        }
                                    }
                                else
                                    conn.Close();
                            }
                        }
                        conn.Close();
                    }
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
                #endregion

                foreach (var marker in markers)
                {
                    doc.Replace(marker.Tag, marker.TextValue, false, false);

                    if (marker.Tag == "{37}") // Цель мероприятия
                        qrText += "#T37#" + marker.QRValue + "#T37#" + Environment.NewLine;
                    else if (marker.Tag == "{38}") // Ориентировка
                        qrText += "#T38#" + marker.QRValue + "#T38#" + Environment.NewLine;
                    else if (marker.Tag == "{42}") // Принадлежность адрес
                        qrText += "#T42#" + marker.QRValue + "#T42#" + Environment.NewLine;
                    else if (marker.Tag == "{75}") // Адрес работы
                        qrText += "#T75#" + marker.QRValue + "#T75#" + Environment.NewLine;
                    else if (marker.Tag == "{76}") // Адрес жительства
                        qrText += "#T76#" + marker.QRValue + "#T76#" + Environment.NewLine;
                    else if (marker.Tag == "{84}") // Характеристика
                        qrText += "#T84#" + marker.QRValue + "#T84#" + Environment.NewLine;
                    else
                        qrText += marker.QRValue + Environment.NewLine;
                }

                InsertQRCode(doc);
                doc.SaveToFile(Application.StartupPath + "\\Temp\\tmp.docx", Spire.Doc.FileFormat.Docx);
            }
            //using (var doc = DocX.Load(Application.StartupPath + "\\Data\\Templates\\templ.docx"))
            //{
            //    doc.ReplaceText("{100}", ControlPanel.controlPanel.taskNo); // Подставляем номер задания

            //    qrText = string.Empty;

            //    #region "Split Object Work Information"
            //    string ObjectWorkPosition = markers.Find(x => x.Tag == "{73}").Value;
            //    string ObjectWorkName = markers.Find(x => x.Tag == "{74}").Value;
            //    string ObjectWorkAddress = markers.Find(x => x.Tag == "{75}").Value;
            //    string ObjectHomeAddress = markers.Find(x => x.Tag == "{76}").Value;

            //    try
            //    {
            //        using (var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData))
            //        {
            //            conn.Open();
            //            using (var comm = conn.CreateCommand())
            //            {
            //                comm.CommandText = "SELECT Name FROM ObjectUnspecified WHERE UnspecifiedType = 2";
            //                using (var dr = comm.ExecuteReader())
            //                {
            //                    if (dr.HasRows)
            //                        while (dr.Read())
            //                        {
            //                            if (ObjectWorkPosition == dr["Name"].ToString() && ObjectWorkName == dr["Name"].ToString() && ObjectWorkAddress == dr["Name"].ToString() && ObjectHomeAddress == dr["Name"].ToString())
            //                            {
            //                                doc.ReplaceText("{73}", "Место работы и жительства не установлено");
            //                                doc.ReplaceText("{74}", "");
            //                                doc.ReplaceText("{75}", "");
            //                                doc.ReplaceText("{76}", "");
            //                            }
            //                        }
            //                    else
            //                        conn.Close();
            //                }
            //            }
            //            conn.Close();
            //        }
            //    }
            //    catch (SQLiteException ex)
            //    {
            //        XtraMessageBox.Show(ex.Message.ToString());
            //    }
            //    #endregion

            //    foreach (var marker in markers)
            //    {
            //        doc.ReplaceText(marker.Tag, marker.TextValue);

            //        if (marker.Tag == "{37}") // Цель мероприятия
            //            qrText += "#T37#" + marker.QRValue + "#T37#" + Environment.NewLine;
            //        else if (marker.Tag == "{38}") // Ориентировка
            //            qrText += "#T38#" + marker.QRValue + "#T38#" + Environment.NewLine;
            //        else if (marker.Tag == "{42}") // Принадлежность адрес
            //            qrText += "#T42#" + marker.QRValue + "#T42#" + Environment.NewLine;
            //        else if (marker.Tag == "{75}") // Адрес работы
            //            qrText += "#T75#" + marker.QRValue + "#T75#" + Environment.NewLine;
            //        else if (marker.Tag == "{76}") // Адрес жительства
            //            qrText += "#T76#" + marker.QRValue + "#T76#" + Environment.NewLine;
            //        else if (marker.Tag == "{84}") // Характеристика
            //            qrText += "#T84#" + marker.QRValue + "#T84#" + Environment.NewLine;
            //        else
            //            qrText += marker.QRValue + Environment.NewLine;
            //    }

            //    InsertQRCode(doc);
            //    doc.SaveAs(Application.StartupPath + "\\Temp\\tmp.docx");
            //}
        }

        public void InsertQRCode(Spire.Doc.Document doc)//(Novacode.DocX document)
        {
            UpdateQR(qrText);
            int i = 0;
            foreach (System.Drawing.Bitmap Img in img)
            {
                using (var ms = new MemoryStream())
                {
                    Img.Save(ms, ImageFormat.Png);
                    ms.Position = 0;

                    Table t = (Table)doc.Sections[0].Tables[2];
                    if (i == 0)
                    {
                        DocPicture picture = t.Rows[0].Cells[0].Paragraphs[0].AppendPicture(ms.ToArray());
                        picture.Width = 120;
                        picture.Height = 120;
                    }
                    if (i == 1)
                    {
                        DocPicture picture = t.Rows[0].Cells[1].Paragraphs[0].AppendPicture(ms.ToArray());
                        picture.Width = 120;
                        picture.Height = 120;
                    }
                    if (i == 2)
                    {
                        DocPicture picture = t.Rows[0].Cells[2].Paragraphs[0].AppendPicture(ms.ToArray());
                        picture.Width = 120;
                        picture.Height = 120;
                    }
                }
                i++;
            }

            //UpdateQR(qrText);

            //int i = 0;
            //foreach (System.Drawing.Bitmap Img in img)
            //{
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        Img.Save(ms, ImageFormat.Png);
            //        ms.Position = 0;
            //        Picture pic1 = document.AddImage(ms).CreatePicture(150, 150);
            //        Novacode.Table t = document.Tables[2];

            //        if (i == 0)
            //            t.Rows[0].Cells[0].Paragraphs.First().AppendPicture(pic1);
            //        if (i == 1)
            //            t.Rows[0].Cells[1].Paragraphs.First().AppendPicture(pic1);
            //        if (i == 2)
            //            t.Rows[0].Cells[2].Paragraphs.First().AppendPicture(pic1);
            //    }
            //    i++;
            //}
        }

        public void UpdateQR(string text)
        {
            img.Clear();

            List<string> list = Split(text, 1200).ToList<string>();

            for (int i = 0; i < list.Count; i++)
                list[i] = Base64Encode((i + 1) + " " + list.Count + Environment.NewLine + ControlPanel.controlPanel.taskNo + " Task" + Environment.NewLine + list[i]);

            img = new List<Bitmap>();

            QRCodeWriter qrEncode = new QRCodeWriter(); //создание QR кода
            BarcodeWriter qrWrite = new BarcodeWriter(); //класс для кодирования QR в растровом файле

            foreach (string s in list)
            {
                BitMatrix qrMatrix = qrEncode.encode(s, BarcodeFormat.QR_CODE, 2000, 2000);

                Bitmap b = qrWrite.Write(qrMatrix);
                img.Add(b);
            }
        }

        public static string Base64Encode(string plainText)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainText));
        }

        public static IEnumerable<string> Split(string s, int length)
        {
            int i;
            for (i = 0; i + length < s.Length; i += length)
                yield return s.Substring(i, length);
            if (i != s.Length)
                yield return s.Substring(i, s.Length - i);
        }

        public static string SelectDativeFromDb(string _columnName, string _searchColumn, string _tableName, string _value)
        {
            string _out = "";

            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT " + _columnName + " FROM " + _tableName + " WHERE " + _searchColumn + " = @Value LIMIT 1";
                comm.Parameters.AddWithValue("@Value", _value);
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                        _out = dr[_columnName].ToString();
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    _out = _value;
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _out;
        }

        public static string SelectDativeFromUserSettings(int _searchParam, int _searchGroup) // 0-Surname, 1-Name, 2-SecondName, 3-Title, 4-Position ?? 0-head, 1-user
        {
            if (_searchGroup == 1)
            {
                if (_searchParam == 0)
                    return UserSettings.SettingsList[0].UserSurnameDative;
                else if (_searchParam == 1)
                    return UserSettings.SettingsList[0].UserNameDative;
                else if (_searchParam == 2)
                    return UserSettings.SettingsList[0].UserSecondNameDative;
                else if (_searchParam == 3)
                    return UserSettings.SettingsList[0].UserTitleDative;
                else if (_searchParam == 4)
                    return UserSettings.SettingsList[0].UserPositionDative;
                else
                    return string.Empty;
            }
            else
            {
                if (_searchParam == 0)
                    return UserSettings.SettingsList[0].HeadSurnameDative;
                else if (_searchParam == 1)
                    return UserSettings.SettingsList[0].HeadNameDative;
                else if (_searchParam == 2)
                    return UserSettings.SettingsList[0].HeadSecondNameDative;
                else if (_searchParam == 3)
                    return UserSettings.SettingsList[0].HeadTitleDative;
                else if (_searchParam == 4)
                    return UserSettings.SettingsList[0].HeadPositionDative;
                else
                    return string.Empty;
            }
        }
        #endregion

        #region "Validate Task Fields"
        public void UpdateForValidate()
        {
            controls.Clear();
            controls.Add(new TaskControls { control = cbHeadApproveSurname, Flag = false });
            controls.Add(new TaskControls { control = cbHeadApproveName, Flag = false });
            controls.Add(new TaskControls { control = cbHeadApproveSecondName, Flag = false });
            controls.Add(new TaskControls { control = cbHeadApprovePosition, Flag = false });
            controls.Add(new TaskControls { control = cbHeadApproveTitle, Flag = false });
            controls.Add(new TaskControls { control = cbHeadAcceptSurname, Flag = false });
            controls.Add(new TaskControls { control = cbHeadAcceptName, Flag = false });
            controls.Add(new TaskControls { control = cbHeadAcceptSecondName, Flag = false });
            controls.Add(new TaskControls { control = cbHeadAcceptPosition, Flag = false });
            controls.Add(new TaskControls { control = cbHeadAcceptTitle, Flag = false });
            controls.Add(new TaskControls { control = cbHeadAcceptDivision, Flag = false });
            controls.Add(new TaskControls { control = cbHeadAcceptService, Flag = false });
            controls.Add(new TaskControls { control = tbHeadAuthorSurname, Flag = false });
            controls.Add(new TaskControls { control = tbHeadAuthorName, Flag = false });
            controls.Add(new TaskControls { control = tbHeadAuthorSecondName, Flag = false });
            controls.Add(new TaskControls { control = cbHeadAuthorPosition, Flag = false });
            controls.Add(new TaskControls { control = cbHeadAuthorTitle, Flag = false });
            controls.Add(new TaskControls { control = cbHeadAuthorDivision, Flag = false });
            controls.Add(new TaskControls { control = cbHeadAuthorService, Flag = false });
            controls.Add(new TaskControls { control = tbAuthorSurname, Flag = false });
            controls.Add(new TaskControls { control = tbAuthorName, Flag = false });
            controls.Add(new TaskControls { control = tbAuthorSecondName, Flag = false });
            controls.Add(new TaskControls { control = cbAuthorPosition, Flag = false });
            controls.Add(new TaskControls { control = cbAuthorTitle, Flag = false });
            controls.Add(new TaskControls { control = tbAuthorPhone, Flag = false });
            controls.Add(new TaskControls { control = cbAuthorDivision, Flag = false });
            controls.Add(new TaskControls { control = cbAuthorService, Flag = false });
            controls.Add(new TaskControls { control = cbAuthorDepartment, Flag = false });
            controls.Add(new TaskControls { control = cbEventType, Flag = false });
            controls.Add(new TaskControls { control = cbEventIdentifierType, Flag = false });
            controls.Add(new TaskControls { control = tbEventIdentifierPoint, Flag = false });
            if (!MainForm.mainForm.IsAdmin)
            {
                controls.Add(new TaskControls { control = cbEventPlace, Flag = false });
                controls.Add(new TaskControls { control = tbEventCount, Flag = false });
                controls.Add(new TaskControls { control = dtEventStartDT, Flag = false });
                controls.Add(new TaskControls { control = tbEventPurpose, Flag = false });
                controls.Add(new TaskControls { control = tbEventOrient, Flag = false });
                controls.Add(new TaskControls { control = tbEventReferenceNo, Flag = false });
                controls.Add(new TaskControls { control = cbEventLongStorage, Flag = false });
                controls.Add(new TaskControls { control = tbAccessoryOwnerFullName, Flag = false });
                controls.Add(new TaskControls { control = tbAccessoryOwnerAddress, Flag = false });
                controls.Add(new TaskControls { control = dtAccessoryOwnerBirthDT, Flag = false });
                controls.Add(new TaskControls { control = cbBaseCourt, Flag = false });
                controls.Add(new TaskControls { control = cbBaseJudge, Flag = false });
                controls.Add(new TaskControls { control = tbBaseResolutionNo, Flag = false });
                controls.Add(new TaskControls { control = dtBaseResolutionStartDT, Flag = false });
                controls.Add(new TaskControls { control = tbBaseResolutionCount, Flag = false });
                controls.Add(new TaskControls { control = cbBaseNotificationCourt, Flag = false });
                controls.Add(new TaskControls { control = cbBaseNotificationJudge, Flag = false });
                controls.Add(new TaskControls { control = tbBaseNotificationNo, Flag = false });
                controls.Add(new TaskControls { control = dtBaseNotificationStartDT, Flag = false });
                controls.Add(new TaskControls { control = cbBaseCaseTypeFirst, Flag = false });
                controls.Add(new TaskControls { control = tbBaseCaseNameFirst, Flag = false });
                controls.Add(new TaskControls { control = tbBaseCaseNoFirst, Flag = false });
                controls.Add(new TaskControls { control = cbBaseCaseArticleNoFirst, Flag = false });
                controls.Add(new TaskControls { control = cbBaseCaseTypeSecond, Flag = false });
                controls.Add(new TaskControls { control = tbBaseCaseNameSecond, Flag = false });
                controls.Add(new TaskControls { control = tbBaseCaseNoSecond, Flag = false });
                controls.Add(new TaskControls { control = cbBaseCaseArticleNoSecond, Flag = false });
                controls.Add(new TaskControls { control = tbObjectSurname, Flag = false });
                controls.Add(new TaskControls { control = tbObjectName, Flag = false });
                controls.Add(new TaskControls { control = tbObjectSecondName, Flag = false });
                controls.Add(new TaskControls { control = tbObjectWorkPosition, Flag = false });
                controls.Add(new TaskControls { control = tbObjectWorkName, Flag = false });
                controls.Add(new TaskControls { control = tbObjectWorkAddress, Flag = false });
                controls.Add(new TaskControls { control = tbObjectHomeAddress, Flag = false });
                controls.Add(new TaskControls { control = cbColorEvent, Flag = false });
                controls.Add(new TaskControls { control = cbColorObject, Flag = false });
                controls.Add(new TaskControls { control = cbColorCrimeSubject, Flag = false });
                controls.Add(new TaskControls { control = cbColorCrimeItem, Flag = false });
                controls.Add(new TaskControls { control = cbColorCrimeTarget, Flag = false });
                controls.Add(new TaskControls { control = cbColorCrimePlace, Flag = false });
                controls.Add(new TaskControls { control = cbColorRoleObject, Flag = false });
                controls.Add(new TaskControls { control = ccbColorPattern, Flag = false });
                controls.Add(new TaskControls { control = tbDocumentSerialNo, Flag = false });
                controls.Add(new TaskControls { control = tbDocumentWorkStation, Flag = false });
                controls.Add(new TaskControls { control = tbDocumentAuthor, Flag = false });
                controls.Add(new TaskControls { control = tbDocumentAuthorPhone, Flag = false });
                controls.Add(new TaskControls { control = tbDocumentPrivacyRank, Flag = false });
                controls.Add(new TaskControls { control = tbDocumentOrderNo, Flag = false });
                controls.Add(new TaskControls { control = tbDocumentPageCount, Flag = false });
                controls.Add(new TaskControls { control = dtDocumentDoneDT, Flag = false });
            }
        }

        public bool ValidateTaskFields(List<TaskControls> controls)
        {
            foreach (var item in controls)
            {
                if (item.control.Enabled == true)
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

        public class TaskControls
        {
            public BaseEdit control { get; set; }
            public bool Flag { get; set; }
        }
        #endregion
    }
}
