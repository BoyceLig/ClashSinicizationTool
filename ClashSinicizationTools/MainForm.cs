using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;

namespace ClashSinicizationTools
{
    public partial class MainForm : Form
    {
        string scriptFilePath, clashPath;
        public MainForm()
        {
            InitializeComponent();
        }

        //加载时执行
        private void MainForm_Load(object sender, EventArgs e)
        {

        }



        //点击清理按钮时执行清空log窗口
        private void CleanLogButton_Click(object sender, EventArgs e)
        {
            logTextBox.Text = string.Empty;
        }

        private void openTranslationFileButton_Click(object sender, EventArgs e)
        {

        }

        //点击浏览翻译脚本文件查找脚本文件
        private void translationScriptBrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "请选择翻译脚本";
            openFileDialog.FileName = "英汉对照.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                scriptFilePath = openFileDialog.FileName;
                translationScriptPath.Text = scriptFilePath;
                StreamReader streamReader = new StreamReader(scriptFilePath, Encoding.UTF8);
                translationScriptText.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }

        //保存当前翻译脚本的修改
        private void saveTranslationScriptButton_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(scriptFilePath, false);
            streamWriter.WriteLine(translationScriptText.Text);
            streamWriter.Flush();
            streamWriter.Close();
        }

        //翻译脚本地址栏修改时执行
        private void translationScriptPath_TextChanged(object sender, EventArgs e)
        {
            if (translationScriptPath.Text == string.Empty)
            {
                //地址栏为空时，打开文件按钮失效
                openTranslationFileButton.Enabled = false;
                translationScriptText.Text = string.Empty;
            }
            else
            {
                //不为空时，打开文件按钮开启
                openTranslationFileButton.Enabled = true;
            }

            //地址栏修改时，把地址交给地址变量           
            if (File.Exists(translationScriptPath.Text))
            {
                scriptFilePath = translationScriptPath.Text;
                translationScriptPath.Text = scriptFilePath;
                StreamReader streamReader = new StreamReader(scriptFilePath, Encoding.UTF8);
                translationScriptText.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }


        }

        //自动检测翻译脚本位置（必须在当前目录）
        private void autoTranslationButton_Click(object sender, EventArgs e)
        {
            scriptFilePath = Directory.GetCurrentDirectory() + @"\" + translationScriptPath.Text;
            MessageBox.Show(scriptFilePath);
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
            StreamReader streamReader = new StreamReader(scriptFilePath, Encoding.UTF8);
            if (translationScriptText.Text == streamReader.ReadToEnd())
            {
                saveTranslationScriptButton.Enabled = false;
            }
            else
            {
                saveTranslationScriptButton.Enabled = true;
            }
            streamReader.Close();
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
