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
        public void CharacterReplace(TextBox textBox, string filePath)
        {
            //string[] newScript = new string[textBox.Lines.Length];
            //for (int i = 0; i < textBox.Lines.Length; i++)
            //{
            //    newScript[i] = textBox.Lines[i];
            //}

            //读取要被替换的文件
            StreamReader streamReader = new StreamReader(filePath);
            TextBox textBox1 = new TextBox();
            textBox1.Visible = false;
            textBox1.Multiline = true;
            textBox1.Text = streamReader.ReadToEnd();

            //拆分替换文本
            for (int i = 0; i < textBox.Lines.Length; i++)
            {
                if (textBox.Lines[i].FirstOrDefault() != '#')
                {
                    string[] t = Regex.Split(textBox.Lines[i], "=", RegexOptions.None);
                }
            }

            //开始替换
            for (int i = 0; i < textBox.Lines.Length; i++)
            {

            }
        }
    }
}
