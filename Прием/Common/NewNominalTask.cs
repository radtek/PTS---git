using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Прием
{
    public partial class NewNominalTask : DevExpress.XtraEditors.XtraForm
    {
        List<TaskControls> controls = new List<TaskControls>();

        public NewNominalTask()
        {
            InitializeComponent();
            DXErrorProvider.GetErrorIcon += DXErrorProvider_GetErrorIcon;
        }

        #region "Validate Fields"
        void DXErrorProvider_GetErrorIcon(GetErrorIconEventArgs e)
        {
            if (e.ErrorType == ErrorType.User1)
                e.ErrorIcon = Properties.Resources.icon_error;
        }

        private void UpdateForValidate()
        {
            controls.Clear();
            controls.Add(new TaskControls { control = cbEventIdentifierType, Flag = false });
            controls.Add(new TaskControls { control = tbEventIdentifierPoint, Flag = false });
            controls.Add(new TaskControls { control = tbObjectSurname, Flag = false });
            controls.Add(new TaskControls { control = tbObjectName, Flag = false });
            controls.Add(new TaskControls { control = tbObjectSecondName, Flag = false });
            controls.Add(new TaskControls { control = cbEventType, Flag = false });
            controls.Add(new TaskControls { control = cbEventCode, Flag = false });
            controls.Add(new TaskControls { control = tbJobNo, Flag = false });
            controls.Add(new TaskControls { control = tbJobCommNo, Flag = false });
            controls.Add(new TaskControls { control = cbJobYear, Flag = false });
            controls.Add(new TaskControls { control = cbTaskExecutor, Flag = false });
            controls.Add(new TaskControls { control = cbTaskGroupControl, Flag = false });
        }

        public bool ValidateFields(List<TaskControls> controls)
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
                return true;
            else
                return false;
        }

        public class TaskControls
        {
            public BaseEdit control { get; set; }
            public bool Flag { get; set; }
        }
        #endregion

        private void NewNominalTask_Load(object sender, EventArgs e)
        {
            LoadEventIdentifierType();
            LoadTaskExecutor();
            LoadTaskGroupControl();
            LoadEventType();
            LoadEventCode();
            LoadTaskYear();
        }

        #region "Load Data"
        private void LoadEventIdentifierType()
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT ObjTypeID, ObjTypeName, TableName FROM ObjType";
                        using (var da = new SqlDataAdapter(comm))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            da.Dispose();
                            cbEventIdentifierType.Properties.DataSource = dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadTaskExecutor()
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT ExecID, ExecName FROM Executor";
                        using (var da = new SqlDataAdapter(comm))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            da.Dispose();
                            cbTaskExecutor.Properties.DataSource = dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadTaskGroupControl()
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT GrpID, GrpName FROM Groups";
                        using (var da = new SqlDataAdapter(comm))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            da.Dispose();
                            cbTaskGroupControl.Properties.DataSource = dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadEventType()
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT JouID, JobType FROM JouJobType";
                        using (var da = new SqlDataAdapter(comm))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            da.Dispose();
                            cbEventType.Properties.DataSource = dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadEventCode()
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT JobCode FROM JouJobCode";
                        using (var dr = comm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                cbEventCode.Properties.Items.Add(dr["JobCode"].ToString());
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadTaskYear()
        {
            int CurrentYear = DateTime.Now.Year;
            cbJobYear.Properties.Items.Add(CurrentYear);
            cbJobYear.Properties.Items.Add(CurrentYear + 1);
        }
        #endregion
        #region "Add New Task"
        #region "Object Insert Methods"
        private int InsertNewPhone()
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "up_PhoneAdd";
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@PhoneNumber", tbEventIdentifierPoint.Text.Substring(1));
                        
                        var ret = new SqlParameter();
                        ret.ParameterName = "@ObjID";
                        ret.DbType = DbType.Int32;
                        ret.Direction = ParameterDirection.Output;
                        comm.Parameters.Add(ret);
                        var result = comm.ExecuteNonQuery();

                        return Convert.ToInt32(comm.Parameters["@ObjID"].Value);
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        private int InsertNewIMEI()
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "up_IMEIAdd";
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@IMEI", tbEventIdentifierPoint.Text);

                        var ret = new SqlParameter();
                        ret.ParameterName = "@ObjID";
                        ret.DbType = DbType.Int32;
                        ret.Direction = ParameterDirection.Output;
                        comm.Parameters.Add(ret);
                        var result = comm.ExecuteNonQuery();

                        return Convert.ToInt32(comm.Parameters["@ObjID"].Value);
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        private int InsertNewIMSI()
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "up_IMSIAdd";
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@IMSI", tbEventIdentifierPoint.Text);

                        var ret = new SqlParameter();
                        ret.ParameterName = "@ObjID";
                        ret.DbType = DbType.Int32;
                        ret.Direction = ParameterDirection.Output;
                        comm.Parameters.Add(ret);
                        var result = comm.ExecuteNonQuery();

                        return Convert.ToInt32(comm.Parameters["@ObjID"].Value);
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        private int InsertNewEMAIL()
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "up_EMAILAdd";
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@EMAIL", tbEventIdentifierPoint.Text);

                        var ret = new SqlParameter();
                        ret.ParameterName = "@ObjID";
                        ret.DbType = DbType.Int32;
                        ret.Direction = ParameterDirection.Output;
                        comm.Parameters.Add(ret);
                        var result = comm.ExecuteNonQuery();

                        return Convert.ToInt32(comm.Parameters["@ObjID"].Value);
                    }
                }
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        private int InsertNewPerson()
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "up_PersonAdd";
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@PersonBirthDT", DBNull.Value);
                        if (!chbNonPerson.Checked)
                        {
                            comm.Parameters.AddWithValue("@PersonSurname", tbObjectSurname.Text);
                            comm.Parameters.AddWithValue("@PersonName", tbObjectName.Text);
                            comm.Parameters.AddWithValue("@PersonPatronymic", tbObjectSecondName.Text);
                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@PersonSurname", "Неустановленное");
                            comm.Parameters.AddWithValue("@PersonName", "лицо");
                            comm.Parameters.AddWithValue("@PersonPatronymic", DBNull.Value);
                        }
                        var ret = new SqlParameter();
                        ret.ParameterName = "@ObjID";
                        ret.DbType = DbType.Int32;
                        ret.Direction = ParameterDirection.Output;
                        comm.Parameters.Add(ret);
                        var result = comm.ExecuteNonQuery();

                        return Convert.ToInt32(comm.Parameters["@ObjID"].Value);
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        private void InsertJob(int PersID, int ObjID)
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "up_JobPut";
                        comm.CommandType = CommandType.StoredProcedure;
                        //comm.Parameters.AddWithValue("@JobID", DBNull.Value);
                        //comm.Parameters.AddWithValue("@JobBlankID", DBNull.Value);
                        comm.Parameters.AddWithValue("@JobBlankNo", "УСЛ - " + DateTime.Now.ToString("ddMMyyyy"));
                        comm.Parameters.AddWithValue("@ObjID", ObjID);
                        comm.Parameters.AddWithValue("@ObjDescription", tbEventIdentifierPoint.Text);
                        comm.Parameters.AddWithValue("@PersID", PersID);
                        comm.Parameters.AddWithValue("@JobDuration", "2");
                        comm.Parameters.AddWithValue("@JobRegion", ""); // Нужен регион
                        comm.Parameters.AddWithValue("@JouID", Convert.ToInt32(cbEventType.GetColumnValue("JouID"))); // Нужен журнал
                        comm.Parameters.AddWithValue("@ActTypeID", DBNull.Value); // Нужен ActID
                        comm.Parameters.AddWithValue("@JobAim", DBNull.Value); // Нужен JobAim
                        comm.Parameters.AddWithValue("@JobOrientation", DBNull.Value); // Нужен JobOrientation
                        comm.Parameters.AddWithValue("@JobMemorandum", DBNull.Value); // Нужен JobMemorandum
                        comm.Parameters.AddWithValue("@JobType", cbEventType.Text);
                        comm.Parameters.AddWithValue("@JobCode", cbEventCode.Text);
                        comm.Parameters.AddWithValue("@JobNo", Convert.ToInt32(tbJobNo.Text));
                        comm.Parameters.AddWithValue("@JobCommissionNo", Convert.ToInt32(tbJobCommNo.Text)); // Не может вставиться NULL
                        comm.Parameters.AddWithValue("@JobCommissionDescription", ""); // Не может вставиться NULL
                        comm.Parameters.AddWithValue("@JobResponseInNo", ""); // Не может вставиться NULL
                        comm.Parameters.AddWithValue("@JobResponseOutNo", 0); // Не может вставиться NULL
                        comm.Parameters.AddWithValue("@JobResponseDescription", ""); // Не может вставиться NULL
                        comm.Parameters.AddWithValue("@JobYear", Convert.ToInt32(cbJobYear.Text));
                        comm.Parameters.AddWithValue("@JobStateID", 1);
                        comm.Parameters.AddWithValue("@ExecID", Convert.ToInt32(cbTaskExecutor.GetColumnValue("ExecID"))); // Нужен ID
                        comm.Parameters.AddWithValue("@GrpID", Convert.ToInt32(cbTaskGroupControl.GetColumnValue("GrpID"))); // Нужен ID
                        comm.Parameters.AddWithValue("@JobGetDT", DateTime.Now);

                        var ret = new SqlParameter();
                        ret.ParameterName = "@JobID";
                        ret.DbType = DbType.Int32;
                        ret.Direction = ParameterDirection.Output;
                        comm.Parameters.Add(ret);

                        var ret2 = new SqlParameter();
                        ret2.ParameterName = "@JobBlankID";
                        ret2.DbType = DbType.Int32;
                        ret2.Direction = ParameterDirection.Output;
                        comm.Parameters.Add(ret2);
                        var result = comm.ExecuteNonQuery();

                        var JobID = Convert.ToInt32(comm.Parameters["@JobID"].Value);
                        var JobBlankID = Convert.ToInt32(comm.Parameters["@JobBlankID"].Value);

                        string Object = "";
                        if (!chbNonPerson.Checked)
                            Object = string.Format("{0} {1} {2}", tbObjectSurname.Text, tbObjectName.Text, tbObjectSecondName.Text);
                        else
                            Object = "Неустановленное лицо";

                        if (InsertNewNominalEntry(tbJobNo.Text, tbEventIdentifierPoint.Text, Object, JobID, JobBlankID))
                        {
                            var dialog = XtraMessageBox.Show("Задание успешно добавлено! Добавить еще одно?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == System.Windows.Forms.DialogResult.Yes)
                            {
                                ClearFields();
                            }
                            else
                            {
                                this.Close();
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private bool InsertNewNominalEntry(string JobNo, string Point, string Object, int JobID, int JobBlankID)
        {
            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionPTS))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "INSERT INTO Nominal (JobNo, Point, Object, JobID, JobBlankID, Status) VALUES (@JobNo, @Point, @Object, @JobID, @JobBlankID, 0)";
                        comm.Parameters.AddWithValue("@JobNo", JobNo);
                        comm.Parameters.AddWithValue("@Point", Point);
                        comm.Parameters.AddWithValue("@Object", Object);
                        comm.Parameters.AddWithValue("@JobID", JobID);
                        comm.Parameters.AddWithValue("@JobBlankID", JobBlankID);
                        comm.ExecuteReader();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        #endregion

        private void cbEventIdentifierType_EditValueChanged(object sender, EventArgs e)
        {
            if (cbEventIdentifierType.EditValue != null)
            {
                tbEventIdentifierPoint.Text = string.Empty;
                tbEventIdentifierPoint.Enabled = true;
                tbEventIdentifierPoint.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                if (cbEventIdentifierType.GetColumnValue("TableName").ToString() == "Phone")
                    tbEventIdentifierPoint.Properties.Mask.EditMask = @"8(\d?\d?\d?)\d\d\d\d\d\d\d";
                else if (cbEventIdentifierType.GetColumnValue("TableName").ToString() == "IMEI")
                    tbEventIdentifierPoint.Properties.Mask.EditMask = @"[0-9]+";
                else if (cbEventIdentifierType.GetColumnValue("TableName").ToString() == "IMSI")
                    tbEventIdentifierPoint.Properties.Mask.EditMask = @"[0-9]+";
                else if (cbEventIdentifierType.GetColumnValue("TableName").ToString() == "EMAIL")
                    tbEventIdentifierPoint.Properties.Mask.EditMask = @"(\w|[\.\-])+@(\w|[\-]+\.)*(\w|[\-]){2,63}\.[a-zA-Z]{2,4}";
                else
                    tbEventIdentifierPoint.Properties.Mask.EditMask = @".+";
            }
        }

        private void chbNonPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNonPerson.Checked)
            {
                tbObjectSurname.Enabled = false;
                tbObjectName.Enabled = false;
                tbObjectSecondName.Enabled = false;

                tbObjectSurname.Text = string.Empty;
                tbObjectName.Text = string.Empty;
                tbObjectSecondName.Text = string.Empty;
            }
            else
            {
                tbObjectSurname.Enabled = true;
                tbObjectName.Enabled = true;
                tbObjectSecondName.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateForValidate();
            if (ValidateFields(controls))
            {
                if (cbEventIdentifierType.GetColumnValue("TableName").ToString() == "Phone")
                    InsertJob(InsertNewPerson(), InsertNewPhone());
                else if (cbEventIdentifierType.GetColumnValue("TableName").ToString() == "IMEI")
                    InsertJob(InsertNewPerson(), InsertNewIMEI());
                else if (cbEventIdentifierType.GetColumnValue("TableName").ToString() == "IMSI")
                    InsertJob(InsertNewPerson(), InsertNewIMSI());
                else if (cbEventIdentifierType.GetColumnValue("TableName").ToString() == "EMAIL")
                    InsertJob(InsertNewPerson(), InsertNewEMAIL());
            }
            else
            {
                XtraMessageBox.Show("Заполните все необходимые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            tbEventIdentifierPoint.Text = string.Empty;
            tbEventIdentifierPoint.Enabled = false;
            cbEventIdentifierType.EditValue = null;
            chbNonPerson.Checked = false;
            tbObjectSurname.Text = string.Empty;
            tbObjectName.Text = string.Empty;
            tbObjectSecondName.Text = string.Empty;
            cbEventType.EditValue = null;
            cbEventCode.Text = string.Empty;
            tbJobNo.Text = string.Empty;
            tbJobCommNo.Text = string.Empty;
            cbJobYear.Text = string.Empty;
            cbTaskExecutor.EditValue = null;
            cbTaskGroupControl.EditValue = null;
        }
    }
}
