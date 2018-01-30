using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HID;

namespace USBPhyRW
{
    public partial class UsefulCommand : Form
    {
        public Hid usbPhyRWHID = new Hid();
        public IntPtr usbPhyRWHIDPtr = new IntPtr();
        //tag=0 default; tag=0x01 swreset；tag=0x02 other;
        Byte[] RecDataBuffer = new byte[90];
        public UsefulCommand()
        {
            usbPhyRWHID.DataReceived += new EventHandler<HID.report>(usbPhyRW_DataReceived);
            usbPhyRWHID.DeviceRemoved += new EventHandler(usbPhyRW_DeviceRemoved); //生USB REC Handler

            InitializeComponent();
        }
        //*************************************USB service function begin*****************************************//
       //数据到达事件
        protected void usbPhyRW_DataReceived(object sender, report e)
        {
            RecDataBuffer = e.reportBuff;
            Int16 ackn = (Int16)((RecDataBuffer[1] << 8) + RecDataBuffer[2]);
            switch (ackn)
            {
                case 0x0000:  MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\nPhy Chip HW RST success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
                case 0x0001:  MessageBox.Show("Receive ACK:" + "0x" + byteToHexStr(RecDataBuffer).Substring(2, 4) + "\nPhy Chip SW RST success.", "USBPhyRW Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); break;
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
        //打开设备
        private void openDevice()
        {
            if (usbPhyRWHID.Opened == false)
            {
                //默认VID/PID STM32中有定义
                UInt16 iVendorID = 0x0483;
                UInt16 iProductID = 0x5750;
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
        //关闭设备
        private void closeDevice()
        {
            usbPhyRWHID.CloseDevice(usbPhyRWHIDPtr);
        }
        //*************************************USB service function end*****************************************//
        public void hwRstPyh()
        {
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01; //version
            data[1] = 0x00;//hw request
            data[2] = 0x00; //hwrst
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
        }
        public void swRstPhy()
        {
            openDevice();
            Byte[] data = new byte[24];
            data[0] = 0x01;//version
            data[1] = 0x00;//sw request
            data[2] = 0x01; //read
            report r = new report(0, data);
            usbPhyRWHID.Write(r);
        }
        private void HWReset_Click(object sender, EventArgs e)
        {
            closeDevice();
            hwRstPyh();
        }
        private void SWReset_Click(object sender, EventArgs e)
        {
            closeDevice();
            swRstPhy();
        }
        private void UsefulCommand_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeDevice();
        }
    }
}
