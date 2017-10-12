namespace Задание
{
    partial class TaskModeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskModeForm));
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnDone = new DevExpress.XtraEditors.SimpleButton();
            this.lbMode = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.lbMode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(243, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDone
            // 
            this.btnDone.Image = ((System.Drawing.Image)(resources.GetObject("btnDone.Image")));
            this.btnDone.Location = new System.Drawing.Point(162, 136);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Готово";
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lbMode
            // 
            this.lbMode.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lbMode.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMode.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbMode.Appearance.Options.UseBackColor = true;
            this.lbMode.Appearance.Options.UseFont = true;
            this.lbMode.Appearance.Options.UseForeColor = true;
            this.lbMode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbMode.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbMode.ItemHeight = 28;
            this.lbMode.Items.AddRange(new object[] {
            "Судейское постановление",
            "Неустановленное лицо",
            "Неотложное СТМ на 48 часов",
            "По постановлению следователя (186 УПК)"});
            this.lbMode.Location = new System.Drawing.Point(12, 12);
            this.lbMode.LookAndFeel.SkinName = "Office 2016 Black";
            this.lbMode.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lbMode.Name = "lbMode";
            this.lbMode.ShowFocusRect = false;
            this.lbMode.Size = new System.Drawing.Size(306, 118);
            this.lbMode.TabIndex = 7;
            this.lbMode.DoubleClick += new System.EventHandler(this.lbMode_DoubleClick);
            // 
            // TaskModeForm
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(331, 166);
            this.ControlBox = false;
            this.Controls.Add(this.lbMode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskModeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите режим работы";
            this.Load += new System.EventHandler(this.TaskModeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lbMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnDone;
        private DevExpress.XtraEditors.ListBoxControl lbMode;
    }
}