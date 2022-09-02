using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashSinicizationTool
{
    public class GlobState
    {
        /// <summary>
        /// 启动时是否自动检查更新
        /// </summary>
        public static bool ConfAutoCheck = false;

        /// <summary>
        /// 是否存在更新
        /// </summary>
        public static bool HadAppUpdate = false;
        /// <summary>
        /// 新版本号
        /// </summary>
        public static string AppUpdateTag = "";
    }
}
