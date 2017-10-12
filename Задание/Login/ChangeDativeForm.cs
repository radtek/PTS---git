using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание
{
    public partial class ChangeDativeForm : DevExpress.XtraEditors.XtraForm
    {
        public static ChangeDativeForm changeDativeForm;

        public ChangeDativeForm(string _input)
        {
            InitializeComponent();
            changeDativeForm = this;
            tbDataEdit.Text = _input;
        }

        private void ChangeDativeForm_Load(object sender, EventArgs e)
        {
            tbDataEdit.Focus();
        }

        public string ReturnData()
        {
            return tbDataEdit.Text.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbDataEdit.Text != "")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("Поле не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbDataEdit.Focus();
            }          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
