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
            #region 检查创建翻译脚本列表文件
            //检查创建列表文件
            if (!File.Exists("Script List.ini"))
            {
                //创建列表文件
                FileStream fileStream = new FileStream("Script List.ini", FileMode.CreateNew);
                fileStream.Close();
                logTextBox.AppendText("已生成脚本列表" + Environment.NewLine);
            }
            else
            {


                if (File.ReadAllText("Script List.ini") == string.Empty)
                {

                }
                else
                {
                    //加载列表文件
                    TranslationScriptFile translationScriptFile = new TranslationScriptFile();
                    translationScriptFile.LoadScriptList(translationScriptFileName, logTextBox, "Script List.ini");
                    //自动加载第一个文件
                    if (File.Exists(translationScriptFileName.Items[0].ToString()))
                    {
                        translationScriptFile.LoadScript(translationScriptFileName.Text, translationScriptText, logTextBox);
                        loadTranslationScriptButton.Enabled = true;
                        openTranslationFileButton.Enabled = true;
                    }
                }
            }

            #endregion

            #region 检查创建clash目录列表
            if (!File.Exists("Clash Path List.ini"))
            {
                FileStream fileStream = new FileStream("Clash Path List.ini", FileMode.CreateNew);
                fileStream.Close();
                logTextBox.AppendText("已生成Clash目录列表" + Environment.NewLine);
            }
            else
            {
                if (File.ReadAllText("Clash Path List.ini") == string.Empty)
                {

                }
                else
                {
                    TranslationScriptFile translationScriptFile = new TranslationScriptFile();
                    translationScriptFile.LoadClashList(clashForWindowsPath, logTextBox, "Clash Path List.ini");
                    openClashBrowseButton.Enabled = true;
                    clashPath = clashForWindowsPath.Text;
                }
            }
            #endregion
        }

        //软件关闭时
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //保存列表文件
            TranslationScriptFile translationScriptFile = new TranslationScriptFile();
            translationScriptFile.SaveListFile(translationScriptFileName, "Script List.ini");
            translationScriptFile.SaveListFile(clashForWindowsPath, "Clash Path List.ini");

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
            TranslationScriptFile translationScriptFile = new TranslationScriptFile();
            translationScriptFile.LoadScript(translationScriptFileName.Text, translationScriptText, logTextBox);

            //把文件名加载到列表
            //如果item没有值
            if (translationScriptFileName.Items.Count == 0)
            {
                //把文件名加载到列表
                translationScriptFileName.Items.Add(translationScriptFileName.Text);
            }
            else
            {
                //察看是否有重复名字
                for (int i = 0; i < translationScriptFileName.Items.Count; i++)
                {
                    if (translationScriptFileName.Text != translationScriptFileName.Items[i].ToString())
                    {
                        //把文件名加载到列表
                        translationScriptFileName.Items.Add(translationScriptFileName.Text);
                    }
                }
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
                if (clashForWindowsPath.Items.Count == 0)
                {
                    //把文件名加载到列表
                    clashForWindowsPath.Items.Add(clashForWindowsPath.Text);
                }
                else
                {
                    for (int i = 0; i < clashForWindowsPath.Items.Count; i++)
                    {
                        if (clashForWindowsPath.Text != clashForWindowsPath.Items[i].ToString())
                        {
                            clashForWindowsPath.Items.Add(clashForWindowsPath.Text);
                        }
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

        //解包
        private void unpackButton_Click(object sender, EventArgs e)
        {
            //备份文件
            File.Copy(clashPath + @"\resources\app.asar", clashPath + @"\resources\app.asar.bak", true);
            logTextBox.AppendText("app.asar文件备份成功，已备份到app.asar目录下的app.asar.bak文件" + Environment.NewLine);
            //解包命令
            CMDCommand command = new CMDCommand();
            command.Unpack(clashPath, logTextBox);
        }
        //自动清理失效目录和文件
        private void autoCleanButton_Click(object sender, EventArgs e)
        {
            TranslationScriptFile translationScriptFile = new TranslationScriptFile();
            translationScriptFile.CleanList(translationScriptFileName);
            translationScriptFile.CleanList(clashForWindowsPath);
            logTextBox.AppendText("清理列表成功" + Environment.NewLine);
        }

        //判定加载按钮和用外部程序打开按钮开关
        private void translationScriptFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (translationScriptFileName.Text == string.Empty)
            {
                loadTranslationScriptButton.Enabled = false;
                openTranslationFileButton.Enabled = false;
            }
            else
            {
                if (File.Exists(translationScriptFileName.Text))
                {
                    loadTranslationScriptButton.Enabled = true;
                    openTranslationFileButton.Enabled = true;
                }
                else
                {
                    loadTranslationScriptButton.Enabled = false;
                    openTranslationFileButton.Enabled = false;
                }
            }
        }

        private void clashForWindowsPath_TextUpdate(object sender, EventArgs e)
        {
            if (clashForWindowsPath.Text == string.Empty)
            {
                openClashBrowseButton.Enabled = false;
            }
            else
            {
                if (Directory.Exists(clashForWindowsPath.Text) && File.Exists(clashForWindowsPath.Text + @"\Clash for Windows.exe"))
                {
                    openClashBrowseButton.Enabled = true;
                    clashPath = clashForWindowsPath.Text;
                }
                else
                {
                    openClashBrowseButton.Enabled = false;
                }
            }
        }

        private void sinicizationButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(clashPath + @"\resources\app"))
            {
                
            }
            else
            {
                logTextBox.AppendText("尚未解包，已自动解包并汉化。" + Environment.NewLine);
                unpackButton_Click(sender, e);
                sinicizationButton_Click(sender, e);
            }
        }
    }
}
