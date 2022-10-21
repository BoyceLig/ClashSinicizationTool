namespace ClashSinicizationToolBase
{
    public class GlobalData
    {
        public const string clashProcessName = "Clash for Windows";
        public struct FilePath
        {
            public const string iniFilePath = "PathList.ini";
            public const string momentFilePath = "moment-with-CN.js";
            public const string translationScriptFilePath = "翻译脚本.txt";
            public const string configPath = "config.xml";
            public const string upgradeExePath = "Upgrade.exe";
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

        private static readonly List<string> SourceUrl = new List<string>
        {
            "https://raw.githubusercontent.com/BoyceLig/{repo}/main/{path}",
            "https://github.boyce.workers.dev/https://raw.githubusercontent.com/BoyceLig/{repo}/main/{path}",
            "https://gcore.jsdelivr.net/gh/BoyceLig/{repo}@main/{path}",
            "https://fastly.jsdelivr.net/gh/BoyceLig/{repo}@main/{path}",
            "https://testingcf.jsdelivr.net/gh/BoyceLig/{repo}@main/{path}",
            "https://raw.fastgit.org/BoyceLig/{repo}/main/{path}",
            "https://cdn.staticaly.com/gh/BoyceLig/{repo}/main/{path}"
        };

        private static string[] GetFileUrl(string repo, string filePath)
        {
            List<string> urlRes = new List<string>();
            foreach (string sUrl in SourceUrl)
            {
                urlRes.Add(sUrl.Replace("{repo}", repo).Replace("{path}", filePath));
            }
            return urlRes.ToArray();
        }

        public static class Url
        {
            public const string projectUrl = "https://github.com/BoyceLig/ClashSinicizationTool";
            public const string latestApiUrl = "https://api.github.com/repos/BoyceLig/ClashSinicizationTool/releases/latest";
            public const string m_TGNoticeBoardUrl = "https://t.me/ClashR_for_Windows_Channel";
            public const string m_TGDiscussionGroup = "https://t.me/+Se4RSc06w8QK1HiS";
            public static string[] translationScriptUrls = GetFileUrl("Clash_Chinese_Patch", "翻译脚本.txt");
        }
    }
}
