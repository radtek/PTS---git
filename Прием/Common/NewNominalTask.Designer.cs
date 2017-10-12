namespace Прием
{
    partial class NewNominalTask
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
            this.tbEventIdentifierPoint = new DevExpress.XtraEditors.TextEdit();
            this.cbEventIdentifierType = new DevExpress.XtraEditors.LookUpEdit();
            this.cbEventCode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tbJobNo = new DevExpress.XtraEditors.TextEdit();
            this.tbJobCommNo = new DevExpress.XtraEditors.TextEdit();
            this.cbJobYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbTaskExecutor = new DevExpress.XtraEditors.LookUpEdit();
            this.cbTaskGroupControl = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.tbObjectSurname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.tbObjectName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.tbObjectSecondName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.chbNonPerson = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.cbEventType = new DevExpress.XtraEditors.LookUpEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbEventIdentifierPoint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEventIdentifierType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEventCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbJobNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbJobCommNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbJobYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTaskExecutor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTaskGroupControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbObjectSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbObjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbObjectSecondName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbNonPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEventType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tbEventIdentifierPoint
            // 
            this.tbEventIdentifierPoint.Enabled = false;
            this.tbEventIdentifierPoint.Location = new System.Drawing.Point(131, 38);
            this.tbEventIdentifierPoint.Name = "tbEventIdentifierPoint";
            this.tbEventIdentifierPoint.Size = new System.Drawing.Size(237, 20);
            this.tbEventIdentifierPoint.TabIndex = 1;
            // 
            // cbEventIdentifierType
            // 
            this.cbEventIdentifierType.Location = new System.Drawing.Point(131, 12);
            this.cbEventIdentifierType.Name = "cbEventIdentifierType";
            this.cbEventIdentifierType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEventIdentifierType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ObjTypeID", "ObjTypeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ObjTypeName", "ObjTypeName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TableName", "TableName", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.cbEventIdentifierType.Properties.DisplayMember = "ObjTypeName";
            this.cbEventIdentifierType.Properties.DropDownRows = 15;
            this.cbEventIdentifierType.Properties.NullText = "";
            this.cbEventIdentifierType.Properties.ShowFooter = false;
            this.cbEventIdentifierType.Properties.ShowHeader = false;
            this.cbEventIdentifierType.Properties.ShowLines = false;
            this.cbEventIdentifierType.Properties.ValueMember = "ObjTypeID";
            this.cbEventIdentifierType.Size = new System.Drawing.Size(237, 20);
            this.cbEventIdentifierType.TabIndex = 0;
            this.cbEventIdentifierType.EditValueChanged += new System.EventHandler(this.cbEventIdentifierType_EditValueChanged);
            // 
            // cbEventCode
            // 
            this.cbEventCode.Location = new System.Drawing.Point(131, 193);
            this.cbEventCode.Name = "cbEventCode";
            this.cbEventCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEventCode.Properties.DropDownRows = 15;
            this.cbEventCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbEventCode.Size = new System.Drawing.Size(237, 20);
            this.cbEventCode.TabIndex = 6;
            // 
            // tbJobNo
            // 
            this.tbJobNo.Location = new System.Drawing.Point(131, 219);
            this.tbJobNo.Name = "tbJobNo";
            this.tbJobNo.Size = new System.Drawing.Size(237, 20);
            this.tbJobNo.TabIndex = 7;
            // 
            // tbJobCommNo
            // 
            this.tbJobCommNo.Location = new System.Drawing.Point(131, 245);
            this.tbJobCommNo.Name = "tbJobCommNo";
            this.tbJobCommNo.Size = new System.Drawing.Size(237, 20);
            this.tbJobCommNo.TabIndex = 8;
            // 
            // cbJobYear
            // 
            this.cbJobYear.Location = new System.Drawing.Point(131, 271);
            this.cbJobYear.Name = "cbJobYear";
            this.cbJobYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbJobYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbJobYear.Size = new System.Drawing.Size(237, 20);
            this.cbJobYear.TabIndex = 9;
            // 
            // cbTaskExecutor
            // 
            this.cbTaskExecutor.Location = new System.Drawing.Point(131, 297);
            this.cbTaskExecutor.Name = "cbTaskExecutor";
            this.cbTaskExecutor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTaskExecutor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ExecID", "ExecID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ExecName", "ExecName")});
            this.cbTaskExecutor.Properties.DisplayMember = "ExecName";
            this.cbTaskExecutor.Properties.NullText = "";
            this.cbTaskExecutor.Properties.ShowFooter = false;
            this.cbTaskExecutor.Properties.ShowHeader = false;
            this.cbTaskExecutor.Properties.ShowLines = false;
            this.cbTaskExecutor.Properties.ValueMember = "ExecID";
            this.cbTaskExecutor.Size = new System.Drawing.Size(237, 20);
            this.cbTaskExecutor.TabIndex = 10;
            // 
            // cbTaskGroupControl
            // 
            this.cbTaskGroupControl.Location = new System.Drawing.Point(131, 323);
            this.cbTaskGroupControl.Name = "cbTaskGroupControl";
            this.cbTaskGroupControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTaskGroupControl.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GrpID", "GrpID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GrpName", "GrpName")});
            this.cbTaskGroupControl.Properties.DisplayMember = "GrpName";
            this.cbTaskGroupControl.Properties.NullText = "";
            this.cbTaskGroupControl.Properties.ShowFooter = false;
            this.cbTaskGroupControl.Properties.ShowHeader = false;
            this.cbTaskGroupControl.Properties.ShowLines = false;
            this.cbTaskGroupControl.Properties.ValueMember = "GrpID";
            this.cbTaskGroupControl.Size = new System.Drawing.Size(237, 20);
            this.cbTaskGroupControl.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Тип точки контроля";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(44, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Точка контроля";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(81, 170);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Вид ОТМ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(80, 196);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Код ОТМ";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(49, 222);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Номер задания";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(37, 248);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(88, 13);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "Номер поручения";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(61, 274);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(64, 13);
            this.labelControl7.TabIndex = 3;
            this.labelControl7.Text = "Год задания";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(59, 300);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(66, 13);
            this.labelControl8.TabIndex = 3;
            this.labelControl8.Text = "Исполнитель";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(38, 326);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(87, 13);
            this.labelControl9.TabIndex = 3;
            this.labelControl9.Text = "Группа контроля";
            // 
            // tbObjectSurname
            // 
            this.tbObjectSurname.Location = new System.Drawing.Point(131, 89);
            this.tbObjectSurname.Name = "tbObjectSurname";
            this.tbObjectSurname.Size = new System.Drawing.Size(237, 20);
            this.tbObjectSurname.TabIndex = 2;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(35, 92);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(90, 13);
            this.labelControl10.TabIndex = 3;
            this.labelControl10.Text = "Объект: Фамилия";
            // 
            // tbObjectName
            // 
            this.tbObjectName.Location = new System.Drawing.Point(131, 115);
            this.tbObjectName.Name = "tbObjectName";
            this.tbObjectName.Size = new System.Drawing.Size(237, 20);
            this.tbObjectName.TabIndex = 3;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(60, 118);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(65, 13);
            this.labelControl11.TabIndex = 3;
            this.labelControl11.Text = "Объект: Имя";
            // 
            // tbObjectSecondName
            // 
            this.tbObjectSecondName.Location = new System.Drawing.Point(131, 141);
            this.tbObjectSecondName.Name = "tbObjectSecondName";
            this.tbObjectSecondName.Size = new System.Drawing.Size(237, 20);
            this.tbObjectSecondName.TabIndex = 4;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(30, 144);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(95, 13);
            this.labelControl12.TabIndex = 3;
            this.labelControl12.Text = "Объект: Отчество";
            // 
            // chbNonPerson
            // 
            this.chbNonPerson.Location = new System.Drawing.Point(131, 64);
            this.chbNonPerson.Name = "chbNonPerson";
            this.chbNonPerson.Properties.Caption = "Неустановленное лицо";
            this.chbNonPerson.Size = new System.Drawing.Size(237, 19);
            this.chbNonPerson.TabIndex = 4;
            this.chbNonPerson.TabStop = false;
            this.chbNonPerson.CheckedChanged += new System.EventHandler(this.chbNonPerson_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(293, 359);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(212, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Добавить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbEventType
            // 
            this.cbEventType.Location = new System.Drawing.Point(131, 167);
            this.cbEventType.Name = "cbEventType";
            this.cbEventType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEventType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("JouID", "JouID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("JobType", "JobType")});
            this.cbEventType.Properties.DisplayMember = "JobType";
            this.cbEventType.Properties.DropDownRows = 10;
            this.cbEventType.Properties.NullText = "";
            this.cbEventType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.cbEventType.Properties.ShowFooter = false;
            this.cbEventType.Properties.ShowHeader = false;
            this.cbEventType.Properties.ShowLines = false;
            this.cbEventType.Size = new System.Drawing.Size(237, 20);
            this.cbEventType.TabIndex = 5;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // NewNominalTask
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(385, 394);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chbNonPerson);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cbJobYear);
            this.Controls.Add(this.cbEventCode);
            this.Controls.Add(this.cbTaskGroupControl);
            this.Controls.Add(this.cbEventType);
            this.Controls.Add(this.cbTaskExecutor);
            this.Controls.Add(this.cbEventIdentifierType);
            this.Controls.Add(this.tbJobCommNo);
            this.Controls.Add(this.tbJobNo);
            this.Controls.Add(this.tbObjectSecondName);
            this.Controls.Add(this.tbObjectName);
            this.Controls.Add(this.tbObjectSurname);
            this.Controls.Add(this.tbEventIdentifierPoint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewNominalTask";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новое условное задание";
            this.Load += new System.EventHandler(this.NewNominalTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbEventIdentifierPoint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEventIdentifierType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEventCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbJobNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbJobCommNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbJobYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTaskExecutor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTaskGroupControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbObjectSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbObjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbObjectSecondName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbNonPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEventType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tbEventIdentifierPoint;
        private DevExpress.XtraEditors.LookUpEdit cbEventIdentifierType;
        private DevExpress.XtraEditors.ComboBoxEdit cbEventCode;
        private DevExpress.XtraEditors.TextEdit tbJobNo;
        private DevExpress.XtraEditors.TextEdit tbJobCommNo;
        private DevExpress.XtraEditors.ComboBoxEdit cbJobYear;
        private DevExpress.XtraEditors.LookUpEdit cbTaskExecutor;
        private DevExpress.XtraEditors.LookUpEdit cbTaskGroupControl;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit tbObjectSurname;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit tbObjectName;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit tbObjectSecondName;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.CheckEdit chbNonPerson;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LookUpEdit cbEventType;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}