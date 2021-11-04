using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashSinicizationTool
{
    public partial class UpdateForm : Form
    {
        string newversion = "1.1.4";

        public UpdateForm()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GlobalData.versionPath);
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(resStream, Encoding.UTF8);
            newversion = streamReader.ReadLine();
        }

        private void UpdateForm_Shown(object sender, EventArgs e)
        {
            DownloadFile(GlobalData.downloadUrlX64, "Clash Sinicization Tool x64.7z", progressBar, stateLabel);
            //Close();
            if (File.Exists("Clash Sinicization Tool x64.7z"))
            {
                Extract7z("Clash Sinicization Tool x64.7z", progressBar, stateLabel);
            }
            else
            {
                stateLabel.Text = "下载失败，请手动下载并替换";
            }
        }

        #region 按钮
        //手动更新
        private void manualUpdateButton_Click(object sender, EventArgs e)
        {
            if (Environment.Is64BitProcess)
            {
                Process.Start("explorer.exe", GlobalData.downloadUrlX64);
            }
            else
            {
                Process.Start("explorer.exe", GlobalData.downloadUrlX86);
            }
        }

        private void retryButton_Click(object sender, EventArgs e)
        {
            UpdateForm_Shown(sender, e);
        }
        #endregion

        //下载
        public void DownloadFile(string URL, string filename, ProgressBar progressBar, Label label)
        {
            float percent = 0;
            try
            {
                HttpWebRequest Myrq = (HttpWebRequest)HttpWebRequest.Create(URL);
                HttpWebResponse myrp = (HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (progressBar != null)
                {
                    progressBar.Maximum = (int)totalBytes;
                    progressBar.Minimum = 0;
                }
                Stream st = myrp.GetResponseStream();
                Stream so = new FileStream(filename, FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    Application.DoEvents();
                    so.Write(by, 0, osize);
                    if (progressBar != null)
                    {
                        progressBar.Value = (int)totalDownloadedByte;
                    }
                    osize = st.Read(by, 0, (int)by.Length);

                    percent = totalDownloadedByte / totalBytes * 100;
                    label.Text = "已下载：" + ((int)percent).ToString() + "%";
                    Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
                }
                label.Text = "下载完成";
                so.Close();
                st.Close();
            }
            catch (Exception)
            {
                label.Text = "下载失败，请手动下载并替换。";
                throw;
            }
        }

        void Extract7z(string filename, ProgressBar progressBar, Label label)
        {
            using var archive = ArchiveFactory.Open(filename);
            progressBar.Maximum = archive.Entries.Count();
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            label.Text = "正在解压……";
            foreach (var entry in archive.Entries)
            {
                if (!entry.IsDirectory)
                {
                    Console.WriteLine(entry.Key);
                    entry.WriteToDirectory(Application.StartupPath, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                }
                progressBar.Value++;
                label.Text = "已解压：" + ((int)((float)progressBar.Value / (float)archive.Entries.Count() * 100)).ToString() + "%";
                //Application.DoEvents();
            }
            label.Text = "解压完成。";
        }


    }
}
