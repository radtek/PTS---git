namespace Задание
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnShow = new DevExpress.XtraEditors.SimpleButton();
            this.dtFinish = new DevExpress.XtraEditors.DateEdit();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaskNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Executor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExecutorDivision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Division = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PrintDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnShow);
            this.panelControl1.Controls.Add(this.dtFinish);
            this.panelControl1.Controls.Add(this.dtStart);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(919, 46);
            this.panelControl1.TabIndex = 6;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(314, 13);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(76, 20);
            this.btnShow.TabIndex = 6;
            this.btnShow.Text = "Показать";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtFinish
            // 
            this.dtFinish.EditValue = null;
            this.dtFinish.Location = new System.Drawing.Point(169, 13);
            this.dtFinish.Name = "dtFinish";
            this.dtFinish.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFinish.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dtFinish.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFinish.Properties.DisplayFormat.FormatString = "G";
            this.dtFinish.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFinish.Properties.EditFormat.FormatString = "G";
            this.dtFinish.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFinish.Properties.Mask.EditMask = "G";
            this.dtFinish.Size = new System.Drawing.Size(139, 20);
            this.dtFinish.TabIndex = 4;
            // 
            // dtStart
            // 
            this.dtStart.EditValue = null;
            this.dtStart.Location = new System.Drawing.Point(23, 13);
            this.dtStart.Name = "dtStart";
            this.dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStart.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dtStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStart.Properties.DisplayFormat.FormatString = "G";
            this.dtStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtStart.Properties.EditFormat.FormatString = "G";
            this.dtStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtStart.Properties.Mask.EditMask = "G";
            this.dtStart.Size = new System.Drawing.Size(139, 20);
            this.dtStart.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(765, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(147, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Закрыть отчет";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 46);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemLookUpEdit1,
            this.repositoryItemComboBox2});
            this.gridControl.Size = new System.Drawing.Size(919, 646);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.TaskNo,
            this.Executor,
            this.ExecutorDivision,
            this.Division,
            this.PrintDT,
            this.Status});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsCustomization.AllowColumnResizing = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsPrint.AllowCancelPrintExport = false;
            this.gridView.OptionsPrint.ShowPrintExportProgress = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
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
            // 
            // TaskNo
            // 
            this.TaskNo.AppearanceCell.Options.UseTextOptions = true;
            this.TaskNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TaskNo.AppearanceHeader.Options.UseTextOptions = true;
            this.TaskNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TaskNo.Caption = "Номер бланка";
            this.TaskNo.FieldName = "TaskNo";
            this.TaskNo.Name = "TaskNo";
            this.TaskNo.OptionsColumn.AllowEdit = false;
            this.TaskNo.OptionsColumn.AllowFocus = false;
            this.TaskNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.TaskNo.OptionsColumn.AllowIncrementalSearch = false;
            this.TaskNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TaskNo.OptionsColumn.AllowMove = false;
            this.TaskNo.OptionsColumn.AllowShowHide = false;
            this.TaskNo.OptionsColumn.AllowSize = false;
            this.TaskNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.TaskNo.Visible = true;
            this.TaskNo.VisibleIndex = 0;
            this.TaskNo.Width = 121;
            // 
            // Executor
            // 
            this.Executor.AppearanceCell.Options.UseTextOptions = true;
            this.Executor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Executor.AppearanceHeader.Options.UseTextOptions = true;
            this.Executor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Executor.Caption = "Исполнитель";
            this.Executor.FieldName = "Executor";
            this.Executor.Name = "Executor";
            this.Executor.OptionsColumn.AllowEdit = false;
            this.Executor.OptionsColumn.AllowFocus = false;
            this.Executor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.Executor.OptionsColumn.AllowIncrementalSearch = false;
            this.Executor.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Executor.OptionsColumn.AllowMove = false;
            this.Executor.OptionsColumn.AllowShowHide = false;
            this.Executor.OptionsColumn.AllowSize = false;
            this.Executor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Executor.Visible = true;
            this.Executor.VisibleIndex = 1;
            this.Executor.Width = 360;
            // 
            // ExecutorDivision
            // 
            this.ExecutorDivision.AppearanceCell.Options.UseTextOptions = true;
            this.ExecutorDivision.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExecutorDivision.AppearanceHeader.Options.UseTextOptions = true;
            this.ExecutorDivision.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExecutorDivision.Caption = "Подразделение исполнителя";
            this.ExecutorDivision.FieldName = "ExecutorDivision";
            this.ExecutorDivision.Name = "ExecutorDivision";
            this.ExecutorDivision.OptionsColumn.AllowEdit = false;
            this.ExecutorDivision.OptionsColumn.AllowFocus = false;
            this.ExecutorDivision.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ExecutorDivision.OptionsColumn.AllowIncrementalSearch = false;
            this.ExecutorDivision.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ExecutorDivision.OptionsColumn.AllowMove = false;
            this.ExecutorDivision.OptionsColumn.AllowShowHide = false;
            this.ExecutorDivision.OptionsColumn.AllowSize = false;
            this.ExecutorDivision.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ExecutorDivision.Visible = true;
            this.ExecutorDivision.VisibleIndex = 2;
            this.ExecutorDivision.Width = 424;
            // 
            // Division
            // 
            this.Division.AppearanceCell.Options.UseTextOptions = true;
            this.Division.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Division.AppearanceHeader.Options.UseTextOptions = true;
            this.Division.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Division.Caption = "Направленно в подразделение";
            this.Division.FieldName = "Division";
            this.Division.Name = "Division";
            this.Division.OptionsColumn.AllowEdit = false;
            this.Division.OptionsColumn.AllowFocus = false;
            this.Division.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.Division.OptionsColumn.AllowIncrementalSearch = false;
            this.Division.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Division.OptionsColumn.AllowMove = false;
            this.Division.OptionsColumn.AllowShowHide = false;
            this.Division.OptionsColumn.AllowSize = false;
            this.Division.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Division.Visible = true;
            this.Division.VisibleIndex = 3;
            this.Division.Width = 397;
            // 
            // PrintDT
            // 
            this.PrintDT.AppearanceCell.Options.UseTextOptions = true;
            this.PrintDT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PrintDT.AppearanceHeader.Options.UseTextOptions = true;
            this.PrintDT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PrintDT.Caption = "Дата печати";
            this.PrintDT.DisplayFormat.FormatString = "G";
            this.PrintDT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
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
            this.PrintDT.Visible = true;
            this.PrintDT.VisibleIndex = 4;
            this.PrintDT.Width = 173;
            // 
            // Status
            // 
            this.Status.AppearanceCell.Options.UseTextOptions = true;
            this.Status.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Status.AppearanceHeader.Options.UseTextOptions = true;
            this.Status.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Status.Caption = "Статус бланка";
            this.Status.ColumnEdit = this.repositoryItemComboBox2;
            this.Status.FieldName = "Status";
            this.Status.Name = "Status";
            this.Status.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.Status.OptionsColumn.AllowIncrementalSearch = false;
            this.Status.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Status.OptionsColumn.AllowMove = false;
            this.Status.OptionsColumn.AllowShowHide = false;
            this.Status.OptionsColumn.AllowSize = false;
            this.Status.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Status.Visible = true;
            this.Status.VisibleIndex = 5;
            this.Status.Width = 154;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.DropDownRows = 3;
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.repositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.DropDownRows = 3;
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.NullText = "Не использован";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caption", "Caption")});
            this.repositoryItemLookUpEdit1.DisplayMember = "Caption";
            this.repositoryItemLookUpEdit1.DropDownRows = 3;
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "Не использован";
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            this.repositoryItemLookUpEdit1.ShowLines = false;
            this.repositoryItemLookUpEdit1.ValueMember = "ID";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl1);
            this.Name = "Report";
            this.Size = new System.Drawing.Size(919, 692);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn TaskNo;
        private DevExpress.XtraGrid.Columns.GridColumn Executor;
        private DevExpress.XtraGrid.Columns.GridColumn ExecutorDivision;
        private DevExpress.XtraGrid.Columns.GridColumn Division;
        private DevExpress.XtraGrid.Columns.GridColumn PrintDT;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.SimpleButton btnShow;
        private DevExpress.XtraEditors.DateEdit dtFinish;
        private DevExpress.XtraEditors.DateEdit dtStart;
        public DevExpress.XtraGrid.GridControl gridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView;
    }
}
