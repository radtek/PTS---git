namespace Прием
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
            this.scanControl = new Прием.ScanControl();
            this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.mainSettings = new Прием.MainSettings();
            this.navigationPage3 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.nominalTasks = new Прием.NominalTasks();
            ((System.ComponentModel.ISupportInitialize)(this.navigation)).BeginInit();
            this.navigation.SuspendLayout();
            this.navigationPage1.SuspendLayout();
            this.navigationPage2.SuspendLayout();
            this.navigationPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigation
            // 
            this.navigation.Controls.Add(this.navigationPage1);
            this.navigation.Controls.Add(this.navigationPage2);
            this.navigation.Controls.Add(this.navigationPage3);
            this.navigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigation.Location = new System.Drawing.Point(0, 0);
            this.navigation.Name = "navigation";
            this.navigation.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage1,
            this.navigationPage2,
            this.navigationPage3});
            this.navigation.SelectedPage = this.navigationPage1;
            this.navigation.Size = new System.Drawing.Size(964, 624);
            this.navigation.TabIndex = 0;
            this.navigation.Text = "navigationFrame1";
            this.navigation.TransitionAnimationProperties.FrameInterval = 3000;
            // 
            // navigationPage1
            // 
            this.navigationPage1.Caption = "navigationPage1";
            this.navigationPage1.Controls.Add(this.scanControl);
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(964, 624);
            // 
            // scanControl
            // 
            this.scanControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scanControl.Location = new System.Drawing.Point(0, 0);
            this.scanControl.Name = "scanControl";
            this.scanControl.Size = new System.Drawing.Size(964, 624);
            this.scanControl.TabIndex = 0;
            // 
            // navigationPage2
            // 
            this.navigationPage2.Caption = "navigationPage2";
            this.navigationPage2.Controls.Add(this.mainSettings);
            this.navigationPage2.Name = "navigationPage2";
            this.navigationPage2.Size = new System.Drawing.Size(964, 624);
            // 
            // mainSettings
            // 
            this.mainSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSettings.Location = new System.Drawing.Point(0, 0);
            this.mainSettings.Name = "mainSettings";
            this.mainSettings.Size = new System.Drawing.Size(964, 624);
            this.mainSettings.TabIndex = 0;
            // 
            // navigationPage3
            // 
            this.navigationPage3.Controls.Add(this.nominalTasks);
            this.navigationPage3.Name = "navigationPage3";
            this.navigationPage3.Size = new System.Drawing.Size(964, 624);
            // 
            // nominalTasks
            // 
            this.nominalTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nominalTasks.Location = new System.Drawing.Point(0, 0);
            this.nominalTasks.Name = "nominalTasks";
            this.nominalTasks.Size = new System.Drawing.Size(964, 624);
            this.nominalTasks.TabIndex = 0;
            // 
            // NavigationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigation);
            this.Name = "NavigationPanel";
            this.Size = new System.Drawing.Size(964, 624);
            ((System.ComponentModel.ISupportInitialize)(this.navigation)).EndInit();
            this.navigation.ResumeLayout(false);
            this.navigationPage1.ResumeLayout(false);
            this.navigationPage2.ResumeLayout(false);
            this.navigationPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
        public DevExpress.XtraBars.Navigation.NavigationFrame navigation;
        private ScanControl scanControl;
        public MainSettings mainSettings;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage3;
        private NominalTasks nominalTasks;
    }
}
