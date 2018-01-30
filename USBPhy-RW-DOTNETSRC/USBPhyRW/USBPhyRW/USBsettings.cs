using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using HID;
using System.Runtime.InteropServices; //dll import

namespace USBPhyRW
{
    public partial class USBsettings : Form
    {
        public Hid myHid = new Hid();
        public IntPtr myHidPtr = new IntPtr();
        public USBsettings()
        {
            InitializeComponent();
            loadUSBcfg();
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
        //***********************************config ini Load save****************************************************************//
            string cfgPath = System.Environment.CurrentDirectory + "\\config.ini";
            string USBsec = "USBSettings";
            string USBvid = "VendorID";
            string USBpid = "ProductID";
        public void loadUSBcfg()
        {
            txtVendorID.Text  = ReadIniKeys(USBsec, USBvid, cfgPath);
            txtProductID.Text = ReadIniKeys(USBsec, USBpid, cfgPath);
        }
        public void saveUSBcfg()
        {
            WriteIniKeys(USBsec, USBvid, txtVendorID.Text,cfgPath);
            WriteIniKeys(USBsec, USBpid, txtProductID.Text, cfgPath);
        }
        public void CommuTest_Click(object sender, EventArgs e)
        {
            //关闭HID设备
            myHid.CloseDevice(myHidPtr);

            if (myHid.Opened == false)
            {
                //测试设备时 从CFG读取 更准确；
                UInt16 myVendorID = Convert.ToUInt16((ReadIniKeys(USBsec, USBvid, cfgPath)), 16);
                UInt16 myProductID = Convert.ToUInt16((ReadIniKeys(USBsec, USBpid, cfgPath)), 16);
                //myHidPtr = new IntPtr();
                if ((int)(myHidPtr = myHid.OpenDevice(myVendorID, myProductID)) != -1)
                {
                    stateLabel.Text = "Check PASS";
                    stateLabel.BackColor = this.stateLabel.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    stateLabel.Text = "Check FAIL";
                    stateLabel.BackColor = this.stateLabel.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                //设备已打开
                stateLabel.Text = "Check PASS";
            }
            //检查完毕关闭HID设备
            myHid.CloseDevice(myHidPtr);
        }

        private void SetCFG_Click(object sender, EventArgs e)
        {
            saveUSBcfg();
            MessageBox.Show("USB VID/PID Save success.\n", "USBPhyRW Notice", MessageBoxButtons.OK);
        }

        private void LoadCFG_Click(object sender, EventArgs e)
        {
            loadUSBcfg();
            MessageBox.Show("USB VID/PID Load success.\n", "USBPhyRW Notice", MessageBoxButtons.OK);
        }

    }
}
