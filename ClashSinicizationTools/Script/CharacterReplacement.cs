using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ClashSinicizationTools
{
    class CharacterReplacement
    {
        public void CharacterReplace(TextBox textBox, string filePath, TextBox logText)
        {
            //读取要被替换的文件
            StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8);
            string s = streamReader.ReadToEnd();
            streamReader.Close();

            //拆分替换文本
            for (int i = 0; i < textBox.Lines.Length; i++)
            {
                if (textBox.Lines[i].FirstOrDefault() != '#')
                {
                    string[] t = textBox.Lines[i].Split('=');
                    switch (t.Length)
                    {
                        //只有一个等号 en=zh
                        case 2:
                            s = s.Replace(t[0], t[1]);
                            break;
                        //有3个等号 en=0=zh=0
                        case 4:
                            s = s.Replace(t[0] + "=" + t[1], t[2] + "=" + t[3]);
                            break;
                        //有5个等号 en=a=0=zh=a=0
                        case 6:
                            s = s.Replace(t[0] + "=" + t[1] + "=" + t[2], t[3] + "=" + t[4] + "=" + t[5]);
                            break;
                        default:
                            break;
                    }
                }
            }

            //保存替换后字段
            StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8);
            streamWriter.WriteLine(s);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
