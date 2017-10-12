using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using DevExpress.XtraEditors;
using fastJSON;

namespace Задание
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        #region "Declaration"
        public static LoginForm loginForm;

        Form MainForm;
        ErrorCollector errorCollector = new ErrorCollector();
        Crypt crypt = new Crypt();
        string ConnString = "Data Source=Data\\UserData.db;Version=3;";
        #endregion

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login(tbLogin.Text, tbPassword.Text))
            {
                this.Hide();
                MainForm.ShowDialog();
            }
        }

        private void btnRegistartion_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }

        #region "Login Method"
        private bool Login(string UserLogin, string UserPassword)
        {
            int UserID = -1;

            try
            {
                using (var conn = new SQLiteConnection(ConnString))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM Users WHERE Login = @Login AND Password = @Password";
                        comm.Parameters.AddWithValue("@Login", UserLogin);
                        comm.Parameters.AddWithValue("@Password", crypt.Encrypt(UserPassword));
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    UserID = Convert.ToInt32(dr["ID"]);

                                    UserSettings.UserList.Add(new UserSettings.User
                                    {
                                        UserID = Convert.ToInt32(dr["ID"]),
                                        IsAdmin = Convert.ToBoolean(dr["Flag"]),
                                        LoadSettings = Convert.ToBoolean(dr["LoadSettings"]),
                                        IsAnimation = Convert.ToBoolean(dr["LoadAnimation"]),
                                        IsDisconnect = Convert.ToBoolean(dr["AllowDisconnect"]),
                                        DisconnectTimeout = Convert.ToInt32(dr["DisconnectTimeout"]),
                                        Theme = dr["Theme"].ToString()
                                    });

                                    if (UserID != -1)
                                    {
                                        using (var conn2 = new SQLiteConnection(ConnString))
                                        {
                                            conn2.Open();
                                            using (var comm2 = conn2.CreateCommand())
                                            {
                                                comm2.CommandText = "SELECT UserData FROM UserData WHERE UserID = @UserID";
                                                comm2.Parameters.AddWithValue("@UserID", UserID);
                                                using (var dr2 = comm2.ExecuteReader())
                                                {
                                                    while (dr2.Read())
                                                    {
                                                        string json = dr2["UserData"].ToString();
                                                        UserSettings.SettingsList = JSON.Instance.ToObject<List<UserSettings.Settings>>(json.Trim(new char[] { '\uFEFF', '\u200B' }));
                                                    }
                                                    conn2.Close();

                                                    if (Convert.ToBoolean(dr["Flag"]))
                                                    {
                                                        NavigationBar.navigationBar.EnableAdministrator();
                                                    }

                                                    if (Convert.ToBoolean(dr["LoadSettings"]))
                                                    {
                                                        Task.task.LoadUserSettings(); // Загружаем данные пользователя, если такая настройка включена пользователем
                                                        Reference.reference.LoadUserSettings(); // Загружаем данные пользователя, если такая настройка включена пользователем
                                                    }

                                                    if (Convert.ToBoolean(dr["LoadAnimation"]))
                                                    {
                                                        // TODO: Отключаем анимацию окон
                                                        Task.task.navigationTask.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;
                                                        SettingsManager.settingsManager.navigation.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;
                                                    }

                                                    if (Convert.ToBoolean(dr["AllowDisconnect"]))
                                                    {
                                                        // TODO: Включаем дисконнект по времени
                                                    }

                                                    // Загружаем персональные настройки пользователя и его руководителя в меню настроек
                                                    PersonalSettings.personalSettings.LoadHeadSettings();
                                                    PersonalSettings.personalSettings.LoadUserSettings();
                                                }
                                            }
                                        }
                                    }
                                }
                                conn.Close();
                                return true;
                            }
                            else
                            {
                                var dialog = XtraMessageBox.Show("Такой учетной записи не существует или введенные данные неверны, попробуйте еще раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (dialog == DialogResult.OK)
                                {
                                    conn.Close();
                                    tbLogin.Text = "";
                                    tbPassword.Text = "";
                                    tbLogin.Focus();
                                }
                                return false;
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(0, 1, ex.Message, "", false);
                return false;
            }
        }
        #endregion

        public LoginForm(XtraForm mainForm)
        {
            JSON.Parameters.UseUTCDateTime = false;
            JSON.Parameters.UseExtensions = false;
            JSON.Parameters.UseEscapedUnicode = false;
            JSON.Parameters.EnableAnonymousTypes = true;
            JSON.Parameters.IgnoreCaseOnDeserialize = true;
            JSON.Parameters.IgnoreUnderscopeOnDeserialize = true;

            InitializeComponent();
            MainForm = mainForm;
            loginForm = this;
        }
    }
}
