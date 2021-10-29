using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ClashSinicizationTool
{
    public partial class MainForm : Form
    {
        public string clashPath;
        string clashProcessName = "Clash for Windows";
        public static MainForm mainForm;

        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
        }

        //加载时执行
        private void MainForm_Load(object sender, EventArgs e)
        {
            #region 标题
            //增加版本号标注
            if (Environment.Is64BitProcess)
            {
                //64位
                mainForm.Text = "Clash 汉化工具 " + " v" + Application.ProductVersion.ToString() + " 64-bit ";
            }
            else
            {
                //32位
                mainForm.Text = "Clash 汉化工具 " + " v" + Application.ProductVersion.ToString() + " 32-bit ";
            }
            #endregion

            #region 创建 Replace Path.ini文件
            if (!File.Exists("Replace Path.ini"))
            {
                FileStream fileStream = new FileStream("Replace Path.ini", FileMode.CreateNew);
                fileStream.Close();
                string[] replacePaths = new string[]
                {
                    @"\resources\app\dist\electron\renderer.js",
                    @"\resources\app\dist\electron\main.js",
                    @"\resources\app\node_modules\axios\lib\adapters\xhr.js",
                    @"\resources\app\node_modules\axios\dist\axios.js",
                    @"\resources\app\node_modules\axios\dist\axios.min.js",
                    @"\resources\app\node_modules\axios\dist\axios.map",
                    @"\resources\app\node_modules\axios\dist\axios.min.map"
                };
                File.WriteAllLines("Replace Path.ini", replacePaths, Encoding.UTF8);
            }
            #endregion

            #region 创建 Delect Path.ini文件
            if (!File.Exists("Delect Path.ini"))
            {
                FileStream fileStream = new FileStream("Delect Path.ini", FileMode.CreateNew);
                fileStream.Close();
                string[] delectPaths = new string[]
                {
                    @"\resources\app\dist\electron\static\files",
                    @"\resources\app\node_modules\moment\dist",
                    @"\resources\app\node_modules\moment\min",
                    @"\resources\app\node_modules\moment\src",
                    @"\resources\app\node_modules\moment\locale"
                };
                File.WriteAllLines("Delect Path.ini", delectPaths, Encoding.UTF8);
            }
            #endregion

            #region 检查创建翻译脚本列表文件
            //检查创建列表文件
            if (File.Exists("Script List.ini"))
            {
                if (File.ReadAllText("Script List.ini") != string.Empty)
                {
                    //加载列表文件
                    TranslationScriptFile translationScriptFile = new TranslationScriptFile();
                    translationScriptFile.LoadScriptList(translationScriptFileName, logTextBox, "Script List.ini");
                    //自动加载第一个文件
                    if (translationScriptFileName.Items.Count != 0)
                    {
                        if (File.Exists(translationScriptFileName.Items[0].ToString()))
                        {
                            translationScriptFile.LoadScript(translationScriptFileName.Text, translationScriptText, logTextBox);
                            loadTranslationScriptButton.Enabled = true;
                            openTranslationFileButton.Enabled = true;
                        }
                    }
                }
            }
            #endregion

            #region 检查创建clash目录列表
            if (File.Exists("Clash Path List.ini"))
            {
                if (File.ReadAllText("Clash Path List.ini") != string.Empty)
                {
                    TranslationScriptFile translationScriptFile = new TranslationScriptFile();
                    translationScriptFile.LoadClashList(clashForWindowsPath, logTextBox, "Clash Path List.ini");
                    openClashBrowseButton.Enabled = true;
                    clashPath = clashForWindowsPath.Text;
                }
            }
            #endregion           

            #region 解包……按钮使用权控制
            if (File.Exists(translationScriptFileName.Text) && Directory.Exists(clashPath))
            {
                unpackButton.Enabled = true;
                simplifyButton.Enabled = true;
                sinicizationButton.Enabled = true;
                packButton.Enabled = true;
                revertButton.Enabled = true;
            }
            #endregion
        }

        //软件关闭时执行
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //保存列表文件
            TranslationScriptFile translationScriptFile = new TranslationScriptFile();
            translationScriptFile.SaveListFile(translationScriptFileName, "Script List.ini");
            translationScriptFile.SaveListFile(clashForWindowsPath, "Clash Path List.ini");
        }

        #region 按钮
        //保存当前翻译脚本的修改
        private void saveTranslationScriptButton_Click(object sender, EventArgs e)
        {
            TranslationScriptFile translationScriptFile = new TranslationScriptFile();
            translationScriptFile.SaveScript(translationScriptFileName.Text, translationScriptText, logTextBox);
            saveTranslationScriptButton.Enabled = false;
        }

        //加载按钮
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
                openClashBrowseButton.Enabled = true;
                unpackButton.Enabled = true;
                simplifyButton.Enabled = true;
                sinicizationButton.Enabled = true;
                packButton.Enabled = true;
                revertButton.Enabled = true;
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

        //解包
        private void unpackButton_Click(object sender, EventArgs e)
        {
            //备份文件
            File.Copy(clashPath + @"\resources\app.asar", clashPath + @"\resources\app.asar.bak", true);
            logTextBox.AppendText("app.asar文件备份成功，已备份到app.asar目录下的app.asar.bak文件" + Environment.NewLine);

            //解包前检查app文件夹是否存在
            if (Directory.Exists(clashPath + @"\resources\app"))
            {
                //已存在删除文件夹再执行解包
                Directory.Delete(clashPath + @"\resources\app", true);
            }

            //检查npm文件夹是否存在
            if (Directory.Exists("npm"))
            {
                //解包命令
                CMDCommand command = new CMDCommand();
                command.Unpack(clashPath);
                if (Directory.Exists(clashPath + @"\resources\app"))
                {
                    logTextBox.AppendText("解包完成，已生成app文件夹，请继续汉化。" + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("解包失败！但是不知道问题出在了哪里，请自行查找");
                    logTextBox.AppendText("解包失败！但是不知道问题出在了哪里，请自行查找" + Environment.NewLine);
                }
            }
            else
            {
                MessageBox.Show("解包失败！npm文件夹检测不存在，请在TG群组求助");
                logTextBox.AppendText("解包失败！npm文件夹检测不存在，请在TG群组求助" + Environment.NewLine);
            }
        }

        //自动清理失效目录和文件
        private void autoCleanButton_Click(object sender, EventArgs e)
        {
            TranslationScriptFile translationScriptFile = new TranslationScriptFile();
            translationScriptFile.CleanList(translationScriptFileName);
            translationScriptFile.CleanList(clashForWindowsPath);
            logTextBox.AppendText("清理列表成功" + Environment.NewLine);
        }

        //汉化按钮
        private void sinicizationButton_Click(object sender, EventArgs e)
        {
            //调取ini文件
            string[] replacePaths = File.ReadAllLines("Replace Path.ini");
            if (File.ReadAllText(clashPath + @"\resources\app\dist\electron\main.js").Contains("退出"))
            {
                MessageBox.Show("您已汉化，不需要二次汉化");
                logTextBox.AppendText("您已汉化，不需要二次汉化" + Environment.NewLine);
            }
            else
            {
                if (Directory.Exists(clashPath + @"\resources\app"))
                {
                    if (File.Exists("moment-with-CN.js"))
                    {
                        File.Copy("moment-with-CN.js", clashPath + @"\resources\app\node_modules\moment\moment.js", true);
                        logTextBox.AppendText("已替换文件 " + clashPath + @"\resources\app\node_modules\moment\moment.js" + Environment.NewLine);
                        CharacterReplacement characterReplacement = new CharacterReplacement();
                        for (int i = 0; i < replacePaths.Length; i++)
                        {
                            if (File.Exists(clashPath + replacePaths[i]))
                            {
                                characterReplacement.CharacterReplace(translationScriptText, clashPath + replacePaths[i], logTextBox);
                            }
                            else
                            {
                                logTextBox.AppendText("被汉化文件不存在 " + clashPath + replacePaths[i] + Environment.NewLine);
                            }
                        }
                        logTextBox.AppendText("汉化完成，请执行下一步操作" + Environment.NewLine);
                    }
                    else
                    {
                        logTextBox.AppendText("moment-with-CN.js 文件不存在" + Environment.NewLine);
                    }
                }
                else
                {
                    logTextBox.AppendText("尚未解包，请按步骤操作" + Environment.NewLine);
                    MessageBox.Show("尚未解包，请按步骤操作");
                }
            }
        }

        //点击精简包时候
        private void simplifyButton_Click(object sender, EventArgs e)
        {
            //调取ini文件
            string[] delectPaths = File.ReadAllLines("Delect Path.ini");
            if (Directory.Exists(clashPath + @"\resources\app"))
            {
                for (int i = 0; i < delectPaths.Length; i++)
                {
                    if (Directory.Exists(clashPath + delectPaths[i]))
                    {
                        Directory.Delete(clashPath + delectPaths[i], true);
                        logTextBox.AppendText("已删除多余目录" + clashPath + delectPaths[i] + Environment.NewLine);
                    }
                    else
                    {
                        logTextBox.AppendText("目录不存在" + clashPath + delectPaths[i] + Environment.NewLine);
                    }
                }
                logTextBox.AppendText("精简完成，请执行下一步操作" + Environment.NewLine);
            }
            else
            {
                logTextBox.AppendText("尚未解包，请按步骤操作" + Environment.NewLine);
                MessageBox.Show("尚未解包，请按步骤操作");
            }
        }

        //打包app.asar
        private void packButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(clashPath + @"\resources\app"))
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.ProcessName == clashProcessName)
                    {
                        MessageBox.Show("Clash for Windows已开启，请关闭后重试。");
                        logTextBox.AppendText("Clash for Windows已开启，请关闭Clash for Windows后重试。" + Environment.NewLine);
                        goto c;
                    }
                }
                //打包命令
                CMDCommand command = new CMDCommand();
                command.Pack(clashPath);
                Directory.Delete(clashPath + @"\resources\app", true);
                logTextBox.AppendText("已删除解包文件夹app" + Environment.NewLine);
            }
            else
            {
                logTextBox.AppendText("尚未解包，请按步骤操作" + Environment.NewLine);
                MessageBox.Show("尚未解包，请按步骤操作");
            }
        c:;
        }

        //用外界程序打开脚本
        private void openTranslationFileButton_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = translationScriptFileName.Text;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        //打开文件夹目录
        private void openClashBrowseButton_Click(object sender, EventArgs e)
        {
            Process.Start("Explorer.exe", clashPath);
            logTextBox.AppendText("已打开Clash文件夹" + Environment.NewLine);
        }

        //还原按钮
        private void revertButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(clashPath + @"\resources\app.asar.bak"))
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.ProcessName == clashProcessName)
                    {
                        MessageBox.Show("Clash for Windows已开启，请关闭后重试。");
                        logTextBox.AppendText("Clash for Windows已开启，请关闭Clash for Windows后重试。" + Environment.NewLine);
                        goto c;
                    }
                }
                File.Move(clashPath + @"\resources\app.asar.bak", clashPath + @"\resources\app.asar", true);
                logTextBox.AppendText("已还原英文版" + Environment.NewLine);
            }
            else
            {
                logTextBox.AppendText("无法还原，" + clashPath + @"\resources\app.asar.bak" + "文件丢失,请下载原版自行替换app.asar。" + Environment.NewLine);
            }
        c:;
        }

        //打开clash按钮
        private void OpenClashButton_Click(object sender, EventArgs e)
        {
            foreach (Process vProc in Process.GetProcesses())
            {
                if (vProc.ProcessName == clashProcessName)
                {
                    logTextBox.AppendText(clashProcessName + " 已开启，无需重复开启" + Environment.NewLine);
                    MessageBox.Show(clashProcessName + " 已开启，无需重复开启");
                    goto c;
                }
            }
            if (Directory.Exists(clashPath + @"\resources\app"))
            {
                File.Delete(clashPath + @"\resources\app.asar");
                Process.Start(clashPath + @"\Clash for Windows.exe");
                logTextBox.AppendText("已打开Clash for Windows" + Environment.NewLine);
            }
            else
            {
                Process.Start(clashPath + @"\Clash for Windows.exe");
                logTextBox.AppendText("已打开Clash for Windows" + Environment.NewLine);
            }
        c:;
        }

        //关闭Clash按钮
        private void CloseClashButton_Click(object sender, EventArgs e)
        {
            Process last = Process.GetProcesses().Last();
            foreach (Process vProc in Process.GetProcesses())   //[BugHere]:请不要加.Exe后缀名称
            {
                if (vProc.ProcessName.ToUpper() == clashProcessName.ToUpper())
                {
                    try
                    {
                        vProc.Kill();
                        logTextBox.AppendText("已关闭程序 " + clashProcessName + Environment.NewLine);
                        ProxySetting proxy = new ProxySetting();
                        proxy.CloseProxy();
                        goto c;
                    }
                    catch (Exception)
                    {
                        logTextBox.AppendText("关闭 " + clashProcessName + " 失败，请手动关闭" + Environment.NewLine);
                        MessageBox.Show(clashProcessName + "关闭 " + clashProcessName + " 失败，请手动关闭");
                        goto c;
                        throw;
                    }
                }
            }
            logTextBox.AppendText(clashProcessName + " 未开启，无需关闭" + Environment.NewLine);
            MessageBox.Show(clashProcessName + " 未开启，无需关闭");
        c:;
        }

        #endregion

        #region Text检测
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

        //判定加载按钮和用外部程序打开按钮开关
        private void translationScriptFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (translationScriptFileName.Text == string.Empty)
            {
                loadTranslationScriptButton.Enabled = false;
                openTranslationFileButton.Enabled = false;
                unpackButton.Enabled = false;
                simplifyButton.Enabled = false;
                sinicizationButton.Enabled = false;
                packButton.Enabled = false;
                revertButton.Enabled = false;
            }
            else
            {
                if (File.Exists(translationScriptFileName.Text))
                {
                    loadTranslationScriptButton.Enabled = true;
                    openTranslationFileButton.Enabled = true;
                    unpackButton.Enabled = true;
                    simplifyButton.Enabled = true;
                    sinicizationButton.Enabled = true;
                    packButton.Enabled = true;
                    revertButton.Enabled = true;
                    foreach (string item in translationScriptFileName.Items)
                    {
                        if (item == translationScriptFileName.Text)
                        {
                            goto c;
                        }
                    }
                    translationScriptFileName.Items.Add(translationScriptFileName.Text);
                c:;
                }
                else
                {
                    loadTranslationScriptButton.Enabled = false;
                    openTranslationFileButton.Enabled = false;
                    unpackButton.Enabled = false;
                    simplifyButton.Enabled = false;
                    sinicizationButton.Enabled = false;
                    packButton.Enabled = false;
                    revertButton.Enabled = false;
                }
            }
        }

        //clash目录栏文字修改时候
        private void clashForWindowsPath_TextUpdate(object sender, EventArgs e)
        {
            if (clashForWindowsPath.Text == string.Empty)
            {
                openClashBrowseButton.Enabled = false;
                unpackButton.Enabled = false;
                simplifyButton.Enabled = false;
                sinicizationButton.Enabled = false;
                packButton.Enabled = false;
                revertButton.Enabled = false;
            }
            else
            {
                if (Directory.Exists(clashForWindowsPath.Text) && File.Exists(clashForWindowsPath.Text + @"\Clash for Windows.exe"))
                {
                    openClashBrowseButton.Enabled = true;
                    clashPath = clashForWindowsPath.Text;
                    unpackButton.Enabled = true;
                    simplifyButton.Enabled = true;
                    sinicizationButton.Enabled = true;
                    packButton.Enabled = true;
                    revertButton.Enabled = true;
                    foreach (string item in clashForWindowsPath.Items)
                    {
                        if (item == clashForWindowsPath.Text)
                        {
                            goto c;
                        }
                    }
                    clashForWindowsPath.Items.Add(clashForWindowsPath.Text);
                c:;
                }
                else
                {
                    openClashBrowseButton.Enabled = false;
                    unpackButton.Enabled = false;
                    simplifyButton.Enabled = false;
                    sinicizationButton.Enabled = false;
                    packButton.Enabled = false;
                    revertButton.Enabled = false;
                }
            }
        }

        #endregion

        //Ctrl+S快捷键
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (saveTranslationScriptButton.Enabled)
                {
                    saveTranslationScriptButton_Click(sender, e);
                }
                TranslationScriptFile translationScriptFile = new TranslationScriptFile();
                translationScriptFile.SaveListFile(translationScriptFileName, "Script List.ini");
                translationScriptFile.SaveListFile(clashForWindowsPath, "Clash Path List.ini");
                logTextBox.AppendText("已保存列表文件" + Environment.NewLine);
            }
        }

        #region log右键菜单
        //复制
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logTextBox.SelectedText != string.Empty)
            {
                Clipboard.SetDataObject(logTextBox.SelectedText);
            }
        }

        //清空log
        private void CleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logTextBox.Text = string.Empty;
        }
        #endregion
    }
}


