using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashSinicizationTool
{
    class GlobalData
    {
        public struct FilePath
        {
            public const string iniFilePath = "PathList.ini";
            public const string momentFilePath = "moment-with-CN.js";
            public const string translationScriptFilePath = "翻译脚本.txt";
        }

        public struct IniSection
        {
            public const string scriptPath = "Script Path";
            public const string clashPath = "Clash Path";
            public const string delectPath = "Delect Path";
            public const string replacePath = "Replace Path";
        }
    }
}
