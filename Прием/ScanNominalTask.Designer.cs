namespace Прием
{
    partial class ScanNominalTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanNominalTask));
            this.tbBlankNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelTask = new DevExpress.XtraEditors.LabelControl();
            this.gridControlTask = new DevExpress.XtraGrid.GridControl();
            this.gridViewTask = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FieldValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbReference = new DevExpress.XtraEditors.MemoEdit();
            this.labelStat = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlankNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbReference.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tbBlankNo
            // 
            this.tbBlankNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBlankNo.Location = new System.Drawing.Point(109, 55);
            this.tbBlankNo.Name = "tbBlankNo";
            this.tbBlankNo.Properties.ReadOnly = true;
            this.tbBlankNo.Size = new System.Drawing.Size(178, 20);
            this.tbBlankNo.TabIndex = 39;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 40;
            this.labelControl1.Text = "Номер бланка";
            // 
            // labelTask
            // 
            this.labelTask.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTask.Location = new System.Drawing.Point(12, 12);
            this.labelTask.Name = "labelTask";
            this.labelTask.Size = new System.Drawing.Size(378, 23);
            this.labelTask.TabIndex = 41;
            this.labelTask.Text = "Изменение условного задания № {0} - {1}";
            // 
            // gridControlTask
            // 
            this.gridControlTask.Location = new System.Drawing.Point(12, 117);
            this.gridControlTask.MainView = this.gridViewTask;
            this.gridControlTask.Name = "gridControlTask";
            this.gridControlTask.Size = new System.Drawing.Size(622, 265);
            this.gridControlTask.TabIndex = 42;
            this.gridControlTask.TabStop = false;
            this.gridControlTask.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTask});
            // 
            // gridViewTask
            // 
            this.gridViewTask.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FieldName,
            this.FieldValue});
            this.gridViewTask.GridControl = this.gridControlTask;
            this.gridViewTask.Name = "gridViewTask";
            this.gridViewTask.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewTask.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewTask.OptionsCustomization.AllowColumnResizing = false;
            this.gridViewTask.OptionsCustomization.AllowGroup = false;
            this.gridViewTask.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewTask.OptionsFind.AllowFindPanel = false;
            this.gridViewTask.OptionsView.ShowGroupPanel = false;
            // 
            // FieldName
            // 
            this.FieldName.Caption = "Наименование поля";
            this.FieldName.FieldName = "FieldName";
            this.FieldName.Name = "FieldName";
            this.FieldName.OptionsColumn.AllowEdit = false;
            this.FieldName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.FieldName.OptionsColumn.AllowMove = false;
            this.FieldName.OptionsColumn.AllowShowHide = false;
            this.FieldName.Visible = true;
            this.FieldName.VisibleIndex = 0;
            this.FieldName.Width = 451;
            // 
            // FieldValue
            // 
            this.FieldValue.Caption = "Полученное значение";
            this.FieldValue.FieldName = "FieldValue";
            this.FieldValue.Name = "FieldValue";
            this.FieldValue.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.FieldValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.FieldValue.OptionsColumn.AllowMove = false;
            this.FieldValue.OptionsColumn.AllowShowHide = false;
            this.FieldValue.Visible = true;
            this.FieldValue.VisibleIndex = 1;
            this.FieldValue.Width = 612;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl2.Location = new System.Drawing.Point(12, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(275, 23);
            this.labelControl2.TabIndex = 41;
            this.labelControl2.Text = "● Полученные данные задания";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl3.Location = new System.Drawing.Point(12, 388);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(375, 23);
            this.labelControl3.TabIndex = 41;
            this.labelControl3.Text = "● Полученные данные справки об объекте";
            // 
            // tbReference
            // 
            this.tbReference.Location = new System.Drawing.Point(12, 417);
            this.tbReference.Name = "tbReference";
            this.tbReference.Size = new System.Drawing.Size(622, 265);
            this.tbReference.TabIndex = 43;
            this.tbReference.TabStop = false;
            // 
            // labelStat
            // 
            this.labelStat.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStat.Location = new System.Drawing.Point(293, 56);
            this.labelStat.Name = "labelStat";
            this.labelStat.Size = new System.Drawing.Size(102, 19);
            this.labelStat.TabIndex = 44;
            this.labelStat.Text = "QR код 0 из 0";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(12, 699);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 23);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Сохранить";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(109, 699);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 23);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "Отмена";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new System.Drawing.Point(559, 699);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 46;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // ScanNominalTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 734);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelStat);
            this.Controls.Add(this.tbReference);
            this.Controls.Add(this.gridControlTask);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelTask);
            this.Controls.Add(this.tbBlankNo);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScanNominalTask";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сканирование условного задания";
            this.Load += new System.EventHandler(this.ScanNominalTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbBlankNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbReference.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit tbBlankNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelTask;
        private DevExpress.XtraGrid.GridControl gridControlTask;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTask;
        private DevExpress.XtraGrid.Columns.GridColumn FieldName;
        private DevExpress.XtraGrid.Columns.GridColumn FieldValue;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit tbReference;
        private DevExpress.XtraEditors.LabelControl labelStat;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraEditors.SimpleButton btnOpen;
    }
}