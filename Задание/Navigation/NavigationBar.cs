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
    public partial class NavigationBar : DevExpress.XtraEditors.XtraUserControl
    {
        public static NavigationBar navigationBar;

        public NavigationBar()
        {
            InitializeComponent();
            navigationBar = this;
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
        #region "Task Group"
        private void btnApprove_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 0)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
            }
            Task.task.navigationTask.SelectedPageIndex = 0;
        }

        private void btnEvent_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 0)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
            }
            Task.task.navigationTask.SelectedPageIndex = 1;
        }

        private void btnObject_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 0)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
            }
            Task.task.navigationTask.SelectedPageIndex = 2;
        }

        private void btnDocument_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 0)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
            }
            Task.task.navigationTask.SelectedPageIndex = 3;
        }
        #endregion
        #region "Settings Group"
        private void btnKeySettings_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 3)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 3;
            }
            SettingsManager.settingsManager.navigation.SelectedPageIndex = 0;
        }

        private void btnPersonalSettings_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 3)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 3;
            }
            SettingsManager.settingsManager.navigation.SelectedPageIndex = 1;
        }

        private void btnPrintBlank_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 3)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 3;
            }
            SettingsManager.settingsManager.navigation.SelectedPageIndex = 2;
        }

        private void btnMarkersSettings_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 3)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 3;
            }
            SettingsManager.settingsManager.navigation.SelectedPageIndex = 3;
        }

        private void btnDivisionsSettings_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void btnTaskApprove_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 3)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 3;
            }
            SettingsManager.settingsManager.navigation.SelectedPageIndex = 5;
        }

        private void btnTaskAccept_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 3)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 3;
            }
            SettingsManager.settingsManager.navigation.SelectedPageIndex = 6;
        }

        private void btnEventSettings_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 3)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 3;
            }
            SettingsManager.settingsManager.navigation.SelectedPageIndex = 7;
        }

        private void btnBaseEventSettings_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 3)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 3;
            }
            SettingsManager.settingsManager.navigation.SelectedPageIndex = 8;
        }

        private void btnColorSettings_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void btnLog_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }
        #endregion        

        public void EnableAdministrator()
        {
            NavigationMain.Groups["Settings"].NavBar.Items["btnMarkersSettings"].Visible = true;
            NavigationMain.Groups["Settings"].NavBar.Items["btnDivisionsSettings"].Visible = true;
            NavigationMain.Groups["Settings"].NavBar.Items["btnTaskApprove"].Visible = true;
            NavigationMain.Groups["Settings"].NavBar.Items["btnTaskAccept"].Visible = true;
            NavigationMain.Groups["Settings"].NavBar.Items["btnEventSettings"].Visible = true;
            NavigationMain.Groups["Settings"].NavBar.Items["btnBaseEventSettings"].Visible = true;
            NavigationMain.Groups["Settings"].NavBar.Items["btnColorSettings"].Visible = true;
            NavigationMain.Groups["Settings"].NavBar.Items["btnLog"].Visible = true;
        }

        private void btnReference_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex != 1)
            {
                var refMode = new ReferenceMode();
                if (refMode.ShowDialog() == DialogResult.Yes)
                {
                    ControlPanel.controlPanel.navigation.SelectedPageIndex = 1;
                    NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 1;
                    MainForm.mainForm.navigationBar.Enabled = false;
                    Reference.reference.OpenFirstGroup();
                }
            }
        }

        private void NavigationMain_GroupExpanded(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            if (NavigationMain.Groups["TaskGroup"].Expanded)
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
            }
            else if (NavigationMain.Groups["ReferenceGroup"].Expanded)
            {
                ControlPanel.controlPanel.navigation.SelectedPageIndex = 1;
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 1;
                MainForm.mainForm.navigationBar.Enabled = false;
                Reference.reference.OpenFirstGroup();

                var refMode = new ReferenceMode();
                refMode.ShowDialog();
            }
            else if (NavigationMain.Groups["ReportGroup"].Expanded)
            {
                ControlPanel.controlPanel.navigation.SelectedPageIndex = 2;
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 4;
                MainForm.mainForm.navigationBar.Enabled = false;

                ReportDialog reportDialog = new ReportDialog();
                reportDialog.ShowDialog();
            }
            else if (NavigationMain.Groups["Settings"].Expanded)
            {
                MainForm.mainForm.controlPanel.Enabled = false;
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 3;
            }
        }
    }
}
