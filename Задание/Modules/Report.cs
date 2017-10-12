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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;

namespace Задание
{
    public partial class Report : DevExpress.XtraEditors.XtraUserControl
    {
        public static Report report;
        public int CurrentPage = 0;
        List<ReportItems> reportItems = new List<ReportItems>();

        public Report()
        {
            InitializeComponent();
            report = this;
        }

        public void CreatePdf()
        {
            PrintingSystem ps = new PrintingSystem();
            PrintableComponentLink pc = new PrintableComponentLink(ps);
            pc.Component = gridControl;
            pc.PaperKind = System.Drawing.Printing.PaperKind.A4Extra;
            pc.Landscape = true;
            pc.CreateDocument();
            pc.PrintingSystemBase.ExportToPdf(Application.StartupPath + "\\Temp\\tmp.pdf");
        }

        public void CreateDoc()
        {
            PrintingSystem ps = new PrintingSystem();
            PrintableComponentLink pc = new PrintableComponentLink(ps);
            pc.Component = gridControl;
            pc.PaperKind = System.Drawing.Printing.PaperKind.A4Extra;
            pc.Landscape = true;
            pc.CreateDocument();
            pc.PrintingSystemBase.ExportToRtf(Application.StartupPath + "\\Temp\\report.rtf");
        }

        public void PrintPdf()
        {
            var pdfViewer = new DevExpress.XtraPdfViewer.PdfViewer();
            var settings = new DevExpress.Pdf.PdfPrinterSettings();
            pdfViewer.DocumentFilePath = Application.StartupPath + "\\Temp\\tmp.pdf";            
            settings.PageOrientation = DevExpress.Pdf.PdfPrintPageOrientation.Landscape;
            pdfViewer.Print(settings);
            pdfViewer.CloseDocument();
        }

        public void LoadMinDate()
        {
            string minDate = "";

            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT MIN (PrintDT) AS MinDate FROM report WHERE SUBSTR(TaskNo, 1, 1) = (SELECT Letter FROM KeyData WHERE Active = 1)";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    minDate = dr["MinDate"].ToString();
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dtStart.EditValue = DateTime.Parse(minDate);
            dtFinish.EditValue = DateTime.Now;
        }

        public void FetchReportData(string dtStart, string dtFinish)
        {
            if (dtStart != string.Empty && dtFinish != string.Empty)
            {
                try
                {
                    using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                    {
                        conn.Open();
                        using (var comm = conn.CreateCommand())
                        {
                            comm.CommandText = "SELECT * FROM Report WHERE SUBSTR(TaskNo, 1, 1) = (SELECT Letter FROM KeyData WHERE Active = 1) AND PrintDT BETWEEN @date1 AND @date2";
                            comm.Parameters.AddWithValue("@date1", DateTime.Parse(dtStart));
                            comm.Parameters.AddWithValue("@date2", DateTime.Parse(dtFinish));
                            using (var da = new SQLiteDataAdapter(comm))
                            {
                                var dt = new DataTable();
                                da.Fill(dt);
                                da.Dispose();
                                gridControl.DataSource = dt;
                            }
                        }
                        conn.Close();
                        
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.dtStart.Text = dtStart;
                this.dtFinish.Text = dtFinish;
                LoadBlank();
                AddItemsToRepositoryList();

                if (gridView.RowCount > 0)
                {
                    gridView.FocusedRowHandle = 0;
                    gridView.SelectRow(0);
                }
            }
        }

        private void LoadBlank()
        {
            reportItems.Clear();
            int i = 0;
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT MAX (ID) AS ID FROM Report";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    i = Convert.ToInt32(dr["ID"].ToString());
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT Letter, CurrentNo, FinishNo FROM KeyData WHERE Active = 1";
                        using (var dr = comm.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    int total = Convert.ToInt32(dr["FinishNo"].ToString());

                                    for (int j = Convert.ToInt32(dr["CurrentNo"].ToString()); j <= total; j++)
                                    {
                                        var s1 = string.Concat(Enumerable.Repeat("0", 5 - j.ToString().Length));

                                        gridView.AddNewRow();
                                        int newRowHandle = gridView.FocusedRowHandle;
                                        gridView.SetRowCellValue(newRowHandle, gridView.Columns[0], i + 1);
                                        gridView.SetRowCellValue(newRowHandle, gridView.Columns[1], dr["Letter"].ToString() + "-" + s1 + j.ToString());
                                        gridView.SetRowCellValue(newRowHandle, gridView.Columns[6], "Не использован");
                                        gridView.UpdateCurrentRow();
                                        gridView.RefreshData();
                                        i++;
                                    }
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void AddItemsToRepositoryList()
        {
            var repItems = new List<RepositoryItems>();
            repItems.Add(new RepositoryItems { Caption = "Принят" });
            repItems.Add(new RepositoryItems { Caption = "Уничтожен" });

            foreach (var item in repItems)
            {
                repositoryItemComboBox2.Items.Add(item.Caption);
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                EditRow(e.Value.ToString());
            }
        }

        private void EditRow(string _value)
        {
            try
            {
                using (var conn = new SQLiteConnection(MainForm.mainForm.connectionKeyData))
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "UPDATE Report SET Status = @Status WHERE ID = @ID";
                        comm.Parameters.AddWithValue("@Status", _value);
                        comm.Parameters.AddWithValue("@ID", gridView.GetFocusedRowCellValue("ID"));
                        comm.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (dtStart.Text != string.Empty && dtFinish.Text != string.Empty)
            {
                if (DateTime.Parse(dtFinish.Text) < DateTime.Parse(dtStart.Text))
                    XtraMessageBox.Show("Дата окончания не может быть меньше даты начала!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Report.report.FetchReportData(dtStart.Text, dtFinish.Text);
            }
            else
            {
                XtraMessageBox.Show("Заполните дату начала и окончания отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ControlPanel.controlPanel.navigation.SelectedPageIndex = 0;
            NavigationPanel.navigationPanel.navigation.SelectedPageIndex = 0;
            NavigationBar.navigationBar.NavigationMain.Groups["TaskGroup"].Expanded = true;
            MainForm.mainForm.navigationBar.Enabled = true;
            gridControl.DataSource = null;
        }

        public class RepositoryItems
        {
            public string Caption { get; set; }
        }

        public class ReportItems
        {
            public int ID { get; set; }
            public string BlankNo { get; set; }
            public string BlankStatus { get; set; }
        }
    }
}
