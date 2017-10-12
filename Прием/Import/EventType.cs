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

namespace Прием
{
    public partial class EventType : DevExpress.XtraEditors.XtraUserControl
    {
        public EventType()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(MainForm.mainForm.ConnectionASSA))
            {
                conn.Open();
                using (var comm = conn.CreateCommand())
                {
                    comm.CommandText = "SELECT JobType FROM JobType";
                    using (var dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            chList.Items.Add(dr["JobType"].ToString());
                        }
                    }
                }
            }

            btnDownload.Enabled = false;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            navigation.SelectedPageIndex = 1;
        }

        private void chList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chList.Items.GetCheckedValues().Count > 0)
                btnDone.Enabled = true;
            else
                btnDone.Enabled = false;
        }
    }
}
