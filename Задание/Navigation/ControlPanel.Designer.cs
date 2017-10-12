namespace Задание
{
    partial class ControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            this.navigation = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.btnTaskMode = new DevExpress.XtraEditors.SimpleButton();
            this.separatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
            this.btnTaskPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnTaskPreview = new DevExpress.XtraEditors.SimpleButton();
            this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.btnRefMode = new DevExpress.XtraEditors.SimpleButton();
            this.separator = new DevExpress.XtraEditors.SeparatorControl();
            this.btnRefDocumentPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefPreview = new DevExpress.XtraEditors.SimpleButton();
            this.navigationPage3 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.btnPrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreviewReport = new DevExpress.XtraEditors.SimpleButton();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelTaskNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigation)).BeginInit();
            this.navigation.SuspendLayout();
            this.navigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).BeginInit();
            this.navigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).BeginInit();
            this.navigationPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl.Controls.Add(this.navigation);
            this.panelControl.Controls.Add(this.separatorControl1);
            this.panelControl.Controls.Add(this.labelControl1);
            this.panelControl.Controls.Add(this.labelTaskNo);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1226, 46);
            this.panelControl.TabIndex = 1;
            // 
            // navigation
            // 
            this.navigation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navigation.Controls.Add(this.navigationPage1);
            this.navigation.Controls.Add(this.navigationPage2);
            this.navigation.Controls.Add(this.navigationPage3);
            this.navigation.Location = new System.Drawing.Point(187, 0);
            this.navigation.Name = "navigation";
            this.navigation.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage1,
            this.navigationPage2,
            this.navigationPage3});
            this.navigation.SelectedPage = this.navigationPage1;
            this.navigation.Size = new System.Drawing.Size(1039, 46);
            this.navigation.TabIndex = 8;
            this.navigation.Text = "navigationFrame1";
            this.navigation.TransitionAnimationProperties.FrameInterval = 3000;
            this.navigation.TransitionType = DevExpress.Utils.Animation.Transitions.Fade;
            // 
            // navigationPage1
            // 
            this.navigationPage1.Caption = "navigationPage1";
            this.navigationPage1.Controls.Add(this.btnTaskMode);
            this.navigationPage1.Controls.Add(this.separatorControl2);
            this.navigationPage1.Controls.Add(this.btnTaskPrint);
            this.navigationPage1.Controls.Add(this.btnTaskPreview);
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(1039, 46);
            // 
            // btnTaskMode
            // 
            this.btnTaskMode.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskMode.Image")));
            this.btnTaskMode.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnTaskMode.Location = new System.Drawing.Point(245, 3);
            this.btnTaskMode.Name = "btnTaskMode";
            this.btnTaskMode.Size = new System.Drawing.Size(125, 40);
            this.btnTaskMode.TabIndex = 18;
            this.btnTaskMode.TabStop = false;
            this.btnTaskMode.Text = "Режим работы";
            this.btnTaskMode.Click += new System.EventHandler(this.btnTaskMode_Click);
            // 
            // separatorControl2
            // 
            this.separatorControl2.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl2.Location = new System.Drawing.Point(211, 0);
            this.separatorControl2.Name = "separatorControl2";
            this.separatorControl2.Size = new System.Drawing.Size(28, 46);
            this.separatorControl2.TabIndex = 17;
            // 
            // btnTaskPrint
            // 
            this.btnTaskPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskPrint.Image")));
            this.btnTaskPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnTaskPrint.Location = new System.Drawing.Point(107, 3);
            this.btnTaskPrint.Name = "btnTaskPrint";
            this.btnTaskPrint.Size = new System.Drawing.Size(98, 40);
            this.btnTaskPrint.TabIndex = 15;
            this.btnTaskPrint.TabStop = false;
            this.btnTaskPrint.Text = "Печать";
            this.btnTaskPrint.Click += new System.EventHandler(this.btnTaskPrint_Click);
            // 
            // btnTaskPreview
            // 
            this.btnTaskPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskPreview.Image")));
            this.btnTaskPreview.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnTaskPreview.Location = new System.Drawing.Point(3, 3);
            this.btnTaskPreview.Name = "btnTaskPreview";
            this.btnTaskPreview.Size = new System.Drawing.Size(98, 40);
            this.btnTaskPreview.TabIndex = 16;
            this.btnTaskPreview.TabStop = false;
            this.btnTaskPreview.Text = "Просмотр";
            this.btnTaskPreview.Click += new System.EventHandler(this.btnTaskPreview_Click);
            // 
            // navigationPage2
            // 
            this.navigationPage2.Caption = "navigationPage2";
            this.navigationPage2.Controls.Add(this.btnRefMode);
            this.navigationPage2.Controls.Add(this.separator);
            this.navigationPage2.Controls.Add(this.btnRefDocumentPrint);
            this.navigationPage2.Controls.Add(this.btnRefPrint);
            this.navigationPage2.Controls.Add(this.btnRefPreview);
            this.navigationPage2.Name = "navigationPage2";
            this.navigationPage2.Size = new System.Drawing.Size(1039, 46);
            // 
            // btnRefMode
            // 
            this.btnRefMode.Image = ((System.Drawing.Image)(resources.GetObject("btnRefMode.Image")));
            this.btnRefMode.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRefMode.Location = new System.Drawing.Point(356, 3);
            this.btnRefMode.Name = "btnRefMode";
            this.btnRefMode.Size = new System.Drawing.Size(125, 40);
            this.btnRefMode.TabIndex = 13;
            this.btnRefMode.TabStop = false;
            this.btnRefMode.Text = "Режим работы";
            this.btnRefMode.Click += new System.EventHandler(this.btnRefMode_Click);
            // 
            // separator
            // 
            this.separator.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separator.Location = new System.Drawing.Point(322, 0);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(28, 46);
            this.separator.TabIndex = 12;
            // 
            // btnRefDocumentPrint
            // 
            this.btnRefDocumentPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnRefDocumentPrint.Image")));
            this.btnRefDocumentPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRefDocumentPrint.Location = new System.Drawing.Point(211, 3);
            this.btnRefDocumentPrint.Name = "btnRefDocumentPrint";
            this.btnRefDocumentPrint.Size = new System.Drawing.Size(105, 40);
            this.btnRefDocumentPrint.TabIndex = 9;
            this.btnRefDocumentPrint.TabStop = false;
            this.btnRefDocumentPrint.Text = "Печать\r\nреквизитов";
            this.btnRefDocumentPrint.Click += new System.EventHandler(this.btnRefDocumentPrint_Click);
            // 
            // btnRefPrint
            // 
            this.btnRefPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnRefPrint.Image")));
            this.btnRefPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRefPrint.Location = new System.Drawing.Point(107, 3);
            this.btnRefPrint.Name = "btnRefPrint";
            this.btnRefPrint.Size = new System.Drawing.Size(98, 40);
            this.btnRefPrint.TabIndex = 10;
            this.btnRefPrint.TabStop = false;
            this.btnRefPrint.Text = "Печать";
            this.btnRefPrint.Click += new System.EventHandler(this.btnRefPrint_Click);
            // 
            // btnRefPreview
            // 
            this.btnRefPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnRefPreview.Image")));
            this.btnRefPreview.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRefPreview.Location = new System.Drawing.Point(3, 3);
            this.btnRefPreview.Name = "btnRefPreview";
            this.btnRefPreview.Size = new System.Drawing.Size(98, 40);
            this.btnRefPreview.TabIndex = 11;
            this.btnRefPreview.TabStop = false;
            this.btnRefPreview.Text = "Просмотр";
            this.btnRefPreview.Click += new System.EventHandler(this.btnRefPreview_Click);
            // 
            // navigationPage3
            // 
            this.navigationPage3.Caption = "navigationPage3";
            this.navigationPage3.Controls.Add(this.btnPrintReport);
            this.navigationPage3.Controls.Add(this.btnPreviewReport);
            this.navigationPage3.Name = "navigationPage3";
            this.navigationPage3.Size = new System.Drawing.Size(1039, 46);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintReport.Image")));
            this.btnPrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrintReport.Location = new System.Drawing.Point(107, 3);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(98, 40);
            this.btnPrintReport.TabIndex = 17;
            this.btnPrintReport.TabStop = false;
            this.btnPrintReport.Text = "Печать";
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnPreviewReport
            // 
            this.btnPreviewReport.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewReport.Image")));
            this.btnPreviewReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPreviewReport.Location = new System.Drawing.Point(3, 3);
            this.btnPreviewReport.Name = "btnPreviewReport";
            this.btnPreviewReport.Size = new System.Drawing.Size(98, 40);
            this.btnPreviewReport.TabIndex = 18;
            this.btnPreviewReport.TabStop = false;
            this.btnPreviewReport.Text = "Просмотр";
            this.btnPreviewReport.Click += new System.EventHandler(this.btnPreviewReport_Click);
            // 
            // separatorControl1
            // 
            this.separatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl1.Location = new System.Drawing.Point(152, 0);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(28, 46);
            this.separatorControl1.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 25);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "№";
            // 
            // labelTaskNo
            // 
            this.labelTaskNo.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTaskNo.Location = new System.Drawing.Point(42, 12);
            this.labelTaskNo.Name = "labelTaskNo";
            this.labelTaskNo.Size = new System.Drawing.Size(0, 25);
            this.labelTaskNo.TabIndex = 4;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(1226, 46);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigation)).EndInit();
            this.navigation.ResumeLayout(false);
            this.navigationPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).EndInit();
            this.navigationPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.separator)).EndInit();
            this.navigationPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        public DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LabelControl labelTaskNo;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        public DevExpress.XtraEditors.SimpleButton btnTaskMode;
        public DevExpress.XtraEditors.SeparatorControl separatorControl2;
        private DevExpress.XtraEditors.SimpleButton btnTaskPrint;
        private DevExpress.XtraEditors.SimpleButton btnTaskPreview;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
        public DevExpress.XtraEditors.SimpleButton btnRefMode;
        public DevExpress.XtraEditors.SeparatorControl separator;
        public DevExpress.XtraEditors.SimpleButton btnRefDocumentPrint;
        private DevExpress.XtraEditors.SimpleButton btnRefPrint;
        private DevExpress.XtraEditors.SimpleButton btnRefPreview;
        public DevExpress.XtraBars.Navigation.NavigationFrame navigation;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage3;
        private DevExpress.XtraEditors.SimpleButton btnPrintReport;
        private DevExpress.XtraEditors.SimpleButton btnPreviewReport;
    }
}
