namespace USBPhyRW
{
    partial class UsefulCommand
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
            this.HWReset = new System.Windows.Forms.Button();
            this.SWReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HWReset
            // 
            this.HWReset.Location = new System.Drawing.Point(79, 81);
            this.HWReset.Name = "HWReset";
            this.HWReset.Size = new System.Drawing.Size(122, 52);
            this.HWReset.TabIndex = 0;
            this.HWReset.Text = "HW Reset PHY";
            this.HWReset.UseVisualStyleBackColor = true;
            this.HWReset.Click += new System.EventHandler(this.HWReset_Click);
            // 
            // SWReset
            // 
            this.SWReset.Location = new System.Drawing.Point(79, 156);
            this.SWReset.Name = "SWReset";
            this.SWReset.Size = new System.Drawing.Size(122, 52);
            this.SWReset.TabIndex = 1;
            this.SWReset.Text = "SW Reset PHY";
            this.SWReset.UseVisualStyleBackColor = true;
            this.SWReset.Click += new System.EventHandler(this.SWReset_Click);
            // 
            // UsefulCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 304);
            this.Controls.Add(this.SWReset);
            this.Controls.Add(this.HWReset);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsefulCommand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsefulCommand";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UsefulCommand_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button HWReset;
        private System.Windows.Forms.Button SWReset;
    }
}