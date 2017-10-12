namespace Задание
{
    partial class NavigationPanel
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
            this.navigation = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage3 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage4 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage5 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.task = new Задание.Task();
            this.reference = new Задание.Reference();
            this.preview = new Задание.Preview();
            this.settingsManager = new Задание.SettingsManager();
            this.report = new Задание.Report();
            ((System.ComponentModel.ISupportInitialize)(this.navigation)).BeginInit();
            this.navigation.SuspendLayout();
            this.navigationPage1.SuspendLayout();
            this.navigationPage2.SuspendLayout();
            this.navigationPage3.SuspendLayout();
            this.navigationPage4.SuspendLayout();
            this.navigationPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigation
            // 
            this.navigation.Controls.Add(this.navigationPage1);
            this.navigation.Controls.Add(this.navigationPage2);
            this.navigation.Controls.Add(this.navigationPage3);
            this.navigation.Controls.Add(this.navigationPage4);
            this.navigation.Controls.Add(this.navigationPage5);
            this.navigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigation.Location = new System.Drawing.Point(0, 0);
            this.navigation.Name = "navigation";
            this.navigation.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage1,
            this.navigationPage2,
            this.navigationPage3,
            this.navigationPage4,
            this.navigationPage5});
            this.navigation.SelectedPage = this.navigationPage1;
            this.navigation.Size = new System.Drawing.Size(800, 681);
            this.navigation.TabIndex = 0;
            this.navigation.Text = "navigation";
            this.navigation.TransitionAnimationProperties.FrameInterval = 3000;
            // 
            // navigationPage1
            // 
            this.navigationPage1.Caption = "navigationPage1";
            this.navigationPage1.Controls.Add(this.task);
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(800, 681);
            // 
            // navigationPage2
            // 
            this.navigationPage2.Caption = "navigationPage2";
            this.navigationPage2.Controls.Add(this.reference);
            this.navigationPage2.Name = "navigationPage2";
            this.navigationPage2.Size = new System.Drawing.Size(800, 681);
            // 
            // navigationPage3
            // 
            this.navigationPage3.Caption = "navigationPage3";
            this.navigationPage3.Controls.Add(this.preview);
            this.navigationPage3.Name = "navigationPage3";
            this.navigationPage3.Size = new System.Drawing.Size(800, 681);
            // 
            // navigationPage4
            // 
            this.navigationPage4.Caption = "navigationPage4";
            this.navigationPage4.Controls.Add(this.settingsManager);
            this.navigationPage4.Name = "navigationPage4";
            this.navigationPage4.Size = new System.Drawing.Size(800, 681);
            // 
            // navigationPage5
            // 
            this.navigationPage5.Caption = "navigationPage5";
            this.navigationPage5.Controls.Add(this.report);
            this.navigationPage5.Name = "navigationPage5";
            this.navigationPage5.Size = new System.Drawing.Size(800, 681);
            // 
            // task
            // 
            this.task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.task.Location = new System.Drawing.Point(0, 0);
            this.task.Name = "task";
            this.task.Size = new System.Drawing.Size(800, 681);
            this.task.TabIndex = 0;
            // 
            // reference
            // 
            this.reference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reference.Location = new System.Drawing.Point(0, 0);
            this.reference.Name = "reference";
            this.reference.Size = new System.Drawing.Size(800, 681);
            this.reference.TabIndex = 0;
            // 
            // preview
            // 
            this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preview.Location = new System.Drawing.Point(0, 0);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(800, 681);
            this.preview.TabIndex = 0;
            // 
            // settingsManager
            // 
            this.settingsManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsManager.Location = new System.Drawing.Point(0, 0);
            this.settingsManager.Name = "settingsManager";
            this.settingsManager.Size = new System.Drawing.Size(800, 681);
            this.settingsManager.TabIndex = 0;
            // 
            // report
            // 
            this.report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.report.Location = new System.Drawing.Point(0, 0);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(800, 681);
            this.report.TabIndex = 0;
            // 
            // NavigationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigation);
            this.Name = "NavigationPanel";
            this.Size = new System.Drawing.Size(800, 681);
            ((System.ComponentModel.ISupportInitialize)(this.navigation)).EndInit();
            this.navigation.ResumeLayout(false);
            this.navigationPage1.ResumeLayout(false);
            this.navigationPage2.ResumeLayout(false);
            this.navigationPage3.ResumeLayout(false);
            this.navigationPage4.ResumeLayout(false);
            this.navigationPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
        public DevExpress.XtraBars.Navigation.NavigationFrame navigation;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage3;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage4;
        private SettingsManager settingsManager;
        private Task task;
        private Preview preview;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage5;
        private Reference reference;
        private Report report;

    }
}
