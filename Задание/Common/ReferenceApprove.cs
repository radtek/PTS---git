using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Задание
{
    public partial class ReferenceApprove : DevExpress.XtraEditors.XtraForm
    {
        List<RefControls> controls = new List<RefControls>();

        public ReferenceApprove()
        {
            InitializeComponent();
            DXErrorProvider.GetErrorIcon += DXErrorProvider_GetErrorIcon;
        }

        private void DXErrorProvider_GetErrorIcon(GetErrorIconEventArgs e)
        {
            if (e.ErrorType == ErrorType.User1)
                e.ErrorIcon = Properties.Resources.icon_error;
        }

        private void ReferenceApprove_Load(object sender, EventArgs e)
        {
            tbSurname.Focus();

            LoadTitle();
            LoadPosition();
            LoadDivisions();
        }

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
                        cbTitle.Properties.Items.Add(dr["Name"].ToString());
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

        private void LoadPosition()
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
                        cbPosition.Properties.Items.Add(dr["Name"].ToString());
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
                cbDivision.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbDivision_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Divisions WHERE Level = 1 AND KeyID = @KeyID";
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbDivision.GetColumnValue("ID").ToString()));
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbService.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbService_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Divisions WHERE Level = 2 AND KeyID = @KeyID";
                var conn = new SQLiteConnection(MainForm.mainForm.connectionDictionaryData);
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@KeyID", Convert.ToInt32(cbService.GetColumnValue("ID").ToString()));
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                cbLine.Properties.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UpdateForValidate();
            if (ValidateFields(controls))
            {
                try
                {
                    using (var conn = new SQLiteConnection(MainForm.mainForm.connectionReferenceData))
                    {
                        conn.Open();
                        using (var comm = conn.CreateCommand())
                        {
                            comm.CommandText = "INSERT INTO Approving (Surname, Name, SecondName, Position, Title, Division, Service, Line) VALUES (@Surname, @Name, @SecondName, @Position, @Title, @Division, @Service, @Line)";
                            comm.Parameters.AddWithValue("@Surname", tbSurname.Text.Trim());
                            comm.Parameters.AddWithValue("@Name", tbName.Text.Trim());
                            comm.Parameters.AddWithValue("@SecondName", tbSecondName.Text.Trim());
                            comm.Parameters.AddWithValue("@Position", cbPosition.Text);
                            comm.Parameters.AddWithValue("@Title", cbTitle.Text);
                            comm.Parameters.AddWithValue("@Division", cbDivision.Text);
                            comm.Parameters.AddWithValue("@Service", cbService.Text);
                            comm.Parameters.AddWithValue("@Line", cbLine.Text);
                            comm.ExecuteNonQuery();
                        }
                        conn.Close();
                    }

                    Reference.reference.LoadApproveList();
                    this.Close();
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                XtraMessageBox.Show("Заполните все необходимые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateForValidate()
        {
            controls.Clear();
            controls.Add(new RefControls { control = tbSurname, Flag = false });
            controls.Add(new RefControls { control = tbName, Flag = false });
            controls.Add(new RefControls { control = tbSecondName, Flag = false });
            controls.Add(new RefControls { control = cbPosition, Flag = false });
            controls.Add(new RefControls { control = cbTitle, Flag = false });
            controls.Add(new RefControls { control = cbDivision, Flag = false });
            controls.Add(new RefControls { control = cbService, Flag = false });
        }

        public bool ValidateFields(List<RefControls> controls)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class RefControls
        {
            public BaseEdit control { get; set; }
            public bool Flag { get; set; }
        }
    }
}
