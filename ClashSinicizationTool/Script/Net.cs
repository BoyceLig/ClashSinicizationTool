using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace ClashSinicizationTool
{
    class Net
    {
        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="URL">下载文件地址</param>
        /// <param name="filename">文件存放地址，包含文件名</param>
        /// <returns></returns>
        public bool DownloadFile(string URL, string filename)
        {
            try
            {
                //创建文件流
                FileStream fileStream;
                HttpClient client = new HttpClient();
                //设置超时秒数
                client.Timeout = TimeSpan.FromSeconds(3);
                byte[] bytes = client.GetByteArrayAsync(URL).Result;
                //写入文件流
                fileStream = new FileStream(filename, FileMode.Create);
                fileStream.Write(bytes, 0, bytes.Length);
                //关闭文件流
                fileStream.Flush();
                fileStream.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DownloadFile(string[] urls, string path)
        {
            for (int i = 0; i < urls.Length; i++)
            {
                if (DownloadFile(urls[i], path))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
