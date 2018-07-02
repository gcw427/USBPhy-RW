namespace USBPhyRW
{
    partial class Logsettings
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
            this.Loglevel = new System.Windows.Forms.TrackBar();
            this.lognote = new System.Windows.Forms.Label();
            this.Note = new System.Windows.Forms.Label();
            this.Display = new System.Windows.Forms.Label();
            this.logButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Loglevel)).BeginInit();
            this.SuspendLayout();
            // 
            // Loglevel
            // 
            this.Loglevel.LargeChange = 1;
            this.Loglevel.Location = new System.Drawing.Point(34, 112);
            this.Loglevel.Maximum = 4;
            this.Loglevel.Name = "Loglevel";
            this.Loglevel.Size = new System.Drawing.Size(203, 45);
            this.Loglevel.TabIndex = 0;
            this.Loglevel.ValueChanged += new System.EventHandler(this.Loglevel_ValueChanged);
            // 
            // lognote
            // 
            this.lognote.AutoSize = true;
            this.lognote.Location = new System.Drawing.Point(43, 170);
            this.lognote.Name = "lognote";
            this.lognote.Size = new System.Drawing.Size(97, 14);
            this.lognote.TabIndex = 1;
            this.lognote.Text = "Current Loglevel:";
            // 
            // Note
            // 
            this.Note.AutoSize = true;
            this.Note.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note.Location = new System.Drawing.Point(31, 66);
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(222, 17);
            this.Note.TabIndex = 3;
            this.Note.Text = "Please Slide the bar to change loglevel";
            // 
            // Display
            // 
            this.Display.AutoSize = true;
            this.Display.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Display.ForeColor = System.Drawing.Color.Red;
            this.Display.Location = new System.Drawing.Point(140, 169);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(50, 17);
            this.Display.TabIndex = 4;
            this.Display.Text = "DEBUG";
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(89, 220);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(89, 39);
            this.logButton.TabIndex = 5;
            this.logButton.Text = "Save to CFG";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // Logsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 304);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.Note);
            this.Controls.Add(this.lognote);
            this.Controls.Add(this.Loglevel);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Logsettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Logsettings";
            ((System.ComponentModel.ISupportInitialize)(this.Loglevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar Loglevel;
        private System.Windows.Forms.Label lognote;
        private System.Windows.Forms.Label Note;
        private System.Windows.Forms.Label Display;
        private System.Windows.Forms.Button logButton;
    }
}