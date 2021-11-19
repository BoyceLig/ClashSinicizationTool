using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ClashSinicizationTool
{
    class CharacterReplacement
    {
        public void CharacterReplace(TextBox textBox, string filePath, TextBox logText)
        {
            //读取要被替换的文件
            StreamReader streamReader = new(filePath, Encoding.UTF8);
            string s = streamReader.ReadToEnd();
            streamReader.Close();

            //拆分替换文本
            for (int i = 0; i < textBox.Lines.Length; i++)
            {
                if (textBox.Lines[i].FirstOrDefault() != '#' && textBox.Lines[i] != string.Empty)
                {
                    string[] t = textBox.Lines[i].Split('=', 2, StringSplitOptions.None);
                    s = s.Replace(t[0], t[1]);
                }
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
