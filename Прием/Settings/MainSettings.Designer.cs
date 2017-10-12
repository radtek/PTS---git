namespace Прием
{
    partial class MainSettings
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnAssaCheckConnection = new DevExpress.XtraEditors.SimpleButton();
            this.btnAssaSaveConnection = new DevExpress.XtraEditors.SimpleButton();
            this.tbAssaPassword = new DevExpress.XtraEditors.TextEdit();
            this.tbAssaLogin = new DevExpress.XtraEditors.TextEdit();
            this.tbAssaDataBase = new DevExpress.XtraEditors.TextEdit();
            this.tbAssaServer = new DevExpress.XtraEditors.TextEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnPtsCheckConnection = new DevExpress.XtraEditors.SimpleButton();
            this.btnPtsSaveConnection = new DevExpress.XtraEditors.SimpleButton();
            this.tbPtsPassword = new DevExpress.XtraEditors.TextEdit();
            this.tbPtsLogin = new DevExpress.XtraEditors.TextEdit();
            this.tbPtsDataBase = new DevExpress.XtraEditors.TextEdit();
            this.tbPtsServer = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAssaPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAssaLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAssaDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAssaServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPtsPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPtsLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPtsDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPtsServer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnAssaCheckConnection);
            this.groupControl1.Controls.Add(this.btnAssaSaveConnection);
            this.groupControl1.Controls.Add(this.tbAssaPassword);
            this.groupControl1.Controls.Add(this.tbAssaLogin);
            this.groupControl1.Controls.Add(this.tbAssaDataBase);
            this.groupControl1.Controls.Add(this.tbAssaServer);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(231, 157);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Настройки подключения «Ассамблея»";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(41, 105);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(37, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Пароль";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(48, 79);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Логин";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "База данных";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(41, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Сервер";
            // 
            // btnAssaCheckConnection
            // 
            this.btnAssaCheckConnection.Location = new System.Drawing.Point(5, 128);
            this.btnAssaCheckConnection.Name = "btnAssaCheckConnection";
            this.btnAssaCheckConnection.Size = new System.Drawing.Size(140, 23);
            this.btnAssaCheckConnection.TabIndex = 1;
            this.btnAssaCheckConnection.Text = "Проверить подключение";
            this.btnAssaCheckConnection.Click += new System.EventHandler(this.btnAssaCheckConnection_Click);
            // 
            // btnAssaSaveConnection
            // 
            this.btnAssaSaveConnection.Location = new System.Drawing.Point(151, 128);
            this.btnAssaSaveConnection.Name = "btnAssaSaveConnection";
            this.btnAssaSaveConnection.Size = new System.Drawing.Size(75, 23);
            this.btnAssaSaveConnection.TabIndex = 1;
            this.btnAssaSaveConnection.Text = "Сохранить";
            this.btnAssaSaveConnection.Click += new System.EventHandler(this.btnAssaSaveConnection_Click);
            // 
            // tbAssaPassword
            // 
            this.tbAssaPassword.Location = new System.Drawing.Point(84, 102);
            this.tbAssaPassword.Name = "tbAssaPassword";
            this.tbAssaPassword.Properties.PasswordChar = '●';
            this.tbAssaPassword.Size = new System.Drawing.Size(142, 20);
            this.tbAssaPassword.TabIndex = 0;
            // 
            // tbAssaLogin
            // 
            this.tbAssaLogin.Location = new System.Drawing.Point(84, 76);
            this.tbAssaLogin.Name = "tbAssaLogin";
            this.tbAssaLogin.Size = new System.Drawing.Size(142, 20);
            this.tbAssaLogin.TabIndex = 0;
            // 
            // tbAssaDataBase
            // 
            this.tbAssaDataBase.Location = new System.Drawing.Point(84, 50);
            this.tbAssaDataBase.Name = "tbAssaDataBase";
            this.tbAssaDataBase.Size = new System.Drawing.Size(142, 20);
            this.tbAssaDataBase.TabIndex = 0;
            // 
            // tbAssaServer
            // 
            this.tbAssaServer.Location = new System.Drawing.Point(84, 24);
            this.tbAssaServer.Name = "tbAssaServer";
            this.tbAssaServer.Size = new System.Drawing.Size(142, 20);
            this.tbAssaServer.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Controls.Add(this.labelControl7);
            this.groupControl3.Controls.Add(this.labelControl8);
            this.groupControl3.Controls.Add(this.btnPtsCheckConnection);
            this.groupControl3.Controls.Add(this.btnPtsSaveConnection);
            this.groupControl3.Controls.Add(this.tbPtsPassword);
            this.groupControl3.Controls.Add(this.tbPtsLogin);
            this.groupControl3.Controls.Add(this.tbPtsDataBase);
            this.groupControl3.Controls.Add(this.tbPtsServer);
            this.groupControl3.Location = new System.Drawing.Point(240, 3);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(231, 157);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Настройки подключения «PTS»";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(41, 105);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Пароль";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(48, 79);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(30, 13);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Логин";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(13, 53);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(65, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "База данных";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(41, 27);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(37, 13);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "Сервер";
            // 
            // btnPtsCheckConnection
            // 
            this.btnPtsCheckConnection.Location = new System.Drawing.Point(5, 128);
            this.btnPtsCheckConnection.Name = "btnPtsCheckConnection";
            this.btnPtsCheckConnection.Size = new System.Drawing.Size(140, 23);
            this.btnPtsCheckConnection.TabIndex = 1;
            this.btnPtsCheckConnection.Text = "Проверить подключение";
            this.btnPtsCheckConnection.Click += new System.EventHandler(this.btnPtsCheckConnection_Click);
            // 
            // btnPtsSaveConnection
            // 
            this.btnPtsSaveConnection.Location = new System.Drawing.Point(151, 128);
            this.btnPtsSaveConnection.Name = "btnPtsSaveConnection";
            this.btnPtsSaveConnection.Size = new System.Drawing.Size(75, 23);
            this.btnPtsSaveConnection.TabIndex = 1;
            this.btnPtsSaveConnection.Text = "Сохранить";
            this.btnPtsSaveConnection.Click += new System.EventHandler(this.btnPtsSaveConnection_Click);
            // 
            // tbPtsPassword
            // 
            this.tbPtsPassword.Location = new System.Drawing.Point(84, 102);
            this.tbPtsPassword.Name = "tbPtsPassword";
            this.tbPtsPassword.Properties.PasswordChar = '●';
            this.tbPtsPassword.Size = new System.Drawing.Size(142, 20);
            this.tbPtsPassword.TabIndex = 0;
            // 
            // tbPtsLogin
            // 
            this.tbPtsLogin.Location = new System.Drawing.Point(84, 76);
            this.tbPtsLogin.Name = "tbPtsLogin";
            this.tbPtsLogin.Size = new System.Drawing.Size(142, 20);
            this.tbPtsLogin.TabIndex = 0;
            // 
            // tbPtsDataBase
            // 
            this.tbPtsDataBase.Location = new System.Drawing.Point(84, 50);
            this.tbPtsDataBase.Name = "tbPtsDataBase";
            this.tbPtsDataBase.Size = new System.Drawing.Size(142, 20);
            this.tbPtsDataBase.TabIndex = 0;
            // 
            // tbPtsServer
            // 
            this.tbPtsServer.Location = new System.Drawing.Point(84, 24);
            this.tbPtsServer.Name = "tbPtsServer";
            this.tbPtsServer.Size = new System.Drawing.Size(142, 20);
            this.tbPtsServer.TabIndex = 0;
            // 
            // MainSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Name = "MainSettings";
            this.Size = new System.Drawing.Size(966, 665);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAssaPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAssaLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAssaDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAssaServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPtsPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPtsLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPtsDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPtsServer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAssaCheckConnection;
        private DevExpress.XtraEditors.SimpleButton btnAssaSaveConnection;
        private DevExpress.XtraEditors.TextEdit tbAssaPassword;
        private DevExpress.XtraEditors.TextEdit tbAssaLogin;
        private DevExpress.XtraEditors.TextEdit tbAssaDataBase;
        private DevExpress.XtraEditors.TextEdit tbAssaServer;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnPtsCheckConnection;
        private DevExpress.XtraEditors.SimpleButton btnPtsSaveConnection;
        private DevExpress.XtraEditors.TextEdit tbPtsPassword;
        private DevExpress.XtraEditors.TextEdit tbPtsLogin;
        private DevExpress.XtraEditors.TextEdit tbPtsDataBase;
        private DevExpress.XtraEditors.TextEdit tbPtsServer;
    }
}
