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
        //解包命令
        public void Unpack(string appPath, TextBox logText)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Process process = new Process();
            //设置要启动的应用程序
            process.StartInfo.FileName = "cmd.exe";
            //设置当前启动路径
            process.StartInfo.WorkingDirectory = appPath + @"\resources";
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
            process.StandardInput.WriteLine("asar extract app.asar app & exit");
            process.StandardInput.AutoFlush = true;
            //输出
            logText.AppendText(process.StandardOutput.ReadToEnd() + Environment.NewLine + "已解包 app.asar ，请进一步汉化。" + Environment.NewLine);
            process.WaitForExit();
            process.Close();
        }

        //打包
        public void Pack(string appPath, TextBox logText)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Process process = new Process();
            //设置要启动的应用程序
            process.StartInfo.FileName = "cmd.exe";
            //设置当前启动路径
            process.StartInfo.WorkingDirectory = appPath + @"\resources";
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
            process.StandardInput.WriteLine("asar pack app app.asar & exit");
            process.StandardInput.AutoFlush = true;
            //输出
            logText.AppendText(process.StandardOutput.ReadToEnd() + Environment.NewLine + "已打包 app.asar" + Environment.NewLine);
            process.WaitForExit();
            process.Close();
        }

        //检查系统是否安装node插件
        public bool IsInastallNode(TextBox logText)
        {
            bool isNode;
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
            process.StandardInput.WriteLine("node -v & exit");
            process.StandardInput.AutoFlush = true;
            //输出
            //process.StandardOutput.Read()

            logText.AppendText(process.StandardOutput.ReadToEnd() + Environment.NewLine);
            //sisNode = process.StandardOutput.ReadToEnd().IndexOf("Options", StringComparison.OrdinalIgnoreCase) > 0;
            process.WaitForExit();
            process.Close();
            return isNode = true;
        }
    }
}
