using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PdfiumViewer;
//using Microsoft.Office.Interop.Word;
using Spire.Doc;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace Задание
{
    public partial class Preview : DevExpress.XtraEditors.XtraUserControl
    {
        #region "Declaration"
        public static Preview preview;
        public int ContentIndex; // 0 - Task, 1 - Reference, 2 - Report
        List<Bitmap> img = new List<Bitmap>();
        public string DocFile;
        #endregion

        public Preview()
        {
            InitializeComponent();
            preview = this;

            pdfViewer1.MenuManager = null;
        }

        private bool CreatePdf(string docFile, string pdfFileExport)
        {
            try
            {
                using (var doc = new Document(docFile))
                {
                    doc.SaveToFile(pdfFileExport, Spire.Doc.FileFormat.PDF);
                    return true;
                }
            }
            catch
            {
                return false;
            }

            //Microsoft.Office.Interop.Word.Application app = null;
            //Document doc = null;

            //object oldFileName = (object)docFile;
            //try
            //{
            //    app = new Microsoft.Office.Interop.Word.Application();
            //    doc = app.Documents.Open(ref oldFileName);
            //    object oMissing = System.Reflection.Missing.Value;

            //    doc.ExportAsFixedFormat(pdfFileExport, WdExportFormat.wdExportFormatPDF, false, WdExportOptimizeFor.wdExportOptimizeForOnScreen,
            //        WdExportRange.wdExportAllDocument, 1, 1, WdExportItem.wdExportDocumentContent, true, true,
            //        WdExportCreateBookmarks.wdExportCreateHeadingBookmarks, true, true, false, ref oMissing);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ошибка:\r\n" + ex.Message + "\r\n" + ex.StackTrace);
            //    return false;
            //}
            //finally
            //{
            //    object nullobject = Type.Missing;

            //    if (doc != null)
            //    {
            //        ((Microsoft.Office.Interop.Word._Document)doc).Close(ref nullobject, ref nullobject, ref nullobject);
            //    }
            //    if (app != null)
            //    {
            //        app.Quit(ref nullobject, ref nullobject, ref nullobject);
            //    }

            //    GC.Collect();
            //    GC.WaitForFullGCComplete();
            //}
        }

        private bool CreateReportPdf(string docFile, string pdfFileExport)
        {
            try
            {
                Spire.Pdf.PdfDocument pdf = new Spire.Pdf.PdfDocument();

                PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
                PdfMargins margin = new PdfMargins();
                margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
                margin.Bottom = margin.Top;
                margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
                margin.Right = margin.Left;

                PdfPageBase page = pdf.Pages.Add(PdfPageSize.A4, margin, PdfPageRotateAngle.RotateAngle0, PdfPageOrientation.Landscape);

                String rtf = System.IO.File.ReadAllText(docFile);
                page.LoadFromRTF(rtf, page.Canvas.ClientSize.Width, true);

                pdf.SaveToFile(pdfFileExport);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ShowPreview(int PageIndex)
        {
            ContentIndex = PageIndex;
            if (File.Exists(DocFile))
            {
                if (CreatePdf(DocFile, System.Windows.Forms.Application.StartupPath + "\\Temp\\tmp.pdf"))
                {
                    pdfViewer1.DocumentFilePath = System.Windows.Forms.Application.StartupPath + "\\Temp\\tmp.pdf";
                }
            }
        }

        public void ShowReportPreview(int PageIndex)
        {
            ContentIndex = PageIndex;
            pdfViewer1.DocumentFilePath = System.Windows.Forms.Application.StartupPath + "\\Temp\\tmp.pdf";
            //if (File.Exists(DocFile))
            //{
            //    if (CreateReportPdf(DocFile, System.Windows.Forms.Application.StartupPath + "\\Temp\\tmp.pdf"))
            //    {
            //        pdfViewer1.DocumentFilePath = System.Windows.Forms.Application.StartupPath + "\\Temp\\tmp.pdf";
            //    }
            //}
        }

        public void PrintPdf()
        {
            var settings = new DevExpress.Pdf.PdfPrinterSettings();
            pdfViewer1.DocumentFilePath = System.Windows.Forms.Application.StartupPath + "\\Temp\\tmp.pdf";
            settings.PageOrientation = DevExpress.Pdf.PdfPrintPageOrientation.Landscape;
            pdfViewer1.Print(settings);
        }

        public bool PrintDocument()
        {
            bool Printed = false;

            if (DocFile != string.Empty)
            {
                PdfPrintMode DefaultPrintMode = PdfPrintMode.CutMargin;

                using (var form = new PrintDialog())
                {
                    using (var document = pdfViewer.Document.CreatePrintDocument(DefaultPrintMode))
                    {
                        form.AllowSomePages = true;
                        form.Document = document;
                        form.UseEXDialog = true;
                        form.Document.PrinterSettings.FromPage = 1;
                        form.Document.PrinterSettings.ToPage = pdfViewer.Document.PageCount;

                        if (form.ShowDialog(FindForm()) == DialogResult.OK)
                        {
                            try
                            {
                                if (form.Document.PrinterSettings.FromPage <= pdfViewer.Document.PageCount)
                                {
                                    form.Document.Print();
                                    Printed = true;
                                }
                            }
                            catch
                            {
                                // Ignore exceptions; the printer dialog should take care of this.
                            }
                        }
                    }
                }
            }
            return Printed;
        }

        private void btnClosePreview_Click(object sender, EventArgs e)
        {
            if (ContentIndex == 0)
                ClosePreview(true, false);
            else if (ContentIndex == 1)
                ClosePreview(true, true);
            else if (ContentIndex == 4)
                ClosePreview(true, true);
        }

        public void ClosePreview(bool BackToPage, bool LockInterface)
        {
            ControlPanel.controlPanel.btnTaskMode.Enabled = true;
            if (LockInterface == true)
                MainForm.mainForm.navigationBar.Enabled = false;
            else
                MainForm.mainForm.navigationBar.Enabled = true;
            if (BackToPage == true)
                NavigationPanel.navigationPanel.navigation.SelectedPageIndex = ContentIndex;
            pdfViewer1.CloseDocument();
            ControlPanel.controlPanel.DeleteTemp();
        }
    }
}
