namespace Задание
{
    partial class BlankControl
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
            this.recentItemControl = new DevExpress.XtraBars.Ribbon.RecentItemControl();
            this.recentStackPanel1 = new DevExpress.XtraBars.Ribbon.RecentStackPanel();
            this.recentStackPanel2 = new DevExpress.XtraBars.Ribbon.RecentStackPanel();
            this.recentStackPanel3 = new DevExpress.XtraBars.Ribbon.RecentStackPanel();
            this.recentTabItem1 = new DevExpress.XtraBars.Ribbon.RecentTabItem();
            this.recentStackPanel4 = new DevExpress.XtraBars.Ribbon.RecentStackPanel();
            this.recentTabItem2 = new DevExpress.XtraBars.Ribbon.RecentTabItem();
            this.recentControlContainerItem1 = new DevExpress.XtraBars.Ribbon.RecentControlContainerItem();
            this.recentControlItemControlContainer1 = new DevExpress.XtraBars.Ribbon.RecentControlItemControlContainer();
            this.recentSeparatorItem1 = new DevExpress.XtraBars.Ribbon.RecentSeparatorItem();
            this.recentControlContainerItem2 = new DevExpress.XtraBars.Ribbon.RecentControlContainerItem();
            this.recentControlItemControlContainer2 = new DevExpress.XtraBars.Ribbon.RecentControlItemControlContainer();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.cbChar = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tbNumber = new DevExpress.XtraEditors.TextEdit();
            this.recentControlContainerItem3 = new DevExpress.XtraBars.Ribbon.RecentControlContainerItem();
            this.recentControlItemControlContainer3 = new DevExpress.XtraBars.Ribbon.RecentControlItemControlContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BlankNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PrintDT = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.recentItemControl)).BeginInit();
            this.recentItemControl.SuspendLayout();
            this.recentControlItemControlContainer1.SuspendLayout();
            this.recentControlItemControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbChar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumber.Properties)).BeginInit();
            this.recentControlItemControlContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // recentItemControl
            // 
            this.recentItemControl.Appearances.RecentItemControl.BackColor = System.Drawing.Color.Gainsboro;
            this.recentItemControl.Appearances.RecentItemControl.Options.UseBackColor = true;
            this.recentItemControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.recentItemControl.Controls.Add(this.recentControlItemControlContainer1);
            this.recentItemControl.Controls.Add(this.recentControlItemControlContainer2);
            this.recentItemControl.Controls.Add(this.recentControlItemControlContainer3);
            this.recentItemControl.DefaultContentPanel = this.recentStackPanel1;
            this.recentItemControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentItemControl.Location = new System.Drawing.Point(0, 0);
            this.recentItemControl.LookAndFeel.SkinName = "Office 2016 Black";
            this.recentItemControl.MainPanel = this.recentStackPanel2;
            this.recentItemControl.MinimumSize = new System.Drawing.Size(330, 100);
            this.recentItemControl.Name = "recentItemControl";
            this.recentItemControl.SelectedTab = this.recentTabItem1;
            this.recentItemControl.Size = new System.Drawing.Size(855, 590);
            this.recentItemControl.SplitterPosition = 275;
            this.recentItemControl.TabIndex = 2;
            this.recentItemControl.Text = "recentItemControl1";
            this.recentItemControl.Title = "Печать пустого бланка задания";
            // 
            // recentStackPanel1
            // 
            this.recentStackPanel1.Name = "recentStackPanel1";
            // 
            // recentStackPanel2
            // 
            this.recentStackPanel2.Items.AddRange(new DevExpress.XtraBars.Ribbon.RecentItemBase[] {
            this.recentTabItem1,
            this.recentTabItem2});
            this.recentStackPanel2.Name = "recentStackPanel2";
            // 
            // recentStackPanel3
            // 
            this.recentStackPanel3.Caption = "Печать бланка";
            this.recentStackPanel3.Items.AddRange(new DevExpress.XtraBars.Ribbon.RecentItemBase[] {
            this.recentControlContainerItem1,
            this.recentSeparatorItem1,
            this.recentControlContainerItem2});
            this.recentStackPanel3.Name = "recentStackPanel3";
            // 
            // recentTabItem1
            // 
            this.recentTabItem1.Caption = "Печать бланка";
            this.recentTabItem1.Name = "recentTabItem1";
            this.recentTabItem1.SuperTip = null;
            this.recentTabItem1.TabPanel = this.recentStackPanel3;
            // 
            // recentStackPanel4
            // 
            this.recentStackPanel4.Caption = "История бланков";
            this.recentStackPanel4.Items.AddRange(new DevExpress.XtraBars.Ribbon.RecentItemBase[] {
            this.recentControlContainerItem3});
            this.recentStackPanel4.Name = "recentStackPanel4";
            // 
            // recentTabItem2
            // 
            this.recentTabItem2.Caption = "История бланков";
            this.recentTabItem2.Name = "recentTabItem2";
            this.recentTabItem2.SuperTip = null;
            this.recentTabItem2.TabPanel = this.recentStackPanel4;
            // 
            // recentControlContainerItem1
            // 
            this.recentControlContainerItem1.ClientHeight = 24;
            this.recentControlContainerItem1.ControlContainer = this.recentControlItemControlContainer1;
            this.recentControlContainerItem1.Name = "recentControlContainerItem1";
            this.recentControlContainerItem1.SuperTip = null;
            // 
            // recentControlItemControlContainer1
            // 
            this.recentControlItemControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.recentControlItemControlContainer1.Appearance.Options.UseBackColor = true;
            this.recentControlItemControlContainer1.Controls.Add(this.tbNumber);
            this.recentControlItemControlContainer1.Controls.Add(this.labelControl2);
            this.recentControlItemControlContainer1.Controls.Add(this.labelControl1);
            this.recentControlItemControlContainer1.Controls.Add(this.cbChar);
            this.recentControlItemControlContainer1.Name = "recentControlItemControlContainer1";
            this.recentControlItemControlContainer1.Size = new System.Drawing.Size(529, 24);
            this.recentControlItemControlContainer1.TabIndex = 1;
            // 
            // recentSeparatorItem1
            // 
            this.recentSeparatorItem1.Name = "recentSeparatorItem1";
            this.recentSeparatorItem1.SuperTip = null;
            // 
            // recentControlContainerItem2
            // 
            this.recentControlContainerItem2.ClientHeight = 30;
            this.recentControlContainerItem2.ControlContainer = this.recentControlItemControlContainer2;
            this.recentControlContainerItem2.Name = "recentControlContainerItem2";
            this.recentControlContainerItem2.SuperTip = null;
            // 
            // recentControlItemControlContainer2
            // 
            this.recentControlItemControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.recentControlItemControlContainer2.Appearance.Options.UseBackColor = true;
            this.recentControlItemControlContainer2.Controls.Add(this.btnPrint);
            this.recentControlItemControlContainer2.Name = "recentControlItemControlContainer2";
            this.recentControlItemControlContainer2.Size = new System.Drawing.Size(529, 30);
            this.recentControlItemControlContainer2.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(3, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Печать";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbChar
            // 
            this.cbChar.Location = new System.Drawing.Point(39, 1);
            this.cbChar.Name = "cbChar";
            this.cbChar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbChar.Properties.DropDownRows = 15;
            this.cbChar.Properties.Items.AddRange(new object[] {
            "А",
            "Б",
            "В",
            "Г",
            "Д",
            "Е",
            "Ж",
            "З",
            "И",
            "К",
            "Л",
            "М",
            "Н",
            "О",
            "П",
            "Р",
            "С",
            "Т",
            "У",
            "Ф",
            "Х",
            "Ц",
            "Ч",
            "Ш",
            "Щ",
            "Э",
            "Ю",
            "Я"});
            this.cbChar.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbChar.Size = new System.Drawing.Size(49, 20);
            this.cbChar.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Буква";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(94, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Номер";
            // 
            // tbNumber
            // 
            this.tbNumber.EditValue = "";
            this.tbNumber.Location = new System.Drawing.Point(131, 1);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Properties.Mask.EditMask = "[0-9]+";
            this.tbNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tbNumber.Properties.MaxLength = 5;
            this.tbNumber.Size = new System.Drawing.Size(56, 20);
            this.tbNumber.TabIndex = 3;
            // 
            // recentControlContainerItem3
            // 
            this.recentControlContainerItem3.ClientHeight = 313;
            this.recentControlContainerItem3.ControlContainer = this.recentControlItemControlContainer3;
            this.recentControlContainerItem3.Name = "recentControlContainerItem3";
            this.recentControlContainerItem3.SuperTip = null;
            // 
            // recentControlItemControlContainer3
            // 
            this.recentControlItemControlContainer3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.recentControlItemControlContainer3.Appearance.Options.UseBackColor = true;
            this.recentControlItemControlContainer3.Controls.Add(this.gridControl1);
            this.recentControlItemControlContainer3.Name = "recentControlItemControlContainer3";
            this.recentControlItemControlContainer3.Size = new System.Drawing.Size(529, 313);
            this.recentControlItemControlContainer3.TabIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(529, 313);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.UserID,
            this.BlankNo,
            this.PrintDT});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.OptionsColumn.AllowFocus = false;
            this.ID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ID.OptionsColumn.AllowIncrementalSearch = false;
            this.ID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ID.OptionsColumn.AllowMove = false;
            this.ID.OptionsColumn.AllowShowHide = false;
            this.ID.OptionsColumn.AllowSize = false;
            this.ID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ID.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.ID.OptionsColumn.ReadOnly = true;
            // 
            // UserID
            // 
            this.UserID.Caption = "Пользователь";
            this.UserID.FieldName = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.OptionsColumn.AllowEdit = false;
            this.UserID.OptionsColumn.AllowFocus = false;
            this.UserID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.UserID.OptionsColumn.AllowIncrementalSearch = false;
            this.UserID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.UserID.OptionsColumn.AllowMove = false;
            this.UserID.OptionsColumn.AllowShowHide = false;
            this.UserID.OptionsColumn.AllowSize = false;
            this.UserID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.UserID.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.UserID.OptionsColumn.ReadOnly = true;
            // 
            // BlankNo
            // 
            this.BlankNo.Caption = "Номер бланка";
            this.BlankNo.FieldName = "BlankNo";
            this.BlankNo.Name = "BlankNo";
            this.BlankNo.OptionsColumn.AllowEdit = false;
            this.BlankNo.OptionsColumn.AllowFocus = false;
            this.BlankNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.BlankNo.OptionsColumn.AllowIncrementalSearch = false;
            this.BlankNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.BlankNo.OptionsColumn.AllowMove = false;
            this.BlankNo.OptionsColumn.AllowShowHide = false;
            this.BlankNo.OptionsColumn.AllowSize = false;
            this.BlankNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.BlankNo.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.BlankNo.OptionsColumn.ReadOnly = true;
            this.BlankNo.Visible = true;
            this.BlankNo.VisibleIndex = 0;
            // 
            // PrintDT
            // 
            this.PrintDT.Caption = "Дата печати";
            this.PrintDT.FieldName = "PrintDT";
            this.PrintDT.Name = "PrintDT";
            this.PrintDT.OptionsColumn.AllowEdit = false;
            this.PrintDT.OptionsColumn.AllowFocus = false;
            this.PrintDT.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.PrintDT.OptionsColumn.AllowIncrementalSearch = false;
            this.PrintDT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PrintDT.OptionsColumn.AllowMove = false;
            this.PrintDT.OptionsColumn.AllowShowHide = false;
            this.PrintDT.OptionsColumn.AllowSize = false;
            this.PrintDT.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.PrintDT.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.PrintDT.OptionsColumn.ReadOnly = true;
            this.PrintDT.Visible = true;
            this.PrintDT.VisibleIndex = 1;
            // 
            // BlankControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.recentItemControl);
            this.Name = "BlankControl";
            this.Size = new System.Drawing.Size(855, 590);
            ((System.ComponentModel.ISupportInitialize)(this.recentItemControl)).EndInit();
            this.recentItemControl.ResumeLayout(false);
            this.recentControlItemControlContainer1.ResumeLayout(false);
            this.recentControlItemControlContainer1.PerformLayout();
            this.recentControlItemControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbChar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumber.Properties)).EndInit();
            this.recentControlItemControlContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraBars.Ribbon.RecentItemControl recentItemControl;
        private DevExpress.XtraBars.Ribbon.RecentStackPanel recentStackPanel1;
        private DevExpress.XtraBars.Ribbon.RecentStackPanel recentStackPanel2;
        private DevExpress.XtraBars.Ribbon.RecentTabItem recentTabItem1;
        private DevExpress.XtraBars.Ribbon.RecentStackPanel recentStackPanel3;
        private DevExpress.XtraBars.Ribbon.RecentTabItem recentTabItem2;
        private DevExpress.XtraBars.Ribbon.RecentStackPanel recentStackPanel4;
        private DevExpress.XtraBars.Ribbon.RecentControlItemControlContainer recentControlItemControlContainer1;
        private DevExpress.XtraBars.Ribbon.RecentControlContainerItem recentControlContainerItem1;
        private DevExpress.XtraBars.Ribbon.RecentControlItemControlContainer recentControlItemControlContainer2;
        private DevExpress.XtraBars.Ribbon.RecentSeparatorItem recentSeparatorItem1;
        private DevExpress.XtraBars.Ribbon.RecentControlContainerItem recentControlContainerItem2;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.TextEdit tbNumber;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbChar;
        private DevExpress.XtraBars.Ribbon.RecentControlItemControlContainer recentControlItemControlContainer3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn UserID;
        private DevExpress.XtraGrid.Columns.GridColumn BlankNo;
        private DevExpress.XtraGrid.Columns.GridColumn PrintDT;
        private DevExpress.XtraBars.Ribbon.RecentControlContainerItem recentControlContainerItem3;
    }
}
