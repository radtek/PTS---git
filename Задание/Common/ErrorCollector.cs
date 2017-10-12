using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace Задание
{
    public class ErrorCollector
    {
        public void ApplicationEvent(int UserID, int ActionLevel, string Event, string Method, bool IsDBLog) // IsDBLog - писать или нет в БД.
        {
            if (IsDBLog)
            {
                try
                {
                    using (var conn = new SQLiteConnection(MainForm.mainForm.connectionUserData))
                    {
                        conn.Open();
                        using (var comm = conn.CreateCommand())
                        {
                            comm.CommandText = "INSERT INTO Log (UserID, ActionLevel, ActionDT, Event) VALUES (@UserID, @ActionLevel, @ActionDT, @Event)";
                            comm.Parameters.AddWithValue("@UserID", UserID);
                            comm.Parameters.AddWithValue("@ActionLevel", ActionLevel);
                            comm.Parameters.AddWithValue("@ActionDT", DateTime.Now);
                            comm.Parameters.AddWithValue("@Event", Event);
                            comm.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString(), "Ошибка доступа к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (ActionLevel == 1)
            {
                try
                {
                    string Line = "";
                    if (Method != "")
                        Line = string.Format("{0}::({1})-{2}", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), Method, Event);
                    else
                        Line = string.Format("{0}::{1}", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), Event);
                    string Path = Application.StartupPath + "\\Log\\";
                    string Caption = DateTime.Now.ToString("dd-MM-yyyy");
                    if (!Directory.Exists(Path))
                        Directory.CreateDirectory(Path);
                    File.AppendAllText(Path + Caption + ".txt", Line + "\r\n", Encoding.UTF8);
                }
                catch (IOException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString(), "Ошибка записи события в файл", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
