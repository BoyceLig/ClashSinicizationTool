using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.IO;
using System.Collections;

namespace ClashSinicizationTool
{
    class TranslationScriptFile
    {
        //加载脚本
        public void LoadScript(string scriptFilePath, TextBox translationScriptText, TextBox logText)
        {
            StreamReader streamReader = new StreamReader(scriptFilePath, Encoding.UTF8);
            translationScriptText.Text = streamReader.ReadToEnd();
            streamReader.Close();
            logText.AppendText("已加载翻译脚本 " + scriptFilePath + Environment.NewLine);
        }

        //保存脚本
        public void SaveScript(string scriptFilePath, TextBox translationScriptText, TextBox logText)
        {
            StreamWriter streamWriter = new StreamWriter(scriptFilePath, false);
            streamWriter.WriteLine(translationScriptText.Text);
            streamWriter.Flush();
            streamWriter.Close();
            logText.AppendText("已保存翻译脚本 " + scriptFilePath + Environment.NewLine);
        }

        //导入脚本列表
        public void LoadScriptList(ComboBox translationScriptFileName, TextBox logText, string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                //不加载空行空行
                if (lines[i] != string.Empty)
                {
                    translationScriptFileName.Items.Add(lines[i]);
                }
            }
            translationScriptFileName.Text = translationScriptFileName.Items[0].ToString();

            //删除空行，遍历修改文件
            if (translationScriptFileName.Items.Count != lines.Length)
            {
                string[] newLines = new string[translationScriptFileName.Items.Count];
                for (int i = 0; i < translationScriptFileName.Items.Count; i++)
                {
                    newLines[i] = translationScriptFileName.Items[i].ToString();
                }
                File.WriteAllLines(filePath, newLines);
                logText.AppendText("”Script List.ini“文件内有空行，已自动删除。" + Environment.NewLine);

            }
        }

        //导入Clash目录文件
        public void LoadClashList(ComboBox clashPath, TextBox logText, string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != string.Empty)
                {
                    clashPath.Items.Add(lines[i]);
                }
                //把第一个目录显示到列表
                clashPath.Text = clashPath.Items[0].ToString();
            }

            //删除空行，遍历修改文件
            if (clashPath.Items.Count != lines.Length)
            {
                string[] newLines = new string[clashPath.Items.Count];
                for (int i = 0; i < clashPath.Items.Count; i++)
                {
                    newLines[i] = clashPath.Items[i].ToString();
                }
                File.WriteAllLines(filePath, newLines);
                logText.AppendText("”Clash Path List.ini“文件内有空行，已自动删除。" + Environment.NewLine);
            }
        }

        //清理失效列表文件
        public void CleanList(ComboBox comboBox)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (!File.Exists(comboBox.Items[i].ToString()))
                {
                    comboBox.Items.Remove(comboBox.Items[i].ToString());
                }
            }
        }

        //保存列表文件
        public void SaveListFile(ComboBox comboBox, string filePath)
        {
            string[] newlines = new string[comboBox.Items.Count];
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                newlines[i] = comboBox.Items[i].ToString();
            }
            File.WriteAllLines(filePath, newlines);
        }
    }
}
