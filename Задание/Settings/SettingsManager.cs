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
    public partial class SettingsManager : DevExpress.XtraEditors.XtraUserControl
    {
        public static SettingsManager settingsManager;

        public SettingsManager()
        {
            InitializeComponent();
            settingsManager = this;

            navigation.SelectedPageChanging += navigation_SelectedPageChanging;
        }

        void navigation_SelectedPageChanging(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangingEventArgs e)
        {
            if (SettingsManager.settingsManager.navigation.SelectedPageIndex == 3)
                XtraMessageBox.Show("Настройки маркеров будут применены только после перезапуска программы!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
