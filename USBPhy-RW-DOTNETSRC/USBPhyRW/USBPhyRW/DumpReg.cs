using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HID;
using System.Runtime.InteropServices; //dll import
using System.IO;
using System.Diagnostics;

namespace USBPhyRW
{
    public partial class DumpReg : Form
    {
        public Hid usbPhyRWHID = new Hid();
        public IntPtr usbPhyRWHIDPtr = new IntPtr();
        Byte[] RecDataBuffer = new byte[90];
        //golbal VID/PID
        UInt16 golbalVID = 0xff;
        UInt16 gobalPID = 0xff;
        UInt16 chipids = 0x00;

        public DumpReg()
        {
            usbPhyRWHID.DataReceived += new EventHandler<HID.report>(usbPhyRW_DataReceived);
            usbPhyRWHID.DeviceRemoved += new EventHandler(usbPhyRW_DeviceRemoved); //生USB REC Handler
            InitializeComponent();
            loadProgramcfg();
            SaveDump.Enabled = false;
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
        String ChipSet = "ChipID";
        string chipid = "IDs";
        string phychip = "NULL";

        string USBsec = "USBSettings";
        string USBvid = "VendorID";
        string USBpid = "ProductID";
        public void loadProgramcfg()
        {
            chipids = Convert.ToUInt16(ReadIniKeys(ChipSec, chipid, cfgPath));
            phychip = Convert.ToString(ReadIniKeys(ChipSec, ChipSet, cfgPath));
            //载入程序配置时 读取当下usb dongle的VID PID
            gobalPID = Convert.ToUInt16((ReadIniKeys(USBsec, USBpid, cfgPath)), 16);
            golbalVID = Convert.ToUInt16((ReadIniKeys(USBsec, USBvid, cfgPath)), 16);
        }
        //***********************************config ini Load save End*************************************************************//
        //***********************************usb transfer and receiver and open and close functions**********************//
        //数据到达事件
        protected void usbPhyRW_DataReceived(object sender, report e)
        {
            RecDataBuffer = e.reportBuff;
            string receiveData =byteToHexStr(RecDataBuffer).Substring(0, 48);
            reg0.Text ="0x"+ receiveData.Substring(0,4);
            reg1.Text = "0x" + receiveData.Substring(4, 4);
            reg2.Text = "0x" + receiveData.Substring(8, 4);
            reg3.Text = "0x" + receiveData.Substring(12, 4);
            reg4.Text = "0x" + receiveData.Substring(16, 4);
            reg5.Text = "0x" + receiveData.Substring(20, 4);
            reg6.Text = "0x" + receiveData.Substring(24, 4);
            reg7.Text = "0x" + receiveData.Substring(28, 4);
            reg8.Text = "0x" + receiveData.Substring(32, 4);
            reg9.Text = "0x" + receiveData.Substring(36, 4);
            reg10.Text = "0x" + receiveData.Substring(40, 4);
   //         reg11.Text = "0x" + receiveData.Substring(44, 4);
            MessageBox.Show("Dump required regs Success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            SaveDump.Enabled = true;
        }
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
        //***********************************config ini API END*******************************************************************//
        //dump reg0 reg1 reg2 reg3
        private void DumpAll_Click_1(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x05; //dump cmd
            for (UInt16 i = 0; i < 0xb; i++)
            {
                //reg 0-reg12
                data[2 + i] = Convert.ToByte(i);
            }
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
        }

        private void DumpAllReg_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeDevice();
        }

        private void SaveDump_Click(object sender, EventArgs e)
        {
            Stream myStream;
            
            SaveFileDialog saveDump = new SaveFileDialog();
            saveDump.FileName = phychip + "_regDump";
            saveDump.Filter = "regDump files   (*.txt)|*.txt";
            saveDump.FilterIndex = 2;
            saveDump.RestoreDirectory = false;

            if (saveDump.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveDump.OpenFile()) != null)
                {
                    using (StreamWriter sw = new StreamWriter(myStream))
                    {
                        sw.Write("Selected Phy Chip is: " + phychip+"\r\n");
                        sw.WriteLine("============START===========");
                        sw.WriteLine("reg0  =   " + reg0.Text );
                        sw.WriteLine("reg1  =   " + reg1.Text);
                        sw.WriteLine("reg2  =   " + reg2.Text);
                        sw.WriteLine("reg3  =   " + reg3.Text);
                        sw.WriteLine("reg4  =   " + reg4.Text);
                        sw.WriteLine("reg5  =   " + reg5.Text);
                        sw.WriteLine("reg6  =   " + reg6.Text);
                        sw.WriteLine("reg7  =   " + reg7.Text);
                        sw.WriteLine("reg8  =   " + reg8.Text);
                        sw.WriteLine("reg9  =   " + reg9.Text);
                        sw.WriteLine("reg10 =   " + reg10.Text);
                  //      sw.WriteLine("reg11 =   " + reg11.Text);
                        sw.WriteLine("===========END============\r\n");
                    }

                    myStream.Close();
                    MessageBox.Show("RegDump Save Success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }

        }
    }
}
