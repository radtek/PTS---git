namespace Прием
{
    partial class ScanFields
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanFields));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Caption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tags = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tokenEdit = new DevExpress.XtraEditors.TokenEdit();
            this.btnDot = new DevExpress.XtraEditors.SimpleButton();
            this.btnComma = new DevExpress.XtraEditors.SimpleButton();
            this.btnSemicolon = new DevExpress.XtraEditors.SimpleButton();
            this.btnSpace = new DevExpress.XtraEditors.SimpleButton();
            this.tbInput = new DevExpress.XtraEditors.TextEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.labelPreview = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.tbCaption = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 20);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(816, 521);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.Caption,
            this.Value,
            this.Tags});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.OptionsColumn.ReadOnly = true;
            // 
            // Caption
            // 
            this.Caption.Caption = "Название";
            this.Caption.FieldName = "Caption";
            this.Caption.Name = "Caption";
            this.Caption.OptionsColumn.AllowEdit = false;
            this.Caption.OptionsColumn.ReadOnly = true;
            this.Caption.Visible = true;
            this.Caption.VisibleIndex = 0;
            // 
            // Value
            // 
            this.Value.Caption = "Значение";
            this.Value.FieldName = "Value";
            this.Value.Name = "Value";
            this.Value.OptionsColumn.AllowEdit = false;
            this.Value.OptionsColumn.ReadOnly = true;
            this.Value.Visible = true;
            this.Value.VisibleIndex = 1;
            // 
            // Tags
            // 
            this.Tags.Caption = "Tags";
            this.Tags.FieldName = "Tags";
            this.Tags.Name = "Tags";
            this.Tags.OptionsColumn.AllowEdit = false;
            this.Tags.OptionsColumn.ReadOnly = true;
            // 
            // tokenEdit
            // 
            this.tokenEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.tokenEdit.Location = new System.Drawing.Point(0, 0);
            this.tokenEdit.Name = "tokenEdit";
            this.tokenEdit.Properties.DropDownRowCount = 20;
            this.tokenEdit.Properties.EditMode = DevExpress.XtraEditors.TokenEditMode.TokenList;
            this.tokenEdit.Properties.EditValueSeparatorChar = '\0';
            this.tokenEdit.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value;
            this.tokenEdit.Properties.NullText = "Начните вводить наименование необходимого маркера";
            this.tokenEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.TokenEditPopupFilterMode.Contains;
            this.tokenEdit.Properties.TokenGlyphLocation = DevExpress.XtraEditors.TokenEditGlyphLocation.Right;
            this.tokenEdit.Size = new System.Drawing.Size(816, 20);
            this.tokenEdit.TabIndex = 4;
            this.tokenEdit.SelectedItemsChanged += new System.ComponentModel.ListChangedEventHandler(this.tokenEdit_SelectedItemsChanged);
            this.tokenEdit.SizeChanged += new System.EventHandler(this.tokenEdit_SizeChanged);
            // 
            // btnDot
            // 
            this.btnDot.Location = new System.Drawing.Point(3, 3);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(23, 20);
            this.btnDot.TabIndex = 5;
            this.btnDot.Text = ".";
            this.btnDot.Click += new System.EventHandler(this.btnDot_Click);
            // 
            // btnComma
            // 
            this.btnComma.Location = new System.Drawing.Point(32, 3);
            this.btnComma.Name = "btnComma";
            this.btnComma.Size = new System.Drawing.Size(23, 20);
            this.btnComma.TabIndex = 5;
            this.btnComma.Text = ",";
            this.btnComma.Click += new System.EventHandler(this.btnComma_Click);
            // 
            // btnSemicolon
            // 
            this.btnSemicolon.Location = new System.Drawing.Point(61, 3);
            this.btnSemicolon.Name = "btnSemicolon";
            this.btnSemicolon.Size = new System.Drawing.Size(23, 20);
            this.btnSemicolon.TabIndex = 5;
            this.btnSemicolon.Text = ";";
            this.btnSemicolon.Click += new System.EventHandler(this.btnSemicolon_Click);
            // 
            // btnSpace
            // 
            this.btnSpace.Location = new System.Drawing.Point(90, 3);
            this.btnSpace.Name = "btnSpace";
            this.btnSpace.Size = new System.Drawing.Size(56, 20);
            this.btnSpace.TabIndex = 5;
            this.btnSpace.Text = "Пробел";
            this.btnSpace.Click += new System.EventHandler(this.btnSpace_Click);
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(152, 3);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(81, 20);
            this.tbInput.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(239, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 20);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelPreview
            // 
            this.labelPreview.Location = new System.Drawing.Point(301, 6);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(0, 13);
            this.labelPreview.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(729, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 20);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbCaption
            // 
            this.tbCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCaption.Location = new System.Drawing.Point(527, 3);
            this.tbCaption.Name = "tbCaption";
            this.tbCaption.Size = new System.Drawing.Size(196, 20);
            this.tbCaption.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(473, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Название";
            // 
            // panelControl
            // 
            this.panelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl.Controls.Add(this.gridControl);
            this.panelControl.Controls.Add(this.tokenEdit);
            this.panelControl.Location = new System.Drawing.Point(3, 29);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(816, 541);
            this.panelControl.TabIndex = 10;
            // 
            // ScanFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tbCaption);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSpace);
            this.Controls.Add(this.btnSemicolon);
            this.Controls.Add(this.btnComma);
            this.Controls.Add(this.btnDot);
            this.Name = "ScanFields";
            this.Size = new System.Drawing.Size(822, 573);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn Caption;
        private DevExpress.XtraGrid.Columns.GridColumn Value;
        private DevExpress.XtraGrid.Columns.GridColumn Tags;
        private DevExpress.XtraEditors.TokenEdit tokenEdit;
        private DevExpress.XtraEditors.SimpleButton btnDot;
        private DevExpress.XtraEditors.SimpleButton btnComma;
        private DevExpress.XtraEditors.SimpleButton btnSemicolon;
        private DevExpress.XtraEditors.SimpleButton btnSpace;
        private DevExpress.XtraEditors.TextEdit tbInput;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelPreview;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit tbCaption;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl;
    }
}
