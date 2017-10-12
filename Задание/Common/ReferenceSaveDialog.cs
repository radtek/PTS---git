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
    public partial class ReferenceSaveDialog : DevExpress.XtraEditors.XtraForm
    {
        public static ReferenceSaveDialog refSaveDialog;

        public ReferenceSaveDialog(string Text)
        {
            InitializeComponent();
            refSaveDialog = this;

            if (Text != string.Empty)
                tbCaption.Text = Text;
        }

        public string Caption
        {
            get
            {
                return tbCaption.Text;
            }
            set
            {
                value = tbCaption.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbCaption.Text != string.Empty)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                XtraMessageBox.Show("Введите название!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}
