using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using DevExpress.XtraEditors;

namespace Задание
{
    public partial class KeyControl : DevExpress.XtraEditors.XtraUserControl
    {
        public static KeyControl keyControl;
        Crypt crypt = new Crypt();

        private void btnAddNewKey_Click(object sender, EventArgs e)
        {
            if (ActivateNewKey(tbNewKey.Text.Trim()))
            {
                GetCurrentKey();
                MainForm.mainForm.EnableForm();
                ControlPanel.controlPanel.GetCurrentTaskNumber();
                ErrorCollector collector = new ErrorCollector();
                string s = string.Format("Активация нового ключа с диапазоном: {0}-{1}", tbStartKeyNo.Text, tbFinishKeyNo.Text);
                collector.ApplicationEvent(MainForm.mainForm.UserID, 0, s, "", true);
            }
        }

        private void btnClearKey_Click(object sender, EventArgs e)
        {
            tbNewKey.Text = string.Empty;
        }

        public KeyControl()
        {
            InitializeComponent();
            keyControl = this;
        }

        #region "Get Current Key"
        public void GetCurrentKey()
        {
            try
            {
                var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData);
                conn.Open();
                var comm = conn.CreateCommand();
                comm.CommandText = "SELECT * FROM KeyData WHERE Active = 1";
                var dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tbCurrentKey.Text = dr["Key"].ToString();
                        var s1 = string.Concat(Enumerable.Repeat("0", 5 - dr["StartNo"].ToString().Length));
                        var s2 = string.Concat(Enumerable.Repeat("0", 5 - dr["FinishNo"].ToString().Length));
                        var s3 = string.Concat(Enumerable.Repeat("0", 5 - dr["CurrentNo"].ToString().Length));
                        tbStartKeyNo.Text = dr["Letter"].ToString() + "-" + s1 + dr["StartNo"].ToString();
                        tbFinishKeyNo.Text = dr["Letter"].ToString() + "-" + s2 + dr["FinishNo"].ToString();
                        tbCurrentKeyNo.Text = dr["Letter"].ToString() + "-" + s3 + dr["CurrentNo"].ToString();
                    }
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    MainForm.mainForm.DisableForm();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show("Ошибка при работе с базой данных! Обратитесь к администратору!\r\n" + ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region "Activate New Key"
        private bool ActivateNewKey(string _key)
        {
            if (_key != "")
            {
                var result = crypt.Decrypt(_key);
                if (result == "Error")
                {
                    XtraMessageBox.Show("Введите корректный ключ!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbNewKey.Text = "";
                    tbNewKey.Focus();
                    return false;
                }
                else
                {
                    using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                    {
                        conn.Open();
                        using (var comm = new SQLiteCommand("SELECT * FROM KeyData WHERE Key = @Key", conn))
                        {
                            comm.Parameters.AddWithValue("@Key", _key);
                            using (var dr = comm.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    XtraMessageBox.Show("Данный ключ уже был использован ранее!\r\nОбратитесь к администратору за новым ключем!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbNewKey.Text = "";
                                    tbNewKey.Focus();
                                    return false;
                                }
                                else
                                {
                                    try
                                    {
                                        var c = new SQLiteConnection(MainForm.mainForm.connectionKeyData);
                                        c.Open();
                                        var cd = c.CreateCommand();
                                        cd.CommandText = "UPDATE KeyData SET Active = 0";
                                        cd.ExecuteNonQuery();
                                        c.Close();
                                    }
                                    catch (SQLiteException ex)
                                    {
                                        XtraMessageBox.Show("Ошибка при работе с базой данных! Обратитесь к администратору!\r\n" + ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    string decryptKey = crypt.Decrypt(_key);
                                    string[] key = decryptKey.Split(new string[] { " " }, StringSplitOptions.None);

                                    try
                                    {
                                        var cn = new SQLiteConnection(MainForm.mainForm.connectionKeyData);
                                        cn.Open();
                                        var cmnd = cn.CreateCommand();
                                        cmnd.CommandText = "INSERT INTO KeyData (" +
                                                            "ActivateDT, " + 
                                                            "Key, " +
                                                            "Letter, " +
                                                            "StartNo, " +
                                                            "FinishNo, " +
                                                            "CurrentNo, " +
                                                            "Active) " +
                                                           "VALUES (" +
                                                            "@ActivateDT, " + 
                                                            "@Key, " +
                                                            "@Letter, " +
                                                            "@StartNo, " +
                                                            "@FinishNo, " +
                                                            "@CurrentNo, " +
                                                            "@Active)";
                                        cmnd.Parameters.AddWithValue("@ActivateDT", DateTime.Now);
                                        cmnd.Parameters.AddWithValue("@Key", _key);
                                        cmnd.Parameters.AddWithValue("@Letter", key[0]);
                                        cmnd.Parameters.AddWithValue("@StartNo", Convert.ToInt32(key[1].ToString()));
                                        cmnd.Parameters.AddWithValue("@FinishNo", Convert.ToInt32(key[2].ToString()));
                                        cmnd.Parameters.AddWithValue("@CurrentNo", Convert.ToInt32(key[1].ToString()));
                                        cmnd.Parameters.AddWithValue("@Active", 1);
                                        cmnd.ExecuteNonQuery();
                                        cn.Close();
                                    }
                                    catch (SQLiteException ex)
                                    {
                                        XtraMessageBox.Show("Ошибка при работе с базой данных! Обратитесь к администратору!\r\n" + ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    
                                    var s1 = string.Concat(Enumerable.Repeat("0", 5 - key[1].Length));
                                    var s2 = string.Concat(Enumerable.Repeat("0", 5 - key[2].Length));
                                    tbNewKey.Text = "";
                                    tbNewKey.Focus();
                                    XtraMessageBox.Show("Ключ был успешно добавлен!\r\nВам доступен диапазон: " + key[0] + "-" + s1 + key[1] + " - " + key[0] + "-" + s2 + key[2], "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    conn.Close();
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Введите ключ!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion
        #region "Load Key History"
        public void LoadKeyHistory()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT Letter ||'-'|| (select replace(substr(quote(zeroblob((7 + 1) / 2)), 3, (5 - length(StartNo))), '0', '0'))|| StartNo ||' - '|| Letter ||'-'|| (select replace(substr(quote(zeroblob((7 + 1) / 2)), 3, (5 - length(FinishNo))), '0', '0')) || FinishNo AS KeyRange, Key AS KeyCode, ActivateDT AS ActivationDT FROM KeyData";
                        using (var da = new SQLiteDataAdapter(comm))
                        {
                            using (var dt = new DataTable())
                            {
                                da.Fill(dt);
                                conn.Close();
                                da.Dispose();
                                gridControl1.DataSource = dt;
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
 
            }
        }
        #endregion
    }
}
