using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Задание
{
    public partial class NavigationPanel : DevExpress.XtraEditors.XtraUserControl
    {
        public static NavigationPanel navigationPanel;

        public NavigationPanel()
        {
            InitializeComponent();
            navigationPanel = this;

            navigation.SelectedPageChanged += navigation_SelectedPageChanged;
            navigation.SelectedPageChanging += navigation_SelectedPageChanging;
        }

        void navigation_SelectedPageChanging(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangingEventArgs e)
        {
            if (navigation.SelectedPageIndex == 3 && SettingsManager.settingsManager.navigation.SelectedPageIndex == 3)
                XtraMessageBox.Show("Настройки маркеров будут применены только после перезапуска программы!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void navigation_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (navigation.SelectedPageIndex != 3)
                MainForm.mainForm.controlPanel.Enabled = true;
        }
    }
}
