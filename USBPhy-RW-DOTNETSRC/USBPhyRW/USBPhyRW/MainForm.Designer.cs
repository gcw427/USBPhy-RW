namespace USBPhyRW
{
    partial class MainDialog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
            this.menuItem = new System.Windows.Forms.MenuStrip();
            this.functionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectChipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTL8226ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTL8211FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTL8211EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTL8211DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTL8201FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTL8201FVBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTL8201FVCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTL8201FVDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTL8201EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iOLTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loopBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpAllRegToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usefulCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packetGenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBsettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logsettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBPhyRWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chipTypeBox = new System.Windows.Forms.Label();
            this.phyAddr = new System.Windows.Forms.Label();
            this.phyAddrbox = new System.Windows.Forms.TextBox();
            this.regAddr = new System.Windows.Forms.Label();
            this.phyRegbox = new System.Windows.Forms.TextBox();
            this.regValue = new System.Windows.Forms.Label();
            this.phyValuebox = new System.Windows.Forms.TextBox();
            this.readPhy = new System.Windows.Forms.Button();
            this.writePhy = new System.Windows.Forms.Button();
            this.ReadWrite = new System.Windows.Forms.GroupBox();
            this.note4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.devAdbox = new System.Windows.Forms.TextBox();
            this.DEVAD = new System.Windows.Forms.Label();
            this.bit15 = new System.Windows.Forms.Label();
            this.note3 = new System.Windows.Forms.Label();
            this.bit14 = new System.Windows.Forms.Label();
            this.note2 = new System.Windows.Forms.Label();
            this.bit13 = new System.Windows.Forms.Label();
            this.bit12 = new System.Windows.Forms.Label();
            this.bit0 = new System.Windows.Forms.Label();
            this.bit11 = new System.Windows.Forms.Label();
            this.bit1 = new System.Windows.Forms.Label();
            this.bit10 = new System.Windows.Forms.Label();
            this.bit2 = new System.Windows.Forms.Label();
            this.bit9 = new System.Windows.Forms.Label();
            this.bit3 = new System.Windows.Forms.Label();
            this.bit8 = new System.Windows.Forms.Label();
            this.bit4 = new System.Windows.Forms.Label();
            this.bit7 = new System.Windows.Forms.Label();
            this.bit5 = new System.Windows.Forms.Label();
            this.bit6 = new System.Windows.Forms.Label();
            this.note1 = new System.Windows.Forms.Label();
            this.regNotice = new System.Windows.Forms.TextBox();
            this.regNoticeBar = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuItem.SuspendLayout();
            this.ReadWrite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuItem
            // 
            this.menuItem.Font = new System.Drawing.Font("Calibri", 9F);
            this.menuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.uSBSettingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuItem.Location = new System.Drawing.Point(0, 0);
            this.menuItem.Name = "menuItem";
            this.menuItem.Size = new System.Drawing.Size(406, 24);
            this.menuItem.TabIndex = 0;
            this.menuItem.Text = "menuStrip1";
            // 
            // functionsToolStripMenuItem
            // 
            this.functionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectChipToolStripMenuItem,
            this.iOLTestToolStripMenuItem,
            this.loopBackToolStripMenuItem,
            this.patchCodeToolStripMenuItem,
            this.dumpAllRegToolStripMenuItem,
            this.usefulCommandToolStripMenuItem,
            this.packetGenToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.functionsToolStripMenuItem.Text = "Functions";
            // 
            // selectChipToolStripMenuItem
            // 
            this.selectChipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rTL8226ToolStripMenuItem,
            this.rTL8211FToolStripMenuItem,
            this.rTL8211EToolStripMenuItem,
            this.rTL8211DToolStripMenuItem,
            this.rTL8201FToolStripMenuItem,
            this.rTL8201FVBToolStripMenuItem,
            this.rTL8201FVCToolStripMenuItem,
            this.rTL8201FVDToolStripMenuItem,
            this.rTL8201EToolStripMenuItem});
            this.selectChipToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.iclogo;
            this.selectChipToolStripMenuItem.Name = "selectChipToolStripMenuItem";
            this.selectChipToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.selectChipToolStripMenuItem.Text = "Select Chip";
            // 
            // rTL8226ToolStripMenuItem
            // 
            this.rTL8226ToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.chipsetlogo;
            this.rTL8226ToolStripMenuItem.Name = "rTL8226ToolStripMenuItem";
            this.rTL8226ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rTL8226ToolStripMenuItem.Text = "RTL8226 2.5G Series";
            this.rTL8226ToolStripMenuItem.Click += new System.EventHandler(this.rTL8226ToolStripMenuItem_Click);
            // 
            // rTL8211FToolStripMenuItem
            // 
            this.rTL8211FToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.chipsetlogo;
            this.rTL8211FToolStripMenuItem.Name = "rTL8211FToolStripMenuItem";
            this.rTL8211FToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rTL8211FToolStripMenuItem.Text = "RTL8211F Series";
            this.rTL8211FToolStripMenuItem.Click += new System.EventHandler(this.rTL8211FToolStripMenuItem_Click);
            // 
            // rTL8211EToolStripMenuItem
            // 
            this.rTL8211EToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.chipsetlogo;
            this.rTL8211EToolStripMenuItem.Name = "rTL8211EToolStripMenuItem";
            this.rTL8211EToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rTL8211EToolStripMenuItem.Text = "RTL8211E Series";
            this.rTL8211EToolStripMenuItem.Click += new System.EventHandler(this.rTL8211EToolStripMenuItem_Click);
            // 
            // rTL8211DToolStripMenuItem
            // 
            this.rTL8211DToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.chipsetlogo;
            this.rTL8211DToolStripMenuItem.Name = "rTL8211DToolStripMenuItem";
            this.rTL8211DToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rTL8211DToolStripMenuItem.Text = "RTL8211D Series";
            this.rTL8211DToolStripMenuItem.Click += new System.EventHandler(this.rTL8211DToolStripMenuItem_Click);
            // 
            // rTL8201FToolStripMenuItem
            // 
            this.rTL8201FToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.chipsetlogo;
            this.rTL8201FToolStripMenuItem.Name = "rTL8201FToolStripMenuItem";
            this.rTL8201FToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rTL8201FToolStripMenuItem.Text = "RTL8201F-VA Series";
            this.rTL8201FToolStripMenuItem.Click += new System.EventHandler(this.rTL8201FToolStripMenuItem_Click);
            // 
            // rTL8201FVBToolStripMenuItem
            // 
            this.rTL8201FVBToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.chipsetlogo;
            this.rTL8201FVBToolStripMenuItem.Name = "rTL8201FVBToolStripMenuItem";
            this.rTL8201FVBToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rTL8201FVBToolStripMenuItem.Text = "RTL8201F-VB Series";
            this.rTL8201FVBToolStripMenuItem.Click += new System.EventHandler(this.rTL8201FVBToolStripMenuItem_Click);
            // 
            // rTL8201FVCToolStripMenuItem
            // 
            this.rTL8201FVCToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.chipsetlogo;
            this.rTL8201FVCToolStripMenuItem.Name = "rTL8201FVCToolStripMenuItem";
            this.rTL8201FVCToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rTL8201FVCToolStripMenuItem.Text = "RTL8201F-VC  Series";
            this.rTL8201FVCToolStripMenuItem.Click += new System.EventHandler(this.rTL8201FVCToolStripMenuItem_Click);
            // 
            // rTL8201FVDToolStripMenuItem
            // 
            this.rTL8201FVDToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.chipsetlogo;
            this.rTL8201FVDToolStripMenuItem.Name = "rTL8201FVDToolStripMenuItem";
            this.rTL8201FVDToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rTL8201FVDToolStripMenuItem.Text = "RTL8201F-VD  Series";
            this.rTL8201FVDToolStripMenuItem.Click += new System.EventHandler(this.rTL8201FVDToolStripMenuItem_Click);
            // 
            // rTL8201EToolStripMenuItem
            // 
            this.rTL8201EToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.chipsetlogo;
            this.rTL8201EToolStripMenuItem.Name = "rTL8201EToolStripMenuItem";
            this.rTL8201EToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rTL8201EToolStripMenuItem.Text = "RTL8201E Series";
            this.rTL8201EToolStripMenuItem.Click += new System.EventHandler(this.rTL8201EToolStripMenuItem_Click);
            // 
            // iOLTestToolStripMenuItem
            // 
            this.iOLTestToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.iollogo;
            this.iOLTestToolStripMenuItem.Name = "iOLTestToolStripMenuItem";
            this.iOLTestToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.iOLTestToolStripMenuItem.Text = "IOL Test";
            this.iOLTestToolStripMenuItem.Click += new System.EventHandler(this.iOLTestToolStripMenuItem_Click);
            // 
            // loopBackToolStripMenuItem
            // 
            this.loopBackToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.loopbacklogo;
            this.loopBackToolStripMenuItem.Name = "loopBackToolStripMenuItem";
            this.loopBackToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.loopBackToolStripMenuItem.Text = "LoopBack";
            this.loopBackToolStripMenuItem.Click += new System.EventHandler(this.loopBackToolStripMenuItem_Click);
            // 
            // patchCodeToolStripMenuItem
            // 
            this.patchCodeToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.cmdl;
            this.patchCodeToolStripMenuItem.Name = "patchCodeToolStripMenuItem";
            this.patchCodeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.patchCodeToolStripMenuItem.Text = "PatchCode";
            this.patchCodeToolStripMenuItem.Click += new System.EventHandler(this.patchCodeToolStripMenuItem_Click);
            // 
            // dumpAllRegToolStripMenuItem
            // 
            this.dumpAllRegToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.reglogo;
            this.dumpAllRegToolStripMenuItem.Name = "dumpAllRegToolStripMenuItem";
            this.dumpAllRegToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.dumpAllRegToolStripMenuItem.Text = "Dump Reg";
            this.dumpAllRegToolStripMenuItem.Click += new System.EventHandler(this.dumpAllRegToolStripMenuItem_Click);
            // 
            // usefulCommandToolStripMenuItem
            // 
            this.usefulCommandToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.usefullogo;
            this.usefulCommandToolStripMenuItem.Name = "usefulCommandToolStripMenuItem";
            this.usefulCommandToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.usefulCommandToolStripMenuItem.Text = "Useful Command";
            this.usefulCommandToolStripMenuItem.Click += new System.EventHandler(this.usefulCommandToolStripMenuItem_Click);
            // 
            // packetGenToolStripMenuItem
            // 
            this.packetGenToolStripMenuItem.Enabled = false;
            this.packetGenToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.pktgenlogo;
            this.packetGenToolStripMenuItem.Name = "packetGenToolStripMenuItem";
            this.packetGenToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.packetGenToolStripMenuItem.Text = "Packet Gen";
            this.packetGenToolStripMenuItem.Click += new System.EventHandler(this.packetGenToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.exitlogo;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usageToolStripMenuItem,
            this.advancedToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // usageToolStripMenuItem
            // 
            this.usageToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.usage;
            this.usageToolStripMenuItem.Name = "usageToolStripMenuItem";
            this.usageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.usageToolStripMenuItem.Text = "Usage";
            this.usageToolStripMenuItem.Click += new System.EventHandler(this.usageToolStripMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.Enabled = false;
            this.advancedToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources._lock;
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.advancedToolStripMenuItem.Text = "Advanced";
            // 
            // uSBSettingsToolStripMenuItem
            // 
            this.uSBSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSBsettingsToolStripMenuItem1,
            this.logsettingsToolStripMenuItem});
            this.uSBSettingsToolStripMenuItem.Name = "uSBSettingsToolStripMenuItem";
            this.uSBSettingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.uSBSettingsToolStripMenuItem.Text = "Settings";
            // 
            // uSBsettingsToolStripMenuItem1
            // 
            this.uSBsettingsToolStripMenuItem1.Image = global::USBPhyRW.Properties.Resources.usblogo;
            this.uSBsettingsToolStripMenuItem1.Name = "uSBsettingsToolStripMenuItem1";
            this.uSBsettingsToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.uSBsettingsToolStripMenuItem1.Text = "USBsettings";
            this.uSBsettingsToolStripMenuItem1.Click += new System.EventHandler(this.uSBsettingsToolStripMenuItem1_Click);
            // 
            // logsettingsToolStripMenuItem
            // 
            this.logsettingsToolStripMenuItem.Enabled = false;
            this.logsettingsToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.loglogo;
            this.logsettingsToolStripMenuItem.Name = "logsettingsToolStripMenuItem";
            this.logsettingsToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.logsettingsToolStripMenuItem.Text = "Logsettings";
            this.logsettingsToolStripMenuItem.Click += new System.EventHandler(this.logsettingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSBBoardToolStripMenuItem,
            this.uSBPhyRWToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // uSBBoardToolStripMenuItem
            // 
            this.uSBBoardToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.usbboard;
            this.uSBBoardToolStripMenuItem.Name = "uSBBoardToolStripMenuItem";
            this.uSBBoardToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.uSBBoardToolStripMenuItem.Text = "USBBoard";
            this.uSBBoardToolStripMenuItem.Click += new System.EventHandler(this.uSBBoardToolStripMenuItem_Click);
            // 
            // uSBPhyRWToolStripMenuItem
            // 
            this.uSBPhyRWToolStripMenuItem.Image = global::USBPhyRW.Properties.Resources.usbsw;
            this.uSBPhyRWToolStripMenuItem.Name = "uSBPhyRWToolStripMenuItem";
            this.uSBPhyRWToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.uSBPhyRWToolStripMenuItem.Text = "USBPhyRW";
            this.uSBPhyRWToolStripMenuItem.Click += new System.EventHandler(this.uSBPhyRWToolStripMenuItem_Click);
            // 
            // chipTypeBox
            // 
            this.chipTypeBox.AutoSize = true;
            this.chipTypeBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.chipTypeBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chipTypeBox.ForeColor = System.Drawing.Color.Red;
            this.chipTypeBox.Location = new System.Drawing.Point(305, 5);
            this.chipTypeBox.Name = "chipTypeBox";
            this.chipTypeBox.Size = new System.Drawing.Size(97, 19);
            this.chipTypeBox.TabIndex = 2;
            this.chipTypeBox.Text = "                      ";
            // 
            // phyAddr
            // 
            this.phyAddr.AutoSize = true;
            this.phyAddr.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phyAddr.Location = new System.Drawing.Point(36, 54);
            this.phyAddr.Name = "phyAddr";
            this.phyAddr.Size = new System.Drawing.Size(56, 17);
            this.phyAddr.TabIndex = 3;
            this.phyAddr.Text = "PrtAddr:";
            // 
            // phyAddrbox
            // 
            this.phyAddrbox.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phyAddrbox.Location = new System.Drawing.Point(104, 51);
            this.phyAddrbox.MaxLength = 2;
            this.phyAddrbox.Name = "phyAddrbox";
            this.phyAddrbox.Size = new System.Drawing.Size(80, 25);
            this.phyAddrbox.TabIndex = 4;
            this.phyAddrbox.Text = "00";
            this.phyAddrbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phyAddrbox_KeyPress);
            // 
            // regAddr
            // 
            this.regAddr.AutoSize = true;
            this.regAddr.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regAddr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.regAddr.Location = new System.Drawing.Point(24, 80);
            this.regAddr.Name = "regAddr";
            this.regAddr.Size = new System.Drawing.Size(61, 17);
            this.regAddr.TabIndex = 5;
            this.regAddr.Text = "RegAddr:";
            // 
            // phyRegbox
            // 
            this.phyRegbox.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phyRegbox.Location = new System.Drawing.Point(92, 77);
            this.phyRegbox.MaxLength = 4;
            this.phyRegbox.Name = "phyRegbox";
            this.phyRegbox.Size = new System.Drawing.Size(80, 25);
            this.phyRegbox.TabIndex = 6;
            this.phyRegbox.Text = "0000";
            this.phyRegbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phyRegbox_KeyPress);
            // 
            // regValue
            // 
            this.regValue.AutoSize = true;
            this.regValue.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.regValue.Location = new System.Drawing.Point(24, 109);
            this.regValue.Name = "regValue";
            this.regValue.Size = new System.Drawing.Size(65, 17);
            this.regValue.TabIndex = 7;
            this.regValue.Text = "RegValue:";
            // 
            // phyValuebox
            // 
            this.phyValuebox.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phyValuebox.Location = new System.Drawing.Point(92, 106);
            this.phyValuebox.MaxLength = 4;
            this.phyValuebox.Name = "phyValuebox";
            this.phyValuebox.Size = new System.Drawing.Size(80, 25);
            this.phyValuebox.TabIndex = 8;
            this.phyValuebox.Text = "0000";
            this.phyValuebox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phyValuebox_KeyPress);
            // 
            // readPhy
            // 
            this.readPhy.Location = new System.Drawing.Point(266, 51);
            this.readPhy.Name = "readPhy";
            this.readPhy.Size = new System.Drawing.Size(78, 33);
            this.readPhy.TabIndex = 9;
            this.readPhy.Text = "Read";
            this.readPhy.UseVisualStyleBackColor = true;
            this.readPhy.Click += new System.EventHandler(this.readPhy_Click);
            // 
            // writePhy
            // 
            this.writePhy.Font = new System.Drawing.Font("Calibri", 9F);
            this.writePhy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.writePhy.Location = new System.Drawing.Point(254, 73);
            this.writePhy.Name = "writePhy";
            this.writePhy.Size = new System.Drawing.Size(78, 33);
            this.writePhy.TabIndex = 10;
            this.writePhy.Text = "Write";
            this.writePhy.UseVisualStyleBackColor = true;
            this.writePhy.Click += new System.EventHandler(this.writePhy_Click);
            // 
            // ReadWrite
            // 
            this.ReadWrite.Controls.Add(this.note4);
            this.ReadWrite.Controls.Add(this.pictureBox1);
            this.ReadWrite.Controls.Add(this.devAdbox);
            this.ReadWrite.Controls.Add(this.writePhy);
            this.ReadWrite.Controls.Add(this.DEVAD);
            this.ReadWrite.Controls.Add(this.bit15);
            this.ReadWrite.Controls.Add(this.note3);
            this.ReadWrite.Controls.Add(this.bit14);
            this.ReadWrite.Controls.Add(this.note2);
            this.ReadWrite.Controls.Add(this.bit13);
            this.ReadWrite.Controls.Add(this.bit12);
            this.ReadWrite.Controls.Add(this.bit0);
            this.ReadWrite.Controls.Add(this.bit11);
            this.ReadWrite.Controls.Add(this.phyValuebox);
            this.ReadWrite.Controls.Add(this.bit1);
            this.ReadWrite.Controls.Add(this.regValue);
            this.ReadWrite.Controls.Add(this.bit10);
            this.ReadWrite.Controls.Add(this.phyRegbox);
            this.ReadWrite.Controls.Add(this.regAddr);
            this.ReadWrite.Controls.Add(this.bit2);
            this.ReadWrite.Controls.Add(this.bit9);
            this.ReadWrite.Controls.Add(this.bit3);
            this.ReadWrite.Controls.Add(this.bit8);
            this.ReadWrite.Controls.Add(this.bit4);
            this.ReadWrite.Controls.Add(this.bit7);
            this.ReadWrite.Controls.Add(this.bit5);
            this.ReadWrite.Controls.Add(this.bit6);
            this.ReadWrite.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ReadWrite.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadWrite.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.ReadWrite.Location = new System.Drawing.Point(12, 28);
            this.ReadWrite.Name = "ReadWrite";
            this.ReadWrite.Size = new System.Drawing.Size(382, 220);
            this.ReadWrite.TabIndex = 11;
            this.ReadWrite.TabStop = false;
            this.ReadWrite.Text = "General R/W";
            // 
            // note4
            // 
            this.note4.AutoSize = true;
            this.note4.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.note4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.note4.Location = new System.Drawing.Point(178, 53);
            this.note4.Name = "note4";
            this.note4.Size = new System.Drawing.Size(60, 17);
            this.note4.TabIndex = 54;
            this.note4.Text = "(decimal)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::USBPhyRW.Properties.Resources.banner;
            this.pictureBox1.Location = new System.Drawing.Point(23, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(335, 23);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // devAdbox
            // 
            this.devAdbox.AcceptsReturn = true;
            this.devAdbox.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devAdbox.Location = new System.Drawing.Point(92, 50);
            this.devAdbox.MaxLength = 2;
            this.devAdbox.Name = "devAdbox";
            this.devAdbox.Size = new System.Drawing.Size(80, 25);
            this.devAdbox.TabIndex = 53;
            this.devAdbox.Text = "00";
            // 
            // DEVAD
            // 
            this.DEVAD.AutoSize = true;
            this.DEVAD.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEVAD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DEVAD.Location = new System.Drawing.Point(24, 53);
            this.DEVAD.Name = "DEVAD";
            this.DEVAD.Size = new System.Drawing.Size(61, 17);
            this.DEVAD.TabIndex = 52;
            this.DEVAD.Text = "DevAddr:";
            // 
            // bit15
            // 
            this.bit15.AutoSize = true;
            this.bit15.BackColor = System.Drawing.Color.DarkOrange;
            this.bit15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit15.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit15.Location = new System.Drawing.Point(26, 169);
            this.bit15.Name = "bit15";
            this.bit15.Size = new System.Drawing.Size(17, 19);
            this.bit15.TabIndex = 29;
            this.bit15.Text = "0";
            this.bit15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bit15.Click += new System.EventHandler(this.bit15_Click);
            // 
            // note3
            // 
            this.note3.AutoSize = true;
            this.note3.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.note3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.note3.Location = new System.Drawing.Point(178, 109);
            this.note3.Name = "note3";
            this.note3.Size = new System.Drawing.Size(36, 17);
            this.note3.TabIndex = 47;
            this.note3.Text = "(hex)";
            // 
            // bit14
            // 
            this.bit14.AutoSize = true;
            this.bit14.BackColor = System.Drawing.Color.DarkOrange;
            this.bit14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit14.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit14.Location = new System.Drawing.Point(48, 169);
            this.bit14.Name = "bit14";
            this.bit14.Size = new System.Drawing.Size(17, 19);
            this.bit14.TabIndex = 30;
            this.bit14.Text = "0";
            this.bit14.Click += new System.EventHandler(this.bit14_Click);
            // 
            // note2
            // 
            this.note2.AutoSize = true;
            this.note2.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.note2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.note2.Location = new System.Drawing.Point(178, 80);
            this.note2.Name = "note2";
            this.note2.Size = new System.Drawing.Size(36, 17);
            this.note2.TabIndex = 46;
            this.note2.Text = "(hex)";
            // 
            // bit13
            // 
            this.bit13.AutoSize = true;
            this.bit13.BackColor = System.Drawing.Color.DarkOrange;
            this.bit13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit13.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit13.Location = new System.Drawing.Point(69, 169);
            this.bit13.Name = "bit13";
            this.bit13.Size = new System.Drawing.Size(17, 19);
            this.bit13.TabIndex = 31;
            this.bit13.Text = "0";
            this.bit13.Click += new System.EventHandler(this.bit13_Click);
            // 
            // bit12
            // 
            this.bit12.AutoSize = true;
            this.bit12.BackColor = System.Drawing.Color.DarkOrange;
            this.bit12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit12.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit12.Location = new System.Drawing.Point(90, 169);
            this.bit12.Name = "bit12";
            this.bit12.Size = new System.Drawing.Size(17, 19);
            this.bit12.TabIndex = 32;
            this.bit12.Text = "0";
            this.bit12.Click += new System.EventHandler(this.bit12_Click);
            // 
            // bit0
            // 
            this.bit0.AutoSize = true;
            this.bit0.BackColor = System.Drawing.Color.Yellow;
            this.bit0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit0.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit0.Location = new System.Drawing.Point(340, 169);
            this.bit0.Name = "bit0";
            this.bit0.Size = new System.Drawing.Size(17, 19);
            this.bit0.TabIndex = 44;
            this.bit0.Text = "0";
            this.bit0.Click += new System.EventHandler(this.bit0_Click);
            // 
            // bit11
            // 
            this.bit11.AutoSize = true;
            this.bit11.BackColor = System.Drawing.Color.Yellow;
            this.bit11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit11.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit11.Location = new System.Drawing.Point(110, 169);
            this.bit11.Name = "bit11";
            this.bit11.Size = new System.Drawing.Size(17, 19);
            this.bit11.TabIndex = 33;
            this.bit11.Text = "0";
            this.bit11.Click += new System.EventHandler(this.bit11_Click);
            // 
            // bit1
            // 
            this.bit1.AutoSize = true;
            this.bit1.BackColor = System.Drawing.Color.Yellow;
            this.bit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit1.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit1.Location = new System.Drawing.Point(320, 169);
            this.bit1.Name = "bit1";
            this.bit1.Size = new System.Drawing.Size(17, 19);
            this.bit1.TabIndex = 43;
            this.bit1.Text = "0";
            this.bit1.Click += new System.EventHandler(this.bit1_Click);
            // 
            // bit10
            // 
            this.bit10.AutoSize = true;
            this.bit10.BackColor = System.Drawing.Color.Yellow;
            this.bit10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit10.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit10.Location = new System.Drawing.Point(132, 169);
            this.bit10.Name = "bit10";
            this.bit10.Size = new System.Drawing.Size(17, 19);
            this.bit10.TabIndex = 34;
            this.bit10.Text = "0";
            this.bit10.Click += new System.EventHandler(this.bit10_Click);
            // 
            // bit2
            // 
            this.bit2.AutoSize = true;
            this.bit2.BackColor = System.Drawing.Color.Yellow;
            this.bit2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit2.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit2.Location = new System.Drawing.Point(300, 169);
            this.bit2.Name = "bit2";
            this.bit2.Size = new System.Drawing.Size(17, 19);
            this.bit2.TabIndex = 42;
            this.bit2.Text = "0";
            this.bit2.Click += new System.EventHandler(this.bit2_Click);
            // 
            // bit9
            // 
            this.bit9.AutoSize = true;
            this.bit9.BackColor = System.Drawing.Color.Yellow;
            this.bit9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit9.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit9.Location = new System.Drawing.Point(153, 169);
            this.bit9.Name = "bit9";
            this.bit9.Size = new System.Drawing.Size(17, 19);
            this.bit9.TabIndex = 35;
            this.bit9.Text = "0";
            this.bit9.Click += new System.EventHandler(this.bit9_Click);
            // 
            // bit3
            // 
            this.bit3.AutoSize = true;
            this.bit3.BackColor = System.Drawing.Color.Yellow;
            this.bit3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit3.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit3.Location = new System.Drawing.Point(280, 169);
            this.bit3.Name = "bit3";
            this.bit3.Size = new System.Drawing.Size(17, 19);
            this.bit3.TabIndex = 41;
            this.bit3.Text = "0";
            this.bit3.Click += new System.EventHandler(this.bit3_Click);
            // 
            // bit8
            // 
            this.bit8.AutoSize = true;
            this.bit8.BackColor = System.Drawing.Color.Yellow;
            this.bit8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit8.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit8.Location = new System.Drawing.Point(174, 169);
            this.bit8.Name = "bit8";
            this.bit8.Size = new System.Drawing.Size(17, 19);
            this.bit8.TabIndex = 36;
            this.bit8.Text = "0";
            this.bit8.Click += new System.EventHandler(this.bit8_Click);
            // 
            // bit4
            // 
            this.bit4.AutoSize = true;
            this.bit4.BackColor = System.Drawing.Color.DarkOrange;
            this.bit4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit4.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit4.Location = new System.Drawing.Point(258, 169);
            this.bit4.Name = "bit4";
            this.bit4.Size = new System.Drawing.Size(17, 19);
            this.bit4.TabIndex = 40;
            this.bit4.Text = "0";
            this.bit4.Click += new System.EventHandler(this.bit4_Click);
            // 
            // bit7
            // 
            this.bit7.AutoSize = true;
            this.bit7.BackColor = System.Drawing.Color.DarkOrange;
            this.bit7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit7.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit7.Location = new System.Drawing.Point(195, 169);
            this.bit7.Name = "bit7";
            this.bit7.Size = new System.Drawing.Size(17, 19);
            this.bit7.TabIndex = 37;
            this.bit7.Text = "0";
            this.bit7.Click += new System.EventHandler(this.bit7_Click);
            // 
            // bit5
            // 
            this.bit5.AutoSize = true;
            this.bit5.BackColor = System.Drawing.Color.DarkOrange;
            this.bit5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit5.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit5.Location = new System.Drawing.Point(237, 169);
            this.bit5.Name = "bit5";
            this.bit5.Size = new System.Drawing.Size(17, 19);
            this.bit5.TabIndex = 39;
            this.bit5.Text = "0";
            this.bit5.Click += new System.EventHandler(this.bit5_Click);
            // 
            // bit6
            // 
            this.bit6.AutoSize = true;
            this.bit6.BackColor = System.Drawing.Color.DarkOrange;
            this.bit6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bit6.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bit6.Location = new System.Drawing.Point(216, 169);
            this.bit6.Name = "bit6";
            this.bit6.Size = new System.Drawing.Size(17, 19);
            this.bit6.TabIndex = 38;
            this.bit6.Text = "0";
            this.bit6.Click += new System.EventHandler(this.bit6_Click);
            // 
            // note1
            // 
            this.note1.AutoSize = true;
            this.note1.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.note1.Location = new System.Drawing.Point(190, 54);
            this.note1.Name = "note1";
            this.note1.Size = new System.Drawing.Size(60, 17);
            this.note1.TabIndex = 45;
            this.note1.Text = "(decimal)";
            // 
            // regNotice
            // 
            this.regNotice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.regNotice.Enabled = false;
            this.regNotice.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regNotice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.regNotice.Location = new System.Drawing.Point(18, 278);
            this.regNotice.Multiline = true;
            this.regNotice.Name = "regNotice";
            this.regNotice.ReadOnly = true;
            this.regNotice.Size = new System.Drawing.Size(370, 139);
            this.regNotice.TabIndex = 48;
            // 
            // regNoticeBar
            // 
            this.regNoticeBar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.regNoticeBar.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regNoticeBar.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.regNoticeBar.Location = new System.Drawing.Point(12, 254);
            this.regNoticeBar.Name = "regNoticeBar";
            this.regNoticeBar.Size = new System.Drawing.Size(382, 166);
            this.regNoticeBar.TabIndex = 49;
            this.regNoticeBar.TabStop = false;
            this.regNoticeBar.Text = "Reg Note";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(86, 443);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(64, 14);
            this.linkLabel1.TabIndex = 51;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 428);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.regNotice);
            this.Controls.Add(this.note1);
            this.Controls.Add(this.readPhy);
            this.Controls.Add(this.phyAddrbox);
            this.Controls.Add(this.phyAddr);
            this.Controls.Add(this.chipTypeBox);
            this.Controls.Add(this.menuItem);
            this.Controls.Add(this.ReadWrite);
            this.Controls.Add(this.regNoticeBar);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuItem;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USBPhyRW （Support RTK 2.5GPHY Build No.20180615）";
            this.menuItem.ResumeLayout(false);
            this.menuItem.PerformLayout();
            this.ReadWrite.ResumeLayout(false);
            this.ReadWrite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuItem;
        private System.Windows.Forms.ToolStripMenuItem functionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSBSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSBsettingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSBBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSBPhyRWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpAllRegToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectChipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTL8201EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTL8201FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTL8211EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTL8211FToolStripMenuItem;
        private System.Windows.Forms.Label chipTypeBox;
        private System.Windows.Forms.Label phyAddr;
        private System.Windows.Forms.TextBox phyAddrbox;
        private System.Windows.Forms.Label regAddr;
        private System.Windows.Forms.TextBox phyRegbox;
        private System.Windows.Forms.Label regValue;
        private System.Windows.Forms.TextBox phyValuebox;
        private System.Windows.Forms.Button readPhy;
        private System.Windows.Forms.Button writePhy;
        private System.Windows.Forms.GroupBox ReadWrite;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label bit15;
        private System.Windows.Forms.Label bit14;
        private System.Windows.Forms.Label bit13;
        private System.Windows.Forms.Label bit12;
        private System.Windows.Forms.Label bit8;
        private System.Windows.Forms.Label bit9;
        private System.Windows.Forms.Label bit10;
        private System.Windows.Forms.Label bit11;
        private System.Windows.Forms.Label bit4;
        private System.Windows.Forms.Label bit5;
        private System.Windows.Forms.Label bit6;
        private System.Windows.Forms.Label bit7;
        private System.Windows.Forms.Label bit0;
        private System.Windows.Forms.Label bit1;
        private System.Windows.Forms.Label bit2;
        private System.Windows.Forms.Label bit3;
        private System.Windows.Forms.Label note1;
        private System.Windows.Forms.Label note2;
        private System.Windows.Forms.Label note3;
        private System.Windows.Forms.ToolStripMenuItem usefulCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loopBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packetGenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iOLTestToolStripMenuItem;
        private System.Windows.Forms.TextBox regNotice;
        private System.Windows.Forms.GroupBox regNoticeBar;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStripMenuItem rTL8211DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTL8201FVBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTL8201FVCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTL8201FVDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTL8226ToolStripMenuItem;
        private System.Windows.Forms.Label note4;
        private System.Windows.Forms.TextBox devAdbox;
        private System.Windows.Forms.Label DEVAD;
    }
}

