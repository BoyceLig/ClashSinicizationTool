using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashSinicizationTool
{
    class GlobalData
    {
        public const string clashProcessName = "Clash for Windows";
        public const string iniFilePath = "PathList.ini";
        public const string versionPath = "https://raw.githubusercontent.com/BoyceLig/ClashSinicizationTool/master/ClashSinicizationTool/Publish/Version.txt";
        public const string downloadUrlX64 = "https://github.com/BoyceLig/ClashSinicizationTool/raw/master/ClashSinicizationTool/Publish/Clash%20Sinicization%20Tool%20x64.7z";
        public const string downloadUrlX86 = "https://github.com/BoyceLig/ClashSinicizationTool/raw/master/ClashSinicizationTool/Publish/Clash%20Sinicization%20Tool%20x86.7z";
        public static readonly string[] cacheList = {
            "[Script Path]",
            "英汉对照.txt",
            "",
            "[Clash Path]",
            ""
        };
    }
}
