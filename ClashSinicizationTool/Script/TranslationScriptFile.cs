using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.IO;
using System.Collections;
using Ini;

namespace ClashSinicizationTool
{
    class TranslationScriptFile
    {
        //加载脚本
        public void LoadScript(string scriptFilePath, TextBox translationScriptText, TextBox logText)
        {
            //StreamReader reader = new StreamReader(scriptFilePath, Encoding.UTF8);
            //translationScriptText.Text = reader.ReadToEnd();
            //reader.Close();
            //translationScriptText.Lines = File.ReadAllLines(scriptFilePath, Encoding.UTF8);
            translationScriptText.Text = File.ReadAllText(scriptFilePath, Encoding.UTF8);
            translationScriptText.SelectionStart = translationScriptText.Text.Length;
            translationScriptText.ScrollToCaret();
            logText.AppendText("已加载翻译脚本 " + scriptFilePath + Environment.NewLine);
        }

        //保存脚本
        public void SaveScript(string scriptFilePath, TextBox translationScriptText, TextBox logText)
        {
            File.WriteAllText(scriptFilePath, translationScriptText.Text, Encoding.UTF8);
            logText.AppendText("已保存翻译脚本 " + scriptFilePath + Environment.NewLine);
        }

        //导入脚本列表
        public void LoadScriptList(ComboBox translationScriptFileName, TextBox logText, string iniPath)
        {
            IniList ini = new IniList();
            string[] lines = ini.GetSectionValue("Script Path", iniPath).ToArray();
            for (int i = 0; i < lines.Length; i++)
            {
                //不加载空行空行
                if (lines[i] != string.Empty)
                {
                    translationScriptFileName.Items.Add(lines[i]);
                }
            }
            foreach (string item in translationScriptFileName.Items)
            {
                if (File.Exists(item))
                {
                    translationScriptFileName.Text = item;
                    break;
                }
            }
        }

        //导入Clash目录文件
        public void LoadClashList(ComboBox clashPath, string iniPath)
        {
            IniList ini = new IniList();
            string[] lines = ini.GetSectionValue("Clash Path", iniPath).ToArray();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != string.Empty)
                {
                    clashPath.Items.Add(lines[i]);
                }
            }
            foreach (string item in clashPath.Items)
            {
                if (Directory.Exists(item))
                {
                    clashPath.Text = item;
                    break;
                }
            }
        }
    }
}
