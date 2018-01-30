using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using HID;
using System.Runtime.InteropServices; //dll import

namespace USBPhyRW
{

    public partial class MainDialog : Form
    {
        public Hid usbPhyRWHID = new Hid();
        public IntPtr usbPhyRWHIDPtr = new IntPtr();
        Byte[] RecDataBuffer = new byte[90];
        //golbal VID/PID
        UInt16 golbalVID = 0xff;
        UInt16 gobalPID= 0xff;
        UInt16 chipids = 0x00;

        public MainDialog()
        {
            usbPhyRWHID.DataReceived += new EventHandler<HID.report>(usbPhyRW_DataReceived); 
            usbPhyRWHID.DeviceRemoved += new EventHandler(usbPhyRW_DeviceRemoved); //生USB REC Handler
            
            InitializeComponent();
            loadProgramcfg();
            upRegNote(0x00);   //显示默认的reg0 的reg notice
            phyValuebox.Leave += new EventHandler(phyValuebox_Leave); //生textbox leave 用以自动update BCD code
            phyAddrbox.Leave += new EventHandler(phyAddrbox_leave); //生leave 用以自动补全至1byte的数据
            phyRegbox.Leave += new EventHandler(phyRegbox_leave); //生leave 用以自动补全至1byte的数据

        }
        //log4net dll -> logreg
        // private static log4net.ILog logreg = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
        string ChipSec = "ChipSettings";
        String ChipSet = "ChipID";
        string chipid = "IDs";

        string USBsec = "USBSettings";
        string USBvid = "VendorID";
        string USBpid = "ProductID";
        public void loadProgramcfg()
        {
            chipTypeBox.Text = ReadIniKeys(ChipSec, ChipSet, cfgPath);
            chipids = Convert.ToUInt16(ReadIniKeys(ChipSec, chipid, cfgPath));
            //载入程序配置时 读取当下usb dongle的VID PID
            gobalPID = Convert.ToUInt16((ReadIniKeys(USBsec, USBpid, cfgPath)), 16);
            golbalVID = Convert.ToUInt16((ReadIniKeys(USBsec, USBvid, cfgPath)), 16);
        }
        public void saveProgramcfg()
        {
            WriteIniKeys(ChipSec, ChipSet, chipTypeBox.Text, cfgPath);
            WriteIniKeys(ChipSec, chipid, Convert.ToString(chipids), cfgPath);
        }
        //***********************************config ini Load save End*************************************************************//

        //***********************************usb transfer and receiver and open and close functions**********************//
        //数据到达事件
        protected void usbPhyRW_DataReceived(object sender, report e)
        {
            RecDataBuffer = e.reportBuff;
            if ((RecDataBuffer[0] & 0x80) == 0x80) bit15.Text = "1"; else bit15.Text = "0";
            if ((RecDataBuffer[0] & 0x40) == 0x40) bit14.Text = "1"; else bit14.Text = "0";
            if ((RecDataBuffer[0] & 0x20) == 0x20) bit13.Text = "1"; else bit13.Text = "0";
            if ((RecDataBuffer[0] & 0x10) == 0x10) bit12.Text = "1"; else bit12.Text = "0";
            if ((RecDataBuffer[0] & 0x08) == 0x08) bit11.Text = "1"; else bit11.Text = "0";
            if ((RecDataBuffer[0] & 0x04) == 0x04) bit10.Text = "1"; else bit10.Text = "0";
            if ((RecDataBuffer[0] & 0x02) == 0x02) bit9.Text = "1"; else bit9.Text = "0";
            if ((RecDataBuffer[0] & 0x01) == 0x01) bit8.Text = "1"; else bit8.Text = "0";
            if ((RecDataBuffer[1] & 0x80) == 0x80) bit7.Text = "1"; else bit7.Text = "0";
            if ((RecDataBuffer[1] & 0x40) == 0x40) bit6.Text = "1"; else bit6.Text = "0";
            if ((RecDataBuffer[1] & 0x20) == 0x20) bit5.Text = "1"; else bit5.Text = "0";
            if ((RecDataBuffer[1] & 0x10) == 0x10) bit4.Text = "1"; else bit4.Text = "0";
            if ((RecDataBuffer[1] & 0x08) == 0x08) bit3.Text = "1"; else bit3.Text = "0";
            if ((RecDataBuffer[1] & 0x04) == 0x04) bit2.Text = "1"; else bit2.Text = "0";
            if ((RecDataBuffer[1] & 0x02) == 0x02) bit1.Text = "1"; else bit1.Text = "0";
            if ((RecDataBuffer[1] & 0x01) == 0x01) bit0.Text = "1"; else bit0.Text = "0";
            //string receiveData = "0x" + byteToHexStr(RecDataBuffer).Substring(0, 4);
            string receiveData = byteToHexStr(RecDataBuffer).Substring(0, 4);
            phyValuebox.Text = receiveData;
            

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
                    //设备打开咯
                }
                else
                {
                    //连接失败；
                    MessageBox.Show("USB Communication Fail.\n"+"Please Check Stm32 Board connection!", "USBPhyRW Warning", MessageBoxButtons.RetryCancel);
                }
            }
            else
            {
                //设备已经打开了
            }
        }
        private void closeDevice()
        {
            usbPhyRWHID.CloseDevice(usbPhyRWHIDPtr);
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

        //指定协议格式：
        //data[0] =version 01
        //dara[1] =cmdwd 00/01/10/11 
        //00=hardware request    data[2] ={00 PHYHWRST,01，Other} data3={}
        //01=board fw update 
        //02 =normal RW             data[2] ={ 00=read 01=write} data[3] ={ PHYADDR;} data[4] = {REGADDR; }data[5] ={ REGVALUE; (only when write)}
        //03 option
       
        public void rdPhyReg()
        {
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x02; //normal rw
            data[2] = 0x00; //read
            data[3] = Convert.ToByte(phyAddrbox.Text);
            data[4] = Convert.ToByte(phyRegbox.Text);
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
        }
        public void wrPhyReg()
        {
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x02; //normal rw
            data[2] = 0x01; //write
            data[3] = Convert.ToByte(phyAddrbox.Text);
            data[4] = Convert.ToByte(phyRegbox.Text);
            //UInt16 phyvalue = Convert.ToUInt16(phyValuebox.Text.Substring(2, 4), 16);
            UInt16 phyvalue = Convert.ToUInt16(phyValuebox.Text.Substring(0, 4), 16);
            data[5] = (byte)((phyvalue >> 8) & 0xff);
            data[6] = (byte)(phyvalue & 0xff);
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
        }

        public void hwRstPyh()
        {
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;
            data[1] = 0x00;
            data[2] = 0x00; //rst
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
        }

        //判断是不是decimal数字啦
        public bool isValueCorr(string strValue)
        {
            bool re = false;
            try
            {
                double result = double.Parse(strValue);
                re = true;
            }
            catch
            {
                re = false;
            }
            return re;
        }

        //read phy click
        private void readPhy_Click(object sender, EventArgs e)
        {
            if ((false == (isValueCorr(phyAddrbox.Text))) || (false == (isValueCorr(phyRegbox.Text))))
            {
                MessageBox.Show("PHYADDR/REGADDR format error.\n" + "Please Check PHYADDR/REGADDR format.", "USBPhyRW Warning", MessageBoxButtons.RetryCancel);
                return;
            }
            rdPhyReg();
        }


        //write phy click
        private void writePhy_Click(object sender, EventArgs e)
        {
            if ((false == (isValueCorr(phyAddrbox.Text))) || (false == (isValueCorr(phyRegbox.Text))))
            {
                MessageBox.Show("PHYADDR/REGADDR format error.\n" + "Please Check PHYADDR/REGADDR format.", "USBPhyRW Warning", MessageBoxButtons.RetryCancel);
                return;
            }
            wrPhyReg();
        }
        //update reg notice box when reg textbox leave happed
        public void upRegNote(UInt16 phyvalue)
        {
            switch (phyvalue)
            {
                case 0x00: regNotice.Text = "BMCR-Basic Mode Control Register Address 0x00" + "\r\n" + "  " +
                        "bit15: RESET(1,phy reset   0,normal operation)" + "\r\n" + "  " +
                        "bit14: LOOPBACK(0/1, Disable/Enable pcs loopback mode)" + "\r\n" + "  " +
                        "bit13: SPEED[0](speed select bit0)" + "\r\n" + "  " +
                        "bit12: ANE(0/1, Disable/Enable Auto-Negotiation)" + "\r\n" + "  " +
                        "bit11: PWD(0/1,Normal/PowerDown mode)" + "\r\n" + "  " +
                        "bit10: ISOLATE(0/1,Normal/Isolate RGMII)" + "\r\n" + "  " +
                        "bit09: RestartAN(0/1,Normal/Reset Auto-Negotiation)" + "\r\n" + "  " +
                        "bit08: Duplex(0/1,Half/Full Duplex mode)" + "\r\n" + "  " +
                        "bit07: Collision test(0/1 Normal/Collision Test enable)" + "\r\n" + "  " +
                        "bit06: SPEED[1](speed select bit1)" + "\r\n" + "  " +
                        "bit05: Uni-Dir enabel" + "\r\n" + "  " +
                        "bit04-bit00: RSVD";
                    break;
                case 0x01: regNotice.Text = "BMSR-Basic Mode Status Register Address 0x01" + "\r\n" + "  " +
                        "bit15: 100BaseT4(0,100Base-T4 capability always 0)" + "\r\n" + "  " +
                        "bit14: 100Base-TX(full)   bit13: 100Base-TX(half)" + "\r\n" + "  " +
                        "bit12: 10Base-T(full)       bit11: 10Base-T(half)" + "\r\n" + "  " +
                        "bit10: 10Base-T2(full)     bit09: 10Base-T2(half)" + "\r\n" + "  " +
                        "bit08: 1000Base-T Extended Status    bit07: Uni-directional ability" + "\r\n" + "  " +
                        "bit06: Premble Susppression   bit05: AN complete" + "\r\n" + "  " +
                        "bit04: Remote fault    bit03: AN ability   bit02: Link Status" + "\r\n" + "  " +
                        "bit01: Jabber Detect   bit00: Extended Capability";
                    break;
                case 0x02: regNotice.Text = "PHY Identifier Register 1 Address 02" + "\r\n" + "  " +
                        "bit15-bit0: OUI_MSB";
                    break;
                case 0x03: regNotice.Text = "PHY Identifier Register 2 Address 03" + "\r\n" + "  " +
                        "bit15-bit10: OUI LSB" + "\r\n" + "  " +
                        "bit09-bit04: Model Number" + "\r\n" + "  " +
                        "bit03-bit00: Revision Number";
                    break;
                case 0x04: regNotice.Text = "ANAR-Auto Negotiation Advertising Register Address 04" + "\r\n" + "  " +
                        "bit15: NextPage    bit14: RSVD    bit13: Remote Fault    bit12:RSVD" + "\r\n" + "  " +
                        "bit11: Asymmetric pause   bit10: PAUSE   bit09 100Base-T4" + "\r\n" + "  " +
                        "bit08: 100Base-TX(full)   bit07: 100Base-TX(half)   bit06: 10Base-T(full)   bit05: 10Base-T(half)" + "\r\n" + "  " +
                        "bit04-bit00: Selector Field";
                    break;
                case 0x05: regNotice.Text = "ANLPAR-Auto Negotitation Link Partner Ability Register Address 05" + "\r\n" + "  " +
                        "bit15: Next Page   bit14 ACK   bit13: Remote Fault   bit12: RSVD" + "\r\n" + "  " +
                        "bit11-bit05: Technology Ability Filed" + "\r\n" + "  " +
                        "bit04-bit00: Selector Field";
                    break;
                case 0x06: regNotice.Text = "ANER-Auto Negotitation Expansion Register Address 06" + "\r\n" + "  " +
                        "bit15-bit05 RSVD" + "\r\n" + "  " +
                        "bit06: RX NP location ability" + "\r\n" + "  " +
                        "bit05: RX NP location" + "\r\n" + "  " +
                        "bit04: Parallel Detection Fault" + "\r\n" + "  " +
                        "bit03: Link Partner Next Page able" + "\r\n" + "  " +
                        "bit02: Local Next Page able" + "\r\n" + "  " +
                        "bit01: Page Received" + "\r\n" + "  " +
                        "bit00: Link Partner Auto-Negotitation capable";
                    break;
                case 0x07: regNotice.Text = "ANNPTR-Auto Negotitation Next Page Transmit  Regisrer Address 07" + "\r\n" + "  " +
                        "bit15: Next Page   bit14:RSVD   bit13:Message Page" + "\r\n" + "  " +
                        "bit12: Acknowledge2   bit11: Toggle" + "\r\n" + "  " +
                        "bit10-bit00: Message/Unformatted Field";
                    break;
                case 0x08: regNotice.Text = "ANNPRR-Auto Negotitation Next Page Receive Register Address08" + "\r\n" + "  " +
                        "bit15: Next Page   bit14: Acknowledge   bit13: Message Page" + "\r\n" + "  " +
                        "bit12: Acknowledge2   bit11: Toggle" + "\r\n" + "  " +
                        "bit10-bit00: Message/Unformatted Field";
                    break;
                case 0x09: regNotice.Text = "GBCR-100Base-T Control Register Address 0x09" + "\r\n" + "  " +
                        "bit15-bit13: Text Mode   bit12: Master/Slave Manual Configuration Enable" + "\r\n" + "  " +
                        "bit11: Master/Slave Configuration Value" + "\r\n" + "  " +
                        "bit10: Port Type   bit09: 1000Base-T Full Duplex" + "\r\n" + "  " +
                        "bit08-bit00: RSVD";
                    break;
                case  0x0A: regNotice.Text = "GBSR-100Base-T Status Register Address 0x0a" + "\r\n" + "  " +
                        "bit15: Master/Slave Configuration Fault" + "\r\n" + "  " +
                        "bit14: Master/Slave Configuration Resolution" + "\r\n" + "  " +
                        "bit13: Local Receiver Status" + "\r\n" + "  " +
                        "bit12: Remote Receiver Status" + "\r\n" + "  " +
                        "bit11: Link Partner 1000Base-T Full Duplex Capability" + "\r\n" + "  " +
                        "bit10: Link Partner 1000Base-T Half Duplex Capability" + "\r\n" + "  " +
                        "bit09-bit08: RSVD   bit07-bit00: Idle Error Count";
                    break;
                case 0x0D: regNotice.Text = "MACR-MMD Access Control Register Address 0x0D" + "\r\n" + "  " +
                        "bit15-bit14: Function" + "\r\n" + "  " +
                         "bit13:bit05: RSVD" + "\r\n" + "  " +
                        "bit04-bit00: DEVAD";
                    break;
                case 0x0E: regNotice.Text = "MAADR-MMD Access Address Data Register Address 0x0E" + "\r\n" + "  " +
                        "bit15-bit00: Address Data" + "\r\n" + "     " +
                        "(bit15-bit14=00 MMD DEVAD's address register)" + "\r\n" + "  " +
                        "(bit14-bit14=01/10/11 MMD DEVAD's data register ad indicated by  the contents of  its address register)";
                    break;
                case 0x0F: regNotice.Text = "GBESR-1000Base-T Extended Status Register Address 0x0F" + "\r\n" + "  " +
                        "bit15: 1000Base-X Full duplex capable" + "\r\n" + "  " +
                        "bit14: 1000Base-X Half duplex capable" + "\r\n" + "  " +
                        "bit13: 1000Base-T Full duplex capable" + "\r\n" + "  " +
                        "bit12: 1000Base-T Half duplex capable" + "\r\n" + "  " +
                        "bit11-bit00: RSVD";
                    break;
                default:
                    regNotice.Text = " ";
                    break;
            }
        }

        //update BCD code from textbox when textbox leave happen.
        public void upRegBCDValue(string hexvalue)
        {
            Byte[] data = new byte[4];
            UInt16 phyvalue = Convert.ToUInt16(hexvalue,16);
            data[0] = (byte)((phyvalue >> 8) & 0xff);
            data[1] = (byte)(phyvalue & 0xff);
            if ((data[0] & 0x80) == 0x80) bit15.Text = "1"; else bit15.Text = "0";
            if ((data[0] & 0x40) == 0x40) bit14.Text = "1"; else bit14.Text = "0";
            if ((data[0] & 0x20) == 0x20) bit13.Text = "1"; else bit13.Text = "0";
            if ((data[0] & 0x10) == 0x10) bit12.Text = "1"; else bit12.Text = "0";

            if ((data[0] & 0x08) == 0x08) bit11.Text = "1"; else bit11.Text = "0";
            if ((data[0] & 0x04) == 0x04) bit10.Text = "1"; else bit10.Text = "0";
            if ((data[0] & 0x02) == 0x02) bit9.Text = "1"; else bit9.Text = "0";
            if ((data[0] & 0x01) == 0x01) bit8.Text = "1"; else bit8.Text = "0";

            if ((data[1] & 0x80) == 0x80) bit7.Text = "1"; else bit7.Text = "0";
            if ((data[1] & 0x40) == 0x40) bit6.Text = "1"; else bit6.Text = "0";
            if ((data[1] & 0x20) == 0x20) bit5.Text = "1"; else bit5.Text = "0";
            if ((data[1] & 0x10) == 0x10) bit4.Text = "1"; else bit4.Text = "0";

            if ((data[1] & 0x08) == 0x08) bit3.Text = "1"; else bit3.Text = "0";
            if ((data[1] & 0x04) == 0x04) bit2.Text = "1"; else bit2.Text = "0";
            if ((data[1] & 0x02) == 0x02) bit1.Text = "1"; else bit1.Text = "0";
            if ((data[1] & 0x01) == 0x01) bit0.Text = "1"; else bit0.Text = "0";
        }

        //update phyvaluebox from BCD code;
        public void upRegVaule()
        {
            Byte[] regValue = new byte[5];
            regValue[0] = 0;
            regValue[1] = 0;
            if (bit15.Text == "1") regValue[0] = (byte)(regValue[0] | 0x80); else regValue[0] = (byte)(regValue[0] & 0x7f);
            if (bit14.Text == "1") regValue[0] = (byte)(regValue[0] | 0x40); else regValue[0] = (byte)(regValue[0] & 0xbf);
            if (bit13.Text == "1") regValue[0] = (byte)(regValue[0] | 0x20); else regValue[0] = (byte)(regValue[0] & 0xdf);
            if (bit12.Text == "1") regValue[0] = (byte)(regValue[0] | 0x10); else regValue[0] = (byte)(regValue[0] & 0xef);

            if (bit11.Text == "1") regValue[0] = (byte)(regValue[0] | 0x08); else regValue[0] = (byte)(regValue[0] & 0xf7);
            if (bit10.Text == "1") regValue[0] = (byte)(regValue[0] | 0x04); else regValue[0] = (byte)(regValue[0] & 0xfb);
            if (bit9.Text == "1") regValue[0] = (byte)(regValue[0] | 0x02); else regValue[0] = (byte)(regValue[0] & 0xfd);
            if (bit8.Text == "1") regValue[0] = (byte)(regValue[0] | 0x01); else regValue[0] = (byte)(regValue[0] & 0xfe);

            if (bit7.Text == "1") regValue[1] = (byte)(regValue[1] | 0x80); else regValue[1] = (byte)(regValue[1] & 0x7f);
            if (bit6.Text == "1") regValue[1] = (byte)(regValue[1] | 0x40); else regValue[1] = (byte)(regValue[1] & 0xbf);
            if (bit5.Text == "1") regValue[1] = (byte)(regValue[1] | 0x20); else regValue[1] = (byte)(regValue[1] & 0xdf);
            if (bit4.Text == "1") regValue[1] = (byte)(regValue[1] | 0x10); else regValue[1] = (byte)(regValue[1] & 0xef);

            if (bit3.Text == "1") regValue[1] = (byte)(regValue[1] | 0x08); else regValue[1] = (byte)(regValue[1] & 0xf7);
            if (bit2.Text == "1") regValue[1] = (byte)(regValue[1] | 0x04); else regValue[1] = (byte)(regValue[1] & 0xfb);
            if (bit1.Text == "1") regValue[1] = (byte)(regValue[1] | 0x02); else regValue[1] = (byte)(regValue[1] & 0xfd);
            if (bit0.Text == "1") regValue[1] = (byte)(regValue[1] | 0x01); else regValue[1] = (byte)(regValue[1] & 0xfe);
            //string regData = "0x" + byteToHexStr(regValue).Substring(0, 4);
            string regData =  byteToHexStr(regValue).Substring(0, 4);
            phyValuebox.Text = regData;
        }

        //自动补全phyvaluebox；
        void phyValuebox_Leave(object sender, EventArgs e)
        {
            //判断长度 要满足4个数；
            if (phyValuebox.Text.Length < 4)
            {
                int len = phyValuebox.Text.Length;
                switch (len) {
                    case 0:  phyValuebox.Text = "0000";
                        break;
                    case 1: phyValuebox.Text = "000" + phyValuebox.Text;
                        break;
                    case 2: phyValuebox.Text = "00" + phyValuebox.Text;
                        break;
                    case 3: phyValuebox.Text = "0" +phyValuebox.Text;
                        break;             
                }
                
            }
            //upRegBCDValue(phyValuebox.Text.Substring(2, 4));
            upRegBCDValue(phyValuebox.Text.Substring(0, 4));
        }

        void phyAddrbox_leave(object sender, EventArgs e)
        {
            if (phyAddrbox.Text.Length < 2)
            {
                int len = phyAddrbox.Text.Length;
                switch (len)
                {
                    case 0: phyAddrbox.Text = "00"; break;
                    case 1: phyAddrbox.Text = "0" + phyAddrbox.Text; break;
                }
            }
        }

        void phyRegbox_leave(object sender, EventArgs e)
        {
            if (phyRegbox.Text.Length < 2) phyRegbox.Text = "0" + phyRegbox.Text;
            if (phyRegbox.Text.Length < 2)
            {
                int len = phyRegbox.Text.Length;
                switch (len)
                {
                    case 0:phyRegbox.Text = "00";break;
                    case 1:phyRegbox.Text = "0" + phyRegbox.Text;break;
                }
            }
            //显示reg提示
            upRegNote(Convert.ToByte(phyRegbox.Text));
        }

        //限定输入0-9 A-F a-f
        private void phyValuebox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 0x2F && e.KeyChar < 0x3A)|| e.KeyChar == 0x08 || (e.KeyChar > 0x60 && e.KeyChar <0x67)|| (e.KeyChar > 0x40 && e.KeyChar <0x47))
                e.Handled = false;
            else e.Handled = true;
        }

        //限定输入0-9 和backspace
        private void phyRegbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar > 0x2F && e.KeyChar < 0x3A) || e.KeyChar == 0x08)
                e.Handled = false;
            else e.Handled = true;
        }

        //限定输入0-9 和backspace
        private void phyAddrbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 0x2F && e.KeyChar < 0x3A) || e.KeyChar == 0x08)
                e.Handled = false;
            else e.Handled = true;
        }


        //********************************************BCD click begin**************************************//
        private void bit15_Click(object sender, EventArgs e)
        {
            if (bit15.Text == "0") bit15.Text = "1";
            else if (bit15.Text == "1") bit15.Text = "0";
            upRegVaule();


        }
        private void bit14_Click(object sender, EventArgs e)
        {
            if (bit14.Text == "0") bit14.Text = "1";
            else if (bit14.Text == "1") bit14.Text = "0";
            upRegVaule();
        }

        private void bit13_Click(object sender, EventArgs e)
        {
            if (bit13.Text == "0") bit13.Text = "1";
            else if (bit13.Text == "1") bit13.Text = "0";
            upRegVaule();
        }

        private void bit12_Click(object sender, EventArgs e)
        {
            if (bit12.Text == "0") bit12.Text = "1";
            else if (bit12.Text == "1") bit12.Text = "0";
            upRegVaule();
        }

        private void bit11_Click(object sender, EventArgs e)
        {
            if (bit11.Text == "0") bit11.Text = "1";
            else if (bit11.Text == "1") bit11.Text = "0";
            upRegVaule();
        }

        private void bit10_Click(object sender, EventArgs e)
        {
            if (bit10.Text == "0") bit10.Text = "1";
            else if (bit10.Text == "1") bit10.Text = "0";
            upRegVaule();
        }

        private void bit9_Click(object sender, EventArgs e)
        {
            if (bit9.Text == "0") bit9.Text = "1";
            else if (bit9.Text == "1") bit9.Text = "0";
            upRegVaule();
        }

        private void bit8_Click(object sender, EventArgs e)
        {
            if (bit8.Text == "0") bit8.Text = "1";
            else if (bit8.Text == "1") bit8.Text = "0";
            upRegVaule();
        }

        private void bit7_Click(object sender, EventArgs e)
        {
            if (bit7.Text == "0") bit7.Text = "1";
            else if (bit7.Text == "1") bit7.Text = "0";
            upRegVaule();
        }

        private void bit6_Click(object sender, EventArgs e)
        {
            if (bit6.Text == "0") bit6.Text = "1";
            else if (bit6.Text == "1") bit6.Text = "0";
            upRegVaule();
        }

        private void bit5_Click(object sender, EventArgs e)
        {
            if (bit5.Text == "0") bit5.Text = "1";
            else if (bit5.Text == "1") bit5.Text = "0";
            upRegVaule();
        }

        private void bit4_Click(object sender, EventArgs e)
        {
            if (bit4.Text == "0") bit4.Text = "1";
            else if (bit4.Text == "1") bit4.Text = "0";
            upRegVaule();
        }

        private void bit3_Click(object sender, EventArgs e)
        {
            if (bit3.Text == "0") bit3.Text = "1";
            else if (bit3.Text == "1") bit3.Text = "0";
            upRegVaule();
        }

        private void bit2_Click(object sender, EventArgs e)
        {
            if (bit2.Text == "0") bit2.Text = "1";
            else if (bit2.Text == "1") bit2.Text = "0";
            upRegVaule();
        }

        private void bit1_Click(object sender, EventArgs e)
        {
            if (bit1.Text == "0") bit1.Text = "1";
            else if (bit1.Text == "1") bit1.Text = "0";
            upRegVaule();
        }

        private void bit0_Click(object sender, EventArgs e)
        {
            if (bit0.Text == "0") bit0.Text = "1";
            else if (bit0.Text == "1") bit0.Text = "0";
            upRegVaule();
        }
        //********************************************BCD click end**************************************//
        //***************************************************menu strip******************************************//
        //chip type:
        //01 -> 8211F
        //02 -> 8211E(-VB)
        //03 -> 8211DS
        //04 -> 8201F-VA(8201FN-CG/8201FL-CG)
        //05 -> 8201FR
        //06 -> 8201F-VB(8201FN-VB/8201FL-VB/8201FR-VB)
        //07 -> 8201FNI-VC
        //08 -> 8201F-VD(8201FR-VD)
        //09 -> 8201E
        //0a ->	8211D
        private void rTL8201EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chipTypeBox.Text = "RTL8201E";
            chipids = 0x09;
            saveProgramcfg();
            loadProgramcfg();
        }

        private void rTL8201FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chipTypeBox.Text = "RTL8201FVA";
            chipids = 0x04;
            saveProgramcfg();
            loadProgramcfg();
        }

        private void rTL8211EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chipTypeBox.Text = "RTL8211E";
            chipids = 0x02;
            saveProgramcfg();
            loadProgramcfg();
        }

        private void rTL8211FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chipTypeBox.Text = "RTL8211F";
            chipids = 0x01;
            saveProgramcfg();
            loadProgramcfg();
        }
        private void rTL8211DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chipTypeBox.Text = "RTL8211D";
            chipids = 0x03;
            saveProgramcfg();
            loadProgramcfg();
        }
        private void rTL8201FVBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chipTypeBox.Text = "RTL8201FVB";
            chipids = 0x06 ;
            saveProgramcfg();
            loadProgramcfg();
        }

        private void rTL8201FVCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chipTypeBox.Text = "RTL8201FVC";
            chipids = 0x07;
            saveProgramcfg();
            loadProgramcfg();
        }

        private void rTL8201FVDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chipTypeBox.Text = "RTL8201FVD";
            chipids = 0x08;
            saveProgramcfg();
            loadProgramcfg();
        }
        //****************************************MenuStrip actions above***************************//
        //****************************************Menu strip below**********************************//
        private void uSBsettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //卧槽下面的menustrip 入口全部都要关闭句柄。。。坑爹。
            closeDevice();
            USBsettings usbsetting = new USBsettings();
            usbsetting.ShowDialog();
        }

        private void uSBBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeDevice();
            USBBoard usbboard = new USBBoard();
            usbboard.ShowDialog();
        }

        private void uSBPhyRWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeDevice();
            USBPhyRW usbphyrw = new USBPhyRW();
            usbphyrw.ShowDialog();
        }
        private void logsettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeDevice();
            Logsettings logsettings = new Logsettings();
            logsettings.ShowDialog();
        }
        private void usageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeDevice();
            System.Diagnostics.Process.Start(Application.StartupPath + "\\ReadMe.mht");
        }
        private void dumpAllRegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeDevice();
            DumpReg dumpallreg = new DumpReg();
            dumpallreg.ShowDialog();
        }

        private void usefulCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeDevice();
            UsefulCommand usefulcommand = new UsefulCommand();
            usefulcommand.ShowDialog();
        }

        private void loopBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeDevice();
            LoopBack loopback = new LoopBack();
            loopback.ShowDialog();
        }

        private void packetGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeDevice();
            PacketGen packetgen = new PacketGen();
            packetgen.ShowDialog();
        }
        private void iOLTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeDevice();
            IolTest ioltest = new IolTest();
            ioltest.ShowDialog();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeDevice();
            Application.Exit();
        }
    }
}
