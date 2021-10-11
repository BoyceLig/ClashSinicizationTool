using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashSinicizationTool
{
    class CMDCommand
    {
        public string CMDCommondBase(string startPath, string command)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Process process = new Process();
            //设置要启动的应用程序
            process.StartInfo.FileName = "cmd.exe";
            //设置当前启动路径
            process.StartInfo.WorkingDirectory = startPath;
            //是否使用操作系统shell启动
            process.StartInfo.UseShellExecute = false;
            //不显示程序窗口
            process.StartInfo.CreateNoWindow = true;
            //接受来自调用程序的输入信息
            process.StartInfo.RedirectStandardInput = true;
            //输出信息
            process.StartInfo.RedirectStandardOutput = true;
            //输出错误
            process.StartInfo.RedirectStandardError = true;
            //启动程序
            process.Start();

            //输入命令
            process.StandardInput.WriteLine(command);
            process.StandardInput.WriteLine("exit");
            process.StandardInput.AutoFlush = true;
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            process.Close();
            return output;
        }
        public string CMDCommondBase(string command)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Process process = new Process();
            //设置要启动的应用程序
            process.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            process.StartInfo.UseShellExecute = false;
            //不显示程序窗口
            process.StartInfo.CreateNoWindow = true;
            //接受来自调用程序的输入信息
            process.StartInfo.RedirectStandardInput = true;
            //输出信息
            process.StartInfo.RedirectStandardOutput = true;
            //输出错误
            process.StartInfo.RedirectStandardError = true;
            //启动程序
            process.Start();

            //输入命令
            process.StandardInput.WriteLine(command);
            process.StandardInput.WriteLine("exit");
            process.StandardInput.AutoFlush = true;
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            process.Close();
            return output;
        }

        //解包命令
        public void Unpack(string appPath)
        {
            CMDCommondBase(appPath + @"\resources", "asar extract app.asar app");
        }

        //打包
        public void Pack(string appPath)
        {
            CMDCommondBase(appPath + @"\resources", "asar pack app app.asar");
        }


    }
}
