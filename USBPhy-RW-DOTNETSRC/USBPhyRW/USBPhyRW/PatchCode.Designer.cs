namespace USBPhyRW
{
    partial class PatchCode
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
            this.loadPatch = new System.Windows.Forms.Button();
            this.downLoadPatch = new System.Windows.Forms.Button();
            this.patchContent = new System.Windows.Forms.DataGridView();
            this.patchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patchType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patchPHYID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patchRegAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patchRegValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patchPATH = new System.Windows.Forms.Label();
            this.patchLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.patchContent)).BeginInit();
            this.SuspendLayout();
            // 
            // loadPatch
            // 
            this.loadPatch.Location = new System.Drawing.Point(30, 8);
            this.loadPatch.Name = "loadPatch";
            this.loadPatch.Size = new System.Drawing.Size(112, 54);
            this.loadPatch.TabIndex = 0;
            this.loadPatch.Text = "LoadPatchCode";
            this.loadPatch.UseVisualStyleBackColor = true;
            this.loadPatch.Click += new System.EventHandler(this.loadPatch_Click);
            // 
            // downLoadPatch
            // 
            this.downLoadPatch.Location = new System.Drawing.Point(187, 8);
            this.downLoadPatch.Name = "downLoadPatch";
            this.downLoadPatch.Size = new System.Drawing.Size(112, 54);
            this.downLoadPatch.TabIndex = 1;
            this.downLoadPatch.Text = "DownLoad to Phy";
            this.downLoadPatch.UseVisualStyleBackColor = true;
            this.downLoadPatch.Click += new System.EventHandler(this.downLoadPatch_Click);
            // 
            // patchContent
            // 
            this.patchContent.AllowUserToAddRows = false;
            this.patchContent.AllowUserToResizeColumns = false;
            this.patchContent.AllowUserToResizeRows = false;
            this.patchContent.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.patchContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patchNo,
            this.patchType,
            this.patchPHYID,
            this.patchRegAddr,
            this.patchRegValue});
            this.patchContent.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.patchContent.Location = new System.Drawing.Point(12, 137);
            this.patchContent.MultiSelect = false;
            this.patchContent.Name = "patchContent";
            this.patchContent.RowHeadersVisible = false;
            this.patchContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.patchContent.RowTemplate.Height = 23;
            this.patchContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patchContent.ShowCellErrors = false;
            this.patchContent.ShowCellToolTips = false;
            this.patchContent.ShowEditingIcon = false;
            this.patchContent.ShowRowErrors = false;
            this.patchContent.Size = new System.Drawing.Size(305, 184);
            this.patchContent.TabIndex = 2;
            this.patchContent.Visible = false;
            // 
            // patchNo
            // 
            this.patchNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.patchNo.HeaderText = "No.";
            this.patchNo.Name = "patchNo";
            this.patchNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.patchNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patchNo.Width = 30;
            // 
            // patchType
            // 
            this.patchType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.patchType.HeaderText = "Type";
            this.patchType.Name = "patchType";
            this.patchType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.patchType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patchType.Width = 40;
            // 
            // patchPHYID
            // 
            this.patchPHYID.HeaderText = "PHYID";
            this.patchPHYID.Name = "patchPHYID";
            this.patchPHYID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.patchPHYID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patchPHYID.Width = 50;
            // 
            // patchRegAddr
            // 
            this.patchRegAddr.HeaderText = "RegAddr";
            this.patchRegAddr.Name = "patchRegAddr";
            this.patchRegAddr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.patchRegAddr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patchRegAddr.Width = 70;
            // 
            // patchRegValue
            // 
            this.patchRegValue.HeaderText = "RegValue";
            this.patchRegValue.Name = "patchRegValue";
            this.patchRegValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.patchRegValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patchRegValue.Width = 80;
            // 
            // patchPATH
            // 
            this.patchPATH.AutoSize = true;
            this.patchPATH.Location = new System.Drawing.Point(12, 88);
            this.patchPATH.Name = "patchPATH";
            this.patchPATH.Size = new System.Drawing.Size(0, 14);
            this.patchPATH.TabIndex = 3;
            // 
            // patchLabel
            // 
            this.patchLabel.AutoSize = true;
            this.patchLabel.Location = new System.Drawing.Point(12, 70);
            this.patchLabel.Name = "patchLabel";
            this.patchLabel.Size = new System.Drawing.Size(0, 14);
            this.patchLabel.TabIndex = 4;
            // 
            // PatchCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 333);
            this.Controls.Add(this.patchLabel);
            this.Controls.Add(this.patchPATH);
            this.Controls.Add(this.patchContent);
            this.Controls.Add(this.downLoadPatch);
            this.Controls.Add(this.loadPatch);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatchCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PatchCode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PatchCode_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.patchContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadPatch;
        private System.Windows.Forms.Button downLoadPatch;
        private System.Windows.Forms.Label patchPATH;
        private System.Windows.Forms.DataGridViewTextBoxColumn patchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn patchType;
        private System.Windows.Forms.DataGridViewTextBoxColumn patchPHYID;
        private System.Windows.Forms.DataGridViewTextBoxColumn patchRegAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn patchRegValue;
        private System.Windows.Forms.DataGridView patchContent;
        private System.Windows.Forms.Label patchLabel;
    }
}