namespace Задание
{
    partial class ReportDialog
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chbWeek = new DevExpress.XtraEditors.CheckEdit();
            this.chbMonth = new DevExpress.XtraEditors.CheckEdit();
            this.chbQuarter = new DevExpress.XtraEditors.CheckEdit();
            this.chbPeriod = new DevExpress.XtraEditors.CheckEdit();
            this.dtFinish = new DevExpress.XtraEditors.DateEdit();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chbWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbQuarter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(130, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Сформировать отчет:";
            // 
            // chbWeek
            // 
            this.chbWeek.EditValue = true;
            this.chbWeek.Location = new System.Drawing.Point(25, 34);
            this.chbWeek.Name = "chbWeek";
            this.chbWeek.Properties.Caption = "За неделю";
            this.chbWeek.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chbWeek.Size = new System.Drawing.Size(75, 19);
            this.chbWeek.TabIndex = 0;
            this.chbWeek.CheckedChanged += new System.EventHandler(this.chbWeek_CheckedChanged);
            // 
            // chbMonth
            // 
            this.chbMonth.Location = new System.Drawing.Point(25, 59);
            this.chbMonth.Name = "chbMonth";
            this.chbMonth.Properties.Caption = "За месяц";
            this.chbMonth.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chbMonth.Size = new System.Drawing.Size(75, 19);
            this.chbMonth.TabIndex = 1;
            this.chbMonth.CheckedChanged += new System.EventHandler(this.chbMonth_CheckedChanged);
            // 
            // chbQuarter
            // 
            this.chbQuarter.Location = new System.Drawing.Point(25, 84);
            this.chbQuarter.Name = "chbQuarter";
            this.chbQuarter.Properties.Caption = "За квартал";
            this.chbQuarter.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chbQuarter.Size = new System.Drawing.Size(81, 19);
            this.chbQuarter.TabIndex = 2;
            this.chbQuarter.CheckedChanged += new System.EventHandler(this.chbQuarter_CheckedChanged);
            // 
            // chbPeriod
            // 
            this.chbPeriod.Location = new System.Drawing.Point(25, 109);
            this.chbPeriod.Name = "chbPeriod";
            this.chbPeriod.Properties.Caption = "Выбрать диапазон вручную";
            this.chbPeriod.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chbPeriod.Size = new System.Drawing.Size(165, 19);
            this.chbPeriod.TabIndex = 3;
            this.chbPeriod.CheckedChanged += new System.EventHandler(this.chbPeriod_CheckedChanged);
            // 
            // dtFinish
            // 
            this.dtFinish.EditValue = null;
            this.dtFinish.Enabled = false;
            this.dtFinish.Location = new System.Drawing.Point(68, 160);
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
            this.dtFinish.Size = new System.Drawing.Size(123, 20);
            this.dtFinish.TabIndex = 5;
            // 
            // dtStart
            // 
            this.dtStart.EditValue = null;
            this.dtStart.Enabled = false;
            this.dtStart.Location = new System.Drawing.Point(68, 134);
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
            this.dtStart.Size = new System.Drawing.Size(123, 20);
            this.dtStart.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 137);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Начало";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(31, 163);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Конец";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(116, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(25, 198);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Сформировать";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ReportDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(216, 238);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.dtFinish);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.chbPeriod);
            this.Controls.Add(this.chbQuarter);
            this.Controls.Add(this.chbMonth);
            this.Controls.Add(this.chbWeek);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет";
            ((System.ComponentModel.ISupportInitialize)(this.chbWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbQuarter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chbWeek;
        private DevExpress.XtraEditors.CheckEdit chbMonth;
        private DevExpress.XtraEditors.CheckEdit chbQuarter;
        private DevExpress.XtraEditors.CheckEdit chbPeriod;
        private DevExpress.XtraEditors.DateEdit dtFinish;
        private DevExpress.XtraEditors.DateEdit dtStart;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}