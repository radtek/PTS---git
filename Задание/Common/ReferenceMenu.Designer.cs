namespace Задание
{
    partial class ReferenceMenu
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RefCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnChoose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(528, 295);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.RefCaption,
            this.CreateDT});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ID.OptionsColumn.AllowMove = false;
            this.ID.OptionsColumn.AllowShowHide = false;
            this.ID.OptionsColumn.AllowSize = false;
            // 
            // RefCaption
            // 
            this.RefCaption.Caption = "№ справки (название)";
            this.RefCaption.FieldName = "RefCaption";
            this.RefCaption.MinWidth = 40;
            this.RefCaption.Name = "RefCaption";
            this.RefCaption.OptionsColumn.AllowEdit = false;
            this.RefCaption.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.RefCaption.OptionsColumn.AllowMove = false;
            this.RefCaption.OptionsColumn.AllowShowHide = false;
            this.RefCaption.OptionsColumn.AllowSize = false;
            this.RefCaption.Visible = true;
            this.RefCaption.VisibleIndex = 0;
            this.RefCaption.Width = 169;
            // 
            // CreateDT
            // 
            this.CreateDT.Caption = "Дата создания";
            this.CreateDT.FieldName = "CreateDT";
            this.CreateDT.MinWidth = 15;
            this.CreateDT.Name = "CreateDT";
            this.CreateDT.OptionsColumn.AllowEdit = false;
            this.CreateDT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.CreateDT.OptionsColumn.AllowMove = false;
            this.CreateDT.OptionsColumn.AllowShowHide = false;
            this.CreateDT.OptionsColumn.AllowSize = false;
            this.CreateDT.Visible = true;
            this.CreateDT.VisibleIndex = 1;
            this.CreateDT.Width = 92;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(441, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.Location = new System.Drawing.Point(360, 305);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 1;
            this.btnChoose.Text = "Выбрать";
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // ReferenceMenu
            // 
            this.AcceptButton = this.btnChoose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(528, 340);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gridControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReferenceMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор справки";
            this.Load += new System.EventHandler(this.ReferenceMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn RefCaption;
        private DevExpress.XtraGrid.Columns.GridColumn CreateDT;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnChoose;
    }
}