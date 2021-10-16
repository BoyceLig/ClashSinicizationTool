using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashSinicizationTool
{
    class LoadCheck
    {
        public bool CheckNode()
        {
            //RegistryKey regSubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Node.js");
            //return regSubKey == null ? false : true;
            CMDCommand cmd = new CMDCommand();
            return cmd.CMDCommondBase("npm").Contains("npm <command>");
        }

        public bool CheckAsar()
        {
            CMDCommand cmd = new CMDCommand();
            return cmd.CMDCommondBase("asar -h").Contains("Manipulate asar archive files");
        }

        public bool CheckPing(string url)
        {
            Network network = new Network();
            try
            {
                return network.Ping(url) ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
