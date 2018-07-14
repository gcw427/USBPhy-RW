using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HID;
using System.Runtime.InteropServices; //dll import
using System.Threading;
using System.Threading.Tasks;

namespace USBPhyRW
{
    public partial class PatchCode25GPHY : Form
    {
        public Hid usbPhyRWHID = new Hid();
        public IntPtr usbPhyRWHIDPtr = new IntPtr();
        Byte[] RecDataBuffer = new byte[90];
        UInt16 CmdType = 0;
        UInt16 RamCodePatchNeed = 0;
        //golbal VID/PID
        UInt16 golbalVID = 0xff;
        UInt16 gobalPID = 0xff;
        UInt16 chipids = 0x00;
        string LDPatchCode1PATH = null;
        string LDPatchCode2PATH = null;
        string LDPatchCode3PATH = null;
        string LDPatchCode4PATH = null;
        string LDPatchCode5PATH = null;
        string LDPatchCode6PATH = null;
        string LDPatchCode7PATH = null;
        string LDPatchCode8PATH = null;
        public void ConfigButton()
        {
            Polling25G.Enabled = true;
            CheckICVer.Enabled = false;
            LDPatchCode1.Enabled = false;
            LDPatchCode2.Enabled = false;
            LDPatchCode3.Enabled = false;
            LDPatchCode4.Enabled = false;
            LDPatchCode5.Enabled = false;
            LDPatchCode6.Enabled = false;
            LDPatchCode7.Enabled = false;
            LDPatchCode8.Enabled = false;
            ApplyAll.Enabled = false; //for debug speed fine tune
            LDPatchCode1PATH = null;
            LDPatchCode2PATH = null;
            LDPatchCode3PATH = null;
            LDPatchCode4PATH = null;
            LDPatchCode5PATH = null;
            LDPatchCode6PATH = null;
            LDPatchCode7PATH = null;
            LDPatchCode8PATH = null;

        }   
        public PatchCode25GPHY()
        {
            usbPhyRWHID.DataReceived += new EventHandler<HID.report>(usbPhyRW_DataReceived);
            usbPhyRWHID.DeviceRemoved += new EventHandler(usbPhyRW_DeviceRemoved); //生USB REC Handler
            InitializeComponent();
            loadProgramcfg();
            ConfigButton();
            dbgshow.Visible = false;
            dbg2show.Visible = false;  
        }
        //***********************************config ini API*************************************************************************//
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSection(string lpAppName, IntPtr lpReturnedString, uint nSize, string lpFileName);
        private static string ReadString(string section, string key, string def, string filePath)
        {
            StringBuilder temp = new StringBuilder(1024);
            try
            {
                GetPrivateProfileString(section, key, def, temp, 1024, filePath);
            }
            catch
            { }
            return temp.ToString();
        }
        /// <summary>
        /// 根据section取所有key
        /// </summary>
        /// <param name="section"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string[] ReadIniAllKeys(string section, string filePath)
        {
            UInt32 MAX_BUFFER = 32767;
            string[] items = new string[0];
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));
            UInt32 bytesReturned = GetPrivateProfileSection(section, pReturnedString, MAX_BUFFER, filePath);
            if (!(bytesReturned == MAX_BUFFER - 2) || (bytesReturned == 0))
            {
                string returnedString = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned);
                items = returnedString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }
            Marshal.FreeCoTaskMem(pReturnedString);
            return items;
        }
        /// 根据section，key取值
        /// <param name="section"></param>
        /// <param name="keys"></param>
        /// <param name="filePath">ini文件路径</param>
        /// <returns></returns>
        public static string ReadIniKeys(string section, string keys, string filePath)
        {
            return ReadString(section, keys, "", filePath);
        }

        /// 保存ini
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="filePath">ini文件路径</param>
        public static void WriteIniKeys(string section, string key, string value, string filePath)
        {
            WritePrivateProfileString(section, key, value, filePath);
        }
        //***********************************config ini API END*******************************************************************//
        string cfgPath = System.Environment.CurrentDirectory + "\\config.ini";
        string ChipSec = "ChipSettings";
        string chipid = "IDs";

        string USBsec = "USBSettings";
        string USBvid = "VendorID";
        string USBpid = "ProductID";
        public void loadProgramcfg()
        {
            chipids = Convert.ToUInt16(ReadIniKeys(ChipSec, chipid, cfgPath));
            //载入程序配置时 读取当下usb dongle的VID PID
            gobalPID = Convert.ToUInt16((ReadIniKeys(USBsec, USBpid, cfgPath)), 16);
            golbalVID = Convert.ToUInt16((ReadIniKeys(USBsec, USBvid, cfgPath)), 16);
        }
        //***********************************config ini Load save End*************************************************************//
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
        //***********************************usb transfer and receiver and open and close functions below**********************//
        protected void usbPhyRW_DataReceived(object sender, report e)
        {
            RecDataBuffer = e.reportBuff;
            //string receiveData = "0x" + byteToHexStr(RecDataBuffer).Substring(2, 5);
         //   dbgshow.Text = "0x" + byteToHexStr(RecDataBuffer).Substring(0, 4);
            if (CmdType == 0x01)
            {
           //     dbgshow.Text = "0x" + byteToHexStr(RecDataBuffer).Substring(0, 4);
                switch (RecDataBuffer[1] & 0x07)
                {
                    case 0x03: phyStatus.Text = "MODE:LAN ON" ;CheckICVer.Enabled = true; break;
                    case 0x00: phyStatus.Text = "MODE:POR RST";break;
                    case 0x01: phyStatus.Text = "MODE:INI" ;break;
                    case 0x02: phyStatus.Text = "MODE:EXT INI";break;
                    case 0x04: phyStatus.Text = "MODE:PHY RESET";break;
                    case 0x05: phyStatus.Text = "MODE:PHY PWRDN";break;
                }
            }
            if (CmdType == 0x02)
            {
           //     dbgshow.Text = "0x" + byteToHexStr(RecDataBuffer).Substring(0, 4);
                switch (RecDataBuffer[1] & 0x01)
                {
                    //excute ram code patch
                    case 0x00: RamCodePatchNeed = 1 ;
                        MessageBox.Show(this, "Checking PhyChip RamCode Status..\n"+"Current PhyChip Need RAMCode Patch." , "USBPhyRW Notie", MessageBoxButtons.OK);
                        patchReq_Rdy();
                        goto recvend; 
                    // jump over ram code patch
                    case 0x01:  RamCodePatchNeed = 0;
                        LDPatchCode1.Enabled = false;
                        LDPatchCode2.Enabled = false;
                        LDPatchCode3.Enabled = false;
                        LDPatchCode4.Enabled = false;
                        LDPatchCode5.Enabled = false;
                        LDPatchCode6.Enabled = false;
                        LDPatchCode7.Enabled = false;
                        LDPatchCode8.Enabled = true;
                        MessageBox.Show(this, "Checking PhyChip RamCode Status..\n" + "Current PhyChip Only Need Issue Patch.", "USBPhyRW Notie", MessageBoxButtons.OK);
                        break;
                }                                  
            }
            if (CmdType == 0x03)
            {
                if ((RecDataBuffer[1] & 0x40) == 0x40)
                {
                    MessageBox.Show(this,"Send patch Request and Wait Patch Ready."+"\n"+"\nGet PhyChip PatchReady Acknowledgement.", "USBPhyRW Notie", MessageBoxButtons.OK);
                    LDPatchCode1.Enabled = true;
                }
                else if ((RecDataBuffer[1] & 0x40) != 0x40)
                {
                    MessageBox.Show(this,"Send patch Request and Wait Patch Ready." + "\n" + "\n Get PhyChip PatchReady Acknowledgement timeout!", "USBPhyRW Warning", MessageBoxButtons.OK);
                    LDPatchCode1.Enabled = false;
                    LDPatchCode2.Enabled = false;
                    LDPatchCode3.Enabled = false;
                    LDPatchCode4.Enabled = false;
                    LDPatchCode5.Enabled = false;
                    LDPatchCode6.Enabled = false;
                    LDPatchCode7.Enabled = false;
                    LDPatchCode8.Enabled = false;
                    ApplyAll.Enabled = false;
                }
            }
            if (CmdType == 0x0c)
            {
                if ((RecDataBuffer[1] & 0x40) == 0x00)
                {
            //        dbgshow.Text = "Release OK";
                   // patchProgressNote.Text = "Patch Release OK.";
                    MessageBox.Show("Wait Phy Patch Release Reply OK.", "USBPhyRW Notie", MessageBoxButtons.OK);
                }
                else
                {
           //         dbgshow.Text = "Release Fail";
                   // patchProgressNote.Text = "Patch Release Fail.";
                    MessageBox.Show("Wait Phy Patch Release Time Out.", "USBPhyRW Warning", MessageBoxButtons.OK);
                }
            }
            recvend:;
        }
        //设备移除事件
        protected void usbPhyRW_DeviceRemoved(object sender, EventArgs e)
        {
            //to be continue
        }

        private void openDevice()
        {
            if (usbPhyRWHID.Opened == false)
            {
                //默认VID/PID STM32中有定义
                UInt16 iVendorID = golbalVID;
                UInt16 iProductID = gobalPID;
                if ((int)(usbPhyRWHIDPtr = usbPhyRWHID.OpenDevice(iVendorID, iProductID)) != -1)
                {
                    //设备打开亮灯；
                }
                else
                {
                    //连接失败；
                    MessageBox.Show("USB Communication Fail.\n" + "Please Check Stm32 Board connection!", "USBPhyRW Warning", MessageBoxButtons.RetryCancel);
                }
            }
            else
            {
                //设备已经打开了亮灯；
            }
        }
        private void closeDevice()
        {
            usbPhyRWHID.CloseDevice(usbPhyRWHIDPtr);
        }

        private void Polling25G_Click(object sender, EventArgs e)
        {
            patchProgressNote.Text = "Ready";
            patchProgressBar.Value = 0;
            CheckICVer.Enabled = false;
            LDPatchCode1.Enabled = false;
            LDPatchCode2.Enabled = false;
            LDPatchCode3.Enabled = false;
            LDPatchCode4.Enabled = false;
            LDPatchCode5.Enabled = false;
            LDPatchCode6.Enabled = false;
            LDPatchCode7.Enabled = false;
            LDPatchCode8.Enabled = false;
            ApplyAll.Enabled = false; //for debug speed fine tune
            while (patchProgress.RowCount > 0)
            {
                patchProgress.Rows.Remove(patchProgress.Rows[0]);
            }
            while (patchDetailProgress.RowCount > 0)
            {
                patchDetailProgress.Rows.Remove(patchDetailProgress.Rows[0]);
            }
            CmdType = 0x01;
            openDevice();
            PatchRead(0xa420, 0x01);
        }

        private void PatchCode25GPHY_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeDevice();
        }

        private void CheckICVer_Click(object sender, EventArgs e)
        {
            LDPatchCode1.Enabled = false;
            LDPatchCode2.Enabled = false;
            LDPatchCode3.Enabled = false;
            LDPatchCode4.Enabled = false;
            LDPatchCode5.Enabled = false;
            LDPatchCode6.Enabled = false;
            LDPatchCode7.Enabled = false;
            LDPatchCode8.Enabled = false;
            ApplyAll.Enabled = false; //for debug speed fine tune
            CmdType = 0x02;
            openDevice();
            PatchWrite(0xa436, 0x801E);
            //==============================set a436 801E above==============================//
            //==============================read a438 below==============================//
            System.Threading.Thread.Sleep(300);
            PatchRead(0xa438,0x02);
        }
        private void LDPatchCode1_Click(object sender, EventArgs e)
        {
            OpenFileDialog choosefile = new OpenFileDialog();   //显示选择文件对话框 
            choosefile.InitialDirectory = System.Environment.CurrentDirectory;
            choosefile.Filter = "phyPatch file(*.cfg)|*.cfg";
            choosefile.FilterIndex = 2;
            choosefile.RestoreDirectory = true;
            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                if (patchProgress.RowCount <= 0)
                { patchProgress.Rows.Add();
                    this.patchProgress.Rows[0].Selected = false;
                }
                patchProgress.Rows[0].Cells[1].Value = System.IO.Path.GetFileName(choosefile.SafeFileName);
                patchProgress.Rows[0].Cells[0].Value = "Not Excute";
                LDPatchCode1PATH = choosefile.FileName;
                dbgshow.Text = LDPatchCode1PATH;
                LDPatchCode2.Enabled = true;
                //ApplyAll.Enabled = true; //debug 20180714
            }
        }

        private void LDPatchCode2_Click(object sender, EventArgs e)
        {
            OpenFileDialog choosefile = new OpenFileDialog();   //显示选择文件对话框 
            choosefile.InitialDirectory = System.Environment.CurrentDirectory;
            choosefile.Filter = "phyPatch file(*.cfg)|*.cfg";
            choosefile.FilterIndex = 2;
            choosefile.RestoreDirectory = true;
            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                if (patchProgress.RowCount <= 1)
                { patchProgress.Rows.Add(); }
                patchProgress.Rows[1].Cells[1].Value = System.IO.Path.GetFileName(choosefile.SafeFileName);
                patchProgress.Rows[1].Cells[0].Value = "Not Excute";
                LDPatchCode2PATH = choosefile.FileName;
                LDPatchCode3.Enabled = true;
            }
        }

        private void LDPatchCode3_Click(object sender, EventArgs e)
        {
            OpenFileDialog choosefile = new OpenFileDialog();   //显示选择文件对话框 
            choosefile.InitialDirectory = System.Environment.CurrentDirectory;
            choosefile.Filter = "phyPatch file(*.cfg)|*.cfg";
            choosefile.FilterIndex = 2;
            choosefile.RestoreDirectory = true;
            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                if (patchProgress.RowCount <= 2 )
                { patchProgress.Rows.Add(); }
                patchProgress.Rows[2].Cells[1].Value = System.IO.Path.GetFileName(choosefile.SafeFileName);
                patchProgress.Rows[2].Cells[0].Value = "Not Excute";
                LDPatchCode3PATH = choosefile.FileName;
                LDPatchCode4.Enabled = true;
            }
        }

        private void LDPatchCode4_Click(object sender, EventArgs e)
        {
            patchProgress.Rows.Add();
            OpenFileDialog choosefile = new OpenFileDialog();   //显示选择文件对话框 
            choosefile.InitialDirectory = System.Environment.CurrentDirectory;
            choosefile.Filter = "phyPatch file(*.cfg)|*.cfg";
            choosefile.FilterIndex = 2;
            choosefile.RestoreDirectory = true;
            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                if (patchProgress.RowCount <= 3)
                { patchProgress.Rows.Add(); }
                patchProgress.Rows[3].Cells[1].Value = System.IO.Path.GetFileName(choosefile.SafeFileName);
                patchProgress.Rows[3].Cells[0].Value = "Not Excute";
                LDPatchCode4PATH = choosefile.FileName;
                LDPatchCode5.Enabled = true;
            }
        }

        private void LDPatchCode5_Click(object sender, EventArgs e)
        {
            OpenFileDialog choosefile = new OpenFileDialog();   //显示选择文件对话框 
            choosefile.InitialDirectory = System.Environment.CurrentDirectory;
            choosefile.Filter = "phyPatch file(*.cfg)|*.cfg";
            choosefile.FilterIndex = 2;
            choosefile.RestoreDirectory = true;
            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                if (patchProgress.RowCount <= 4)
                { patchProgress.Rows.Add(); }
                patchProgress.Rows[4].Cells[1].Value = System.IO.Path.GetFileName(choosefile.SafeFileName);
                patchProgress.Rows[4].Cells[0].Value = "Not Excute";
                LDPatchCode5PATH = choosefile.FileName;
                LDPatchCode6.Enabled = true;
            }
        }

        private void LDPatchCode6_Click(object sender, EventArgs e)
        {
            OpenFileDialog choosefile = new OpenFileDialog();   //显示选择文件对话框 
            choosefile.InitialDirectory = System.Environment.CurrentDirectory;
            choosefile.Filter = "phyPatch file(*.cfg)|*.cfg";
            choosefile.FilterIndex = 2;
            choosefile.RestoreDirectory = true;
            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                if (patchProgress.RowCount <= 5)
                { patchProgress.Rows.Add(); }
                patchProgress.Rows[5].Cells[1].Value = System.IO.Path.GetFileName(choosefile.SafeFileName);
                patchProgress.Rows[5].Cells[0].Value = "Not Excute";
                LDPatchCode6PATH = choosefile.FileName;
                LDPatchCode7.Enabled = true;
            }
        }

        private void LDPatchCode7_Click(object sender, EventArgs e)
        {
            OpenFileDialog choosefile = new OpenFileDialog();   //显示选择文件对话框 
            choosefile.InitialDirectory = System.Environment.CurrentDirectory;
            choosefile.Filter = "phyPatch file(*.cfg)|*.cfg";
            choosefile.FilterIndex = 2;
            choosefile.RestoreDirectory = true;
            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                if (patchProgress.RowCount <= 6)
                { patchProgress.Rows.Add(); }
                patchProgress.Rows[6].Cells[1].Value = System.IO.Path.GetFileName(choosefile.SafeFileName);
                patchProgress.Rows[6].Cells[0].Value = "Not Excute";
                LDPatchCode7PATH = choosefile.FileName;
                LDPatchCode8.Enabled = true;
            }
        }

        private void LDPatchCode8_Click(object sender, EventArgs e)
        {
            OpenFileDialog choosefile = new OpenFileDialog();   //显示选择文件对话框 
            choosefile.InitialDirectory = System.Environment.CurrentDirectory;
            choosefile.Filter = "phyPatch file(*.cfg)|*.cfg";
            choosefile.FilterIndex = 2;
            choosefile.RestoreDirectory = true;
            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                if (patchProgress.RowCount <= 7)
                { patchProgress.Rows.Add(); }
                if (RamCodePatchNeed == 1)
                {
                    patchProgress.Rows[7].Cells[1].Value = System.IO.Path.GetFileName(choosefile.SafeFileName);
                    patchProgress.Rows[7].Cells[0].Value = "Not Excute";
                }
                if (RamCodePatchNeed == 0)
                {
                    patchProgress.Rows[0].Cells[1].Value = System.IO.Path.GetFileName(choosefile.SafeFileName);
                    patchProgress.Rows[0].Cells[0].Value = "Not Excute";
                    
                }
                LDPatchCode8PATH = choosefile.FileName;
                ApplyAll.Enabled = true;
            }
        }

        public void PatchWrite(UInt16 regvalue, UInt16 phyvalue)
        {
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x02; //normal rw
            data[2] = 0x01; //write
            data[3] = 0x00;   //phyad
            data[4] = (byte)((regvalue >> 8) & 0xff); //phy reg address
            data[9] = (byte)(regvalue & 0xff);
            data[5] = (byte)((phyvalue >> 8) & 0xff); // phy value
            data[6] = (byte)(phyvalue & 0xff);
            data[7] = 0x1F;    //DEVAD
            data[8] = Convert.ToByte(chipids); //TBD
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
        }
        public void PatchRead(UInt16 regvalue, UInt16 xCmdType)
        {
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x02; //normal rw
            data[2] = 0x00; //read
            data[3] = 0x00; //patch mode addr is always 0x00;
            data[4] = (byte)((regvalue >> 8) & 0xff);
            data[7] = (byte)(regvalue & 0xff);
            data[5] = 0x1F;//patch mode addr is always 0x1F;
            data[6] = Convert.ToByte(chipids);//TBD
            data[8] = 0x00;
            data[9] = 0x00;
            report rrd = new report(0, data);
            CmdType = xCmdType;
            usbPhyRWHID.Write(rrd);
        }
        public void PatchSetBit(UInt16 regvalue, byte setbit)
        {
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x06; //setbit /resetbit operation
            data[2] = 0x00; //setbit
            data[3] = 0x00;   //phyad
            data[4] = (byte)((regvalue >> 8) & 0xff); //phy reg address
            data[9] = (byte)(regvalue & 0xff);
            data[5] = setbit;
            data[6] = 0x1F;
            data[7] = Convert.ToByte(chipids); //TBD        
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
            System.Threading.Thread.Sleep(100);
        }

        public void PatchResetBit(UInt16 regvalue, byte setbit)
        {
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x06; //setbit /resetbit operation
            data[2] = 0x01; //resetbit
            data[3] = 0x00;   //phyad
            data[4] = (byte)((regvalue >> 8) & 0xff); //phy reg address
            data[9] = (byte)(regvalue & 0xff);
            data[5] = setbit;
            data[6] = 0x1F;
            data[7] = Convert.ToByte(chipids); //TBD        
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
            System.Threading.Thread.Sleep(100);
        }
        //Patch request & wait patch_ready
        public void patchReq_Rdy()
        {
            //patch request
            PatchSetBit(0xB820, 0x04);
            System.Threading.Thread.Sleep(100);
            PatchRead(0xB800, 0x03);
           System.Threading.Thread.Sleep(500);
        }

        UInt16 patchseqNumCurrent = 0; //Show current patch detail
        public void ExcutePatchCFG(string PatchPath, UInt16 xCmdType,UInt16 GridRows)
        {   
            
            CmdType = xCmdType;
            string[] patchcfgLine = File.ReadAllLines(PatchPath);
            for (UInt16 i = 0; i < patchcfgLine.Length; i++)
            {
                if (patchcfgLine[i].Length == 14)
                {
                //    patchProgressNote.Text = "write" + patchcfgLine[i].Substring(0, 6) + "with" + patchcfgLine[i].Substring(8, 6);
                    //dbgshow.Text = patchcfgLine[i].Substring(0, 6);
                    //dbgshow.Text = patchcfgLine[i].Substring(8, 6);
                    //Convert.ToUInt16(patchcfgLine[i].Substring(0, 6), 16);
                    if (patchcfgLine[i].Substring(8, 2) == "0x")
                    {
                        PatchWrite(Convert.ToUInt16(patchcfgLine[i].Substring(0, 6), 16), Convert.ToUInt16(patchcfgLine[i].Substring(8, 6), 16));
                    }
                    else if (patchcfgLine[i].Substring(8, 3) == "set")
                    {
                        PatchSetBit((Convert.ToUInt16(patchcfgLine[i].Substring(0, 6), 16)), (Convert.ToByte(patchcfgLine[i].Substring(12, 2), 16)));
                    }
                    else if (patchcfgLine[i].Substring(8, 3) == "rst")
                    {
                        PatchResetBit((Convert.ToUInt16(patchcfgLine[i].Substring(0, 6), 16)), (Convert.ToByte(patchcfgLine[i].Substring(12, 2), 16)));
                    }
                    System.Threading.Thread.Sleep(500);
                    patchDetailProgress.CurrentCell = patchDetailProgress.Rows[patchseqNumCurrent].Cells[0];
                    patchseqNumCurrent++;
                    this.patchProgress.Rows[GridRows].Selected = true;
                    patchProgress.Rows[GridRows].Cells[0].Value = "Excuted OK";
                    patchDetailProgress.Update();
                    patchProgress.Update();
                }
                else
                {
                    MessageBox.Show("Phy patch file format error.\n" + "Please Check patch file LINE:" + Convert.ToString(i + 1), "USBPhyRW Warning", MessageBoxButtons.OK);
                    goto end;
                }
            }
            end:;
        }

        public void fillDetailGridView()
        {
            UInt16 patchseqNum = 0;
            if (LDPatchCode1PATH != null)
            {
                string[] patchcfgLine = File.ReadAllLines(LDPatchCode1PATH);
                for (UInt16 i = 0; i < patchcfgLine.Length; i++)
                {
                    if (patchcfgLine[i].Length == 14)
                    {
                        patchDetailProgress.Rows.Add();
                        patchDetailProgress.Rows[patchseqNum].Cells[0].Value = Convert.ToString(patchseqNum);
                        patchDetailProgress.Rows[patchseqNum].Cells[1].Value = "patching  " + patchcfgLine[i].Substring(0, 6) + " with " + patchcfgLine[i].Substring(8, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(0, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(8, 6);
                        patchseqNum++;
                    }
                    else
                    {
                        MessageBox.Show("Phy patch file format error.\n" + "Please Check patch file LINE:" + Convert.ToString(i + 1), "USBPhyRW Warning", MessageBoxButtons.OK);
                        goto endpatch1;
                    }
                }
            }
                endpatch1:;
                if (LDPatchCode2PATH != null)
            {
                string[] patchcfgLine = File.ReadAllLines(LDPatchCode2PATH);
                for (UInt16 i = 0; i < patchcfgLine.Length; i++)
                {
                    if (patchcfgLine[i].Length == 14)
                    {
                        patchDetailProgress.Rows.Add();
                        patchDetailProgress.Rows[patchseqNum].Cells[0].Value = Convert.ToString(patchseqNum);
                        patchDetailProgress.Rows[patchseqNum].Cells[1].Value = "patching  " + patchcfgLine[i].Substring(0, 6) + " with " + patchcfgLine[i].Substring(8, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(0, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(8, 6);
                        patchseqNum++;
                    }
                    else
                    {
                        MessageBox.Show("Phy patch file format error.\n" + "Please Check patch file LINE:" + Convert.ToString(i + 1), "USBPhyRW Warning", MessageBoxButtons.OK);
                        goto endpatch2;
                    }
                }
            }
            endpatch2:;
            if (LDPatchCode3PATH != null)
            {
                string[] patchcfgLine = File.ReadAllLines(LDPatchCode3PATH);
                for (UInt16 i = 0; i < patchcfgLine.Length; i++)
                {
                    if (patchcfgLine[i].Length == 14)
                    {
                        patchDetailProgress.Rows.Add();
                        patchDetailProgress.Rows[patchseqNum].Cells[0].Value = Convert.ToString(patchseqNum);
                        patchDetailProgress.Rows[patchseqNum].Cells[1].Value = "patching  " + patchcfgLine[i].Substring(0, 6) + " with " + patchcfgLine[i].Substring(8, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(0, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(8, 6);
                        patchseqNum++;
                    }
                    else
                    {
                        MessageBox.Show("Phy patch file format error.\n" + "Please Check patch file LINE:" + Convert.ToString(i + 1), "USBPhyRW Warning", MessageBoxButtons.OK);
                        goto endpatch3;
                    }
                }
            }
            endpatch3:;
            if (LDPatchCode4PATH != null)
            {
                string[] patchcfgLine = File.ReadAllLines(LDPatchCode4PATH);
                for (UInt16 i = 0; i < patchcfgLine.Length; i++)
                {
                    if (patchcfgLine[i].Length == 14)
                    {
                        patchDetailProgress.Rows.Add();
                        patchDetailProgress.Rows[patchseqNum].Cells[0].Value = Convert.ToString(patchseqNum);
                        patchDetailProgress.Rows[patchseqNum].Cells[1].Value = "patching  " + patchcfgLine[i].Substring(0, 6) + " with " + patchcfgLine[i].Substring(8, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(0, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(8, 6);
                        patchseqNum++;
                    }
                    else
                    {
                        MessageBox.Show("Phy patch file format error.\n" + "Please Check patch file LINE:" + Convert.ToString(i + 1), "USBPhyRW Warning", MessageBoxButtons.OK);
                        goto endpatch4;
                    }
                }
            }
            endpatch4:;
            if (LDPatchCode5PATH != null)
            {
                string[] patchcfgLine = File.ReadAllLines(LDPatchCode5PATH);
                for (UInt16 i = 0; i < patchcfgLine.Length; i++)
                {
                    if (patchcfgLine[i].Length == 14)
                    {
                        patchDetailProgress.Rows.Add();
                        patchDetailProgress.Rows[patchseqNum].Cells[0].Value = Convert.ToString(patchseqNum);
                        patchDetailProgress.Rows[patchseqNum].Cells[1].Value = "patching  " + patchcfgLine[i].Substring(0, 6) + " with " + patchcfgLine[i].Substring(8, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(0, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(8, 6);
                        patchseqNum++;
                    }
                    else
                    {
                        MessageBox.Show("Phy patch file format error.\n" + "Please Check patch file LINE:" + Convert.ToString(i + 1), "USBPhyRW Warning", MessageBoxButtons.OK);
                        goto endpatch5;
                    }
                }
            }
            endpatch5:;
            if (LDPatchCode6PATH != null)
            {
                string[] patchcfgLine = File.ReadAllLines(LDPatchCode6PATH);
                for (UInt16 i = 0; i < patchcfgLine.Length; i++)
                {
                    if (patchcfgLine[i].Length == 14)
                    {
                        patchDetailProgress.Rows.Add();
                        patchDetailProgress.Rows[patchseqNum].Cells[0].Value = Convert.ToString(patchseqNum);
                        patchDetailProgress.Rows[patchseqNum].Cells[1].Value = "patching  " + patchcfgLine[i].Substring(0, 6) + " with " + patchcfgLine[i].Substring(8, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(0, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(8, 6);
                        patchseqNum++;
                    }
                    else
                    {
                        MessageBox.Show("Phy patch file format error.\n" + "Please Check patch file LINE:" + Convert.ToString(i + 1), "USBPhyRW Warning", MessageBoxButtons.OK);
                        goto endpatch6;
                    }
                }
            }
            endpatch6:;
            if (LDPatchCode7PATH != null)
            {
                string[] patchcfgLine = File.ReadAllLines(LDPatchCode7PATH);
                for (UInt16 i = 0; i < patchcfgLine.Length; i++)
                {
                    if (patchcfgLine[i].Length == 14)
                    {
                        patchDetailProgress.Rows.Add();
                        patchDetailProgress.Rows[patchseqNum].Cells[0].Value = Convert.ToString(patchseqNum);
                        patchDetailProgress.Rows[patchseqNum].Cells[1].Value = "patching  " + patchcfgLine[i].Substring(0, 6) + " with " + patchcfgLine[i].Substring(8, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(0, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(8, 6);
                        patchseqNum++;
                    }
                    else
                    {
                        MessageBox.Show("Phy patch file format error.\n" + "Please Check patch file LINE:" + Convert.ToString(i + 1), "USBPhyRW Warning", MessageBoxButtons.OK);
                        goto endpatch7;
                    }
                }
            }
            endpatch7:;
            if (LDPatchCode8PATH != null)
            {
                string[] patchcfgLine = File.ReadAllLines(LDPatchCode8PATH);
                for (UInt16 i = 0; i < patchcfgLine.Length; i++)
                {
                    if (patchcfgLine[i].Length == 14)
                    {
                        patchDetailProgress.Rows.Add();
                        patchDetailProgress.Rows[patchseqNum].Cells[0].Value = Convert.ToString(patchseqNum);
                        patchDetailProgress.Rows[patchseqNum].Cells[1].Value = "patching  " + patchcfgLine[i].Substring(0, 6) + " with " + patchcfgLine[i].Substring(8, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(0, 6);
                        //dbgshow.Text = patchcfgLine[i].Substring(8, 6);
                        patchseqNum++;
                    }
                    else
                    {
                        MessageBox.Show("Phy patch file format error.\n" + "Please Check patch file LINE:" + Convert.ToString(i + 1), "USBPhyRW Warning", MessageBoxButtons.OK);
                        goto endpatch8;
                    }
                }
            }
            endpatch8:;
        }
        private void ApplyAll_Click(object sender, EventArgs e)
        {
            openDevice();
            patchseqNumCurrent = 0;
            patchProgressNote.Text = "Excuting PatchSet.....";
            if (RamCodePatchNeed == 1)
            {
                 fillDetailGridView();
                //patchReq_Rdy(); // Patch request & wait patch_ready flow move to check ramcode flow
                this.patchDetailProgress.Rows[0].Selected = true;
                ExcutePatchCFG(LDPatchCode1PATH, 0x04, 0x00);
                patchProgressBar.Value = 10;
                ExcutePatchCFG(LDPatchCode2PATH, 0x05, 0x01);
                patchProgressBar.Value = 40;
                ExcutePatchCFG(LDPatchCode3PATH, 0x06, 0x02);
                patchProgressBar.Value = 50;
                ExcutePatchCFG(LDPatchCode4PATH, 0x07, 0x03);
                patchProgressBar.Value = 70;
                ExcutePatchCFG(LDPatchCode5PATH, 0x08, 0x04);
                patchProgressBar.Value = 80;
                PatchResetBit(0xB820,0x07); //(enable dbg_s auto increment)
                ExcutePatchCFG(LDPatchCode6PATH, 0x09, 0x05);
                patchProgressBar.Value = 90;
                ExcutePatchCFG(LDPatchCode7PATH, 0x0a, 0x06);
                patchProgressBar.Value = 95;
                //Release patch request PHY private reg 0xB820 bit[4] = 1'b0 (release patch request)
                PatchResetBit(0xB820, 0x04);
                PatchRead(0xB800,  0x0C); 
                //Update Patch Version
                PatchWrite(0xA436, 0x801E);
                PatchWrite(0xA438, 0x0001);
                //Issue code
                ExcutePatchCFG(LDPatchCode8PATH, 0x0b, 0x07);
                //PHYRST & Restart nway
                PatchWrite(0xA400,0x9200);  
            }
            else
                {
                    fillDetailGridView();
                    ExcutePatchCFG(LDPatchCode8PATH, 0x0b, 0x00);
                    PatchWrite(0xA400, 0x9200); //PHYRST & Restart nway
                }
            ConfigButton();
            patchProgressBar.Value = 100;
            patchProgressNote.Text = "Excuted Complete.";
        }
        //***********************************usb transfer and receiver and open and close functions above**********************//

    }


}
