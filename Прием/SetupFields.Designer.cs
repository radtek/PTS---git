namespace Прием
{
    partial class SetupFields
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
            this.scanFields = new Прием.ScanFields();
            this.SuspendLayout();
            // 
            // scanFields
            // 
            this.scanFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scanFields.Location = new System.Drawing.Point(0, 0);
            this.scanFields.Name = "scanFields";
            this.scanFields.Size = new System.Drawing.Size(823, 547);
            this.scanFields.TabIndex = 0;
            // 
            // SetupFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 547);
            this.Controls.Add(this.scanFields);
            this.Name = "SetupFields";
            this.Text = "SetupFields";
            this.Load += new System.EventHandler(this.SetupFields_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ScanFields scanFields;
    }
}