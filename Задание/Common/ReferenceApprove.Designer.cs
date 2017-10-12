namespace Задание
{
    partial class ReferenceApprove
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
            this.tbSurname = new DevExpress.XtraEditors.TextEdit();
            this.tbName = new DevExpress.XtraEditors.TextEdit();
            this.tbSecondName = new DevExpress.XtraEditors.TextEdit();
            this.cbPosition = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbTitle = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbLine = new DevExpress.XtraEditors.LookUpEdit();
            this.cbService = new DevExpress.XtraEditors.LookUpEdit();
            this.cbDivision = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl31 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSecondName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDivision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(98, 12);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(265, 20);
            this.tbSurname.TabIndex = 0;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(98, 38);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(265, 20);
            this.tbName.TabIndex = 1;
            // 
            // tbSecondName
            // 
            this.tbSecondName.Location = new System.Drawing.Point(98, 64);
            this.tbSecondName.Name = "tbSecondName";
            this.tbSecondName.Size = new System.Drawing.Size(265, 20);
            this.tbSecondName.TabIndex = 2;
            // 
            // cbPosition
            // 
            this.cbPosition.Location = new System.Drawing.Point(98, 90);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPosition.Size = new System.Drawing.Size(265, 20);
            this.cbPosition.TabIndex = 3;
            // 
            // cbTitle
            // 
            this.cbTitle.Location = new System.Drawing.Point(98, 116);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTitle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbTitle.Size = new System.Drawing.Size(265, 20);
            this.cbTitle.TabIndex = 4;
            // 
            // cbLine
            // 
            this.cbLine.Location = new System.Drawing.Point(98, 194);
            this.cbLine.Name = "cbLine";
            this.cbLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLine.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Наименование"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Level", "Level", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KeyID", "KeyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.cbLine.Properties.DisplayMember = "Name";
            this.cbLine.Properties.NullText = "";
            this.cbLine.Properties.NullValuePrompt = "Выберите направление службы";
            this.cbLine.Properties.ShowFooter = false;
            this.cbLine.Properties.ShowHeader = false;
            this.cbLine.Properties.ShowLines = false;
            this.cbLine.Properties.ValueMember = "ID";
            this.cbLine.Size = new System.Drawing.Size(265, 20);
            this.cbLine.TabIndex = 7;
            // 
            // cbService
            // 
            this.cbService.Location = new System.Drawing.Point(98, 168);
            this.cbService.Name = "cbService";
            this.cbService.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbService.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Наименование"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Level", "Level", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KeyID", "KeyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.cbService.Properties.DisplayMember = "Name";
            this.cbService.Properties.NullText = "";
            this.cbService.Properties.NullValuePrompt = "Выберите службу";
            this.cbService.Properties.ShowFooter = false;
            this.cbService.Properties.ShowHeader = false;
            this.cbService.Properties.ShowLines = false;
            this.cbService.Properties.ValueMember = "ID";
            this.cbService.Size = new System.Drawing.Size(265, 20);
            this.cbService.TabIndex = 6;
            this.cbService.EditValueChanged += new System.EventHandler(this.cbService_EditValueChanged);
            // 
            // cbDivision
            // 
            this.cbDivision.Location = new System.Drawing.Point(98, 142);
            this.cbDivision.Name = "cbDivision";
            this.cbDivision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDivision.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Наименование"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Level", "Level", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KeyID", "KeyID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.cbDivision.Properties.DisplayMember = "Name";
            this.cbDivision.Properties.NullText = "";
            this.cbDivision.Properties.NullValuePrompt = "Выберите подразделение";
            this.cbDivision.Properties.ShowFooter = false;
            this.cbDivision.Properties.ShowHeader = false;
            this.cbDivision.Properties.ShowLines = false;
            this.cbDivision.Properties.ValueMember = "ID";
            this.cbDivision.Size = new System.Drawing.Size(265, 20);
            this.cbDivision.TabIndex = 5;
            this.cbDivision.EditValueChanged += new System.EventHandler(this.cbDivision_EditValueChanged);
            // 
            // labelControl31
            // 
            this.labelControl31.Location = new System.Drawing.Point(61, 197);
            this.labelControl31.Name = "labelControl31";
            this.labelControl31.Size = new System.Drawing.Size(31, 13);
            this.labelControl31.TabIndex = 12;
            this.labelControl31.Text = "Линия";
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(53, 171);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(39, 13);
            this.labelControl17.TabIndex = 13;
            this.labelControl17.Text = "Служба";
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(12, 145);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(80, 13);
            this.labelControl16.TabIndex = 14;
            this.labelControl16.Text = "Подразделение";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 119);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Звание";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(35, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Должность";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(43, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Отчество";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(73, 41);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(19, 13);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "Имя";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(48, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(44, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Фамилия";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(207, 220);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(288, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // ReferenceApprove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 254);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbLine);
            this.Controls.Add(this.cbService);
            this.Controls.Add(this.cbDivision);
            this.Controls.Add(this.labelControl31);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.cbTitle);
            this.Controls.Add(this.cbPosition);
            this.Controls.Add(this.tbSecondName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbSurname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReferenceApprove";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить согласующего";
            this.Load += new System.EventHandler(this.ReferenceApprove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSecondName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDivision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tbSurname;
        private DevExpress.XtraEditors.TextEdit tbName;
        private DevExpress.XtraEditors.TextEdit tbSecondName;
        private DevExpress.XtraEditors.ComboBoxEdit cbPosition;
        private DevExpress.XtraEditors.ComboBoxEdit cbTitle;
        private DevExpress.XtraEditors.LookUpEdit cbLine;
        private DevExpress.XtraEditors.LookUpEdit cbService;
        private DevExpress.XtraEditors.LookUpEdit cbDivision;
        private DevExpress.XtraEditors.LabelControl labelControl31;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}