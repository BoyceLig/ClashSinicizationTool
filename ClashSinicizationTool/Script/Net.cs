using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashSinicizationTool
{
    class Net
    {
        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="path">文件存放地址，包含文件名</param>
        /// <returns></returns>
        public bool DownloadFile(string URL, string filename, ToolStripProgressBar progressBar, TextBox logBox)
        {
            float percent = 0;
            try
            {
                HttpWebRequest Myrq = (HttpWebRequest)HttpWebRequest.Create(URL);
                Myrq.Method = "GET";
                Myrq.Timeout = 3000;    //超时时间3S
                HttpWebResponse myrp = (HttpWebResponse)Myrq.GetResponse();
                if (myrp.StatusCode == HttpStatusCode.OK)
                {
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
                        //logBox.Text = "已下载：" + ((int)percent).ToString() + "%";
                        //Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
                    }
                    logBox.AppendText("下载完成" + Environment.NewLine);
                    so.Close();
                    st.Close();
                    progressBar.Value = 0;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                //logBox.Text = "下载失败，请手动下载并替换。";
                return false;
            }
        }

        public bool DownloadFile(string[] urls, string path, ToolStripProgressBar progressBar, TextBox logText)
        {
            for (int i = 0; i < urls.Length; i++)
            {
                if (DownloadFile(urls[i], path, progressBar, logText))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            logText.AppendText("下载失败，请重试！" + Environment.NewLine);
            return false;
        }
    }
}
