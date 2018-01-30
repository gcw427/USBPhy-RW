namespace USBPhyRW
{
    partial class USBsettings
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
            this.iProductID = new System.Windows.Forms.Label();
            this.iVenderID = new System.Windows.Forms.Label();
            this.SetCFG = new System.Windows.Forms.Button();
            this.LoadCFG = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtVendorID = new System.Windows.Forms.TextBox();
            this.CommuTest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // iProductID
            // 
            this.iProductID.AutoSize = true;
            this.iProductID.Font = new System.Drawing.Font("Calibri", 10.5F);
            this.iProductID.Location = new System.Drawing.Point(49, 66);
            this.iProductID.Name = "iProductID";
            this.iProductID.Size = new System.Drawing.Size(63, 17);
            this.iProductID.TabIndex = 0;
            this.iProductID.Text = "PID(HEX):";
            // 
            // iVenderID
            // 
            this.iVenderID.AutoSize = true;
            this.iVenderID.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iVenderID.Location = new System.Drawing.Point(48, 36);
            this.iVenderID.Name = "iVenderID";
            this.iVenderID.Size = new System.Drawing.Size(64, 17);
            this.iVenderID.TabIndex = 1;
            this.iVenderID.Text = "VID(HEX):";
            // 
            // SetCFG
            // 
            this.SetCFG.Location = new System.Drawing.Point(53, 104);
            this.SetCFG.Name = "SetCFG";
            this.SetCFG.Size = new System.Drawing.Size(72, 31);
            this.SetCFG.TabIndex = 4;
            this.SetCFG.Text = "Save 2CFG";
            this.SetCFG.UseVisualStyleBackColor = true;
            this.SetCFG.Click += new System.EventHandler(this.SetCFG_Click);
            // 
            // LoadCFG
            // 
            this.LoadCFG.Location = new System.Drawing.Point(141, 104);
            this.LoadCFG.Name = "LoadCFG";
            this.LoadCFG.Size = new System.Drawing.Size(72, 31);
            this.LoadCFG.TabIndex = 5;
            this.LoadCFG.Text = "Load CFG";
            this.LoadCFG.UseVisualStyleBackColor = true;
            this.LoadCFG.Click += new System.EventHandler(this.LoadCFG_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProductID);
            this.groupBox1.Controls.Add(this.txtVendorID);
            this.groupBox1.Location = new System.Drawing.Point(21, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 139);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USBSettings";
            // 
            // txtProductID
            // 
            this.txtProductID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductID.Location = new System.Drawing.Point(97, 52);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(95, 22);
            this.txtProductID.TabIndex = 9;
            this.txtProductID.Text = "5750";
            // 
            // txtVendorID
            // 
            this.txtVendorID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVendorID.Location = new System.Drawing.Point(97, 23);
            this.txtVendorID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVendorID.Name = "txtVendorID";
            this.txtVendorID.Size = new System.Drawing.Size(95, 22);
            this.txtVendorID.TabIndex = 8;
            this.txtVendorID.Text = "0483";
            // 
            // CommuTest
            // 
            this.CommuTest.Location = new System.Drawing.Point(65, 75);
            this.CommuTest.Name = "CommuTest";
            this.CommuTest.Size = new System.Drawing.Size(93, 31);
            this.CommuTest.TabIndex = 7;
            this.CommuTest.Text = "Test";
            this.CommuTest.UseVisualStyleBackColor = true;
            this.CommuTest.Click += new System.EventHandler(this.CommuTest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stateLabel);
            this.groupBox2.Controls.Add(this.CommuTest);
            this.groupBox2.Location = new System.Drawing.Point(21, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 123);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Communication Test";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.stateLabel.Font = new System.Drawing.Font("Calibri", 18F);
            this.stateLabel.Location = new System.Drawing.Point(54, 32);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(0, 29);
            this.stateLabel.TabIndex = 8;
            // 
            // USBsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 304);
            this.Controls.Add(this.LoadCFG);
            this.Controls.Add(this.SetCFG);
            this.Controls.Add(this.iVenderID);
            this.Controls.Add(this.iProductID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "USBsettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USBsettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label iProductID;
        private System.Windows.Forms.Label iVenderID;
        private System.Windows.Forms.Button SetCFG;
        private System.Windows.Forms.Button LoadCFG;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CommuTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label stateLabel;
        internal System.Windows.Forms.TextBox txtProductID;
        internal System.Windows.Forms.TextBox txtVendorID;
    }
}