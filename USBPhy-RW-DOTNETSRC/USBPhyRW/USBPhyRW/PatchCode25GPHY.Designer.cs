namespace USBPhyRW
{
    partial class PatchCode25GPHY
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
            this.Polling25G = new System.Windows.Forms.Button();
            this.CheckICVer = new System.Windows.Forms.Button();
            this.dbgshow = new System.Windows.Forms.Label();
            this.phyStatus = new System.Windows.Forms.Label();
            this.LDPatchCode1 = new System.Windows.Forms.Button();
            this.LDPatchCode2 = new System.Windows.Forms.Button();
            this.LDPatchCode3 = new System.Windows.Forms.Button();
            this.LDPatchCode4 = new System.Windows.Forms.Button();
            this.LDPatchCode5 = new System.Windows.Forms.Button();
            this.LDPatchCode6 = new System.Windows.Forms.Button();
            this.LDPatchCode7 = new System.Windows.Forms.Button();
            this.LDPatchCode8 = new System.Windows.Forms.Button();
            this.ApplyAll = new System.Windows.Forms.Button();
            this.patchProgressBar = new System.Windows.Forms.ProgressBar();
            this.patchProgressNote = new System.Windows.Forms.Label();
            this.patchDetailProgress = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatchDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatchList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patchProgress = new System.Windows.Forms.DataGridView();
            this.dbg2show = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.patchDetailProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patchProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // Polling25G
            // 
            this.Polling25G.Location = new System.Drawing.Point(12, 30);
            this.Polling25G.Name = "Polling25G";
            this.Polling25G.Size = new System.Drawing.Size(96, 43);
            this.Polling25G.TabIndex = 0;
            this.Polling25G.Text = "Polling Status";
            this.Polling25G.UseVisualStyleBackColor = true;
            this.Polling25G.Click += new System.EventHandler(this.Polling25G_Click);
            // 
            // CheckICVer
            // 
            this.CheckICVer.Location = new System.Drawing.Point(109, 30);
            this.CheckICVer.Name = "CheckICVer";
            this.CheckICVer.Size = new System.Drawing.Size(91, 43);
            this.CheckICVer.TabIndex = 1;
            this.CheckICVer.Text = "Check RamCode";
            this.CheckICVer.UseVisualStyleBackColor = true;
            this.CheckICVer.Click += new System.EventHandler(this.CheckICVer_Click);
            // 
            // dbgshow
            // 
            this.dbgshow.AutoSize = true;
            this.dbgshow.Location = new System.Drawing.Point(529, 14);
            this.dbgshow.Name = "dbgshow";
            this.dbgshow.Size = new System.Drawing.Size(23, 12);
            this.dbgshow.TabIndex = 2;
            this.dbgshow.Text = "dbg";
            // 
            // phyStatus
            // 
            this.phyStatus.AutoSize = true;
            this.phyStatus.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.phyStatus.Font = new System.Drawing.Font("Calibri", 12F);
            this.phyStatus.ForeColor = System.Drawing.Color.Lime;
            this.phyStatus.Location = new System.Drawing.Point(14, 5);
            this.phyStatus.Name = "phyStatus";
            this.phyStatus.Size = new System.Drawing.Size(120, 19);
            this.phyStatus.TabIndex = 3;
            this.phyStatus.Text = "MODE: UnKnown";
            // 
            // LDPatchCode1
            // 
            this.LDPatchCode1.Location = new System.Drawing.Point(12, 74);
            this.LDPatchCode1.Name = "LDPatchCode1";
            this.LDPatchCode1.Size = new System.Drawing.Size(188, 32);
            this.LDPatchCode1.TabIndex = 4;
            this.LDPatchCode1.Text = "Set Patch Key and Lock";
            this.LDPatchCode1.UseVisualStyleBackColor = true;
            this.LDPatchCode1.Click += new System.EventHandler(this.LDPatchCode1_Click);
            // 
            // LDPatchCode2
            // 
            this.LDPatchCode2.Location = new System.Drawing.Point(12, 107);
            this.LDPatchCode2.Name = "LDPatchCode2";
            this.LDPatchCode2.Size = new System.Drawing.Size(188, 32);
            this.LDPatchCode2.TabIndex = 6;
            this.LDPatchCode2.Text = "Load Patch NC0";
            this.LDPatchCode2.UseVisualStyleBackColor = true;
            this.LDPatchCode2.Click += new System.EventHandler(this.LDPatchCode2_Click);
            // 
            // LDPatchCode3
            // 
            this.LDPatchCode3.Location = new System.Drawing.Point(12, 140);
            this.LDPatchCode3.Name = "LDPatchCode3";
            this.LDPatchCode3.Size = new System.Drawing.Size(188, 32);
            this.LDPatchCode3.TabIndex = 7;
            this.LDPatchCode3.Text = "Load Patch NC1";
            this.LDPatchCode3.UseVisualStyleBackColor = true;
            this.LDPatchCode3.Click += new System.EventHandler(this.LDPatchCode3_Click);
            // 
            // LDPatchCode4
            // 
            this.LDPatchCode4.Location = new System.Drawing.Point(12, 173);
            this.LDPatchCode4.Name = "LDPatchCode4";
            this.LDPatchCode4.Size = new System.Drawing.Size(188, 32);
            this.LDPatchCode4.TabIndex = 8;
            this.LDPatchCode4.Text = "Load Patch NC2";
            this.LDPatchCode4.UseVisualStyleBackColor = true;
            this.LDPatchCode4.Click += new System.EventHandler(this.LDPatchCode4_Click);
            // 
            // LDPatchCode5
            // 
            this.LDPatchCode5.Location = new System.Drawing.Point(12, 206);
            this.LDPatchCode5.Name = "LDPatchCode5";
            this.LDPatchCode5.Size = new System.Drawing.Size(188, 32);
            this.LDPatchCode5.TabIndex = 9;
            this.LDPatchCode5.Text = "Load Patch UC2";
            this.LDPatchCode5.UseVisualStyleBackColor = true;
            this.LDPatchCode5.Click += new System.EventHandler(this.LDPatchCode5_Click);
            // 
            // LDPatchCode6
            // 
            this.LDPatchCode6.Location = new System.Drawing.Point(12, 239);
            this.LDPatchCode6.Name = "LDPatchCode6";
            this.LDPatchCode6.Size = new System.Drawing.Size(188, 32);
            this.LDPatchCode6.TabIndex = 10;
            this.LDPatchCode6.Text = "Load Patch UC";
            this.LDPatchCode6.UseVisualStyleBackColor = true;
            this.LDPatchCode6.Click += new System.EventHandler(this.LDPatchCode6_Click);
            // 
            // LDPatchCode7
            // 
            this.LDPatchCode7.Location = new System.Drawing.Point(12, 272);
            this.LDPatchCode7.Name = "LDPatchCode7";
            this.LDPatchCode7.Size = new System.Drawing.Size(188, 32);
            this.LDPatchCode7.TabIndex = 11;
            this.LDPatchCode7.Text = "Clear Patch Key and Lock";
            this.LDPatchCode7.UseVisualStyleBackColor = true;
            this.LDPatchCode7.Click += new System.EventHandler(this.LDPatchCode7_Click);
            // 
            // LDPatchCode8
            // 
            this.LDPatchCode8.Location = new System.Drawing.Point(12, 305);
            this.LDPatchCode8.Name = "LDPatchCode8";
            this.LDPatchCode8.Size = new System.Drawing.Size(188, 32);
            this.LDPatchCode8.TabIndex = 12;
            this.LDPatchCode8.Text = "Load Issue Code";
            this.LDPatchCode8.UseVisualStyleBackColor = true;
            this.LDPatchCode8.Click += new System.EventHandler(this.LDPatchCode8_Click);
            // 
            // ApplyAll
            // 
            this.ApplyAll.Location = new System.Drawing.Point(12, 338);
            this.ApplyAll.Name = "ApplyAll";
            this.ApplyAll.Size = new System.Drawing.Size(188, 32);
            this.ApplyAll.TabIndex = 13;
            this.ApplyAll.Text = "Apply Patch";
            this.ApplyAll.UseVisualStyleBackColor = true;
            this.ApplyAll.Click += new System.EventHandler(this.ApplyAll_Click);
            // 
            // patchProgressBar
            // 
            this.patchProgressBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.patchProgressBar.Location = new System.Drawing.Point(235, 351);
            this.patchProgressBar.Name = "patchProgressBar";
            this.patchProgressBar.Size = new System.Drawing.Size(405, 19);
            this.patchProgressBar.TabIndex = 14;
            // 
            // patchProgressNote
            // 
            this.patchProgressNote.AutoSize = true;
            this.patchProgressNote.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.patchProgressNote.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patchProgressNote.ForeColor = System.Drawing.Color.Lime;
            this.patchProgressNote.Location = new System.Drawing.Point(235, 329);
            this.patchProgressNote.Name = "patchProgressNote";
            this.patchProgressNote.Size = new System.Drawing.Size(49, 19);
            this.patchProgressNote.TabIndex = 15;
            this.patchProgressNote.Text = "Ready";
            // 
            // patchDetailProgress
            // 
            this.patchDetailProgress.AllowUserToAddRows = false;
            this.patchDetailProgress.AllowUserToDeleteRows = false;
            this.patchDetailProgress.AllowUserToResizeColumns = false;
            this.patchDetailProgress.AllowUserToResizeRows = false;
            this.patchDetailProgress.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.patchDetailProgress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.patchDetailProgress.Location = new System.Drawing.Point(235, 242);
            this.patchDetailProgress.MultiSelect = false;
            this.patchDetailProgress.Name = "patchDetailProgress";
            this.patchDetailProgress.RowHeadersVisible = false;
            this.patchDetailProgress.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.patchDetailProgress.RowTemplate.Height = 23;
            this.patchDetailProgress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patchDetailProgress.ShowCellErrors = false;
            this.patchDetailProgress.ShowCellToolTips = false;
            this.patchDetailProgress.ShowEditingIcon = false;
            this.patchDetailProgress.ShowRowErrors = false;
            this.patchDetailProgress.Size = new System.Drawing.Size(405, 86);
            this.patchDetailProgress.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Patch Sequence";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Patch Detail Information";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 285;
            // 
            // PatchDetail
            // 
            this.PatchDetail.HeaderText = "Patch Set Description";
            this.PatchDetail.Name = "PatchDetail";
            this.PatchDetail.ReadOnly = true;
            this.PatchDetail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PatchDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PatchDetail.Width = 300;
            // 
            // PatchList
            // 
            this.PatchList.HeaderText = "Patch Action";
            this.PatchList.Name = "PatchList";
            this.PatchList.ReadOnly = true;
            this.PatchList.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PatchList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // patchProgress
            // 
            this.patchProgress.AllowUserToAddRows = false;
            this.patchProgress.AllowUserToDeleteRows = false;
            this.patchProgress.AllowUserToResizeColumns = false;
            this.patchProgress.AllowUserToResizeRows = false;
            this.patchProgress.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.patchProgress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatchList,
            this.PatchDetail});
            this.patchProgress.Location = new System.Drawing.Point(235, 30);
            this.patchProgress.MultiSelect = false;
            this.patchProgress.Name = "patchProgress";
            this.patchProgress.RowHeadersVisible = false;
            this.patchProgress.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.patchProgress.RowTemplate.Height = 23;
            this.patchProgress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patchProgress.ShowCellErrors = false;
            this.patchProgress.ShowCellToolTips = false;
            this.patchProgress.ShowEditingIcon = false;
            this.patchProgress.ShowRowErrors = false;
            this.patchProgress.Size = new System.Drawing.Size(405, 210);
            this.patchProgress.TabIndex = 5;
            // 
            // dbg2show
            // 
            this.dbg2show.AutoSize = true;
            this.dbg2show.Location = new System.Drawing.Point(431, 14);
            this.dbg2show.Name = "dbg2show";
            this.dbg2show.Size = new System.Drawing.Size(41, 12);
            this.dbg2show.TabIndex = 17;
            this.dbg2show.Text = "label1";
            // 
            // PatchCode25GPHY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 390);
            this.Controls.Add(this.dbg2show);
            this.Controls.Add(this.patchDetailProgress);
            this.Controls.Add(this.patchProgressNote);
            this.Controls.Add(this.patchProgressBar);
            this.Controls.Add(this.ApplyAll);
            this.Controls.Add(this.LDPatchCode8);
            this.Controls.Add(this.LDPatchCode7);
            this.Controls.Add(this.LDPatchCode6);
            this.Controls.Add(this.LDPatchCode5);
            this.Controls.Add(this.LDPatchCode4);
            this.Controls.Add(this.LDPatchCode3);
            this.Controls.Add(this.LDPatchCode2);
            this.Controls.Add(this.patchProgress);
            this.Controls.Add(this.LDPatchCode1);
            this.Controls.Add(this.phyStatus);
            this.Controls.Add(this.dbgshow);
            this.Controls.Add(this.CheckICVer);
            this.Controls.Add(this.Polling25G);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatchCode25GPHY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PatchCode 2.5G PHY";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PatchCode25GPHY_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.patchDetailProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patchProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Polling25G;
        private System.Windows.Forms.Button CheckICVer;
        private System.Windows.Forms.Label dbgshow;
        private System.Windows.Forms.Label phyStatus;
        private System.Windows.Forms.Button LDPatchCode1;
        private System.Windows.Forms.Button LDPatchCode2;
        private System.Windows.Forms.Button LDPatchCode3;
        private System.Windows.Forms.Button LDPatchCode4;
        private System.Windows.Forms.Button LDPatchCode5;
        private System.Windows.Forms.Button LDPatchCode6;
        private System.Windows.Forms.Button LDPatchCode7;
        private System.Windows.Forms.Button LDPatchCode8;
        private System.Windows.Forms.Button ApplyAll;
        private System.Windows.Forms.ProgressBar patchProgressBar;
        private System.Windows.Forms.Label patchProgressNote;
        private System.Windows.Forms.DataGridView patchDetailProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatchDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatchList;
        private System.Windows.Forms.DataGridView patchProgress;
        private System.Windows.Forms.Label dbg2show;
    }
}