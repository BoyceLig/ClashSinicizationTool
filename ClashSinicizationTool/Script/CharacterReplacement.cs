using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ClashSinicizationTool
{
    class CharacterReplacement
    {
        public void CharacterReplace(RichTextBox textBox, string filePath, TextBox logText)
        {
            //读取要被替换的文件
            StreamReader streamReader = new(filePath, Encoding.UTF8);
            string s = streamReader.ReadToEnd();
            streamReader.Close();

            //拆分替换文本
            string transText = textBox.Text;
            string[] transArr = transText.Split('\n');
            int i = 0;
            foreach (string str in transArr)
            {
                if (!string.IsNullOrEmpty(str) && str.FirstOrDefault() != '#')
                {
                    if (str.Contains('='))
                    {
                        string[] t = str.Split('=', 2, StringSplitOptions.None);
                        s = s.Replace(t[0], t[1]);
                    }
                    else
                    {
                        logText.AppendText($"第{i + 1}行 ‘{str}’ 缺失‘=’，已跳过{Environment.NewLine}");
                    }
                }
                i++;
            }

            //保存替换后字段
            StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8);
            streamWriter.WriteLine(s);
            streamWriter.Flush();
            streamWriter.Close();
            logText.AppendText("已汉化文件 " + filePath + Environment.NewLine);
        }        
    }
}
