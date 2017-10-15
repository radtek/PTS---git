using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Прием
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        #region "Decalaration"
        public static MainForm mainForm;
        ErrorCollector errorCollector = new ErrorCollector();
        public string ConnectionASSA = "";
        public string ConnectionPTS = "";
        #endregion

        public MainForm(Thread t, int IsDeveloper)
        {
            LoadSettings();
            if (IsDeveloper == 1)
            {
                ScanControl.scanControl.btnOpenQR.Visible = true;
                ScanControl.scanControl.simpleButton1.Visible = true;
                ScanControl.scanControl.simpleButton2.Visible = true;
            }
            InitializeComponent();
            mainForm = this;
            try
            {
                t.Abort(); // Закрываем поток из которого мы загружались, он больше не требуется
            }
            catch (ThreadAbortException ex)
            {
                errorCollector.ApplicationEvent(0, ex.Message, "");
            }
        }

        public void LoadSettings()
        {
            ConnectionASSA = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};MultipleActiveResultSets=True;", 
                ProgramSettings.settings[0].AssaServer, 
                ProgramSettings.settings[0].AssaDataBase, 
                ProgramSettings.settings[0].AssaLogin, 
                ProgramSettings.settings[0].AssaPassword);
            ConnectionPTS = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};MultipleActiveResultSets=True;", 
                ProgramSettings.settings[0].PtsServer, 
                ProgramSettings.settings[0].PtsDataBase, 
                ProgramSettings.settings[0].PtsLogin, 
                ProgramSettings.settings[0].PtsPassword);
        }
    }
}
