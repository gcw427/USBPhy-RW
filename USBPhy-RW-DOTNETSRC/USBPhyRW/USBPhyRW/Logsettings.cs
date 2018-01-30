using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices; //dll import
using System.IO;

namespace USBPhyRW
{
    public partial class Logsettings : Form
    {
        public Logsettings()
        {
            InitializeComponent();
            //log level: debug info Warn error Fatal
            loadLogcfg();
        }
        string logsec = "Loglevel";
        string loglevel = "loglevel";
        string cfgPath = System.Environment.CurrentDirectory + "\\config.ini";
    //    string log4netcfg = System.Environment.CurrentDirectory + "\\USBPHYRWLOG.config";
        public void loadLogcfg()
        {
            Display.Text = ReadIniKeys(logsec, loglevel, cfgPath);
            switch (Display.Text)
            {
                case "DEBUG": Loglevel.Value = 0; break;
                case "INFO": Loglevel.Value = 1; break;
                case "WARN": Loglevel.Value = 2; break;
                case "ERROR": Loglevel.Value = 3; break;
                case "FATAL": Loglevel.Value = 4; break;
            }
        }
        private void Loglevel_ValueChanged(object sender, EventArgs e)
        {
            switch (Loglevel.Value)
            {
                case 0: Display.Text = "DEBUG";break;
                case 1: Display.Text = "INFO";break;
                case 2: Display.Text = "WARN";break;
                case 3: Display.Text = "ERROR";break;
                case 4: Display.Text = "FATAL";break;
            }         
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

        private void logButton_Click(object sender, EventArgs e)
        {
            WriteIniKeys(logsec, loglevel, Display.Text, cfgPath);
            MessageBox.Show("Loglevel save success.\n", "USBPhyRW Notice", MessageBoxButtons.OK);
        
 /*           StreamWriter writer = new StreamWriter(File.OpenWrite(log4netcfg));
            writer.BaseStream.Seek(1192, SeekOrigin.Begin);
            writer.Write("\""+Display.Text+"\""+" ");
            writer.Close(); */
        }
        //***********************************config ini API END*******************************************************************//
    }
}
