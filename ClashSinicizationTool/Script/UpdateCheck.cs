using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ClashSinicizationToolBase;
using Newtonsoft.Json;

namespace ClashSinicizationTool
{
    public class UpdateCheck
    {
        #region 事件
        public delegate void hasUp(object sender, bool isUpdate, bool isError);
        public event hasUp HasUpdated;

        protected virtual void OnHasUpdated(bool isU, bool isE)
        {
            HasUpdated?.Invoke(this, isU, isE);
        }
        #endregion

        #region 属性
        public string VersionValue { get; set; }
        public bool IsUpdate = false;
        public bool IsError = false;

        /// <summary>
        /// 版本格式
        /// </summary>
        private static readonly int[] Standard = new int[3] { 8, 4, 2 };

        private readonly string localVersion;
        private readonly ProductInfoHeaderValue productInfoHeaderValue;
        #endregion

        public UpdateCheck(string localVersion)
        {
            this.localVersion = localVersion;
            ProductHeaderValue header = new ProductHeaderValue("ClashSinicizationTool", localVersion);
            this.productInfoHeaderValue = new ProductInfoHeaderValue(header);
        }

        public override string ToString()
        {
            return VersionValue;
        }

        public async void UpdateChecking()
        {
            IsUpdate = false;
            IsError = false;
            try
            {
                Uri uri = new Uri(GlobalData.Url.latestApiUrl);
                HttpClient request = new HttpClient();
                request.DefaultRequestHeaders.UserAgent.Add(this.productInfoHeaderValue);
                request.Timeout = TimeSpan.FromSeconds(5);
                HttpResponseMessage response = await request.GetAsync(uri);
                string responseText = await response.Content.ReadAsStringAsync();
                LatestInfo info = JsonConvert.DeserializeObject<LatestInfo>(responseText.Trim());
                if (info != null && !string.IsNullOrEmpty(info.tag_name))
                {
                    string latestVersion = info.tag_name;
                    VersionValue = latestVersion;
                    // 对版本进行判断
                    if (CompareVer(localVersion, latestVersion))
                    {
                        IsUpdate = true;
                    }
                }
                else
                {
                    IsError = true;
                }
            }
            catch (Exception)
            {
                IsUpdate = false;
                IsError = true;
            }
            finally
            {
                OnHasUpdated(IsUpdate, IsError);
            }
        }

        /// <summary>
        /// 获取各个小版本号
        /// </summary>
        /// <param name="ver"></param>
        /// <returns></returns>
        private int[] SpliteVer(string ver)
        {
            var sp = ver.Split('.');
            if (sp.Length < 3)
            {
                return new int[3] { 1, 0, 0 };
            }
            var sv = new int[3];
            int.TryParse(sp[0], out sv[0]);
            int.TryParse(sp[1], out sv[1]);
            int.TryParse(sp[2], out sv[2]);
            return sv;
        }

        /// <summary>
        /// 比较版本是否有更新
        /// </summary>
        /// <param name="vL">本地版本</param>
        /// <param name="vN">网络版本</param>
        /// <returns>若 vN 大于 vL 则返回 ture</returns>
        private bool CompareVer(string vL, string vN)
        {
            var vLoc = SpliteVer(vL);
            var vNet = SpliteVer(vN);
            if (vNet[0] == -1) return false;
            int compare = 0;
            for (int index = 0; index < vLoc.Length; index++)
            {
                if (vNet[index] > vLoc[index])
                {
                    compare += Standard[index];
                }
                else if (vNet[index] < vLoc[index])
                {
                    compare -= Standard[index];
                }
            }
            return compare > 0;
        }
    }

    public class LatestInfo
    {
        public string url { get; set; }
        public string html_url { get; set; }
        public string id { get; set; }
        public string tag_name { get; set; }
        public string name { get; set; }
        public string created_at { get; set; }
        public string published_at { get; set; }
    }
}
