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
using System.Threading;
using Spire.Doc;
using System.Drawing.Printing;
using System.IO;

namespace Задание
{
    public partial class ControlPanel : DevExpress.XtraEditors.XtraUserControl
    {
        #region "Decalaration"
        public static ControlPanel controlPanel;

        public string taskNo = "";
        public int currentTaskNo;
        public int lastTaskNo;
        public string maxJournalTaskNo = "";

        ErrorCollector errorCollector = new ErrorCollector();
        #endregion

        public ControlPanel()
        {
            InitializeComponent();
            controlPanel = this;
        }

        #region "Key Response"
        public void GetCurrentTaskNumber()
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM KeyData WHERE Active = 1";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    string _letter = dr["Letter"].ToString();
                                    int _currentNo = Convert.ToInt32(dr["CurrentNo"].ToString());
                                    var s1 = string.Concat(Enumerable.Repeat("0", 5 - dr["CurrentNo"].ToString().Length));
                                    labelTaskNo.Text = _letter + "-" + s1 + Convert.ToString(_currentNo);
                                    taskNo = _letter + "-" + s1 + Convert.ToString(_currentNo);
                                    currentTaskNo = Convert.ToInt32(dr["CurrentNo"].ToString());
                                    lastTaskNo = Convert.ToInt32(dr["FinishNo"].ToString());
                                }
                                conn.Close();
                            }
                            else
                            {
                                dr.Close();
                                conn.Close();
                                MainForm.mainForm.DisableForm();
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                errorCollector.ApplicationEvent(0, 1, ex.Message, "GetCurrentTaskNumber", false);
            }
        }

        public void CheckUnprintedTaskNo()
        {
            int i = 0;

            using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
            {
                conn.Open();
                using (var comm = new SQLiteCommand("SELECT * FROM Journal WHERE TaskNo = @TaskNo", conn))
                {
                    comm.Parameters.AddWithValue("@TaskNo", taskNo);
                    using (var dr = comm.ExecuteReader())
                    {
                        if (dr.HasRows)
                            i = 1;
                    }
                }
                conn.Close();
            }

            if (i == 1)
            {
                UpdateKey();
            }
        }

        private void UpdateKey()
        {
            if (currentTaskNo < lastTaskNo)
            {
                try
                {
                    using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                    {
                        conn.Open();
                        using (var comm = conn.CreateCommand())
                        {
                            comm.CommandText = "UPDATE KeyData SET CurrentNo = @CurrentNo WHERE Active = 1";
                            comm.Parameters.AddWithValue("@TaskNo", taskNo);
                            comm.Parameters.AddWithValue("@CurrentNo", currentTaskNo + 1);
                            comm.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show("Ошибка при работе с базой данных! Обратитесь к администратору!\r\n" + ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                GetCurrentTaskNumber();
            }
            else
            {
                // Блочим форму и выводим страницу ввода ключа
                MainForm.mainForm.DisableForm();
            }
        }

        public void CheckKey()
        {
            if (taskNo != string.Empty)
            {
                try
                {
                    using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                    {
                        conn.Open();
                        using (var comm = conn.CreateCommand())
                        {
                            comm.CommandText = "SELECT MAX (ID), TaskNo FROM Journal";
                            using (var dr = comm.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    maxJournalTaskNo = dr["TaskNo"].ToString();
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show("Ошибка при работе с базой данных! Обратитесь к администратору!\r\n" + ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (maxJournalTaskNo == taskNo && currentTaskNo == lastTaskNo)
                {
                    taskNo = "";
                    labelTaskNo.Text = string.Empty;

                    try
                    {
                        using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                        {
                            conn.Open();
                            using (var comm = conn.CreateCommand())
                            {
                                comm.CommandText = "UPDATE KeyData SET Active = 0 WHERE Active = 1";
                                comm.ExecuteNonQuery();
                            }
                            conn.Close();
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        XtraMessageBox.Show("Ошибка при работе с базой данных! Обратитесь к администратору!\r\n" + ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Блочим форму и открываем страницу ввода нового ключа
                    MainForm.mainForm.DisableForm();
                }
            }
        }
        #endregion

        public void SplashScreen()
        {
            Application.Run(new DocLoading());
        }

        public void SplashPrinting()
        {
            Application.Run(new Printing());
        }

        #region "Delete Temp Files"
        public void DeleteTemp()
        {
            string doc1Path = Application.StartupPath + "\\Temp\\tmp.docx";
            string doc2Path = Application.StartupPath + "\\Temp\\tmp2.docx";
            string doc3Path = Application.StartupPath + "\\Temp\\tmp3.docx";
            string pdfPath = Application.StartupPath + "\\Temp\\tmp.pdf";
            string reportPdfPath = Application.StartupPath + "\\Temp\\report.pdf";
            string reportDocPath = Application.StartupPath + "\\Temp\\report.rtf";

            if (File.Exists(doc1Path))
            {
                try
                {
                    File.Delete(doc1Path);
                }
                catch (IOException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }

            if (File.Exists(doc2Path))
            {
                try
                {
                    File.Delete(doc2Path);
                }
                catch (IOException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }

            if (File.Exists(doc3Path))
            {
                try
                {
                    File.Delete(doc3Path);
                }
                catch (IOException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }

            if (File.Exists(pdfPath))
            {
                try
                {
                    File.Delete(pdfPath);
                }
                catch (IOException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }

            if (File.Exists(reportPdfPath))
            {
                try
                {
                    File.Delete(reportPdfPath);
                }
                catch (IOException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }

            if (File.Exists(reportDocPath))
            {
                try
                {
                    File.Delete(reportDocPath);
                }
                catch (IOException ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
        }
        #endregion
        #region "Print Dialog"
        public void PrintNewTask()
        {
            if (taskNo != string.Empty)
            {
                if (CheckJournal(taskNo) == 0)
                    InsertJournal(taskNo);

                PrintResultDialog printResultDialog = new PrintResultDialog();
                if (currentTaskNo + 1 <= lastTaskNo)
                    printResultDialog.btnCreateNext.Enabled = true;

                DialogResult dialog = PrintResultDialog.printResultDialog.ShowDialog();
                if (dialog == DialogResult.Yes)
                {
                    string authorDivision = AuthorDivision();
                    string authorFullName = AuthorFullName();

                    if (CheckReport(taskNo) == 0)
                        FillReport(taskNo, Task.task.cbHeadAcceptService.Text.Trim() + " " + Task.task.cbHeadAcceptDivision.Text.Trim(), authorDivision, authorFullName);
                    else
                        UpdateReport(taskNo, Task.task.cbHeadAcceptService.Text.Trim() + " " + Task.task.cbHeadAcceptDivision.Text.Trim(), authorDivision, authorFullName);

                    UpdateNo();
                    Task.task.ClearForm();
                }
                else if (dialog == DialogResult.No)
                {
                    string authorDivision = AuthorDivision();
                    string authorFullName = AuthorFullName();

                    if (CheckReport(taskNo) == 0)
                        FillReport(taskNo, Task.task.cbHeadAcceptService.Text.Trim() + " " + Task.task.cbHeadAcceptDivision.Text.Trim(), authorDivision, authorFullName);
                    else
                        UpdateReport(taskNo, Task.task.cbHeadAcceptService.Text.Trim() + " " + Task.task.cbHeadAcceptDivision.Text.Trim(), authorDivision, authorFullName);
                }
                else if (dialog == DialogResult.Ignore)
                {
                    string authorDivision = AuthorDivision();
                    string authorFullName = AuthorFullName();

                    if (CheckReport(taskNo) == 0)
                        FillReport(taskNo, Task.task.cbHeadAcceptService.Text.Trim() + " " + Task.task.cbHeadAcceptDivision.Text.Trim(), authorDivision, authorFullName);
                    else
                        UpdateReport(taskNo, Task.task.cbHeadAcceptService.Text.Trim() + " " + Task.task.cbHeadAcceptDivision.Text.Trim(), authorDivision, authorFullName);

                    UpdateNo();
                    Task.task.cbEventType.EditValue = null;
                }
            }
        }

        public string AuthorFullName()
        {
            string result = "";
            result = Task.task.tbAuthorSurname.Text.Trim() + " " + Task.task.tbAuthorName.Text.Trim() + " " + Task.task.tbAuthorSecondName.Text.Trim();
            return result;
        }

        public string AuthorDivision()
        {
            string result = "";

            if (Task.task.cbAuthorLine.Text.Trim() != string.Empty)
                result = Task.task.cbAuthorLine.Text.Trim() + " " + Task.task.cbAuthorService.Text.Trim() + " " + Task.task.cbAuthorDivision.Text.Trim();
            else
                result = Task.task.cbAuthorService.Text.Trim() + " " + Task.task.cbAuthorDivision.Text.Trim();

            return result;
        }

        public int CheckReport(string _TaskNo)
        {
            int result = 0;
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM Report WHERE TaskNo = @TaskNo";
                        comm.Parameters.AddWithValue("@TaskNo", _TaskNo);
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                                result = 1;
                            else
                                result = 0;
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show("CheckReport " + ex.ToString());
            }
            return result;
        }

        public void UpdateNo()
        {
            if (currentTaskNo != lastTaskNo)
            {
                int _currentNo = currentTaskNo + 1;

                try
                {
                    using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                    {
                        conn.Open();
                        using (var comm = conn.CreateCommand())
                        {
                            comm.CommandText = "UPDATE KeyData SET CurrentNo = @CurrentNo WHERE Active = 1";
                            comm.Parameters.AddWithValue("@CurrentNo", _currentNo);
                            comm.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                catch (SQLiteException ex)
                {
                    XtraMessageBox.Show("UpdateNo " + ex.ToString());
                }

                GetCurrentTaskNumber();
            }
            else
            {
                // Переход на форму ключа и блокировка интерфейса.
                MainForm.mainForm.DisableForm();
            }
        }

        private void FillReport(string _TaskNo, string _GetDivision, string _ExecutorDivision, string _Executor)
        {
            using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
            {
                conn.Open();
                using (var comm = conn.CreateCommand())
                {
                    comm.CommandText = "INSERT INTO Report (TaskNo, PrintDT, Division, Executor, ExecutorDivision, Status) VALUES (@TaskNo, @PrintDT, @Division, @Executor, @ExecutorDivision, @Status)";
                    comm.Parameters.AddWithValue("@TaskNo", taskNo);
                    comm.Parameters.AddWithValue("@PrintDT", ToDateSQLite(DateTime.Now));
                    comm.Parameters.AddWithValue("@Division", _GetDivision);
                    comm.Parameters.AddWithValue("@Executor", _Executor);
                    comm.Parameters.AddWithValue("@ExecutorDivision", _ExecutorDivision);
                    comm.Parameters.AddWithValue("@Status", "Принят");
                    comm.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        private void UpdateReport(string _TaskNo, string _GetDivision, string _ExecutorDivision, string _Executor)
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "UPDATE Report SET PrintDT = @PrintDT, Division = @Division, Executor = @Executor, ExecutorDivision = @ExecutorDivision, Status = @Status WHERE TaskNo = @TaskNo";
                        comm.Parameters.AddWithValue("@TaskNo", taskNo);
                        comm.Parameters.AddWithValue("@PrintDT", ToDateSQLite(DateTime.Now));
                        comm.Parameters.AddWithValue("@Division", _GetDivision);
                        comm.Parameters.AddWithValue("@Executor", _Executor);
                        comm.Parameters.AddWithValue("@ExecutorDivision", _ExecutorDivision);
                        comm.Parameters.AddWithValue("@Status", "Принят");
                        comm.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show("UpdateReport " + ex.ToString());
            }
        }

        private int CheckJournal(string _TaskNo)
        {
            int result = 0;

            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT * FROM Journal WHERE TaskNo = @TaskNo";
                        comm.Parameters.AddWithValue("@TaskNo", _TaskNo);
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                                result = 1;
                            else
                                result = 0;
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show("CheckJournal " + ex.ToString());
            }
            return result;
        }

        private void InsertJournal(string _TaskNo)
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "INSERT INTO Journal (TaskNo) VALUES (@TaskNo)";
                        comm.Parameters.AddWithValue("@TaskNo", _TaskNo);
                        comm.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                XtraMessageBox.Show("InsertJournal " + ex.ToString());
            }
        }

        public static string ToDateSQLite(DateTime value)
        {
            string format_date = "yyyy-MM-dd HH:mm:ss.fff";
            return value.ToString(format_date);
        }
        #endregion
        #region "Reference Controls"
        private void btnRefPreview_Click(object sender, EventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 1) // Если выбрана справка об объекте
            {
                Reference.reference.UpdateForValidate();
                if (Reference.reference.ValidateReferenceFields(Reference.reference.controls))
                {
                    Thread t = new Thread(new ThreadStart(SplashScreen));
                    t.Start();
                    Thread.Sleep(1000);
                    if (Preview.preview.pdfViewer.Document != null)
                    {
                        Preview.preview.pdfViewer.Document.Dispose();
                    }
                    Reference.reference.InsertDocX(1, Reference.reference.TotalDivisions);
                    Reference.reference.CreateReferenceDocument();
                    MergeDocuments();
                    Preview.preview.DocFile = Application.StartupPath + "\\Temp\\tmp3.docx";
                    Preview.preview.ShowPreview(1);
                    btnTaskMode.Enabled = false;
                    MainForm.mainForm.navigationBar.Enabled = false;
                    NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 2;
                    t.Abort();
                }
                else
                {
                    XtraMessageBox.Show("Заполните все необходимые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefPrint_Click(object sender, EventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 1) // Если выбрана справка об объекте
            {
                Reference.reference.UpdateForValidate();
                if (Reference.reference.ValidateReferenceFields(Reference.reference.controls))
                {
                    Thread t = new Thread(new ThreadStart(SplashPrinting));
                    t.Start();
                    Thread.Sleep(1000);
                    for (int i = 1; i <= Reference.reference.TotalDivisions; i++)
                    {
                        Reference.reference.InsertDocX(i, Reference.reference.TotalDivisions);
                        Document doc = new Document();
                        doc.LoadFromFile(Application.StartupPath + "\\Temp\\tmp.docx");
                        PrintDialog dialog = new PrintDialog();
                        doc.PrintDialog = dialog;
                        PrintDocument printDoc = doc.PrintDocument;
                        printDoc.PrintController = new StandardPrintController();
                        printDoc.Print();
                        DeleteTemp();
                    }
                    t.Abort();
                }
                else
                {
                    XtraMessageBox.Show("Заполните все необходимые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 2) // Если выбран предпросмотр
            {
                Thread t = new Thread(new ThreadStart(SplashPrinting));
                t.Start();
                Thread.Sleep(1000);
                for (int i = 1; i <= Reference.reference.TotalDivisions; i++)
                {
                    Reference.reference.InsertDocX(i, Reference.reference.TotalDivisions);
                    Document doc = new Document();
                    doc.LoadFromFile(Application.StartupPath + "\\Temp\\tmp.docx");
                    PrintDialog dialog = new PrintDialog();
                    doc.PrintDialog = dialog;
                    PrintDocument printDoc = doc.PrintDocument;
                    printDoc.PrintController = new StandardPrintController();
                    printDoc.Print();
                }
                t.Abort();
            }
        }

        private void btnRefDocumentPrint_Click(object sender, EventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 1) // Если выбрана справка об объекте
            {
                Reference.reference.UpdateForValidate();
                if (Reference.reference.ValidateReferenceFields(Reference.reference.controls))
                {
                    Thread t = new Thread(new ThreadStart(SplashPrinting));
                    t.Start();
                    Thread.Sleep(1000);
                    Reference.reference.CreateReferenceDocument();
                    for (int i = 1; i <= Reference.reference.TotalDivisions; i++)
                    {
                        Document doc = new Document();
                        doc.LoadFromFile(Application.StartupPath + "\\Temp\\tmp2.docx");
                        PrintDialog dialog = new PrintDialog();
                        doc.PrintDialog = dialog;
                        PrintDocument printDoc = doc.PrintDocument;
                        printDoc.PrintController = new StandardPrintController();
                        printDoc.Print();
                    }
                    DeleteTemp();
                    t.Abort();
                }
                else
                {
                    XtraMessageBox.Show("Заполните все необходимые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 2) // Если выбран предпросмотр
            {
                Thread t = new Thread(new ThreadStart(SplashPrinting));
                t.Start();
                Thread.Sleep(1000);
                for (int i = 1; i <= Reference.reference.TotalDivisions; i++)
                {
                    Document doc = new Document();
                    doc.LoadFromFile(Application.StartupPath + "\\Temp\\tmp2.docx");
                    PrintDialog dialog = new PrintDialog();
                    doc.PrintDialog = dialog;
                    PrintDocument printDoc = doc.PrintDocument;
                    printDoc.PrintController = new StandardPrintController();
                    printDoc.Print();
                }
                t.Abort();
            }
        }

        private void btnRefMode_Click(object sender, EventArgs e)
        {
            var refMode = new ReferenceMode();
            refMode.ShowDialog();
        }

        public void MergeDocuments()
        {
            Document DocOne = new Document();
            DocOne.LoadFromFile(Application.StartupPath + "\\Temp\\tmp.docx", FileFormat.Docx);
            Document DocTwo = new Document();
            DocTwo.LoadFromFile(Application.StartupPath + "\\Temp\\tmp2.docx", FileFormat.Docx);

            foreach (Spire.Doc.Section sec in DocTwo.Sections)
            {
                DocOne.Sections.Add(sec.Clone());
            }
            DocOne.SaveToFile(Application.StartupPath + "\\Temp\\tmp3.docx", FileFormat.Docx);
        }
        #endregion
        #region "Task Controls"
        private void btnTaskPreview_Click(object sender, EventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 0) // Если выбрано задание
            {
                Task.task.UpdateForValidate();
                if (Task.task.ValidateTaskFields(Task.task.controls))
                {
                    try
                    {
                        Thread t = new Thread(new ThreadStart(SplashScreen));
                        t.Start();
                        Thread.Sleep(1000);
                        if (Preview.preview.pdfViewer.Document != null)
                        {
                            Preview.preview.pdfViewer.Document.Dispose();
                        }
                        Task.task.UpdateFields();
                        Task.task.UpdateDoc();
                        Preview.preview.DocFile = Application.StartupPath + "\\Temp\\tmp.docx";
                        Preview.preview.ShowPreview(0);
                        btnTaskMode.Enabled = false;
                        MainForm.mainForm.navigationBar.Enabled = false;
                        NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 2;
                        t.Abort();
                    }
                    catch (ThreadAbortException ex)
                    {
                        XtraMessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    XtraMessageBox.Show("Заполните все необходимые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTaskPrint_Click(object sender, EventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 0) // Если выбрано задание
            {
                Task.task.UpdateForValidate();
                if (Task.task.ValidateTaskFields(Task.task.controls))
                {
                    Thread t = new Thread(new ThreadStart(SplashScreen));
                    t.Start();
                    Thread.Sleep(1000);
                    Task.task.UpdateFields();
                    Task.task.UpdateDoc();
                    t.Abort();

                    Document doc = new Document();
                    doc.LoadFromFile(Application.StartupPath + "\\Temp\\tmp.docx");
                    PrintDialog dialog = new PrintDialog();
                    doc.PrintDialog = dialog;
                    PrintDocument printDoc = doc.PrintDocument;
                    printDoc.PrintController = new StandardPrintController();
                    printDoc.Print();
                    DeleteTemp();

                    PrintNewTask();
                }
                else
                {
                    XtraMessageBox.Show("Заполните все необходимые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 2) // Если выбран предпросмотр
            {
                Document doc = new Document();
                doc.LoadFromFile(Application.StartupPath + "\\Temp\\tmp.docx");
                PrintDialog dialog = new PrintDialog();
                doc.PrintDialog = dialog;
                PrintDocument printDoc = doc.PrintDocument;
                printDoc.PrintController = new StandardPrintController();
                printDoc.Print();

                PrintNewTask();
            }
        }

        private void btnTaskMode_Click(object sender, EventArgs e)
        {
            var taskMode = new TaskModeForm();
            taskMode.ShowDialog();
        }
        #endregion
        #region "Report Controls"
        private void btnPreviewReport_Click(object sender, EventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 4) // Если выбран отчет
            {
                if (Report.report.gridView.RowCount > 0)
                {
                    Thread t = new Thread(new ThreadStart(SplashScreen));
                    t.Start();
                    Thread.Sleep(1000);
                    if (Preview.preview.pdfViewer.Document != null)
                    {
                        Preview.preview.pdfViewer.Document.Dispose();
                    }
                    Report.report.CreateDoc();
                    //Preview.preview.DocFile = Application.StartupPath + "\\Temp\\report.rtf";
                    Preview.preview.ShowReportPreview(4);
                    btnTaskMode.Enabled = false;
                    MainForm.mainForm.navigationBar.Enabled = false;
                    NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 2;
                    t.Abort();
                }
                else
                {
                    XtraMessageBox.Show("Выберите период отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 4) // Если выбран отчет
            {
                Thread t = new Thread(new ThreadStart(SplashPrinting));
                t.Start();
                Thread.Sleep(1000);
                if (Preview.preview.pdfViewer.Document != null)
                {
                    Preview.preview.pdfViewer.Document.Dispose();
                }
                Report.report.CreatePdf();
                Document docReport = new Document();
                docReport.LoadFromFile(Application.StartupPath + "\\Data\\Templates\\report.docx");
                PrintDialog dialogReport = new PrintDialog();
                docReport.PrintDialog = dialogReport;
                PrintDocument printDocReport = docReport.PrintDocument;
                printDocReport.PrintController = new StandardPrintController();
                printDocReport.Print();
                Report.report.PrintPdf();
                DeleteTemp();
                t.Abort();
            }
            else if (NavigationPanel.navigationPanel.navigation.SelectedPageIndex == 2) // Если выбран предпросмотр
            {
                Thread t = new Thread(new ThreadStart(SplashPrinting));
                t.Start();
                Thread.Sleep(1000);
                if (Preview.preview.pdfViewer.Document != null)
                {
                    Preview.preview.pdfViewer.Document.Dispose();
                }
                Document docReport = new Document();
                docReport.LoadFromFile(Application.StartupPath + "\\Data\\Templates\\report.docx");
                PrintDialog dialogReport = new PrintDialog();
                docReport.PrintDialog = dialogReport;
                PrintDocument printDocReport = docReport.PrintDocument;
                printDocReport.PrintController = new StandardPrintController();
                printDocReport.Print();
                Preview.preview.PrintPdf();
                t.Abort();
            }
        }
        #endregion
    }
}
