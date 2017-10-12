using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Прием
{
    public partial class SetupFields : DevExpress.XtraEditors.XtraForm
    {
        public SetupFields()
        {
            InitializeComponent();
        }

        private void SetupFields_Load(object sender, EventArgs e)
        {
            ScanFields.scanFields.FetchData();
            ScanFields.scanFields.FetchMarkersList();
        }
    }
}
