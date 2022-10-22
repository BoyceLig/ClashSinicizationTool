using ClashSinicizationToolBase;
using System.Text;

namespace ReplaceTool
{
    public class ReplaceScriptFile
    {
        //加载脚本
        public void LoadScript(string scriptFilePath, RichTextBox translationScriptText, TextBox logText)
        {
            if (File.Exists(scriptFilePath))
            {
                translationScriptText.Text = File.ReadAllText(scriptFilePath, Encoding.UTF8);
                translationScriptText.SelectionStart = translationScriptText.Text.Length;
                translationScriptText.ScrollToCaret();
                logText.AppendText("已加载替换脚本 " + scriptFilePath + Environment.NewLine);
            }
            else
            {
                logText.AppendText("替换脚本不存在" + Environment.NewLine);
            }

        }

        //保存脚本
        public void SaveScript(string scriptFilePath, RichTextBox translationScriptText, TextBox logText)
        {
            File.WriteAllText(scriptFilePath, translationScriptText.Text, Encoding.UTF8);
            logText.AppendText("已保存替换脚本 " + scriptFilePath + Environment.NewLine);
        }

        //导入脚本列表
        public void LoadScriptList(ComboBox translationScriptFileName, string iniPath, bool needExist = false)
        {
            IniList ini = new IniList();
            string[] lines = ini.GetSectionValue("Script Path", iniPath).ToArray();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                //不加载空行
                if (line != string.Empty)
                {
                    if (!needExist || File.Exists(line))
                    {
                        translationScriptFileName.Items.Add(line);
                    }
                }
            }

            if (translationScriptFileName.Items.Count > 0)
            {
                translationScriptFileName.Text = translationScriptFileName.Items[0].ToString();
            }
        }

        //导入Clash目录文件
        public void LoadReplaceFileList(ComboBox clashPath, string iniPath, bool needExist = false)
        {
            IniList ini = new IniList();
            string[] lines = ini.GetSectionValue(GlobalData.IniSection.replacePath, iniPath).ToArray();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (line != string.Empty)
                {
                    if (!needExist || File.Exists(line))
                    {
                        clashPath.Items.Add(line);
                    }
                }
            }

            if (clashPath.Items.Count > 0)
            {
                clashPath.Text = clashPath.Items[0].ToString();
            }
        }
    }
}
