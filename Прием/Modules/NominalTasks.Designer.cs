namespace Прием
{
    partial class NominalTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NominalTasks));
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.btnScan = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.JobNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Point = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Object = new DevExpress.XtraGrid.Columns.GridColumn();
            this.JobID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.JobBlankID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel.Controls.Add(this.btnScan);
            this.panel.Controls.Add(this.btnAddNew);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(953, 59);
            this.panel.TabIndex = 0;
            // 
            // btnScan
            // 
            this.btnScan.Image = ((System.Drawing.Image)(resources.GetObject("btnScan.Image")));
            this.btnScan.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnScan.Location = new System.Drawing.Point(107, 3);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(96, 53);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Сканировать";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnAddNew.Location = new System.Drawing.Point(5, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(96, 53);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Добавить";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 59);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(953, 616);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.JobNo,
            this.Point,
            this.Object,
            this.JobID,
            this.JobBlankID});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.OptionsColumn.AllowShowHide = false;
            this.ID.OptionsColumn.ReadOnly = true;
            // 
            // JobNo
            // 
            this.JobNo.AppearanceCell.Options.UseTextOptions = true;
            this.JobNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.JobNo.Caption = "Номер задания";
            this.JobNo.FieldName = "JobNo";
            this.JobNo.Name = "JobNo";
            this.JobNo.OptionsColumn.AllowEdit = false;
            this.JobNo.OptionsColumn.AllowShowHide = false;
            this.JobNo.OptionsColumn.ReadOnly = true;
            this.JobNo.Visible = true;
            this.JobNo.VisibleIndex = 0;
            this.JobNo.Width = 131;
            // 
            // Point
            // 
            this.Point.Caption = "Точка контроля";
            this.Point.FieldName = "Point";
            this.Point.Name = "Point";
            this.Point.OptionsColumn.AllowEdit = false;
            this.Point.OptionsColumn.AllowShowHide = false;
            this.Point.OptionsColumn.ReadOnly = true;
            this.Point.Visible = true;
            this.Point.VisibleIndex = 1;
            this.Point.Width = 201;
            // 
            // Object
            // 
            this.Object.Caption = "Объект";
            this.Object.FieldName = "Object";
            this.Object.Name = "Object";
            this.Object.OptionsColumn.AllowEdit = false;
            this.Object.OptionsColumn.AllowShowHide = false;
            this.Object.OptionsColumn.ReadOnly = true;
            this.Object.Visible = true;
            this.Object.VisibleIndex = 2;
            this.Object.Width = 731;
            // 
            // JobID
            // 
            this.JobID.Caption = "JobID";
            this.JobID.FieldName = "JobID";
            this.JobID.Name = "JobID";
            this.JobID.OptionsColumn.AllowEdit = false;
            this.JobID.OptionsColumn.AllowShowHide = false;
            this.JobID.OptionsColumn.ReadOnly = true;
            // 
            // JobBlankID
            // 
            this.JobBlankID.Caption = "JobBlankID";
            this.JobBlankID.FieldName = "JobBlankID";
            this.JobBlankID.Name = "JobBlankID";
            this.JobBlankID.OptionsColumn.AllowEdit = false;
            this.JobBlankID.OptionsColumn.AllowShowHide = false;
            this.JobBlankID.OptionsColumn.ReadOnly = true;
            // 
            // NominalTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panel);
            this.Name = "NominalTasks";
            this.Size = new System.Drawing.Size(953, 675);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel;
        public DevExpress.XtraEditors.SimpleButton btnScan;
        public DevExpress.XtraEditors.SimpleButton btnAddNew;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn JobNo;
        private DevExpress.XtraGrid.Columns.GridColumn Point;
        private DevExpress.XtraGrid.Columns.GridColumn Object;
        private DevExpress.XtraGrid.Columns.GridColumn JobID;
        private DevExpress.XtraGrid.Columns.GridColumn JobBlankID;
    }
}
