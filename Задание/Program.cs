using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание
{
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LicenseHelper.ModifyInMemory.ActivateMemoryPatching();
            var errorCollector = new ErrorCollector();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

            try
            {
                var thread = new Thread(new ThreadStart(SplashWIndowShow)); // Запускаем в новом потоке загрузку всех форм и дата-менеджеров
                thread.Start();
                Thread.Sleep(1000);
                var taskMode = new TaskModeForm();
                var mainForm = new MainForm(thread, taskMode); // Вызываем новую основную форму и передаем в нее текущий поток                
                var loginForm = new LoginForm(mainForm); // Вызываем новую логин форму
                mainForm.CheckTempFolder();
                PersonalSettings.personalSettings.LoadData();
                BaseEventSettings.baseEventSettings.LoadData();
                ControlPanel.controlPanel.GetCurrentTaskNumber(); // Получаем 
                ControlPanel.controlPanel.CheckUnprintedTaskNo();
                ControlPanel.controlPanel.CheckKey();
                KeyControl.keyControl.GetCurrentKey();
                KeyControl.keyControl.LoadKeyHistory();
                Task.task.LoadData();
                Reference.reference.LoadApproveList();
                MarkersControl.markersControl.LoadMarkers();
                BlankControl.blankControl.FetchData();
                loginForm.ShowDialog();
            }
            catch (ThreadStartException ex)
            {
                errorCollector.ApplicationEvent(0, 1, ex.Message, "", true);
            }
            catch (ThreadInterruptedException ex)
            {
                errorCollector.ApplicationEvent(0, 1, ex.Message, "", true);
            }
            catch (ThreadStateException ex)
            {
                errorCollector.ApplicationEvent(0, 1, ex.Message, "", true);
            }
            catch (ThreadAbortException ex)
            {
                errorCollector.ApplicationEvent(0, 1, ex.Message, "", true);
            }
        }

        static void SplashWIndowShow()
        {
            Application.Run(new SplashWindow());
        }
    }
}
