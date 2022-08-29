﻿namespace ClashSinicizationToolBase
{
    public class GlobalData
    {
        public const string clashProcessName = "Clash for Windows";
        public struct FilePath
        {
            public const string iniFilePath = "PathList.ini";
            public const string momentFilePath = "moment-with-CN.js";
            public const string translationScriptFilePath = "翻译脚本.txt";
        }

        public static class DirectoryPath
        {
            public static string nodePath = @$"{AppContext.BaseDirectory}\Node";
        }

        public struct IniSection
        {
            public const string scriptPath = "Script Path";
            public const string clashPath = "Clash Path";
            public const string replacePath = "Replace Path";
        }

        public struct Url
        {
            public const string projectUrl = "https://github.com/BoyceLig/ClashSinicizationTool";
            public static readonly string[] translationScriptUrls =
                {
                "https://raw.githubusercontent.com/BoyceLig/Clash_Chinese_Patch/main/翻译脚本.txt",
                "https://github.boyce.workers.dev/https://raw.githubusercontent.com/BoyceLig/Clash_Chinese_Patch/main/翻译脚本.txt",
            };
        }
    }
}
