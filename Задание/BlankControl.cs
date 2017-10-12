using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Novacode;
using Spire.Doc;
using System.Drawing.Printing;
using System.Threading;
using System.Data.SQLite;

namespace Задание
{
    public partial class BlankControl : DevExpress.XtraEditors.XtraUserControl
    {
        public static BlankControl blankControl;

        public BlankControl()
        {
            InitializeComponent();
            blankControl = this;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (tbNumber.Text.Length == 5)
            {
                if (cbChar.Text != string.Empty)
                {
                    Thread t = new Thread(new ThreadStart(SplashPrinting));
                    t.Start();
                    Thread.Sleep(500);
                    using (var doc = DocX.Load(Application.StartupPath + "\\Data\\Templates\\blank.docx"))
                    {
                        for (int i = 0; i <= 99; i++)
                        {
                            doc.ReplaceText("{" + i.ToString() + "}", "");
                        }
                        doc.ReplaceText("{100}", string.Format("{0}-{1}", cbChar.Text, tbNumber.Text));
                        doc.SaveAs(Application.StartupPath + "\\Temp\\tmp.docx");

                        Document document = new Document();
                        document.LoadFromFile(Application.StartupPath + "\\Temp\\tmp.docx");
                        PrintDialog dialog = new PrintDialog();
                        document.PrintDialog = dialog;
                        PrintDocument printDoc = document.PrintDocument;
                        printDoc.PrintController = new StandardPrintController();
                        printDoc.Print();
                        ControlPanel.controlPanel.DeleteTemp();

                        InsertData();
                        FetchData();
                    }
                    t.Abort();
                }
                else
                {
                    XtraMessageBox.Show("Выберите букву номера бланка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Введите корректный номер бланка! Номер должен состоять из 5 цифр!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FetchData()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionUserData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT ID, PrintDT, BlankNo FROM BlankPrint";
                        using (var da = new SQLiteDataAdapter(comm))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            da.Dispose();
                            gridControl1.DataSource = dt;
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void InsertData()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionUserData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "INSERT INTO BlankPrint (UserID, BlankNo, PrintDT) VALUES (@UserID, @BlankNo, @PrintDT)";
                        comm.Parameters.AddWithValue("@UserID", MainForm.mainForm.UserID);
                        comm.Parameters.AddWithValue("@BlankNo", string.Format("{0}-{1}", cbChar.Text, tbNumber.Text));
                        comm.Parameters.AddWithValue("@PrintDT", DateTime.Now);
                        comm.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        public void SplashPrinting()
        {
            Application.Run(new Printing());
        }
    }
}
