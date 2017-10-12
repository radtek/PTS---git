namespace Прием
{
    partial class ImportData
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
            this.eventType = new Прием.EventType();
            this.SuspendLayout();
            // 
            // eventType
            // 
            this.eventType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventType.Location = new System.Drawing.Point(0, 0);
            this.eventType.Name = "eventType";
            this.eventType.Size = new System.Drawing.Size(860, 531);
            this.eventType.TabIndex = 0;
            // 
            // ImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 531);
            this.Controls.Add(this.eventType);
            this.Name = "ImportData";
            this.Text = "Мастер импорта";
            this.ResumeLayout(false);

        }

        #endregion

        private EventType eventType;
    }
}