using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание
{
    public partial class HeadApproveSettings : DevExpress.XtraEditors.XtraUserControl
    {
        public static HeadApproveSettings headApproveSettings;

        public HeadApproveSettings()
        {
            InitializeComponent();
            headApproveSettings = this;
        }
    }
}
