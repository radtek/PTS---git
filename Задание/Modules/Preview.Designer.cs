namespace Задание
{
    partial class Preview
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClosePreview = new DevExpress.XtraEditors.SimpleButton();
            this.pdfViewer = new PdfiumViewer.PdfViewer();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnClosePreview);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(732, 46);
            this.panelControl1.TabIndex = 0;
            // 
            // btnClosePreview
            // 
            this.btnClosePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClosePreview.Image = ((System.Drawing.Image)(resources.GetObject("btnClosePreview.Image")));
            this.btnClosePreview.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnClosePreview.Location = new System.Drawing.Point(582, 3);
            this.btnClosePreview.Name = "btnClosePreview";
            this.btnClosePreview.Size = new System.Drawing.Size(147, 40);
            this.btnClosePreview.TabIndex = 9;
            this.btnClosePreview.TabStop = false;
            this.btnClosePreview.Text = "Закрыть просмотр";
            this.btnClosePreview.Click += new System.EventHandler(this.btnClosePreview_Click);
            // 
            // pdfViewer
            // 
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Location = new System.Drawing.Point(0, 46);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.ShowBookmarks = false;
            this.pdfViewer.ShowToolbar = false;
            this.pdfViewer.Size = new System.Drawing.Size(732, 474);
            this.pdfViewer.TabIndex = 1;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.AcceptsTab = false;
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.HandTool = true;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 46);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.NavigationPaneInitialVisibility = DevExpress.XtraPdfViewer.PdfNavigationPaneVisibility.Hidden;
            this.pdfViewer1.ReadOnly = true;
            this.pdfViewer1.ShowPrintStatusDialog = false;
            this.pdfViewer1.Size = new System.Drawing.Size(732, 474);
            this.pdfViewer1.TabIndex = 2;
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.pdfViewer);
            this.Controls.Add(this.panelControl1);
            this.Name = "Preview";
            this.Size = new System.Drawing.Size(732, 520);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClosePreview;
        public PdfiumViewer.PdfViewer pdfViewer;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
    }
}
