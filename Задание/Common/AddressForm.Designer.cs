namespace Задание
{
    partial class AddressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddressForm));
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tbRoomNo = new DevExpress.XtraEditors.TextEdit();
            this.tbHomePartNo = new DevExpress.XtraEditors.TextEdit();
            this.tbHomePart = new DevExpress.XtraEditors.TextEdit();
            this.tbHomeNo = new DevExpress.XtraEditors.TextEdit();
            this.tbStreet = new DevExpress.XtraEditors.TextEdit();
            this.tbCity = new DevExpress.XtraEditors.TextEdit();
            this.tbRegion = new DevExpress.XtraEditors.TextEdit();
            this.cbCountry = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRoomNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHomePartNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHomePart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHomeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStreet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRegion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCountry.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(343, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Отмена";
            // 
            // btnApply
            // 
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.Location = new System.Drawing.Point(262, 186);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 26;
            this.btnApply.Text = "Готово";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(234, 145);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(78, 13);
            this.labelControl8.TabIndex = 19;
            this.labelControl8.Text = "Квартира/офис";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(276, 119);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 13);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = "Корпус";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(66, 145);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(49, 13);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "Строение";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(95, 119);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(20, 13);
            this.labelControl5.TabIndex = 20;
            this.labelControl5.Text = "Дом";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(19, 93);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(96, 13);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Улица/гор. объект";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(101, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Город/насел. пункт";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(80, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(35, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Регион";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(78, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Страна";
            // 
            // tbRoomNo
            // 
            this.tbRoomNo.Location = new System.Drawing.Point(318, 142);
            this.tbRoomNo.Name = "tbRoomNo";
            this.tbRoomNo.Size = new System.Drawing.Size(100, 20);
            this.tbRoomNo.TabIndex = 25;
            // 
            // tbHomePartNo
            // 
            this.tbHomePartNo.Location = new System.Drawing.Point(121, 142);
            this.tbHomePartNo.Name = "tbHomePartNo";
            this.tbHomePartNo.Size = new System.Drawing.Size(100, 20);
            this.tbHomePartNo.TabIndex = 24;
            // 
            // tbHomePart
            // 
            this.tbHomePart.Location = new System.Drawing.Point(318, 116);
            this.tbHomePart.Name = "tbHomePart";
            this.tbHomePart.Size = new System.Drawing.Size(100, 20);
            this.tbHomePart.TabIndex = 23;
            // 
            // tbHomeNo
            // 
            this.tbHomeNo.Location = new System.Drawing.Point(121, 116);
            this.tbHomeNo.Name = "tbHomeNo";
            this.tbHomeNo.Size = new System.Drawing.Size(100, 20);
            this.tbHomeNo.TabIndex = 22;
            // 
            // tbStreet
            // 
            this.tbStreet.Location = new System.Drawing.Point(121, 90);
            this.tbStreet.Name = "tbStreet";
            this.tbStreet.Size = new System.Drawing.Size(297, 20);
            this.tbStreet.TabIndex = 21;
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(121, 64);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(297, 20);
            this.tbCity.TabIndex = 12;
            // 
            // tbRegion
            // 
            this.tbRegion.Location = new System.Drawing.Point(121, 38);
            this.tbRegion.Name = "tbRegion";
            this.tbRegion.Size = new System.Drawing.Size(297, 20);
            this.tbRegion.TabIndex = 11;
            // 
            // cbCountry
            // 
            this.cbCountry.Location = new System.Drawing.Point(121, 12);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCountry.Properties.DropDownRows = 15;
            this.cbCountry.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbCountry.Size = new System.Drawing.Size(297, 20);
            this.cbCountry.TabIndex = 10;
            // 
            // AddressForm
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 224);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tbRoomNo);
            this.Controls.Add(this.tbHomePartNo);
            this.Controls.Add(this.tbHomePart);
            this.Controls.Add(this.tbHomeNo);
            this.Controls.Add(this.tbStreet);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.tbRegion);
            this.Controls.Add(this.cbCountry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод адреса";
            this.Load += new System.EventHandler(this.AddressForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbRoomNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHomePartNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHomePart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHomeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStreet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRegion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCountry.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tbRoomNo;
        private DevExpress.XtraEditors.TextEdit tbHomePartNo;
        private DevExpress.XtraEditors.TextEdit tbHomePart;
        private DevExpress.XtraEditors.TextEdit tbHomeNo;
        private DevExpress.XtraEditors.TextEdit tbStreet;
        private DevExpress.XtraEditors.TextEdit tbCity;
        private DevExpress.XtraEditors.TextEdit tbRegion;
        private DevExpress.XtraEditors.ComboBoxEdit cbCountry;
    }
}