using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;
using System.Diagnostics;

namespace ClashSinicizationToolUpgrade
{
    public partial class UpgradeMainForm : Form
    {
        private readonly string appPath;

        public UpgradeMainForm(string appPath)
        {
            InitializeComponent();

            this.appPath = appPath.Replace("\"", "");
        }

        private void UpgradeMainForm_Load(object sender, EventArgs e)
        {
            this.PathLabel.Text = "程序路径: " + appPath;
            this.ContentLabel.Text = "正在升级主程序...";
            this.RunButton.Enabled = false;
            if (CloseMainProgram())
            {
                Upgrading();
            }
            else
            {
                this.ContentLabel.Text = "无法退出主程序！";
            }
        }

        private bool CloseMainProgram()
        {
            foreach (Process vProc in Process.GetProcesses())
            {
                if (vProc.ProcessName.ToLower() == "clash sinicization tool")
                {
                    try
                    {
                        vProc.Kill();
                        vProc.WaitForExit();
                        vProc.Close();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void Upgrading()
        {
            var mainInfo = Directory.GetParent(Application.StartupPath);
            if (Directory.Exists(appPath) &&  mainInfo != null && mainInfo.Parent != null)
            {
                string mainPath = mainInfo.Parent.FullName;
                foreach (string file in GetFiles(mainPath))
                {
                    File.Copy(file, Path.Combine(appPath, Path.GetRelativePath(mainPath, file)), true);
                }
                this.ContentLabel.Text = "升级完成！";
                this.RunButton.Enabled = true;
            }
            else
            {
                this.ContentLabel.Text = "程序目录不存在！";
            }
        }

        private string[] GetFiles(string dirPath)
        {
            List<string> files = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                files.Add(file.FullName);
            }

            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                foreach (string subFile in GetFiles(dir.FullName))
                {
                    files.Add(subFile);
                }
            }

            return files.ToArray();
        }

        private void DeleteItSelfByCMD()
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 1000 > Nul & RD /S /Q " + Directory.GetParent(Application.ExecutablePath) + " & exit");
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.CreateNoWindow = true;
            Process.Start(psi);
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            bool run;
            Process p = new Process();
            try
            {
                p.StartInfo.FileName = Path.Combine(appPath, "Clash Sinicization Tool.exe");
                p.StartInfo.WorkingDirectory = appPath;
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.Verb = "runas";
                p.Start();
                run = true;
                p.Close();
            }
            catch
            {
                run = false;
                p.Close();
                this.ContentLabel.Text = "主程序启动失败！";
            }

            if (run)
            {
                Application.Exit();
            }
        }

        private void UpgradeMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteItSelfByCMD();
        }
    }
}