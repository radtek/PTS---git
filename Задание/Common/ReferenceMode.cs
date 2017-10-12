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
    public partial class ReferenceMode : DevExpress.XtraEditors.XtraForm
    {
        public ReferenceMode()
        {
            InitializeComponent();
        }

        private void ReferenceMode_Load(object sender, EventArgs e)
        {
            this.Focus();
            lbMode.SelectedIndex = 0;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (lbMode.SelectedIndex != -1)
            {
                if (lbMode.SelectedIndex == 1)
                {
                    Reference.reference.Flag = true;
                    Reference.reference.gc9.Enabled = true;
                    Reference.reference.tb9.Enabled = true;
                }
                else
                {
                    Reference.reference.Flag = false;
                    Reference.reference.gc9.Enabled = false;
                    Reference.reference.tb9.Enabled = false;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void lbMode_DoubleClick(object sender, EventArgs e)
        {
            if (lbMode.SelectedIndex != -1)
            {
                if (lbMode.SelectedIndex == 1)
                {
                    Reference.reference.Flag = true;
                    Reference.reference.gc9.Enabled = true;
                    Reference.reference.tb9.Enabled = true;
                }
                else
                {
                    Reference.reference.Flag = false;
                    Reference.reference.gc9.Enabled = false;
                    Reference.reference.tb9.Enabled = false;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
        }
    }
}
