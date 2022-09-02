using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Threading;

namespace ClashSinicizationTool
{
    public partial class DownloadForm : Form
    {
        private readonly string appFileName;
        private readonly string downloadFile;
        private readonly string downloadUrl;
        private readonly string tempDir;
        private readonly CancellationTokenSource source;

        public DownloadForm(string tag)
        {
            InitializeComponent();

            this.appFileName = $"ClashSinicizationTool-{tag}.zip";
            this.downloadFile = Path.Combine(Application.StartupPath, this.appFileName);
            this.downloadUrl = $"https://github.com/BoyceLig/ClashSinicizationTool/releases/download/{tag}/ClashSinicizationTool-{tag}.zip";
            this.tempDir = Path.Combine(Path.GetTempPath(), "ClashSinicizationTool_temp");
            this.source = new CancellationTokenSource();

        }

        private void UpgradeMainForm_Load(object sender, EventArgs e)
        {
            this.PercentageLabel.Text = "0%";
            Downloading();
        }

        private async void Downloading()
        {
            if (File.Exists(downloadFile))
            {
                File.Delete(downloadFile);
            }

            CancellationToken token = this.source.Token;

            using (var client = new HttpClientDownloadWithProgress(downloadUrl, downloadFile, token))
            {
                client.ProgressChanged += (totalFileSize, totalBytesDownload, progressPercentage, isCompleted) =>
                {
                    if (totalFileSize != null)
                    {
                        this.UProgressBar.Maximum = (int)totalFileSize;
                    }

                    if (totalBytesDownload <= this.UProgressBar.Maximum)
                    {
                        this.UProgressBar.Value = (int)totalBytesDownload;
                    }

                    if (progressPercentage != null)
                    {
                        this.PercentageLabel.Text = progressPercentage.ToString() + "%";
                    }

                    if (isCompleted)
                    { //! ÏÂÔØÍê³É
                        if (Directory.Exists(tempDir))
                        {
                            Directory.Delete(tempDir, true);
                            Directory.CreateDirectory(tempDir);
                        }

                        if (File.Exists(downloadFile))
                        {
                            ZipFile.ExtractToDirectory(downloadFile, tempDir);
                            File.Delete(downloadFile);
                            string tempExe = Path.Combine(tempDir, @"ClashSinicizationTool\Upgrade.exe");
                            if (File.Exists(tempExe))
                            {
                                Process upApp = new Process();
                                upApp.StartInfo.FileName = tempExe;
                                upApp.StartInfo.Arguments = Directory.GetCurrentDirectory();
                                upApp.StartInfo.WorkingDirectory = tempDir;
                                upApp.Start();
                                upApp.Close();
                                client.Dispose();
                            }
                        }
                    }
                };

                await client.StartDownload();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (this.source != null)
            {
                this.source.Cancel();
                this.source.Dispose();
            }
            this.Close();
        }
    }
}