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
    public partial class MainForm : Form
    {
        string clashPath;
        public MainForm()
        {
            InitializeComponent();
        }

        //加载时执行
        private void MainForm_Load(object sender, EventArgs e)
        {
            //检查创建列表文件
            if (!File.Exists("Script List.ini"))
            {
                FileStream fileStream = new FileStream("Script List.ini", FileMode.CreateNew);
                fileStream.Close();
                logTextBox.AppendText("已生成脚本列表" + Environment.NewLine);
            }
            else
            {
                TranslationScriptFile translationScriptFile = new TranslationScriptFile();
                translationScriptFile.LoadScriptList(translationScriptFileName, logTextBox, "Script List.ini");

                if (File.ReadAllText("Script List.ini") == string.Empty)
                {
                    logTextBox.AppendText("脚本列表为空，手动输入后自动记忆，下次打开自动加载。" + Environment.NewLine);
                }
            }
            //自动加载第一个文件
            if (translationScriptFileName.Text != string.Empty && File.Exists(translationScriptFileName.Text))
            {
                TranslationScriptFile translationScriptFile = new TranslationScriptFile();
                translationScriptFile.LoadScript(translationScriptFileName.Text, translationScriptText, logTextBox);
            }
        }



        //点击清理按钮时执行清空log窗口
        private void CleanLogButton_Click(object sender, EventArgs e)
        {
            logTextBox.Text = string.Empty;
        }

        //保存当前翻译脚本的修改
        private void saveTranslationScriptButton_Click(object sender, EventArgs e)
        {
            TranslationScriptFile translationScriptFile = new TranslationScriptFile();
            translationScriptFile.SaveScript(translationScriptFileName.Text, translationScriptText, logTextBox);
        }

        //自动检测翻译脚本位置（必须在当前目录）
        private void loadTranslationScriptButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\" + translationScriptFileName.Text))
            {
                translationScriptFileName.Text = Directory.GetCurrentDirectory() + @"\" + translationScriptFileName.Text;
                translationScriptFileName.Text = translationScriptFileName.Text;
                logTextBox.AppendText("已加载翻译脚本 " + translationScriptFileName.Text + Environment.NewLine);
            }
            else
            {
                logTextBox.AppendText("未检测到当前目录翻译脚本，请重新检查输入内容" + Environment.NewLine);
            }

        }

        //点击浏览文件夹并将path传递给clash path
        private void ClashBrowseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "请选择 Clash for Windows 根路径";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                clashPath = folderBrowserDialog.SelectedPath;
                clashForWindowsPath.Text = clashPath;
                for (int i = 0; i < clashForWindowsPath.Items.Count; i++)
                {
                    if (clashForWindowsPath.Text != clashForWindowsPath.Items[i].ToString())
                    {
                        clashForWindowsPath.Items.Add(clashForWindowsPath.Text);
                    }
                }
            }

        }

        //翻译脚本显示器修改时，检测与源文件匹配，控制保存开关
        private void translationScriptText_TextChanged(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader(translationScriptFileName.Text, Encoding.UTF8);
            if (translationScriptText.Text == streamReader.ReadToEnd())
            {
                saveTranslationScriptButton.Enabled = false;

            }
            else
            {
                saveTranslationScriptButton.Enabled = true;
            }
            streamReader.Close();

            if (translationScriptFileName.Text == string.Empty)
            {
                openTranslationFileButton.Enabled = false;
            }
            else
            {
                openTranslationFileButton.Enabled = true;
            }
        }

        //手动输入path
        private void clashForWindowsPath_TextUpdate(object sender, EventArgs e)
        {
            if (clashForWindowsPath.Text == string.Empty)
            {
                openClashBrowseButton.Enabled = false;
            }
            else
            {
                openClashBrowseButton.Enabled = true;
            }
        }

    }
}
