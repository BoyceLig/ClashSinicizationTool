using System.CommandLine;
using System.Text;
using ClashSinicizationToolBase;

namespace ClashSinicizationToolCLI
{
    internal class Program
    {
        public static readonly string BackupOriginal = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Clash Sinicization Tool\backup_original";

        static void Main(string[] args)
        {
            var clashOpt = new Option<string>(new string[] { "--clash", "-c" }, "Clash for Windows 程序目录");
            var transScriptOpt = new Option<string>(new string[] { "--trans-script", "-t" }, "翻译脚本文件路径");
            var rootCmd = new RootCommand("Clash for Windows 汉化工具 CLI.");
            rootCmd.AddOption(clashOpt);
            rootCmd.AddOption(transScriptOpt);

            rootCmd.SetHandler((clash, transScript) =>
            {
                if (!string.IsNullOrEmpty(clash) && !string.IsNullOrEmpty(transScript))
                {
                    //检查文件是否存在
                    if (!File.Exists(GlobalData.FilePath.iniFilePath))
                    {
                        //创建替换索引路径文件
                        File.Create(GlobalData.FilePath.iniFilePath).Close();
                        File.WriteAllText(GlobalData.FilePath.iniFilePath, ClashSinicizationToolBase.Properties.Resources.PathList);
                    }

                    if (!File.Exists(GlobalData.FilePath.momentFilePath))
                    {
                        //创建翻译所需文件
                        File.Create(GlobalData.FilePath.momentFilePath).Close();
                        File.WriteAllText(GlobalData.FilePath.momentFilePath, ClashSinicizationToolBase.Properties.Resources.moment_with_CN);
                    }

                    bool unpackState = Unpack(clash);
                    if (unpackState)
                    {
                        bool sinicizationState = Sinicization(clash, transScript);
                        if (sinicizationState)
                        {
                            Pack(clash);
                        }
                    }
                }
            }, clashOpt, transScriptOpt);

            rootCmd.Invoke(args);
        }

        /// <summary>
        /// 解包
        /// </summary>
        /// <param name="clashPath"></param>
        /// <returns></returns>
        private static bool Unpack(string clashPath)
        {
            try
            {
                Directory.Delete(BackupOriginal, true);
                Directory.CreateDirectory(BackupOriginal);
            }
            catch { }

            string asarPath = Path.Combine(clashPath, @"resources\", "app.asar");
            if (File.Exists(asarPath))
            {
                if (!Directory.Exists(BackupOriginal))
                {
                    Directory.CreateDirectory(BackupOriginal);
                }
                //备份文件
                File.Copy(asarPath, Path.Combine(BackupOriginal, "app.asar"));
                Console.WriteLine($@"app.asar文件备份成功，已备份到{BackupOriginal}目录");

                //解包前检查app文件夹是否存在
                string appPath = Path.Combine(clashPath, @"resources\", @"app\");
                if (Directory.Exists(appPath))
                {
                    //已存在删除文件夹再执行解包
                    Directory.Delete(appPath, true);
                }

                //检查npm文件夹是否存在
                if (Directory.Exists(GlobalData.DirectoryPath.nodePath))
                {
                    //解包命令
                    CMDCommand command = new();
                    command.Unpack(clashPath);

                    if (Directory.Exists(appPath))
                    {
                        Console.WriteLine("解包完成，已生成app文件夹。");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("解包失败！但是不知道问题出在了哪里，请自行查找");
                    }
                }
                else
                {
                    Console.WriteLine("解包失败！npm文件夹检测不存在，请在TG群组求助");
                }
            }
            else
            {
                Console.WriteLine("解包失败！没有找到 app.asar 文件！");
            }
            return false;
        }

        /// <summary>
        /// 汉化
        /// </summary>
        /// <param name="clashPath"></param>
        /// <param name="scriptPath"></param>
        /// <returns></returns>
        private static bool Sinicization(string clashPath, string scriptPath)
        {
            string appPath = Path.Combine(clashPath, @"resources\", @"app\");
            if (Directory.Exists(appPath))
            {
                if (File.Exists("moment-with-CN.js"))
                {
                    if (File.ReadAllText(clashPath + @"\resources\app\dist\electron\main.js").Contains("退出"))
                    {
                        Console.WriteLine("您已汉化，不需要二次汉化");
                    }
                    else
                    {
                        //调取ini文件
                        IniList iniList = new IniList();
                        string[] replacePaths = iniList.GetSectionValue(GlobalData.IniSection.replacePath, GlobalData.FilePath.iniFilePath).ToArray();

                        //创建备份目录
                        if (!Directory.Exists(BackupOriginal))
                        {
                            Directory.CreateDirectory(BackupOriginal);
                        }

                        string[] transArr = LoadTranslationScript(scriptPath);
                        //备份
                        File.Copy(clashPath + @"\resources\app\node_modules\moment\moment.js", BackupOriginal + @"moment.js", true);
                        Console.WriteLine("已备份文件 " + clashPath + @"\resources\app\node_modules\moment\moment.js");
                        File.Copy("moment-with-CN.js", clashPath + @"\resources\app\node_modules\moment\moment.js", true);
                        Console.WriteLine("已替换文件 " + clashPath + @"\resources\app\node_modules\moment\moment.js");

                        CharacterReplacement characterReplacement = new(transArr);
                        for (int i = 0; i < replacePaths.Length; i++)
                        {
                            if (File.Exists(clashPath + replacePaths[i]))
                            {
                                string[] s = replacePaths[i].Split(@"\");
                                string fileName = s[^1];
                                File.Copy(clashPath + replacePaths[i], BackupOriginal + @"\" + fileName, true);
                                Console.WriteLine("已备份文件 " + clashPath + replacePaths[i]);
                                string resText = characterReplacement.CharacterReplace(clashPath + replacePaths[i]);
                            }
                            else
                            {
                                Console.WriteLine("被汉化文件不存在 " + clashPath + replacePaths[i]);
                            }
                        }
                        Console.WriteLine("汉化完成，执行下一步操作");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("moment-with-CN.js 文件不存在");
                }
            }
            else
            {
                Console.WriteLine("尚未解包，请按步骤操作");
            }
            return false;
        }

        /// <summary>
        /// 打包
        /// </summary>
        /// <param name="clashPath"></param>
        private static void Pack(string clashPath)
        {
            string appPath = Path.Combine(clashPath, @"resources\", @"app\");
            if (Directory.Exists(appPath))
            {
                string asarPath = Path.Combine(clashPath, @"resources\", "app.asar");
                if (File.Exists(asarPath))
                {
                    if (FileStatusHelper.IsFileOccupied(asarPath))
                    {
                        Console.WriteLine(asarPath + " 被占用，无法打包。");
                        return;
                    }
                }

                CMDCommand command = new();
                command.Pack(clashPath);
                try
                {
                    Directory.Delete(appPath, true);
                    Console.WriteLine("打包完成。已删除解包文件夹app。");
                }
                catch (Exception)
                {
                    Console.WriteLine($"打包完成。{appPath} 文件夹删除失败，有文件占用。");
                }
            }
            else
            {
                Console.WriteLine("尚未解包，请按步骤操作");
            }
        }

        /// <summary>
        /// 加载翻译脚本
        /// </summary>
        /// <param name="scriptPath"></param>
        /// <returns></returns>
        private static string[] LoadTranslationScript(string scriptPath)
        {
            if (File.Exists(scriptPath))
            {
                Console.WriteLine("加载翻译脚本：" + scriptPath);
                return File.ReadAllLines(scriptPath, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine("翻译脚本不存在！");
                return Array.Empty<string>();
            }
        }
    }
}