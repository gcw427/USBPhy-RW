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


namespace USBPhyRW
{
    public partial class PatchCode : Form
    {

        public Hid usbPhyRWHID = new Hid();
        public IntPtr usbPhyRWHIDPtr = new IntPtr();
        Byte[] RecDataBuffer = new byte[90];
        //golbal VID/PID
        UInt16 golbalVID = 0xff;
        UInt16 gobalPID = 0xff;
        UInt16 chipids = 0x00;

        public void patchInitForm()
        {
            usbPhyRWHID.DataReceived += new EventHandler<HID.report>(usbPhyRW_DataReceived);
            usbPhyRWHID.DeviceRemoved += new EventHandler(usbPhyRW_DeviceRemoved); //生USB REC Handler
            loadProgramcfg();
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
        protected void usbPhyRW_DataReceived(object sender, report e)
        {
            RecDataBuffer = e.reportBuff;
            //string receiveData = "0x" + byteToHexStr(RecDataBuffer).Substring(2, 5);
        }
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

        private void PatchCode_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeDevice();
        }

        public PatchCode()
        {
            InitializeComponent();
            downLoadPatch.Enabled = false;
            patchInitForm();
        }

     
        private void loadPatch_Click(object sender, EventArgs e)
        {
            OpenFileDialog choosefile = new OpenFileDialog();   //显示选择文件对话框 
            choosefile.InitialDirectory = System.Environment.CurrentDirectory;
            choosefile.Filter = "phyPatch file(*.patch)|*.patch";
            choosefile.FilterIndex = 2;
            choosefile.RestoreDirectory = true;

            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                 patchContent.Visible = true;
                //先清空grid view,防止后面再载入patch file时表格行号会被叠加；
                while (patchContent.RowCount > 0)
                {
                    patchContent.Rows.Remove(patchContent.Rows[0]);
                }
                this.patchLabel.Text = "Patch File PATH:";
                if (choosefile.FileName.Length >= 48)
                {
                    this.patchPATH.Text = choosefile.FileName.Substring(0, 48) + "\n" + choosefile.FileName.Substring(48);     //显示文件路径 
                }
                else
                {
                    this.patchPATH.Text = choosefile.FileName;
                 }
                string[] patchLine = File.ReadAllLines(choosefile.FileName);
                //parsing 表格数据到表格里面；
                for (int i = 0; i < patchLine.Length; i++)
                {
                    if (patchLine[i].Length == 13 )
                    {
                        patchContent.Rows.Add();
                        patchContent.Rows[i].Cells[0].Value = Convert.ToString(i);
                        patchContent.Rows[i].Cells[1].Value = patchLine[i].Substring(0, 1);
                        patchContent.Rows[i].Cells[2].Value = patchLine[i].Substring(2, 1);
                        patchContent.Rows[i].Cells[3].Value = patchLine[i].Substring(4, 2);
                        patchContent.Rows[i].Cells[4].Value = patchLine[i].Substring(7, 6);

                    }
                    else
                    {
                        while (patchContent.RowCount > 0)
                        {
                            patchContent.Rows.Remove(patchContent.Rows[0]);
                        }

                        MessageBox.Show("Phy patch file format error.\n" + "Please Check patch file LINE:"+Convert.ToString(i+1), "USBPhyRW Warning", MessageBoxButtons.OK);
                        goto end;
                    }
                }
                downLoadPatch.Enabled = true;
                MessageBox.Show("Phy patch file parsing success.\n" + "Please press download button to apply.", "USBPhyRW Notice", MessageBoxButtons.OK);
            }
            end:;
        }

        private void downLoadPatch_Click(object sender, EventArgs e)
        {
            //返回第0行选中，patch code要一行行下
            this.patchContent.Rows[0].Selected = true;
            loadPatch.Enabled = false;

            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x02; //normal rw
            data[2] = 0x01; //write
            UInt16 phyvalue;
            for (int i = 0; i < patchContent.Rows.Count; i++)
            {
                closeDevice();
                openDevice();
                patchContent.CurrentCell = patchContent.Rows[i].Cells[0];
                patchContent.Update();
               // patchContent.Rows[i].Selected = true;
                data[3] = Convert.ToByte(patchContent.Rows[i].Cells[2].Value.ToString());
                data[4] = Convert.ToByte(patchContent.Rows[i].Cells[3].Value.ToString());
                phyvalue = Convert.ToUInt16(patchContent.Rows[i].Cells[4].Value.ToString().Substring(2,4),16);
                data[5] = (byte)((phyvalue >> 8) & 0xff);
                data[6] = (byte)(phyvalue & 0xff);
                report r = new report(0, data);
                usbPhyRWHID.Write(r);
                System.Threading.Thread.Sleep(300);
                //debug
                //label1.Text = patchContent.Rows[i].Cells[4].Value.ToString().Substring(2,4);
           }
            loadPatch.Enabled = true;
            MessageBox.Show("Phy patch success.\n" + "Please press OK to close this messagebox.", "USBPhyRW Notice", MessageBoxButtons.OK);

        }


    }
}
