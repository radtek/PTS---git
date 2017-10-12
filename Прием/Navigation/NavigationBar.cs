using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Прием
{
    public partial class NavigationBar : DevExpress.XtraEditors.XtraUserControl
    {
        public NavigationBar()
        {
            InitializeComponent();
        }

        private void NavigationMain_NavPaneStateChanged(object sender, EventArgs e)
        {
            if (NavigationMain.OptionsNavPane.NavPaneState == DevExpress.XtraNavBar.NavPaneState.Expanded)
            {
                this.Width = 167;
                NavigationMain.Width = 167;
            }
            else
            {
                this.Width = 50;
                NavigationMain.Width = 50;
            }
        }

        private void btnScan_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
        }

        private void btnConditionalTask_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 2;
        }

        private void btnMainSettings_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 1;
        }
    }
}
