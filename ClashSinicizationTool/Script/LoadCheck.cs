using Microsoft.VisualBasic.Devices;
using System;
using ClashSinicizationToolBase;

namespace ClashSinicizationTool
{
    class LoadCheck
    {
        public bool CheckNode()
        {
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

        public bool CheckIntegratedAsar()
        {
            CMDCommand cmd = new CMDCommand();
            string[] commands = new string[] { "set path=npm;%path%", "asar -h" };
            return cmd.CMDCommondBase(commands).Contains("Manipulate asar archive files");
        }
    }
}
