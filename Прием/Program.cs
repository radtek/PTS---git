using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using ReadSettingsINI;
using System.IO;

namespace Прием
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var errorCollector = new ErrorCollector();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

            try
            {
                if (File.Exists("config.ini"))
                {
                    ReadINI();
                    var thread = new Thread(new ThreadStart(SplashWIndowShow)); // Запускаем в новом потоке загрузку всех форм и дата-менеджеров
                    thread.Start();
                    Thread.Sleep(3000);
                    var mainForm = new MainForm(thread); // Вызываем новую основную форму и передаем в нее текущий поток
                    ScanControl.scanControl.BeginScan();
                    NominalTasks.nominalTasks.FetchData();
                    MainSettings.mainSettings.LoadSettings();
                    mainForm.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Отствутствует файл конфигурации, приложение будет закрыто!", "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (ThreadStartException ex)
            {
                errorCollector.ApplicationEvent(0, ex.Message, "");
            }
            catch (ThreadInterruptedException ex)
            {
                errorCollector.ApplicationEvent(0, ex.Message, "");
            }
            catch (ThreadStateException ex)
            {
                errorCollector.ApplicationEvent(0, ex.Message, "");
            }
            catch (ThreadAbortException ex)
            {
                errorCollector.ApplicationEvent(0, ex.Message, "");
            }
        }

        static void ReadINI()
        {
            INIFile iniFile = new INIFile("config.ini");
            ProgramSettings.settings.Add(new Settings 
            { 
                AssaServer = iniFile.GetValue("ASSACONNECT", "DataSource", (string)null),
                AssaDataBase = iniFile.GetValue("ASSACONNECT", "InitialCatalog", (string)null),
                AssaLogin = iniFile.GetValue("ASSACONNECT", "UserID", (string)null),
                AssaPassword = iniFile.GetValue("ASSACONNECT", "Password", (string)null),
                PtsServer = iniFile.GetValue("PTSCONNECT", "DataSource", (string)null),
                PtsDataBase = iniFile.GetValue("PTSCONNECT", "InitialCatalog", (string)null),
                PtsLogin = iniFile.GetValue("PTSCONNECT", "UserID", (string)null),
                PtsPassword = iniFile.GetValue("PTSCONNECT", "Password", (string)null)
            });
        }

        static void SplashWIndowShow()
        {
            Application.Run(new SplashWindow());
        }
    }
}
