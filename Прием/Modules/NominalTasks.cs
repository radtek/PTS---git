using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace Прием
{
    public partial class NominalTasks : DevExpress.XtraEditors.XtraUserControl
    {
        public static NominalTasks nominalTasks;

        public NominalTasks()
        {
            InitializeComponent();
            nominalTasks = this;
        }

        public void FetchData()
        {
            gridControl.DataSource = null;

            try
            {
                using (var conn = new SqlConnection(MainForm.mainForm.ConnectionPTS))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM Nominal WHERE Status = 0";
                        using (var da = new SqlDataAdapter(comm))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            da.Dispose();
                            gridControl.DataSource = dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            NewNominalTask newNominalTask = new NewNominalTask();
            if (newNominalTask.ShowDialog() == DialogResult.OK)
            {
                FetchData();
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (gridView.RowCount > 0)
            {
                ScanControl.scanControl.timer.Enabled = false;
                ScanNominalTask scanNominalTask = new ScanNominalTask(gridView.GetFocusedRowCellDisplayText("JobNo"), gridView.GetFocusedRowCellDisplayText("Object"));
                scanNominalTask.ShowDialog();
            }
        }
    }
}
