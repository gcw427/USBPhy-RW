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

namespace USBPhyRW
{
    public partial class IolTest : Form
    {
        public Hid usbPhyRWHID = new Hid();
        public IntPtr usbPhyRWHIDPtr = new IntPtr();
        Byte[] RecDataBuffer = new byte[90];
        //golbal VID/PID
        UInt16 golbalVID = 0xff;
        UInt16 gobalPID = 0xff;
        UInt16 chipids = 0x00;

        public IolTest()
        {
           usbPhyRWHID.DataReceived += new EventHandler<HID.report>(usbPhyRW_DataReceived);
           usbPhyRWHID.DeviceRemoved += new EventHandler(usbPhyRW_DeviceRemoved); //生USB REC Handler
            InitializeComponent();
            loadProgramcfg();
            matchButton(chipids);
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
        //***********************************usb transfer and receiver and open and close functions**********************//
        //数据到达事件
        protected void usbPhyRW_DataReceived(object sender, report e)
        {
            RecDataBuffer = e.reportBuff;
            //string receiveData = "0x" + byteToHexStr(RecDataBuffer).Substring(0, 4);
            Int16 ackn = (Int16)((RecDataBuffer[1] << 8) + RecDataBuffer[2]);
            switch (ackn)
            {
                case 0x0301: MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\n100M CHannel-A MLT3 Set success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
                case 0x0302: MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\n100M CHannel-B MLT3 Set success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
                case 0x0303: MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\n1000M TestMode 1 Set success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
                case 0x0304: MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\n1000M TestMode 2  Set success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
                case 0x0305: MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\n1000M TestMode 3  Set success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
                case 0x0306: MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\n1000M TestMode 4  Set success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
                case 0x0307: MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\n1000M TestMode 1 Stop success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
                case 0x0308: MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\n1000M TestMode 2 Stop success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
                case 0x0309: MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\n1000M TestMode 3 Stop success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
                case 0x030a: MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\n1000M TestMode 4 Stop success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
                case 0x030b: MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\n100M MLT3 Stop success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;

            }
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

        private void matchButton(UInt16 chiptype)
        {
            if ((chiptype >= 0x04) && (chiptype <= 0x09))
            {
                GigaT1Start.Enabled = false;
                GigaT2Start.Enabled = false;
                GigaT3Start.Enabled = false;
                GigaT4Start.Enabled = false;
                GigaT1Stop.Enabled = false;
                GigaT2Stop.Enabled = false;
                GigaT3Stop.Enabled = false;
                GigaT4Stop.Enabled = false;
            }
            //8211F 有Testmode2 
            else if (chiptype == 0x01)
            {
                GigaT3Start.Enabled = false;
                GigaT3Stop.Enabled = false;
            }
            else if (chiptype == 0x02 || chiptype == 0x03 || chiptype == 0x0a)
            {
                GigaT3Start.Enabled = false;
                GigaT3Stop.Enabled = false;
                GigaT2Start.Enabled = false;
                GigaT2Stop.Enabled = false;
            }
        }

        private void MegaChAStart_Click(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x03; //iol cmd
            data[2] = 0x01;//channel 
            data[3] = (byte)chipids;
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
          //  closeDevice();
        }
        private void MegaChBStart_Click(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01; 
            data[1] = 0x03; //iol cmd
            data[2] = 0x02; //channel B
            data[3] = (byte)chipids;
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
         //   closeDevice();
        }
        private void MegaTestStop_Click(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x03; //iol cmd
            data[2] = 0x0b; //stop mlt3
            data[3] = (byte)chipids;
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
         //   closeDevice();
        }

        private void GigaT1Start_Click(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x03; //iol cmd
            data[2] = 0x03; //Giga Testmode1 start
            data[3] = (byte)chipids;
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
        //    closeDevice();
        }

        private void GigaT2Start_Click(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x03; //iol cmd
            data[2] = 0x04; //Giga Testmode2 start
            data[3] = (byte)chipids;
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
         //   closeDevice();
        }

        private void GigaT3Start_Click(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x03; //iol cmd
            data[2] = 0x05; //Giga Testmode3 start
            data[3] = (byte)chipids;
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
       //     closeDevice();
        }

        private void GigaT4Start_Click(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x03; //iol cmd
            data[2] = 0x06; //Giga Testmode4 start
            data[3] = (byte)chipids;
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
        //    closeDevice();
        }

        private void GigaT1Stop_Click(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x03; //iol cmd
            data[2] = 0x07; //Giga Testmode1 stop
            data[3] = (byte)chipids;
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
      //      closeDevice();
        }

        private void GigaT2Stop_Click(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x03; //iol cmd
            data[2] = 0x08; //Giga Testmode2 stop
            data[3] = (byte)chipids;
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
       //     closeDevice();
        }

        private void GigaT3Stop_Click(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x03; //iol cmd
            data[2] = 0x09; //Giga Testmode3 stop
            data[3] = (byte)chipids;
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
      //      closeDevice();
        }

        private void GigaT4Stop_Click(object sender, EventArgs e)
        {
            closeDevice();
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x03; //iol cmd
            data[2] = 0x0a; //Giga Testmode4 stop
            data[3] = (byte)chipids;
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
      //      closeDevice();
        }

        //关闭窗口时释放USB 句柄占用
        private void IolTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeDevice();
        }
    }
}
