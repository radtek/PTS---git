namespace Прием
{
    partial class NavigationBar
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
            this.NavigationMain = new DevExpress.XtraNavBar.NavBarControl();
            this.ScanGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnScan = new DevExpress.XtraNavBar.NavBarItem();
            this.btnConditionalTask = new DevExpress.XtraNavBar.NavBarItem();
            this.SettingsGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnMainSettings = new DevExpress.XtraNavBar.NavBarItem();
            this.ImportGroup = new DevExpress.XtraNavBar.NavBarGroup();
            ((System.ComponentModel.ISupportInitialize)(this.NavigationMain)).BeginInit();
            this.SuspendLayout();
            // 
            // NavigationMain
            // 
            this.NavigationMain.ActiveGroup = this.ScanGroup;
            this.NavigationMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.NavigationMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavigationMain.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.NavigationMain.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.ScanGroup,
            this.SettingsGroup,
            this.ImportGroup});
            this.NavigationMain.HotTrackedItemCursor = System.Windows.Forms.Cursors.Arrow;
            this.NavigationMain.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnScan,
            this.btnConditionalTask,
            this.btnMainSettings});
            this.NavigationMain.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInGroupAndAllowAutoSelect;
            this.NavigationMain.Location = new System.Drawing.Point(0, 0);
            this.NavigationMain.Name = "NavigationMain";
            this.NavigationMain.OptionsNavPane.ExpandedWidth = 167;
            this.NavigationMain.OptionsNavPane.ShowGroupImageInHeader = true;
            this.NavigationMain.OptionsNavPane.ShowOverflowButton = false;
            this.NavigationMain.OptionsNavPane.ShowOverflowPanel = false;
            this.NavigationMain.OptionsNavPane.ShowSplitter = false;
            this.NavigationMain.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.NavigationMain.Size = new System.Drawing.Size(167, 665);
            this.NavigationMain.TabIndex = 3;
            this.NavigationMain.Text = "navBarControl1";
            this.NavigationMain.NavPaneStateChanged += new System.EventHandler(this.NavigationMain_NavPaneStateChanged);
            // 
            // ScanGroup
            // 
            this.ScanGroup.Caption = "Сканирование";
            this.ScanGroup.Expanded = true;
            this.ScanGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnScan),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnConditionalTask)});
            this.ScanGroup.Name = "ScanGroup";
            this.ScanGroup.SelectedLinkIndex = 0;
            // 
            // btnScan
            // 
            this.btnScan.Caption = "Новое сканирование";
            this.btnScan.Name = "btnScan";
            this.btnScan.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnScan_LinkPressed);
            // 
            // btnConditionalTask
            // 
            this.btnConditionalTask.Caption = "Условное задание";
            this.btnConditionalTask.Name = "btnConditionalTask";
            this.btnConditionalTask.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnConditionalTask_LinkPressed);
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.Caption = "Настройки";
            this.SettingsGroup.Expanded = true;
            this.SettingsGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnMainSettings)});
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.SelectedLinkIndex = 0;
            // 
            // btnMainSettings
            // 
            this.btnMainSettings.Caption = "Основные настройки";
            this.btnMainSettings.Name = "btnMainSettings";
            this.btnMainSettings.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnMainSettings_LinkPressed);
            // 
            // ImportGroup
            // 
            this.ImportGroup.Caption = "Мастер импорта";
            this.ImportGroup.Name = "ImportGroup";
            // 
            // NavigationBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NavigationMain);
            this.Name = "NavigationBar";
            this.Size = new System.Drawing.Size(167, 665);
            ((System.ComponentModel.ISupportInitialize)(this.NavigationMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraNavBar.NavBarControl NavigationMain;
        private DevExpress.XtraNavBar.NavBarGroup ScanGroup;
        private DevExpress.XtraNavBar.NavBarItem btnScan;
        private DevExpress.XtraNavBar.NavBarItem btnConditionalTask;
        private DevExpress.XtraNavBar.NavBarGroup SettingsGroup;
        private DevExpress.XtraNavBar.NavBarItem btnMainSettings;
        private DevExpress.XtraNavBar.NavBarGroup ImportGroup;

    }
}
