namespace USBPhyRW
{
    partial class USBBoard
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
            this.HardBoardver = new System.Windows.Forms.Label();
            this.Hardwarefw = new System.Windows.Forms.Label();
            this.vercode = new System.Windows.Forms.Label();
            this.fwcode = new System.Windows.Forms.Label();
            this.checkfwupdate = new System.Windows.Forms.Button();
            this.pcblogo = new System.Windows.Forms.PictureBox();
            this.author = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcblogo)).BeginInit();
            this.SuspendLayout();
            // 
            // HardBoardver
            // 
            this.HardBoardver.AutoSize = true;
            this.HardBoardver.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardBoardver.ForeColor = System.Drawing.Color.Blue;
            this.HardBoardver.Location = new System.Drawing.Point(80, 180);
            this.HardBoardver.Name = "HardBoardver";
            this.HardBoardver.Size = new System.Drawing.Size(56, 17);
            this.HardBoardver.TabIndex = 2;
            this.HardBoardver.Text = "PCB Ver:";
            // 
            // Hardwarefw
            // 
            this.Hardwarefw.AutoSize = true;
            this.Hardwarefw.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hardwarefw.ForeColor = System.Drawing.Color.Blue;
            this.Hardwarefw.Location = new System.Drawing.Point(80, 202);
            this.Hardwarefw.Name = "Hardwarefw";
            this.Hardwarefw.Size = new System.Drawing.Size(52, 17);
            this.Hardwarefw.TabIndex = 4;
            this.Hardwarefw.Text = "FW Ver:";
            // 
            // vercode
            // 
            this.vercode.AutoSize = true;
            this.vercode.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vercode.ForeColor = System.Drawing.Color.Blue;
            this.vercode.Location = new System.Drawing.Point(142, 180);
            this.vercode.Name = "vercode";
            this.vercode.Size = new System.Drawing.Size(96, 17);
            this.vercode.TabIndex = 5;
            this.vercode.Text = "v02-2017-01-10";
            // 
            // fwcode
            // 
            this.fwcode.AutoSize = true;
            this.fwcode.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fwcode.ForeColor = System.Drawing.Color.Blue;
            this.fwcode.Location = new System.Drawing.Point(142, 202);
            this.fwcode.Name = "fwcode";
            this.fwcode.Size = new System.Drawing.Size(46, 17);
            this.fwcode.TabIndex = 6;
            this.fwcode.Text = "v 0.1.4";
            // 
            // checkfwupdate
            // 
            this.checkfwupdate.Location = new System.Drawing.Point(83, 233);
            this.checkfwupdate.Name = "checkfwupdate";
            this.checkfwupdate.Size = new System.Drawing.Size(109, 37);
            this.checkfwupdate.TabIndex = 7;
            this.checkfwupdate.Text = "Check FWUpdate";
            this.checkfwupdate.UseVisualStyleBackColor = true;
            this.checkfwupdate.Click += new System.EventHandler(this.checkfwupdate_Click);
            // 
            // pcblogo
            // 
            this.pcblogo.Image = global::USBPhyRW.Properties.Resources.pcblogo;
            this.pcblogo.Location = new System.Drawing.Point(75, 29);
            this.pcblogo.Name = "pcblogo";
            this.pcblogo.Size = new System.Drawing.Size(123, 131);
            this.pcblogo.TabIndex = 3;
            this.pcblogo.TabStop = false;
            // 
            // author
            // 
            this.author.AutoSize = true;
            this.author.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.author.ForeColor = System.Drawing.Color.DimGray;
            this.author.Location = new System.Drawing.Point(95, 275);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(83, 23);
            this.author.TabIndex = 8;
            this.author.Text = "By Danza";
            // 
            // USBBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 304);
            this.Controls.Add(this.author);
            this.Controls.Add(this.checkfwupdate);
            this.Controls.Add(this.fwcode);
            this.Controls.Add(this.vercode);
            this.Controls.Add(this.Hardwarefw);
            this.Controls.Add(this.pcblogo);
            this.Controls.Add(this.HardBoardver);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "USBBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USBBoard";
            ((System.ComponentModel.ISupportInitialize)(this.pcblogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HardBoardver;
        private System.Windows.Forms.PictureBox pcblogo;
        private System.Windows.Forms.Label Hardwarefw;
        private System.Windows.Forms.Label vercode;
        private System.Windows.Forms.Label fwcode;
        private System.Windows.Forms.Button checkfwupdate;
        private System.Windows.Forms.Label author;
    }
}