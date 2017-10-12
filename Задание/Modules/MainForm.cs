using DevExpress.XtraEditors;
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

namespace Задание
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        #region "Declaration"
        public static MainForm mainForm;

        public int UserID;
        public bool IsAdmin; // Администраторские права у пользователя
        public bool LoadSettings; // Загружать пользовательские данные на форму
        public bool IsAnimation; // Включена или нет анимация окон
        public bool IsDisconnect; // Включен или нет дисконнект по времени
        public int DisconnectTimeout; // Время дисконнекта в секундах
        public string Theme = ""; // Стиль окон пользователя
        public bool AutoDisconnect = false;

        public string connectionKeyData = "Data Source=Data\\KeyData.db;Version=3;";
        public string connectionUserData = "Data Source=Data\\UserData.db;Version=3;";
        public string connectionDictionaryData = "Data Source=Data\\Dictionary.db;Version=3;";
        public string connectionTemplateData = "Data Source=Data\\Template.db;Version=3;";
        public string connectionReferenceData = "Data Source=Data\\ReferenceData.db;Version=3;";

        ErrorCollector errorCollector = new ErrorCollector();
        UserSettings userSettings = new UserSettings();

        XtraForm taskModeForm;
        #endregion

        private void SplashScreen()
        {
            Application.Run(new Loading());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UserID = userSettings.UserID;
            IsAdmin = userSettings.IsAdmin;
            LoadSettings = userSettings.LoadSettings;
            IsAnimation = userSettings.IsAnimation;
            IsDisconnect = userSettings.IsDisconnect;
            DisconnectTimeout = userSettings.DisconnectTimeout;
            Theme = userSettings.Theme;

            if (Theme == "Office 2016 Black")
                PersonalSettings.personalSettings.cbStyle.SelectedIndex = 0;
            else if (Theme == "Office 2016 Dark")
                PersonalSettings.personalSettings.cbStyle.SelectedIndex = 1;
            else if (Theme == "Office 2016 Colorful")
                PersonalSettings.personalSettings.cbStyle.SelectedIndex = 2;
            else if (Theme == "Seven Classic")
                PersonalSettings.personalSettings.cbStyle.SelectedIndex = 3;

            if (LoadSettings)
                PersonalSettings.personalSettings.chbDataLoad.Checked = false;
            else
                PersonalSettings.personalSettings.chbDataLoad.Checked = true;

            if (IsAnimation)
                PersonalSettings.personalSettings.chbWindowAnimation.Checked = false;
            else
                PersonalSettings.personalSettings.chbWindowAnimation.Checked = true;

            if (IsDisconnect)
            {
                PersonalSettings.personalSettings.chbAutoLogout.Checked = true;
                PersonalSettings.personalSettings.tbTimer.Text = DisconnectTimeout.ToString();
            }
            else
            {
                PersonalSettings.personalSettings.chbAutoLogout.Checked = false;
                PersonalSettings.personalSettings.tbTimer.Text = string.Empty;
            }

            errorCollector.ApplicationEvent(0, 1, "Запуск приложения", "", false);

            if (controlPanel.Enabled)
            {
                taskModeForm.ShowDialog();
            }
        }

        public MainForm(Thread t, XtraForm modeForm)
        {
            InitializeComponent();
            mainForm = this;
            taskModeForm = modeForm;
            try
            {
                t.Abort(); // Закрываем поток из которого мы загружались, он больше не требуется
            }
            catch (ThreadAbortException ex)
            {
                errorCollector.ApplicationEvent(0, 1, ex.Message, "", true);
            }
        }

        public void DisableForm()
        {
            controlPanel.Enabled = false;
            navigationBar.Enabled = false;
            NavigationBar.navigationBar.NavigationMain.Groups[3].Expanded = true;
            NavigationBar.navigationBar.NavigationMain.Groups[3].SelectedLinkIndex = 0;
            NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 3;
            SettingsManager.settingsManager.navigation.SelectedPageIndex = 0;
        }

        public void EnableForm()
        {
            controlPanel.Enabled = true;
            navigationBar.Enabled = true;
            NavigationBar.navigationBar.NavigationMain.Groups[0].Expanded = true;
            NavigationBar.navigationBar.NavigationMain.Groups[0].SelectedLinkIndex = 0;
            NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
            //TODO: Открыть 1 страницу заполнения задания
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AutoDisconnect)
            {
                var dialog = XtraMessageBox.Show("Вы действительно хотите закрыть программу?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }
    }
}
