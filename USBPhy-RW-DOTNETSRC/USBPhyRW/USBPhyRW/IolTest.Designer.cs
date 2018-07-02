namespace USBPhyRW
{
    partial class IolTest
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
            this.MegaChAStart = new System.Windows.Forms.Button();
            this.MegaChBStart = new System.Windows.Forms.Button();
            this.GigaT1Start = new System.Windows.Forms.Button();
            this.GigaT2Start = new System.Windows.Forms.Button();
            this.GigaT3Start = new System.Windows.Forms.Button();
            this.GigaT4Start = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MegaTestStop = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GigaT4Stop = new System.Windows.Forms.Button();
            this.GigaT3Stop = new System.Windows.Forms.Button();
            this.GigaT2Stop = new System.Windows.Forms.Button();
            this.GigaT1Stop = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MegaChAStart
            // 
            this.MegaChAStart.Location = new System.Drawing.Point(12, 24);
            this.MegaChAStart.Name = "MegaChAStart";
            this.MegaChAStart.Size = new System.Drawing.Size(126, 30);
            this.MegaChAStart.TabIndex = 4;
            this.MegaChAStart.Text = "100M Channel A";
            this.MegaChAStart.UseVisualStyleBackColor = true;
            this.MegaChAStart.Click += new System.EventHandler(this.MegaChAStart_Click);
            // 
            // MegaChBStart
            // 
            this.MegaChBStart.Location = new System.Drawing.Point(146, 24);
            this.MegaChBStart.Name = "MegaChBStart";
            this.MegaChBStart.Size = new System.Drawing.Size(126, 30);
            this.MegaChBStart.TabIndex = 5;
            this.MegaChBStart.Text = "100M Channel B";
            this.MegaChBStart.UseVisualStyleBackColor = true;
            this.MegaChBStart.Click += new System.EventHandler(this.MegaChBStart_Click);
            // 
            // GigaT1Start
            // 
            this.GigaT1Start.Location = new System.Drawing.Point(9, 21);
            this.GigaT1Start.Name = "GigaT1Start";
            this.GigaT1Start.Size = new System.Drawing.Size(126, 30);
            this.GigaT1Start.TabIndex = 6;
            this.GigaT1Start.Text = "1000M Test Mode 1";
            this.GigaT1Start.UseVisualStyleBackColor = true;
            this.GigaT1Start.Click += new System.EventHandler(this.GigaT1Start_Click);
            // 
            // GigaT2Start
            // 
            this.GigaT2Start.Location = new System.Drawing.Point(9, 59);
            this.GigaT2Start.Name = "GigaT2Start";
            this.GigaT2Start.Size = new System.Drawing.Size(126, 30);
            this.GigaT2Start.TabIndex = 7;
            this.GigaT2Start.Text = "1000M Test Mode 2";
            this.GigaT2Start.UseVisualStyleBackColor = true;
            this.GigaT2Start.Click += new System.EventHandler(this.GigaT2Start_Click);
            // 
            // GigaT3Start
            // 
            this.GigaT3Start.Location = new System.Drawing.Point(9, 97);
            this.GigaT3Start.Name = "GigaT3Start";
            this.GigaT3Start.Size = new System.Drawing.Size(126, 30);
            this.GigaT3Start.TabIndex = 8;
            this.GigaT3Start.Text = "1000M Test Mode 3";
            this.GigaT3Start.UseVisualStyleBackColor = true;
            this.GigaT3Start.Click += new System.EventHandler(this.GigaT3Start_Click);
            // 
            // GigaT4Start
            // 
            this.GigaT4Start.Location = new System.Drawing.Point(9, 133);
            this.GigaT4Start.Name = "GigaT4Start";
            this.GigaT4Start.Size = new System.Drawing.Size(126, 30);
            this.GigaT4Start.TabIndex = 9;
            this.GigaT4Start.Text = "1000M Test Mode 4";
            this.GigaT4Start.UseVisualStyleBackColor = true;
            this.GigaT4Start.Click += new System.EventHandler(this.GigaT4Start_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MegaTestStop);
            this.groupBox2.Location = new System.Drawing.Point(3, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 96);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "100M MLT3";
            // 
            // MegaTestStop
            // 
            this.MegaTestStop.Location = new System.Drawing.Point(64, 51);
            this.MegaTestStop.Name = "MegaTestStop";
            this.MegaTestStop.Size = new System.Drawing.Size(153, 30);
            this.MegaTestStop.TabIndex = 14;
            this.MegaTestStop.Text = "STOP MLT3 TEST(HWRST)";
            this.MegaTestStop.UseVisualStyleBackColor = true;
            this.MegaTestStop.Click += new System.EventHandler(this.MegaTestStop_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.GigaT4Stop);
            this.groupBox3.Controls.Add(this.GigaT3Stop);
            this.groupBox3.Controls.Add(this.GigaT2Stop);
            this.groupBox3.Controls.Add(this.GigaT1Stop);
            this.groupBox3.Controls.Add(this.GigaT3Start);
            this.groupBox3.Controls.Add(this.GigaT1Start);
            this.groupBox3.Controls.Add(this.GigaT4Start);
            this.groupBox3.Controls.Add(this.GigaT2Start);
            this.groupBox3.Location = new System.Drawing.Point(3, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 181);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "1000M";
            // 
            // GigaT4Stop
            // 
            this.GigaT4Stop.Location = new System.Drawing.Point(144, 133);
            this.GigaT4Stop.Name = "GigaT4Stop";
            this.GigaT4Stop.Size = new System.Drawing.Size(126, 30);
            this.GigaT4Stop.TabIndex = 13;
            this.GigaT4Stop.Text = "Stop Test Mode 4";
            this.GigaT4Stop.UseVisualStyleBackColor = true;
            this.GigaT4Stop.Click += new System.EventHandler(this.GigaT4Stop_Click);
            // 
            // GigaT3Stop
            // 
            this.GigaT3Stop.Location = new System.Drawing.Point(144, 97);
            this.GigaT3Stop.Name = "GigaT3Stop";
            this.GigaT3Stop.Size = new System.Drawing.Size(126, 30);
            this.GigaT3Stop.TabIndex = 12;
            this.GigaT3Stop.Text = "Stop Test Mode 3";
            this.GigaT3Stop.UseVisualStyleBackColor = true;
            this.GigaT3Stop.Click += new System.EventHandler(this.GigaT3Stop_Click);
            // 
            // GigaT2Stop
            // 
            this.GigaT2Stop.Location = new System.Drawing.Point(144, 59);
            this.GigaT2Stop.Name = "GigaT2Stop";
            this.GigaT2Stop.Size = new System.Drawing.Size(126, 30);
            this.GigaT2Stop.TabIndex = 11;
            this.GigaT2Stop.Text = "Stop Test Mode 2";
            this.GigaT2Stop.UseVisualStyleBackColor = true;
            this.GigaT2Stop.Click += new System.EventHandler(this.GigaT2Stop_Click);
            // 
            // GigaT1Stop
            // 
            this.GigaT1Stop.Location = new System.Drawing.Point(144, 21);
            this.GigaT1Stop.Name = "GigaT1Stop";
            this.GigaT1Stop.Size = new System.Drawing.Size(126, 30);
            this.GigaT1Stop.TabIndex = 10;
            this.GigaT1Stop.Text = "Stop Test Mode 1";
            this.GigaT1Stop.UseVisualStyleBackColor = true;
            this.GigaT1Stop.Click += new System.EventHandler(this.GigaT1Stop_Click);
            // 
            // IolTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 304);
            this.Controls.Add(this.MegaChBStart);
            this.Controls.Add(this.MegaChAStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IolTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IolTest";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IolTest_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button MegaChAStart;
        private System.Windows.Forms.Button MegaChBStart;
        private System.Windows.Forms.Button GigaT1Start;
        private System.Windows.Forms.Button GigaT2Start;
        private System.Windows.Forms.Button GigaT3Start;
        private System.Windows.Forms.Button GigaT4Start;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button MegaTestStop;
        private System.Windows.Forms.Button GigaT4Stop;
        private System.Windows.Forms.Button GigaT3Stop;
        private System.Windows.Forms.Button GigaT2Stop;
        private System.Windows.Forms.Button GigaT1Stop;
    }
}