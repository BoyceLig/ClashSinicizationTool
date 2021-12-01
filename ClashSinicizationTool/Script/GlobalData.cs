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
        public struct FilePath
        {
            public const string iniFilePath = "PathList.ini";
            public const string momentFilePath = "moment-with-CN.js";
            public const string translationScriptFilePath = "翻译脚本.txt";
        }

        public struct DirectoryPath
        {
            public const string nodePath = "Node";
        }

        public struct IniSection
        {
            public const string scriptPath = "Script Path";
            public const string clashPath = "Clash Path";
            public const string delectPath = "Delect Path";
            public const string replacePath = "Replace Path";
        }

        public struct Url
        {
            public const string projectUrl = "https://github.com/BoyceLig/ClashSinicizationTool";
            public static readonly string[] translationScriptUrls =
                {
                "https://raw.githubusercontent.com/BoyceLig/Clash_Chinese_Patch/master/%E7%BF%BB%E8%AF%91%E8%84%9A%E6%9C%AC.txt",
                "https://github.boyce.workers.dev/raw.githubusercontent.com/BoyceLig/Clash_Chinese_Patch/master/%E7%BF%BB%E8%AF%91%E8%84%9A%E6%9C%AC.txt",
            };
        }

    }
}
