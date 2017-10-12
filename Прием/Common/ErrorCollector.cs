using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace Прием
{
    public class ErrorCollector
    {
        public void ApplicationEvent(int UserID, string Event, string Method) // IsDBLog - писать или нет в БД.
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
                //XtraMessageBox.Show(ex.Message.ToString(), "Ошибка записи события в файл", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
