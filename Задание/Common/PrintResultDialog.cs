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
    public partial class PrintResultDialog : DevExpress.XtraEditors.XtraForm
    {
        public static PrintResultDialog printResultDialog;

        public PrintResultDialog()
        {
            InitializeComponent();
            printResultDialog = this;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            BackToTask(true);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            BackToTask(false);
        }

        private void btnCreateNext_Click(object sender, EventArgs e)
        {
            BackToTask(true);
        }

        private void BackToTask(bool FirstPage)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 2)
            {
                Preview.preview.ClosePreview(false, false);
            }
            if (FirstPage)
            {
                Task.task.navigationTask.SelectedPageIndex = 0;
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
                NavigationBar.navigationBar.NavigationMain.Groups["TaskGroup"].Expanded = true;
                NavigationBar.navigationBar.NavigationMain.Groups["TaskGroup"].SelectedLinkIndex = 0;
                NavigationBar.navigationBar.NavigationMain.Groups["TaskGroup"].ItemLinks[0].PerformClick();
            }
            else
            {
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
            }
        }
    }
}
