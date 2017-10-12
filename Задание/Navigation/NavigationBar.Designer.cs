namespace Задание
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
            this.TaskGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnApprove = new DevExpress.XtraNavBar.NavBarItem();
            this.btnEvent = new DevExpress.XtraNavBar.NavBarItem();
            this.btnObject = new DevExpress.XtraNavBar.NavBarItem();
            this.btnDocument = new DevExpress.XtraNavBar.NavBarItem();
            this.ReferenceGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnReference = new DevExpress.XtraNavBar.NavBarItem();
            this.ReportGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem18 = new DevExpress.XtraNavBar.NavBarItem();
            this.Settings = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnKeySettings = new DevExpress.XtraNavBar.NavBarItem();
            this.btnPersonalSettings = new DevExpress.XtraNavBar.NavBarItem();
            this.btnPrintBlank = new DevExpress.XtraNavBar.NavBarItem();
            this.btnMarkersSettings = new DevExpress.XtraNavBar.NavBarItem();
            this.btnDivisionsSettings = new DevExpress.XtraNavBar.NavBarItem();
            this.btnTaskApprove = new DevExpress.XtraNavBar.NavBarItem();
            this.btnTaskAccept = new DevExpress.XtraNavBar.NavBarItem();
            this.btnEventSettings = new DevExpress.XtraNavBar.NavBarItem();
            this.btnBaseEventSettings = new DevExpress.XtraNavBar.NavBarItem();
            this.btnColorSettings = new DevExpress.XtraNavBar.NavBarItem();
            this.btnLog = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.NavigationMain)).BeginInit();
            this.SuspendLayout();
            // 
            // NavigationMain
            // 
            this.NavigationMain.ActiveGroup = this.TaskGroup;
            this.NavigationMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.NavigationMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavigationMain.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.NavigationMain.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.TaskGroup,
            this.ReferenceGroup,
            this.ReportGroup,
            this.Settings});
            this.NavigationMain.HotTrackedItemCursor = System.Windows.Forms.Cursors.Arrow;
            this.NavigationMain.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3,
            this.btnApprove,
            this.btnEvent,
            this.btnObject,
            this.btnDocument,
            this.btnReference,
            this.navBarItem18,
            this.btnKeySettings,
            this.btnPersonalSettings,
            this.btnPrintBlank,
            this.btnMarkersSettings,
            this.btnDivisionsSettings,
            this.btnTaskApprove,
            this.btnTaskAccept,
            this.btnEventSettings,
            this.btnBaseEventSettings,
            this.btnColorSettings,
            this.btnLog});
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
            this.NavigationMain.TabIndex = 2;
            this.NavigationMain.Text = "navBarControl1";
            this.NavigationMain.GroupExpanded += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.NavigationMain_GroupExpanded);
            this.NavigationMain.NavPaneStateChanged += new System.EventHandler(this.NavigationMain_NavPaneStateChanged);
            // 
            // TaskGroup
            // 
            this.TaskGroup.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.TaskGroup.Caption = "Задание";
            this.TaskGroup.Expanded = true;
            this.TaskGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.TaskGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnApprove),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnEvent),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnObject),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnDocument)});
            this.TaskGroup.Name = "TaskGroup";
            this.TaskGroup.SelectedLinkIndex = 0;
            // 
            // btnApprove
            // 
            this.btnApprove.CanDrag = false;
            this.btnApprove.Caption = "Согласование";
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnApprove_LinkPressed);
            // 
            // btnEvent
            // 
            this.btnEvent.CanDrag = false;
            this.btnEvent.Caption = "Мероприятие";
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnEvent_LinkPressed);
            // 
            // btnObject
            // 
            this.btnObject.CanDrag = false;
            this.btnObject.Caption = "Объект";
            this.btnObject.Name = "btnObject";
            this.btnObject.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnObject_LinkPressed);
            // 
            // btnDocument
            // 
            this.btnDocument.CanDrag = false;
            this.btnDocument.Caption = "Реквизиты";
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnDocument_LinkPressed);
            // 
            // ReferenceGroup
            // 
            this.ReferenceGroup.Caption = "Справка об объекте";
            this.ReferenceGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.ReferenceGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnReference)});
            this.ReferenceGroup.Name = "ReferenceGroup";
            this.ReferenceGroup.SelectedLinkIndex = 0;
            // 
            // btnReference
            // 
            this.btnReference.CanDrag = false;
            this.btnReference.Caption = "Справка об объекте";
            this.btnReference.Name = "btnReference";
            this.btnReference.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnReference_LinkPressed);
            // 
            // ReportGroup
            // 
            this.ReportGroup.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.ReportGroup.Caption = "Отчет";
            this.ReportGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.ReportGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem18)});
            this.ReportGroup.Name = "ReportGroup";
            this.ReportGroup.SelectedLinkIndex = 0;
            // 
            // navBarItem18
            // 
            this.navBarItem18.Caption = "Отчет по текущему ключу";
            this.navBarItem18.Name = "navBarItem18";
            // 
            // Settings
            // 
            this.Settings.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.Settings.Caption = "Настройки";
            this.Settings.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.Settings.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnKeySettings),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnPersonalSettings),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnPrintBlank),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnMarkersSettings),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnDivisionsSettings),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnTaskApprove),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnTaskAccept),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnEventSettings),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnBaseEventSettings),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnColorSettings),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnLog)});
            this.Settings.Name = "Settings";
            this.Settings.SelectedLinkIndex = 0;
            // 
            // btnKeySettings
            // 
            this.btnKeySettings.CanDrag = false;
            this.btnKeySettings.Caption = "Управление ключами";
            this.btnKeySettings.Name = "btnKeySettings";
            this.btnKeySettings.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnKeySettings_LinkPressed);
            // 
            // btnPersonalSettings
            // 
            this.btnPersonalSettings.CanDrag = false;
            this.btnPersonalSettings.Caption = "Персональные настройки";
            this.btnPersonalSettings.Name = "btnPersonalSettings";
            this.btnPersonalSettings.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnPersonalSettings_LinkPressed);
            // 
            // btnPrintBlank
            // 
            this.btnPrintBlank.CanDrag = false;
            this.btnPrintBlank.Caption = "Печать пустого бланка";
            this.btnPrintBlank.Name = "btnPrintBlank";
            this.btnPrintBlank.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnPrintBlank_LinkPressed);
            // 
            // btnMarkersSettings
            // 
            this.btnMarkersSettings.CanDrag = false;
            this.btnMarkersSettings.Caption = "Управление маркерами";
            this.btnMarkersSettings.Name = "btnMarkersSettings";
            this.btnMarkersSettings.Visible = false;
            this.btnMarkersSettings.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnMarkersSettings_LinkPressed);
            // 
            // btnDivisionsSettings
            // 
            this.btnDivisionsSettings.CanDrag = false;
            this.btnDivisionsSettings.Caption = "Управление подразделениями";
            this.btnDivisionsSettings.Name = "btnDivisionsSettings";
            this.btnDivisionsSettings.Visible = false;
            this.btnDivisionsSettings.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnDivisionsSettings_LinkPressed);
            // 
            // btnTaskApprove
            // 
            this.btnTaskApprove.CanDrag = false;
            this.btnTaskApprove.Caption = "Утверждение задания";
            this.btnTaskApprove.Name = "btnTaskApprove";
            this.btnTaskApprove.Visible = false;
            this.btnTaskApprove.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnTaskApprove_LinkPressed);
            // 
            // btnTaskAccept
            // 
            this.btnTaskAccept.CanDrag = false;
            this.btnTaskAccept.Caption = "Прием задания";
            this.btnTaskAccept.Name = "btnTaskAccept";
            this.btnTaskAccept.Visible = false;
            this.btnTaskAccept.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnTaskAccept_LinkPressed);
            // 
            // btnEventSettings
            // 
            this.btnEventSettings.CanDrag = false;
            this.btnEventSettings.Caption = "Мероприятие";
            this.btnEventSettings.Name = "btnEventSettings";
            this.btnEventSettings.Visible = false;
            this.btnEventSettings.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnEventSettings_LinkPressed);
            // 
            // btnBaseEventSettings
            // 
            this.btnBaseEventSettings.CanDrag = false;
            this.btnBaseEventSettings.Caption = "Основание";
            this.btnBaseEventSettings.Name = "btnBaseEventSettings";
            this.btnBaseEventSettings.Visible = false;
            this.btnBaseEventSettings.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnBaseEventSettings_LinkPressed);
            // 
            // btnColorSettings
            // 
            this.btnColorSettings.CanDrag = false;
            this.btnColorSettings.Caption = "Окраска";
            this.btnColorSettings.Name = "btnColorSettings";
            this.btnColorSettings.Visible = false;
            this.btnColorSettings.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnColorSettings_LinkPressed);
            // 
            // btnLog
            // 
            this.btnLog.CanDrag = false;
            this.btnLog.Caption = "Протокол работы";
            this.btnLog.Name = "btnLog";
            this.btnLog.Visible = false;
            this.btnLog.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnLog_LinkPressed);
            // 
            // navBarItem1
            // 
            this.navBarItem1.CanDrag = false;
            this.navBarItem1.Caption = "navBarItem8";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // navBarItem2
            // 
            this.navBarItem2.CanDrag = false;
            this.navBarItem2.Caption = "navBarItem9";
            this.navBarItem2.Name = "navBarItem2";
            // 
            // navBarItem3
            // 
            this.navBarItem3.CanDrag = false;
            this.navBarItem3.Caption = "navBarItem10";
            this.navBarItem3.Name = "navBarItem3";
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

        private DevExpress.XtraNavBar.NavBarGroup TaskGroup;
        private DevExpress.XtraNavBar.NavBarGroup ReferenceGroup;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarGroup Settings;
        private DevExpress.XtraNavBar.NavBarItem btnKeySettings;
        private DevExpress.XtraNavBar.NavBarItem btnPersonalSettings;
        private DevExpress.XtraNavBar.NavBarItem btnPrintBlank;
        private DevExpress.XtraNavBar.NavBarItem btnMarkersSettings;
        private DevExpress.XtraNavBar.NavBarItem btnDivisionsSettings;
        private DevExpress.XtraNavBar.NavBarItem btnTaskApprove;
        private DevExpress.XtraNavBar.NavBarItem btnTaskAccept;
        private DevExpress.XtraNavBar.NavBarItem btnApprove;
        private DevExpress.XtraNavBar.NavBarItem btnEvent;
        private DevExpress.XtraNavBar.NavBarItem btnObject;
        private DevExpress.XtraNavBar.NavBarItem btnDocument;
        private DevExpress.XtraNavBar.NavBarItem btnReference;
        private DevExpress.XtraNavBar.NavBarGroup ReportGroup;
        private DevExpress.XtraNavBar.NavBarItem navBarItem18;
        private DevExpress.XtraNavBar.NavBarItem btnEventSettings;
        private DevExpress.XtraNavBar.NavBarItem btnBaseEventSettings;
        private DevExpress.XtraNavBar.NavBarItem btnColorSettings;
        private DevExpress.XtraNavBar.NavBarItem btnLog;
        public DevExpress.XtraNavBar.NavBarControl NavigationMain;
    }
}
