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
    }
}
