using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace USBPhyRW
{
    public partial class USBPhyRW : Form
    {
        public USBPhyRW()
        {
            InitializeComponent();
        }

        private void checkupdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update Server(172.29.32.49) is Not available.\n" + "Please conntact 57489 if any doubt.", "USBPhyRW Warning", MessageBoxButtons.OK);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Wendy1106/USBPhy-RW");
        }
    }
}
