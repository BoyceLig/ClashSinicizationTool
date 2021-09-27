using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.IO;

namespace ClashSinicizationTools
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
        public void LoadScriptList(ComboBox translationScriptPath, TextBox logText, string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                //不加载空行空行
                if (lines[i] != string.Empty)
                {
                    translationScriptPath.Items.Add(lines[i]);
                }
            }
            translationScriptPath.Text = translationScriptPath.Items[0].ToString();
            logText.AppendText("已加载脚本列表。如需删除某个文件名，请进入”Script List.ini“删除对应关键字" + Environment.NewLine);

            //删除空行，遍历修改文件
            if (translationScriptPath.Items.Count != lines.Length)
            {
                string[] newLines = new string[translationScriptPath.Items.Count];
                for (int i = 0; i < translationScriptPath.Items.Count; i++)
                {
                    newLines[i] = translationScriptPath.Items[i].ToString();
                }
                File.WriteAllLines(filePath, newLines);
                logText.AppendText("”Script List.ini“文件内有空行，已自动删除。" + Environment.NewLine);

            }
        }
    }
}
