namespace Задание
{
    partial class MarkersControl
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Caption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BeforeSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AfterSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QRFirstChar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.QRToUpper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.QRToDative = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.TextFirstChar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.TextToUpper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.TextToDative = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4,
            this.repositoryItemCheckEdit5,
            this.repositoryItemCheckEdit6,
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(731, 419);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.Tag,
            this.Caption,
            this.BeforeSymbol,
            this.AfterSymbol,
            this.QRFirstChar,
            this.QRToUpper,
            this.QRToDative,
            this.TextFirstChar,
            this.TextToUpper,
            this.TextToDative});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.OptionsColumn.AllowFocus = false;
            this.ID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.ID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ID.OptionsColumn.AllowMove = false;
            this.ID.OptionsColumn.AllowShowHide = false;
            this.ID.OptionsColumn.AllowSize = false;
            this.ID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // Tag
            // 
            this.Tag.Caption = "Маркер";
            this.Tag.FieldName = "Tag";
            this.Tag.Name = "Tag";
            this.Tag.OptionsColumn.AllowEdit = false;
            this.Tag.OptionsColumn.AllowFocus = false;
            this.Tag.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.Tag.OptionsColumn.AllowIncrementalSearch = false;
            this.Tag.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Tag.OptionsColumn.AllowMove = false;
            this.Tag.OptionsColumn.AllowShowHide = false;
            this.Tag.Visible = true;
            this.Tag.VisibleIndex = 0;
            // 
            // Caption
            // 
            this.Caption.Caption = "Название";
            this.Caption.FieldName = "Caption";
            this.Caption.Name = "Caption";
            this.Caption.OptionsColumn.AllowEdit = false;
            this.Caption.OptionsColumn.AllowFocus = false;
            this.Caption.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.Caption.OptionsColumn.AllowIncrementalSearch = false;
            this.Caption.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Caption.OptionsColumn.AllowMove = false;
            this.Caption.OptionsColumn.AllowShowHide = false;
            this.Caption.Visible = true;
            this.Caption.VisibleIndex = 1;
            // 
            // BeforeSymbol
            // 
            this.BeforeSymbol.Caption = "Символ до";
            this.BeforeSymbol.FieldName = "BeforeSymbol";
            this.BeforeSymbol.Name = "BeforeSymbol";
            this.BeforeSymbol.Visible = true;
            this.BeforeSymbol.VisibleIndex = 2;
            // 
            // AfterSymbol
            // 
            this.AfterSymbol.Caption = "Символ после";
            this.AfterSymbol.FieldName = "AfterSymbol";
            this.AfterSymbol.Name = "AfterSymbol";
            this.AfterSymbol.Visible = true;
            this.AfterSymbol.VisibleIndex = 3;
            // 
            // QRFirstChar
            // 
            this.QRFirstChar.Caption = "Передавать в QR первую букву";
            this.QRFirstChar.ColumnEdit = this.repositoryItemCheckEdit1;
            this.QRFirstChar.FieldName = "QRFirstChar";
            this.QRFirstChar.Name = "QRFirstChar";
            this.QRFirstChar.Visible = true;
            this.QRFirstChar.VisibleIndex = 4;
            this.QRFirstChar.Width = 102;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // QRToUpper
            // 
            this.QRToUpper.Caption = "Передавать в QR с большой буквы";
            this.QRToUpper.ColumnEdit = this.repositoryItemCheckEdit2;
            this.QRToUpper.FieldName = "QRToUpper";
            this.QRToUpper.Name = "QRToUpper";
            this.QRToUpper.Visible = true;
            this.QRToUpper.VisibleIndex = 5;
            this.QRToUpper.Width = 103;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // QRToDative
            // 
            this.QRToDative.Caption = "Передавать в QR в дательном";
            this.QRToDative.ColumnEdit = this.repositoryItemCheckEdit5;
            this.QRToDative.FieldName = "QRToDative";
            this.QRToDative.Name = "QRToDative";
            this.QRToDative.Visible = true;
            this.QRToDative.VisibleIndex = 6;
            // 
            // repositoryItemCheckEdit5
            // 
            this.repositoryItemCheckEdit5.AutoHeight = false;
            this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
            // 
            // TextFirstChar
            // 
            this.TextFirstChar.Caption = "Передавать в текст первую букву";
            this.TextFirstChar.ColumnEdit = this.repositoryItemCheckEdit3;
            this.TextFirstChar.FieldName = "TextFirstChar";
            this.TextFirstChar.Name = "TextFirstChar";
            this.TextFirstChar.Visible = true;
            this.TextFirstChar.VisibleIndex = 7;
            this.TextFirstChar.Width = 103;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // TextToUpper
            // 
            this.TextToUpper.Caption = "Передавать в текст с большой буквы";
            this.TextToUpper.ColumnEdit = this.repositoryItemCheckEdit4;
            this.TextToUpper.FieldName = "TextToUpper";
            this.TextToUpper.Name = "TextToUpper";
            this.TextToUpper.Visible = true;
            this.TextToUpper.VisibleIndex = 8;
            this.TextToUpper.Width = 94;
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // TextToDative
            // 
            this.TextToDative.Caption = "Передавать в текст в дательном";
            this.TextToDative.ColumnEdit = this.repositoryItemCheckEdit6;
            this.TextToDative.FieldName = "TextToDative";
            this.TextToDative.Name = "TextToDative";
            this.TextToDative.Visible = true;
            this.TextToDative.VisibleIndex = 9;
            // 
            // repositoryItemCheckEdit6
            // 
            this.repositoryItemCheckEdit6.AutoHeight = false;
            this.repositoryItemCheckEdit6.Name = "repositoryItemCheckEdit6";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // MarkersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "MarkersControl";
            this.Size = new System.Drawing.Size(731, 419);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn Tag;
        private DevExpress.XtraGrid.Columns.GridColumn Caption;
        private DevExpress.XtraGrid.Columns.GridColumn BeforeSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn AfterSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn QRFirstChar;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn QRToUpper;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn QRToDative;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private DevExpress.XtraGrid.Columns.GridColumn TextFirstChar;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn TextToUpper;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn TextToDative;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit6;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;

    }
}
