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

namespace Задание
{
    public partial class BaseEventSettings : DevExpress.XtraEditors.XtraUserControl
    {
        public static BaseEventSettings baseEventSettings;
        ErrorCollector errorCollector = new ErrorCollector();

        public BaseEventSettings()
        {
            InitializeComponent();
            baseEventSettings = this;
        }

        public void LoadData()
        {
            LoadCourtData();
            LoadCaseList();
            LoadArticleList();
            LoadJudgesList();
        }

        #region "Load Data"
        private void LoadCourtData()
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
                lbCourts.DataSource = dataTable;
                cbCourtsList.Properties.DataSource = dataTable;
                cbAddNewCourt.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "LoadCourtData()", false);
            }
        }

        private void LoadCaseList()
        {
            try
            {
                string query = "SELECT * FROM EventCase";
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                lbCase.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "LoadCaseList()", false);
            }
        }

        private void LoadArticleList()
        {
            try
            {
                string query = "SELECT * FROM EventArticle";
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                lbArticle.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "LoadArticleList()", false);
            }
        }

        private void LoadJudgesList()
        {
            if (cbCourtsList.EditValue != null)
            {
                try
                {
                    string query = "SELECT * FROM Judges WHERE CourtID = @CourtID";
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourtID", cbCourtsList.GetColumnValue("ID"));
                    conn.Open();
                    var da = new SQLiteDataAdapter(cmd);
                    var dataTable = new DataTable();
                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose();
                    lbJudges.DataSource = dataTable;
                }
                catch (SQLiteException ex)
                {
                    errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "LoadJudgesList()", false);
                }
            }
        }

        private void lbCourts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCourts.ItemCount > 0)
            {
                try
                {
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    conn.Open();
                    var comm = conn.CreateCommand();
                    comm.CommandText = "SELECT * FROM Courts WHERE ID = @ID";
                    comm.Parameters.AddWithValue("@ID", lbCourts.GetItemValue(lbCourts.SelectedIndex));
                    var dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            tbCourtCaption.Text = dr["Name"].ToString();
                            CourtCaption = dr["Name"].ToString();
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
                    errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "cbCourtsList_EditValueChanged()", false);
                }
            }
        }

        private void cbCourtsList_EditValueChanged(object sender, EventArgs e)
        {
            if (cbCourtsList.EditValue != null)
            {
                try
                {
                    string query = "SELECT * FROM Judges WHERE CourtID = @CourtID";
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourtID", cbCourtsList.GetColumnValue("ID"));
                    conn.Open();
                    var da = new SQLiteDataAdapter(cmd);
                    var dataTable = new DataTable();
                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose();
                    lbJudges.DataSource = dataTable;
                }
                catch (SQLiteException ex)
                {
                    errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "cbCourtsList_EditValueChanged()", false);
                }
            }
        }

        private void lbJudges_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbJudges.ItemCount > 0)
            {
                try
                {
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    conn.Open();
                    var comm = conn.CreateCommand();
                    comm.CommandText = "SELECT * FROM Judges WHERE ID = @ID";
                    comm.Parameters.AddWithValue("@ID", lbJudges.GetItemValue(lbJudges.SelectedIndex));
                    var dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            tbJudgeName.Text = dr["Name"].ToString();
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
                    errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "lbJudges_SelectedIndexChanged()", false);
                }
            }
        }

        private void lbCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCase.ItemCount > 0)
            {
                try
                {
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    conn.Open();
                    var comm = conn.CreateCommand();
                    comm.CommandText = "SELECT * FROM EventCase WHERE ID = @ID";
                    comm.Parameters.AddWithValue("@ID", lbCase.GetItemValue(lbCase.SelectedIndex));
                    var dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            tbCaseName.Text = dr["Name"].ToString();
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
                    errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "lbCase_SelectedIndexChanged()", false);
                }
            }
        }

        private void lbArticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbArticle.ItemCount > 0)
            {
                try
                {
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    conn.Open();
                    var comm = conn.CreateCommand();
                    comm.CommandText = "SELECT * FROM EventArticle WHERE ID = @ID";
                    comm.Parameters.AddWithValue("@ID", lbArticle.GetItemValue(lbArticle.SelectedIndex));
                    var dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            tbArticleName.Text = dr["Name"].ToString();
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
                    errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "lbArticle_SelectedIndexChanged()", false);
                }
            }
        }
        #endregion

        #region "Court Controls"
        private void btnCourtSave_Click(object sender, EventArgs e)
        {
            if (lbCourts.ItemCount > 0)
            {
                try
                {
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    conn.Open();
                    var comm = conn.CreateCommand();
                    comm.CommandText = "UPDATE Courts SET Name = @Name WHERE ID = @ID";
                    comm.Parameters.AddWithValue("@Name", tbCourtCaption.Text.Trim());
                    comm.Parameters.AddWithValue("@ID", lbCourts.GetItemValue(lbCourts.SelectedIndex));
                    comm.ExecuteNonQuery();
                    conn.Close();

                    XtraMessageBox.Show("Запись успешно сохранена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourtData();
                    Task.task.LoadBaseCourts();
                }
                catch (SQLiteException ex)
                {
                    errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "btnCourtSave_Click()", false);
                }
            }
        }

        string CourtCaption = "";

        private void btnCourtCancel_Click(object sender, EventArgs e)
        {
            tbCourtCaption.Text = CourtCaption;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dialog = XtraMessageBox.Show("Вы действительно хотите удалить запись?\r\nУдаение суда приведет к удалению всех судей входящих в его состав!", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                if (lbCourts.ItemCount > 0)
                {
                    try
                    {
                        var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                        conn.Open();
                        var comm = conn.CreateCommand();
                        comm.CommandText = "DELETE FROM Judges WHERE CourtID = @ID";
                        comm.Parameters.AddWithValue("@ID", lbCourts.GetItemValue(lbCourts.SelectedIndex));
                        comm.ExecuteNonQuery();
                        conn.Close();

                        LoadJudgesList();
                        Task.task.LoadBaseJudges();
                    }
                    catch (SQLiteException ex)
                    {
                        errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "btnDelete_Click()", false);
                    }

                    try
                    {
                        var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                        conn.Open();
                        var comm = conn.CreateCommand();
                        comm.CommandText = "DELETE FROM Courts WHERE ID = @ID";
                        comm.Parameters.AddWithValue("@ID", lbCourts.GetItemValue(lbCourts.SelectedIndex));
                        comm.ExecuteNonQuery();
                        conn.Close();

                        XtraMessageBox.Show("Запись успешно удалена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCourtData();
                        Task.task.LoadBaseCourts();
                    }
                    catch (SQLiteException ex)
                    {
                        errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "btnDelete_Click()", false);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void btnCourtAdd_Click(object sender, EventArgs e)
        {
            if (tbAddNewCourt.Text != string.Empty)
            {
                try
                {
                    var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                    conn.Open();
                    var comm = conn.CreateCommand();
                    comm.CommandText = "INSERT INTO Courts (Name) VALUES (@Name)";
                    comm.Parameters.AddWithValue("@Name", tbAddNewCourt.Text.Trim());
                    comm.ExecuteNonQuery();
                    conn.Close();

                    XtraMessageBox.Show("Запись успешно добавлена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourtData();
                    Task.task.LoadBaseCourts();
                    tbAddNewCourt.Text = string.Empty;
                }
                catch (SQLiteException ex)
                {
                    errorCollector.ApplicationEvent(MainForm.mainForm.UserID, 1, ex.Message, "btnCourtAdd_Click()", false);
                }
            }
        }

        private void btnCourtClear_Click(object sender, EventArgs e)
        {
            tbAddNewCourt.Text = string.Empty;
        }
        #endregion
        #region "Judge Controls"
        private void btnJudgeSave_Click(object sender, EventArgs e)
        {

        }

        private void btnJudgeCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnJudgeDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnJudgeAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnJudgeClear_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region "Case Controls"
        private void btnCaseSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCaseCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnCaseDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnCaseAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnCaseClear_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region "Article Controls"
        private void btnArticleSave_Click(object sender, EventArgs e)
        {

        }

        private void btnArticleCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnArticleDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnArticleAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnArticleClear_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
