using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace Прием
{
    public partial class MainSettings : DevExpress.XtraEditors.XtraUserControl
    {
        public static MainSettings mainSettings;

        public MainSettings()
        {
            InitializeComponent();
            mainSettings = this;
        }

        public void LoadSettings()
        {
            tbAssaServer.Text = ProgramSettings.settings[0].AssaServer;
            tbAssaDataBase.Text = ProgramSettings.settings[0].AssaDataBase;
            tbAssaLogin.Text = ProgramSettings.settings[0].AssaLogin;
            tbAssaPassword.Text = ProgramSettings.settings[0].AssaPassword;
            tbPtsServer.Text = ProgramSettings.settings[0].PtsServer;
            tbPtsDataBase.Text = ProgramSettings.settings[0].PtsDataBase;
            tbPtsLogin.Text = ProgramSettings.settings[0].PtsLogin;
            tbPtsPassword.Text = ProgramSettings.settings[0].PtsPassword;
        }

        private void btnAssaCheckConnection_Click(object sender, EventArgs e)
        {
            if (tbAssaDataBase.Text != string.Empty && tbAssaServer.Text != string.Empty && tbAssaLogin.Text != string.Empty && tbAssaPassword.Text != string.Empty)
            {
                string connString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};MultipleActiveResultSets=True;", tbAssaServer.Text, tbAssaDataBase.Text, tbAssaLogin.Text, tbAssaPassword.Text);
                if (IsServerConnected(connString))
                    XtraMessageBox.Show("Соединение установлено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("Проверьте правильность настроек! Соединение не установлено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XtraMessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssaSaveConnection_Click(object sender, EventArgs e)
        {

        }

        private void btnPtsCheckConnection_Click(object sender, EventArgs e)
        {
            if (tbPtsServer.Text != string.Empty && tbPtsDataBase.Text != string.Empty && tbPtsLogin.Text != string.Empty && tbPtsPassword.Text != string.Empty)
            {
                string connString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};MultipleActiveResultSets=True;", tbPtsServer.Text, tbPtsDataBase.Text, tbPtsLogin.Text, tbPtsPassword.Text);
                if (IsServerConnected(connString))
                    XtraMessageBox.Show("Соединение установлено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("Проверьте правильность настроек! Соединение не установлено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XtraMessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPtsSaveConnection_Click(object sender, EventArgs e)
        {

        }

        private static bool IsServerConnected(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

    }
}
