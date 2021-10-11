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
            RegistryKey regKey = Registry.CurrentUser;
            RegistryKey regSubKey = regKey.OpenSubKey(@"SOFTWARE\Node.js");
            return regSubKey == null ? false : true;
        }

        public bool CheckAsar()
        {
            CMDCommand cmd = new CMDCommand();
            if (cmd.CMDCommondBase("asar -h").Contains("Manipulate asar archive files"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
