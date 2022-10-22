using System.Text;

namespace ClashSinicizationToolBase
{
    public class CharacterReplacement
    {
        private readonly string[] transArr;

        public CharacterReplacement(string[] transArr)
        {
            //拆分替换文本
            this.transArr = transArr;
        }

        public string CharacterReplace(string filePath)
        {
            //读取要被替换的文件
            StreamReader streamReader = new(filePath, Encoding.UTF8);
            string s = streamReader.ReadToEnd();
            streamReader.Close();

            string resText = string.Empty;
            int i = 0;
            foreach (string str in this.transArr)
            {
                if (!string.IsNullOrEmpty(str) && str.FirstOrDefault() != '#')
                {
                    if (str.Contains("==="))
                    {
                        string[] t = str.Split("===", 2, StringSplitOptions.None);
                        s = s.Replace(t[0], t[1]);
                    }
                    else if(str.Contains('='))
                    {
                        string[] t = str.Split('=', 2, StringSplitOptions.None);
                        s = s.Replace(t[0], t[1]);
                    }                   
                    else
                    {
                        resText += $"第{i + 1}行 ‘{str}’ 缺失‘=’，已跳过{Environment.NewLine}";
                    }
                }
                i++;
            }

            //保存替换后字段
            StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8);
            streamWriter.WriteLine(s);
            streamWriter.Flush();
            streamWriter.Close();
            resText += "已汉化文件 " + filePath + Environment.NewLine;
            return resText;
        }
    }
}
