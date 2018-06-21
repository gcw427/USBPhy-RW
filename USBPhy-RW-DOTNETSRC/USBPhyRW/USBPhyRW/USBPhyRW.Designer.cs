namespace USBPhyRW
{
    partial class USBPhyRW
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
            this.swlogo = new System.Windows.Forms.PictureBox();
            this.vercode = new System.Windows.Forms.Label();
            this.SWver = new System.Windows.Forms.Label();
            this.checkupdate = new System.Windows.Forms.Button();
            this.author = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.swlogo)).BeginInit();
            this.SuspendLayout();
            // 
            // swlogo
            // 
            this.swlogo.Image = global::USBPhyRW.Properties.Resources.swlogo;
            this.swlogo.Location = new System.Drawing.Point(66, 38);
            this.swlogo.Name = "swlogo";
            this.swlogo.Size = new System.Drawing.Size(151, 126);
            this.swlogo.TabIndex = 0;
            this.swlogo.TabStop = false;
            // 
            // vercode
            // 
            this.vercode.AutoSize = true;
            this.vercode.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vercode.ForeColor = System.Drawing.Color.Blue;
            this.vercode.Location = new System.Drawing.Point(149, 189);
            this.vercode.Name = "vercode";
            this.vercode.Size = new System.Drawing.Size(46, 17);
            this.vercode.TabIndex = 7;
            this.vercode.Text = "v 0.1.8";
            // 
            // SWver
            // 
            this.SWver.AutoSize = true;
            this.SWver.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SWver.ForeColor = System.Drawing.Color.Blue;
            this.SWver.Location = new System.Drawing.Point(87, 189);
            this.SWver.Name = "SWver";
            this.SWver.Size = new System.Drawing.Size(60, 17);
            this.SWver.TabIndex = 6;
            this.SWver.Text = "Core Ver:";
            // 
            // checkupdate
            // 
            this.checkupdate.Location = new System.Drawing.Point(85, 222);
            this.checkupdate.Name = "checkupdate";
            this.checkupdate.Size = new System.Drawing.Size(109, 37);
            this.checkupdate.TabIndex = 8;
            this.checkupdate.Text = "Check SWUpdate";
            this.checkupdate.UseVisualStyleBackColor = true;
            this.checkupdate.Click += new System.EventHandler(this.checkupdate_Click);
            // 
            // author
            // 
            this.author.AutoSize = true;
            this.author.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.author.ForeColor = System.Drawing.Color.DimGray;
            this.author.Location = new System.Drawing.Point(95, 272);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(83, 23);
            this.author.TabIndex = 9;
            this.author.Text = "By Danza";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(170, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(102, 14);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Github PressHere";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // USBPhyRW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 304);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.author);
            this.Controls.Add(this.checkupdate);
            this.Controls.Add(this.vercode);
            this.Controls.Add(this.SWver);
            this.Controls.Add(this.swlogo);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "USBPhyRW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USBPhyRW";
            ((System.ComponentModel.ISupportInitialize)(this.swlogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox swlogo;
        private System.Windows.Forms.Label vercode;
        private System.Windows.Forms.Label SWver;
        private System.Windows.Forms.Button checkupdate;
        private System.Windows.Forms.Label author;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}