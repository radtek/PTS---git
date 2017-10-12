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

namespace Задание
{
    public partial class ReferenceMenu : DevExpress.XtraEditors.XtraForm
    {
        public static ReferenceMenu refMenu;

        public ReferenceMenu()
        {
            InitializeComponent();
            refMenu = this;
        }

        private void ReferenceMenu_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT ID, Caption AS RefCaption, CreateDT FROM Reference WHERE UserID = @UserID";
                var conn = new SQLiteConnection(MainForm.mainForm.connectionReferenceData);
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", MainForm.mainForm.UserID);
                conn.Open();
                var da = new SQLiteDataAdapter(cmd);
                var dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                gridControl1.DataSource = dataTable;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                XtraMessageBox.Show("Выберите справку об объекте!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        public int GetID
        {
            get
            {
                return Convert.ToInt32(gridView1.GetFocusedRowCellDisplayText("ID"));
            }
            set
            {
                value = Convert.ToInt32(gridView1.GetFocusedRowCellDisplayText("ID"));
            }
        }

        public string GetCaption
        {
            get
            {
                return gridView1.GetFocusedRowCellDisplayText("RefCaption");
            }
            set
            {
                value = gridView1.GetFocusedRowCellDisplayText("RefCaption");
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                XtraMessageBox.Show("Выберите справку об объекте!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
