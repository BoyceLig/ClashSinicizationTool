using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClashSinicizationToolBase;

namespace ClashSinicizationTool
{
    public partial class MainForm : Form
    {
        private string clashPath;
        private readonly string cacheList = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Clash Sinicization Tool\CacheList.ini";
        private readonly string backup_original = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Clash Sinicization Tool\backup_original";
        Version currentVersion;

        public MainForm()
        {
            InitializeComponent();
        }

        //加载时执行
        private void MainForm_Load(object sender, EventArgs e)
        {
            #region 标题
            //增加版本号标注
            currentVersion = new Version(Application.ProductVersion.ToString());

            if (Environment.Is64BitProcess)
            {
                //64位
                Text = "Clash 汉化工具 " + " v" + currentVersion + " 64-bit ";
            }
            else
            {
                //32位
                Text = "Clash 汉化工具 " + " v" + currentVersion + " 32-bit ";
            }
            #endregion

            //自动选择字词关闭（面板关闭按钮失效）
            translationScriptRichTextBox.AutoWordSelection = false;
            timer.Start();
            //检查文件是否存在
            if (!File.Exists(GlobalData.FilePath.iniFilePath))
            {
                //创建替换索引路径文件
                File.Create(GlobalData.FilePath.iniFilePath).Close();
                File.WriteAllText(GlobalData.FilePath.iniFilePath, ClashSinicizationToolBase.Properties.Resources.PathList);
            }

            if (!File.Exists(GlobalData.FilePath.momentFilePath))
            {
                //创建翻译所需文件
                File.Create(GlobalData.FilePath.momentFilePath).Close();
                File.WriteAllText(GlobalData.FilePath.momentFilePath, ClashSinicizationToolBase.Properties.Resources.moment_with_CN);
            }

            TranslationScriptFile translationScriptFile = new TranslationScriptFile();

            #region 检查创建clash目录列表

            translationScriptFile.LoadClashList(clashForWindowsPath, cacheList);
            if (Directory.Exists(clashForWindowsPath.Text))
            {
                clashPath = clashForWindowsPath.Text;
            }

            #endregion

            #region 检查创建翻译脚本列表文件

            //检查创建列表文件
            if (!File.Exists(cacheList))
            {
                if (!Directory.Exists(cacheList.Replace(@"\CacheList.ini", string.Empty)))
                {
                    Directory.CreateDirectory(cacheList.Replace(@"\CacheList.ini", string.Empty));
                }
                //创建cacheList文件
                File.Create(cacheList).Close();
                File.WriteAllText(cacheList, ClashSinicizationToolBase.Properties.Resources.CacheList);
            }

            //加载列表文件
            translationScriptFile.LoadScriptList(translationScriptFileName, cacheList);
            //自动加载第一个文件
            if (translationScriptFileName.Items.Count != 0)
            {
                string curTransFile = translationScriptFileName.Items[0].ToString();
                if (File.Exists(curTransFile))
                {
                    translationScriptFile.LoadScript(curTransFile, translationScriptRichTextBox, logTextBox);
                    loadTranslationScriptButton.Enabled = true;
                    openTranslationFileButton.Enabled = true;
                    SetActionButtonState(true);
                }
                else if (curTransFile == GlobalData.FilePath.translationScriptFilePath)
                {
                    //显示等待下载操作提示
                    SetActionButtonState(false);
                    logTextBox.AppendText("目录下不存在翻译脚本文件，正在自动下载中，请耐心等待..." + Environment.NewLine);

                    File.Create(GlobalData.FilePath.translationScriptFilePath).Close();
                    using (BackgroundWorker bw = new BackgroundWorker())
                    {
                        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TransScriptDownload_RunWorkerCompleted);
                        bw.DoWork += new DoWorkEventHandler(TransScriptDownload_DoWork);
                        bw.RunWorkerAsync();
                    }
                }
            }
            #endregion

            #region 读取程序配置
            AppConfig.LoadConfig();
            GlobState.ConfAutoCheck = AppConfig.GetValue("AutoCheck") == "1";
            #endregion

            #region 启动时检查程序更新
            if (GlobState.ConfAutoCheck)
            {
                UpdateCheck UC = new UpdateCheck(Application.ProductVersion.ToString());
                UC.HasUpdated += UC_HasUpdated;
                Task task = Task.Run(() => UC.UpdateChecking());
                task.Wait(TimeSpan.FromSeconds(5));
            }
            #endregion
        }

        #region 按钮
        //保存当前翻译脚本的修改
        private void SaveTranslationScriptButton_Click(object sender, EventArgs e)
        {
            TranslationScriptFile translationScriptFile = new();
            translationScriptFile.SaveScript(translationScriptFileName.Text, translationScriptRichTextBox, logTextBox);
            saveTranslationScriptButton.Enabled = false;
        }

        //加载按钮
        private void LoadTranslationScriptButton_Click(object sender, EventArgs e)
        {
            TranslationScriptFile translationScriptFile = new();
            translationScriptFile.LoadScript(translationScriptFileName.Text, translationScriptRichTextBox, logTextBox);

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
                SetActionButtonState(true);
                if (clashForWindowsPath.Items.Count == 0)
                {
                    //把文件名加载到列表
                    clashForWindowsPath.Items.Add(clashForWindowsPath.Text);
                }
                else
                {
                    for (int i = 0; i < clashForWindowsPath.Items.Count; i++)
                    {
                        if (clashForWindowsPath.Text == clashForWindowsPath.Items[i].ToString())
                        {
                            return;
                        }
                    }
                    clashForWindowsPath.Items.Add(clashForWindowsPath.Text);
                    IniList ini = new();
                    ini.AddSectionValue(GlobalData.IniSection.clashPath, cacheList, clashForWindowsPath.Text);
                }
            }
        }

        //解包
        private void UnpackButton_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.Delete(backup_original, true);
                Directory.CreateDirectory(backup_original);
            }
            catch (Exception)
            {

            }
            if (File.Exists(clashPath + @"\resources\app.asar"))
            {
                if (!Directory.Exists(backup_original))
                {
                    Directory.CreateDirectory(backup_original);
                }
                //备份文件
                File.Copy(clashPath + @"\resources\app.asar", backup_original + @"\app.asar", true);
                logTextBox.AppendText($@"app.asar文件备份成功，已备份到{backup_original}目录" + Environment.NewLine);

                //解包前检查app文件夹是否存在
                if (Directory.Exists(clashPath + @"\resources\app"))
                {
                    //已存在删除文件夹再执行解包
                    Directory.Delete(clashPath + @"\resources\app", true);
                }

                //检查npm文件夹是否存在
                if (Directory.Exists(GlobalData.DirectoryPath.nodePath))
                {
                    SetActionButtonState(false);
                    //解包命令
                    using (BackgroundWorker bw = new BackgroundWorker())
                    {
                        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Unpack_RunWorkerCompleted);
                        bw.DoWork += new DoWorkEventHandler(Unpack_DoWork);
                        bw.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("解包失败！npm文件夹检测不存在，请在TG群组求助", "提示");
                    logTextBox.AppendText("解包失败！npm文件夹检测不存在，请在TG群组求助" + Environment.NewLine);
                }
            }
            else
            {
                if (Directory.Exists(clashPath + @"\resources\app"))
                {
                    MessageBox.Show("已解包，并且 app.asar 文件不存在", "提示");
                    logTextBox.AppendText("已解包，并且 app.asar 文件不存在" + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("app.asar 文件不存在", "提示");
                    logTextBox.AppendText("app.asar 文件不存在" + Environment.NewLine);
                }
            }
        }

        //自动清理失效目录和文件
        private void AutoCleanButton_Click(object sender, EventArgs e)
        {
            IniList ini = new();
            ini.CleanSectionValue(GlobalData.IniSection.scriptPath, cacheList);
            ini.CleanSectionValue(GlobalData.IniSection.clashPath, cacheList);
            translationScriptFileName.Items.Clear();
            translationScriptFileName.Text = string.Empty;
            clashForWindowsPath.Items.Clear();
            clashForWindowsPath.Text = string.Empty;

            TranslationScriptFile translationScriptFile = new();

            translationScriptFile.LoadClashList(clashForWindowsPath, cacheList, true);
            for (int i = 0; i < clashForWindowsPath.Items.Count; i++)
            {
                ini.AddSectionValue(GlobalData.IniSection.clashPath, cacheList, clashForWindowsPath.Items[i].ToString());
            }
            if (Directory.Exists(clashForWindowsPath.Text))
            {
                openClashBrowseButton.Enabled = true;
                clashPath = clashForWindowsPath.Text;
            }

            translationScriptFile.LoadScriptList(translationScriptFileName, cacheList, true);
            for (int i = 0; i < translationScriptFileName.Items.Count; i++)
            {
                ini.AddSectionValue(GlobalData.IniSection.scriptPath, cacheList, translationScriptFileName.Items[i].ToString());
            }
            if (File.Exists(translationScriptFileName.Text) && Directory.Exists(clashPath))
            {
                openClashBrowseButton.Enabled = true;
                clashPath = clashForWindowsPath.Text;
                SetActionButtonState(true);
            }

            logTextBox.AppendText("清理列表成功" + Environment.NewLine);
        }

        //汉化按钮
        private void SinicizationButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(clashPath + @"\resources\app"))
            {
                if (File.Exists("moment-with-CN.js"))
                {
                    if (File.ReadAllText(clashPath + @"\resources\app\dist\electron\main.js").Contains("退出"))
                    {
                        MessageBox.Show("您已汉化，不需要二次汉化", "提示");
                        logTextBox.AppendText("您已汉化，不需要二次汉化" + Environment.NewLine);
                    }
                    else
                    {
                        SetActionButtonState(false);
                        string transText = translationScriptRichTextBox.Text;
                        using (BackgroundWorker bw = new BackgroundWorker())
                        {
                            bw.WorkerReportsProgress = true;
                            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Trans_RunWorkerCompleted);
                            bw.ProgressChanged += new ProgressChangedEventHandler(Trans_ProgressChanged);
                            bw.DoWork += new DoWorkEventHandler(Trans_DoWork);
                            bw.RunWorkerAsync(transText);
                        }
                    }
                }
                else
                {
                    logTextBox.AppendText("moment-with-CN.js 文件不存在" + Environment.NewLine);
                }
            }
            else
            {
                logTextBox.AppendText("尚未解包，请按步骤操作" + Environment.NewLine);
                MessageBox.Show("尚未解包，请按步骤操作", "提示");
            }

        }

        //打包app.asar
        private void PackButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(clashPath + @"\resources\app"))
            {
                if (File.Exists(clashPath + @"\resources\app.asar"))
                {
                    if (FileStatusHelper.IsFileOccupied(clashPath + @"\resources\app.asar"))
                    {
                        MessageBox.Show(clashPath + @"\resources\app.asar被占用，无法打包。", "提示");
                        logTextBox.AppendText(clashPath + @"\resources\app.asar被占用，无法打包。" + Environment.NewLine);
                        return;
                    }
                }

                SetActionButtonState(false);
                using (BackgroundWorker bw = new BackgroundWorker())
                {
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Pack_RunWorkerCompleted);
                    bw.DoWork += new DoWorkEventHandler(Pack_DoWork);
                    bw.RunWorkerAsync();
                }
            }
            else
            {
                logTextBox.AppendText("尚未解包，请按步骤操作" + Environment.NewLine);
                MessageBox.Show("尚未解包，请按步骤操作", "提示");
            }
        }

        //用外界程序打开脚本
        private void OpenTranslationFileButton_Click(object sender, EventArgs e)
        {
            Process process = new();
            process.StartInfo.FileName = translationScriptFileName.Text;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        //打开文件夹目录
        private void OpenClashBrowseButton_Click(object sender, EventArgs e)
        {
            Process.Start("Explorer.exe", clashPath);
            logTextBox.AppendText("已打开Clash文件夹" + Environment.NewLine);
        }

        //还原按钮
        private void RevertButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(clashPath + @"\resources\app"))
            {
                if (!File.ReadAllText(clashPath + @"\resources\app\dist\electron\main.js").Contains("退出"))
                {
                    MessageBox.Show("当前已经是英文版，不需要还原", "提示");
                    logTextBox.AppendText("当前已经是英文版，不需要还原" + Environment.NewLine);
                }
                else
                {
                    SetActionButtonState(false);
                    using (BackgroundWorker bw = new BackgroundWorker())
                    {
                        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Revert_RunWorkerCompleted);
                        bw.DoWork += new DoWorkEventHandler(Revert_DoWork);
                        bw.RunWorkerAsync();
                    }
                }
            }
            else if (File.Exists(backup_original + @"\app.asar"))
            {
                if (FileStatusHelper.IsFileOccupied(clashPath + @"\resources\app.asar"))
                {
                    logTextBox.AppendText(clashPath + @"\resources\app.asar被占用，无法还原。" + Environment.NewLine);
                    MessageBox.Show(clashPath + @"\resources\app.asar被占用，无法还原。", "提示");
                    return;
                }

                try
                {
                    File.Delete(clashPath + @"\resources\app.asar");
                    try
                    {
                        File.Move(backup_original + @"\app.asar", clashPath + @"\resources\app.asar", true);
                        logTextBox.AppendText("已还原英文版" + Environment.NewLine);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(backup_original + @"\app.asar 文件被占用，无法还原。", "提示");
                        logTextBox.AppendText(backup_original + @"\app.asar 文件被占用，无法还原。" + Environment.NewLine);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(clashPath + @"\resources\app.asar 文件被占用，无法还原。", "提示");
                    logTextBox.AppendText(clashPath + @"\resources\app.asar 文件被占用，无法还原。" + Environment.NewLine);
                }
            }
            else
            {
                MessageBox.Show($@"无法还原，{backup_original}\app.asar 文件丢失,请下载原版自行替换app.asar。", "提示");
                logTextBox.AppendText($@"无法还原，{backup_original}\app.asar 文件丢失,请下载原版自行替换app.asar。" + Environment.NewLine);
            }
        }

        //打开clash按钮
        private void OpenClashButton_Click(object sender, EventArgs e)
        {
            foreach (Process vProc in Process.GetProcesses())
            {
                if (vProc.ProcessName == GlobalData.clashProcessName)
                {
                    logTextBox.AppendText(GlobalData.clashProcessName + " 已开启，无需重复开启" + Environment.NewLine);
                    MessageBox.Show(GlobalData.clashProcessName + " 已开启，无需重复开启", "提示");
                    return;
                }
            }
            if (Directory.Exists(clashPath + @"\resources\app"))
            {
                try
                {
                    File.Delete(clashPath + @"\resources\app.asar");
                    Process.Start(clashPath + @"\Clash for Windows.exe");
                    logTextBox.AppendText("已打开Clash for Windows" + Environment.NewLine);
                }
                catch (Exception)
                {
                    MessageBox.Show("app.asar被占用，删除失败。", "提示");
                    logTextBox.AppendText("app.asar被占用，删除失败。" + Environment.NewLine);
                }

            }
            else
            {
                Process.Start(clashPath + @"\Clash for Windows.exe");
                logTextBox.AppendText("已打开Clash for Windows" + Environment.NewLine);
            }
        }

        //关闭Clash按钮
        private void CloseClashButton_Click(object sender, EventArgs e)
        {
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CloseClash_RunWorkerCompleted);
                bw.DoWork += new DoWorkEventHandler(CloseClash_DoWork);
                bw.RunWorkerAsync();
            }
        }

        //自动检测clash地址
        private void AutoCkeckClashPathButton_Click(object sender, EventArgs e)
        {
            foreach (Process vProc in Process.GetProcesses())
            {
                if (vProc.ProcessName.ToUpper() == GlobalData.clashProcessName.ToUpper())
                {
                    clashPath = vProc.MainModule.FileName.Replace(@"\Clash for Windows.exe", "");
                    clashForWindowsPath.Text = clashPath;
                    openClashBrowseButton.Enabled = true;
                    SetActionButtonState(true);

                    try
                    {
                        vProc.Kill();
                        logTextBox.AppendText("已关闭程序 " + GlobalData.clashProcessName + Environment.NewLine);
                        ProxySetting proxy = new();
                        proxy.CloseProxy();
                    }
                    catch (Exception)
                    {
                        logTextBox.AppendText("关闭 " + GlobalData.clashProcessName + " 失败，请手动关闭" + Environment.NewLine);
                        MessageBox.Show(GlobalData.clashProcessName + "关闭 " + GlobalData.clashProcessName + " 失败，请手动关闭", "提示");
                        throw;
                    }

                    if (clashForWindowsPath.Items.Count == 0)
                    {
                        //把文件名加载到列表
                        clashForWindowsPath.Items.Add(clashForWindowsPath.Text);
                        IniList ini = new();
                        ini.AddSectionValue(GlobalData.IniSection.clashPath, cacheList, clashForWindowsPath.Text);
                    }
                    else
                    {
                        for (int i = 0; i < clashForWindowsPath.Items.Count; i++)
                        {
                            if (clashForWindowsPath.Text == clashForWindowsPath.Items[i].ToString())
                            {
                                return;
                            }
                        }
                        clashForWindowsPath.Items.Add(clashForWindowsPath.Text);
                        IniList ini = new();
                        ini.AddSectionValue(GlobalData.IniSection.clashPath, cacheList, clashForWindowsPath.Text);
                    }
                    logTextBox.AppendText("已加载地址" + clashPath + Environment.NewLine);
                    return;
                }
            }
            logTextBox.AppendText(GlobalData.clashProcessName + " 未开启 Clash for Windows ，请打开 Clash for Windows 后重试" + Environment.NewLine);
            MessageBox.Show(GlobalData.clashProcessName + " 未开启 Clash for Windows ，请打开 Clash for Windows 后重试", "提示");
        }

        //从云端更新脚本文件
        private void UpdateTranslationScriptButton_Click(object sender, EventArgs e)
        {
            //显示等待下载操作提示
            logTextBox.AppendText("正在下载更新翻译脚本文件，请耐心等待..." + Environment.NewLine);
            SetActionButtonState(false);

            if (!File.Exists(GlobalData.FilePath.translationScriptFilePath))
            {
                File.Create(GlobalData.FilePath.translationScriptFilePath).Close();
            }
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TransScriptDownload_RunWorkerCompleted);
                bw.DoWork += new DoWorkEventHandler(TransScriptDownload_DoWork);
                bw.RunWorkerAsync();
            }
        }

        //查找和替换
        private void findReplaceButton_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "查找和替换")
                {
                    f.Activate();
                    return;
                }
            }
            FindAndReplaceForm findAndReplaceForm = new FindAndReplaceForm(this);
            findAndReplaceForm.StartPosition = FormStartPosition.CenterScreen;
            findAndReplaceForm.Show();
        }

        //检查翻译脚本完整性
        private void checkTranslationScriptButton_Click(object sender, EventArgs e)
        {
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Minimum = 0;
            toolStripProgressBar.Maximum = translationScriptRichTextBox.Lines.Length;
            for (int i = 0; i < translationScriptRichTextBox.Lines.Length; i++)
            {
                if (!translationScriptRichTextBox.Lines[i].StartsWith("#") && translationScriptRichTextBox.Lines[i] != string.Empty)
                {
                    if (!translationScriptRichTextBox.Lines[i].Contains('='))
                    {
                        logTextBox.AppendText($"第{i + 1}行 ‘{translationScriptRichTextBox.Lines[i]}’ 缺失‘=’" + Environment.NewLine);
                    }
                }
                toolStripProgressBar.Value += 1;
            }
            toolStripProgressBar.Value = 0;
            MessageBox.Show("翻译脚本检查已完成，结果已打印到log界面", "提示");
            logTextBox.AppendText("翻译脚本检查已完成" + Environment.NewLine);
        }
        #endregion

        #region Text检测
        //翻译脚本显示器修改时，检测与源文件匹配，控制保存开关
        private void TranslationScriptText_TextChanged(object sender, EventArgs e)
        {
            StreamReader streamReader = new(translationScriptFileName.Text, Encoding.UTF8);
            if (translationScriptRichTextBox.Text == streamReader.ReadToEnd())
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
        private void TranslationScriptFileName_TextChanged(object sender, EventArgs e)
        {
            if (translationScriptFileName.Text == string.Empty)
            {
                loadTranslationScriptButton.Enabled = false;
                openTranslationFileButton.Enabled = false;
                SetActionButtonState(false);
            }
            else
            {
                if (File.Exists(translationScriptFileName.Text))
                {
                    loadTranslationScriptButton.Enabled = true;
                    openTranslationFileButton.Enabled = true;
                    SetActionButtonState(true);
                    foreach (string item in translationScriptFileName.Items)
                    {
                        if (item == translationScriptFileName.Text)
                        {
                            return;
                        }
                    }
                    translationScriptFileName.Items.Add(translationScriptFileName.Text);
                    IniList ini = new();
                    ini.AddSectionValue(GlobalData.IniSection.scriptPath, cacheList, translationScriptFileName.Text);
                }
                else
                {
                    loadTranslationScriptButton.Enabled = false;
                    openTranslationFileButton.Enabled = false;
                    SetActionButtonState(false);
                }
            }
        }

        //clash目录栏文字修改时以及选择项目时
        private void ClashForWindowsPath_TextUpdate(object sender, EventArgs e)
        {
            if (clashForWindowsPath.Text == string.Empty)
            {
                openClashBrowseButton.Enabled = false;
                SetActionButtonState(false);
            }
            else
            {
                if (Directory.Exists(clashForWindowsPath.Text) && File.Exists(clashForWindowsPath.Text + @"\Clash for Windows.exe"))
                {
                    openClashBrowseButton.Enabled = true;
                    clashPath = clashForWindowsPath.Text;

                    #region 解包……按钮使用权控制
                    if (File.Exists(translationScriptFileName.Text))
                    {
                        SetActionButtonState(true);
                    }
                    #endregion

                    foreach (string item in clashForWindowsPath.Items)
                    {
                        if (item == clashForWindowsPath.Text)
                        {
                            return;
                        }
                    }
                    clashForWindowsPath.Items.Add(clashForWindowsPath.Text);
                    IniList ini = new();
                    ini.AddSectionValue(GlobalData.IniSection.clashPath, cacheList, clashForWindowsPath.Text);
                }
                else
                {
                    openClashBrowseButton.Enabled = false;
                    SetActionButtonState(false);
                }
            }
        }

        #endregion

        //快捷键
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //保存快捷键
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (saveTranslationScriptButton.Enabled)
                {
                    SaveTranslationScriptButton_Click(sender, e);
                }
            }

            //替换和查找快捷键
            if ((e.KeyCode == Keys.F && e.Control) || (e.KeyCode == Keys.H && e.Control))
            {
                findReplaceButton_Click(sender, e);
            }
        }

        #region log右键菜单
        //复制
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logTextBox.SelectedText != string.Empty)
            {
                logTextBox.Copy();
            }
        }

        //清空log
        private void CleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logTextBox.Text = string.Empty;
        }
        #endregion

        //GitHub链接点击进入
        private void GithubToolStripStatusLabel_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", GlobalData.Url.projectUrl);
        }

        #region 脚本编辑器右键菜单
        private void translationScriptRichTextBoxMenuStripCopy_Click(object sender, EventArgs e)
        {
            if (translationScriptRichTextBox.SelectedText != string.Empty)
            {
                translationScriptRichTextBox.Copy();
            }
        }

        private void translationScriptRichTextBoxMenuStripCut_Click(object sender, EventArgs e)
        {
            if (translationScriptRichTextBox.SelectedText != string.Empty)
            {
                translationScriptRichTextBox.Cut();
            }
        }

        private void translationScriptRichTextBoxMenuStripPaste_Click(object sender, EventArgs e)
        {
            translationScriptRichTextBox.Paste();
        }

        private void translationScriptRichTextBoxMenuStripUndo_Click(object sender, EventArgs e)
        {
            translationScriptRichTextBox.Undo();
        }

        #endregion

        //检测复制、撤销和粘贴按钮是否可用
        private void translationScriptRichTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (translationScriptRichTextBox.SelectedText == string.Empty)
            {
                translationScriptRichTextBoxMenuStripCopy.Enabled = false;
                translationScriptRichTextBoxMenuStripCut.Enabled = false;
            }
            else
            {
                translationScriptRichTextBoxMenuStripCopy.Enabled = true;
                translationScriptRichTextBoxMenuStripCut.Enabled = true;
            }
            if (translationScriptRichTextBox.CanUndo)
            {
                translationScriptRichTextBoxMenuStripUndo.Enabled = true;
            }
            else
            {
                translationScriptRichTextBoxMenuStripUndo.Enabled = false;
            }
            if (Clipboard.GetText() == string.Empty)
            {
                translationScriptRichTextBoxMenuStripPaste.Enabled = false;
            }
            else
            {
                translationScriptRichTextBoxMenuStripPaste.Enabled = true;
            }
        }

        //检测log的右键按钮是否可用
        private void logTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (logTextBox.Text == string.Empty)
            {
                CleanToolStripMenuItem.Enabled = false;
            }
            else
            {
                CleanToolStripMenuItem.Enabled = true;
            }
            if (logTextBox.SelectedText == string.Empty)
            {
                CopyToolStripMenuItem.Enabled = false;
            }
            else
            {
                CopyToolStripMenuItem.Enabled = true;
            }
        }

        private void jumpLineButton_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "跳转到行")
                {
                    f.Activate();
                    return;
                }
            }
            JumpLineForm jumpLineForm = new JumpLineForm(this);
            jumpLineForm.StartPosition = FormStartPosition.CenterScreen;
            jumpLineForm.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"行 {(1 + translationScriptRichTextBox.GetLineFromCharIndex(translationScriptRichTextBox.SelectionStart)).ToString()}，列{(1 + translationScriptRichTextBox.SelectionStart - (translationScriptRichTextBox.GetFirstCharIndexFromLine(1 + translationScriptRichTextBox.GetLineFromCharIndex(translationScriptRichTextBox.SelectionStart) - 1))).ToString()}";
        }

        /// <summary>
        /// 检查更新按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckUpdateButton_Click(object sender, EventArgs e)
        {
            UpgradeForm up = new UpgradeForm(this);
            up.ShowDialog();
        }

        #region 按钮状态
        /// <summary>
        /// 设置汉化操作四个按钮的状态
        /// </summary>
        /// <param name="state">需要设定的 Enabled 值</param>
        private void SetActionButtonState(bool state)
        {
            unpackButton.Enabled = state;
            sinicizationButton.Enabled = state;
            packButton.Enabled = state;
            revertButton.Enabled = state;
        }
        #endregion

        #region 操作方法
        /// <summary>
        /// 关闭 Clash for Windows 程序
        /// </summary>
        /// <returns>结果消息</returns>
        private string CloseClash()
        {
            foreach (Process vProc in Process.GetProcesses())   //[BugHere]:请不要加.Exe后缀名称
            {
                if (vProc.ProcessName.ToUpper() == GlobalData.clashProcessName.ToUpper())
                {
                    try
                    {
                        vProc.Kill();
                        vProc.WaitForExit();
                        ProxySetting proxy = new();
                        proxy.CloseProxy();
                        return "已关闭程序 " + GlobalData.clashProcessName;
                    }
                    catch (Exception)
                    {
                        return "关闭 " + GlobalData.clashProcessName + " 失败，请手动关闭";
                    }
                }
            }
            return GlobalData.clashProcessName + " 未开启，无需关闭";
        }

        /// <summary>
        /// 后台关闭 Clash 工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseClash_DoWork(object sender, DoWorkEventArgs e)
        {
            string message = CloseClash();
            e.Result = e.Argument + message;
        }

        private void CloseClash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string resText = e.Result.ToString();
            logTextBox.AppendText(resText + Environment.NewLine);
            if (resText.Contains("失败") || resText.Contains("未开启"))
            {
                MessageBox.Show(resText, "提示");
            }
        }

        /// <summary>
        /// 后台解包工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Unpack_DoWork(object sender, DoWorkEventArgs e)
        {
            CMDCommand command = new();
            command.Unpack(clashPath);
        }

        private void Unpack_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Directory.Exists(clashPath + @"\resources\app"))
            {
                logTextBox.AppendText("解包完成，已生成app文件夹，请继续汉化。" + Environment.NewLine);
            }
            else
            {
                logTextBox.AppendText("解包失败！但是不知道问题出在了哪里，请自行查找" + Environment.NewLine);
                MessageBox.Show("解包失败！但是不知道问题出在了哪里，请自行查找", "提示");
            }
            SetActionButtonState(true);
        }

        /// <summary>
        /// 后台汉化工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Trans_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string transText = e.Argument.ToString();
            string[] transArr = transText.Split('\n');

            //调取ini文件
            IniList iniList = new();
            string[] replacePaths = iniList.GetSectionValue(GlobalData.IniSection.replacePath, GlobalData.FilePath.iniFilePath).ToArray();
            //创建备份目录
            if (!Directory.Exists(backup_original))
            {
                Directory.CreateDirectory(backup_original);
            }
            worker.ReportProgress(0, (replacePaths.Length + 1) * 2);
            File.Copy(clashPath + @"\resources\app\node_modules\moment\moment.js", backup_original + @"\moment.js", true);
            worker.ReportProgress(1, "已备份文件 " + clashPath + @"\resources\app\node_modules\moment\moment.js" + Environment.NewLine);
            File.Copy("moment-with-CN.js", clashPath + @"\resources\app\node_modules\moment\moment.js", true);
            worker.ReportProgress(2, "已替换文件 " + clashPath + @"\resources\app\node_modules\moment\moment.js" + Environment.NewLine);

            CharacterReplacement characterReplacement = new(transArr);
            for (int i = 0; i < replacePaths.Length; i++)
            {
                if (File.Exists(clashPath + replacePaths[i]))
                {
                    string[] s = replacePaths[i].Split(@"\");
                    string fileName = s[^1];
                    File.Copy(clashPath + replacePaths[i], backup_original + @"\" + fileName, true);
                    worker.ReportProgress(i * 2 + 3, "已备份文件 " + clashPath + replacePaths[i] + Environment.NewLine);
                    string resText = characterReplacement.CharacterReplace(clashPath + replacePaths[i]);
                    worker.ReportProgress(i * 2 + 4, resText);
                }
                else
                {
                    worker.ReportProgress(i * 2 + 3, "被汉化文件不存在 " + clashPath + replacePaths[i] + Environment.NewLine);
                }
            }
        }

        private void Trans_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 0:
                    toolStripProgressBar.Value = 0;
                    toolStripProgressBar.Maximum = (int)e.UserState;
                    break;
                default:
                    logTextBox.AppendText(e.UserState.ToString());
                    toolStripProgressBar.Value++;
                    break;
            }
        }

        private void Trans_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            logTextBox.AppendText("汉化完成，请执行下一步操作" + Environment.NewLine);
            toolStripProgressBar.Value = 0;//恢复默认值
            SetActionButtonState(true);
        }

        /// <summary>
        /// 后台打包工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pack_DoWork(object sender, DoWorkEventArgs e)
        {
            string message = "";
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName == GlobalData.clashProcessName)
                {
                    if (MessageBox.Show("Clash for Windows 已开启，是否关闭 Clash for Windows？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        message = CloseClash();
                        break;
                    }
                    else
                    {
                        e.Result = e.Argument + "Clash for Windows 已开启，请关闭 Clash for Windows 后重试。";
                        return;
                    }
                }
            }

            if (message.Contains("失败"))
            {
                e.Result = e.Argument + message;
                return;
            }

            CMDCommand command = new();
            command.Pack(clashPath);
            try
            {
                Directory.Delete(clashPath + @"\resources\app", true);
                e.Result = e.Argument + "打包完成。已删除解包文件夹app。请打开 Clash for Windows 使用。";
            }
            catch (Exception)
            {
                e.Result = e.Argument + $@"打包完成。{clashPath}\resources\app 文件夹删除失败，有文件占用。请打开 Clash for Windows 使用。";
            }

        }

        private void Pack_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string resText = e.Result.ToString();
            logTextBox.AppendText(resText + Environment.NewLine);
            if (resText.Contains("失败"))
            {
                MessageBox.Show(resText, "提示");
            }
            SetActionButtonState(true);
        }

        /// <summary>
        /// 后台还原工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Revert_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName == GlobalData.clashProcessName)
                {
                    if (MessageBox.Show("Clash for Windows 已开启，是否关闭 Clash for Windows？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        e.Result = e.Argument + CloseClash();
                        return;
                    }
                    else
                    {
                        e.Result = e.Argument + "Clash for Windows 已开启，请关闭 Clash for Windows 后重试。";
                        return;
                    }
                }
            }
            e.Result = e.Argument + "Clash for Windows 未开启，可以继续操作";
        }

        private void Revert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string resText = e.Result.ToString();
            logTextBox.AppendText(resText + Environment.NewLine);
            if (!resText.Contains("失败") && !resText.Contains("已开启"))
            {
                IniList ini = new();
                string[] replacePath = ini.GetSectionValue(GlobalData.IniSection.replacePath, GlobalData.FilePath.iniFilePath).ToArray();
                toolStripProgressBar.Maximum = replacePath.Length + 1;
                toolStripProgressBar.Value = 0;
                bool isfileExists = false;
                if (File.Exists(backup_original + @"\moment.js"))
                {
                    try
                    {
                        File.Move(backup_original + @"\moment.js", clashPath + @"\resources\app\node_modules\moment\moment.js", true);
                        logTextBox.AppendText("已还原被汉化文件" + clashPath + @"\resources\app\node_modules\moment\moment.js" + Environment.NewLine);
                        isfileExists = true;
                    }
                    catch (Exception)
                    {
                        logTextBox.AppendText(backup_original + @"\moment.js 文件被占用，无法还原。" + Environment.NewLine);
                    }
                }
                else
                {
                    logTextBox.AppendText(backup_original + @"\moment.js 文件不存在，无法还原。" + Environment.NewLine);
                }
                toolStripProgressBar.Value += 1;
                foreach (string item in replacePath)
                {
                    string[] s = item.Split(@"\");
                    string fileName = s[^1];
                    if (File.Exists(backup_original + @"\" + fileName))
                    {
                        File.Move(backup_original + @"\" + fileName, clashPath + item, true);
                        logTextBox.AppendText("已还原被汉化文件 " + clashPath + item + Environment.NewLine);
                        isfileExists = true;
                    }
                    else
                    {
                        logTextBox.AppendText(backup_original + @"\" + fileName + "不存在，无法还原" + Environment.NewLine);
                    }
                    toolStripProgressBar.Value++;
                }
                toolStripProgressBar.Value = 0;

                //判断备份文件是否全不存在
                if (isfileExists)
                {
                    MessageBox.Show("文件还原完毕，已还原至已解包状态，可以继续汉化。", "提示");
                    logTextBox.AppendText("文件还原完毕，已还原至已解包状态，可以继续汉化。" + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("散备份文件不存在或丢失。", "提示");
                    logTextBox.AppendText("散备份文件不存在或丢失。" + Environment.NewLine);
                }
            }
            SetActionButtonState(true);
        }

        /// <summary>
        /// 检查程序更新完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="isU"></param>
        /// <param name="isE"></param>
        private void UC_HasUpdated(object sender, bool isU, bool isE)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                if (!isE && isU)
                {
                    GlobState.HadAppUpdate = true;
                    GlobState.AppUpdateTag = sender.ToString();
                }

                if (GlobState.HadAppUpdate)
                {
                    this.Text += $" (存在新版本)";
                }
            }));
        }

        /// <summary>
        /// 后台脚本下载工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransScriptDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            Net net = new();
            e.Result = net.DownloadFile(GlobalData.Url.translationScriptUrls, GlobalData.FilePath.translationScriptFilePath);
        }

        private void TransScriptDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                logTextBox.AppendText("下载完成" + Environment.NewLine);
                TranslationScriptFile translationScriptFile = new TranslationScriptFile();
                translationScriptFile.LoadScript(GlobalData.FilePath.translationScriptFilePath, translationScriptRichTextBox, logTextBox);
                if (translationScriptFileName.Text != GlobalData.FilePath.translationScriptFilePath)
                {
                    IniList ini = new();
                    if (translationScriptFileName.Items.Count > 0)
                    {
                        for (int i = 0; i < translationScriptFileName.Items.Count; i++)
                        {
                            if (translationScriptFileName.Items[i].ToString() == GlobalData.FilePath.translationScriptFilePath)
                            {
                                break;
                            }

                            if (translationScriptFileName.Items[i].ToString() != GlobalData.FilePath.translationScriptFilePath && i == translationScriptFileName.Items.Count - 1)
                            {
                                ini.AddSectionValue(GlobalData.IniSection.scriptPath, cacheList, GlobalData.FilePath.translationScriptFilePath);
                                translationScriptFileName.Items.Add(GlobalData.FilePath.translationScriptFilePath);
                                translationScriptFileName.Text = GlobalData.FilePath.translationScriptFilePath;
                            }
                        }
                    }
                    else
                    {
                        ini.AddSectionValue(GlobalData.IniSection.scriptPath, cacheList, GlobalData.FilePath.translationScriptFilePath);
                        translationScriptFileName.Items.Add(GlobalData.FilePath.translationScriptFilePath);
                        translationScriptFileName.Text = GlobalData.FilePath.translationScriptFilePath;
                    }
                }

                loadTranslationScriptButton.Enabled = true;
                openTranslationFileButton.Enabled = true;
            }
            else
            {
                logTextBox.AppendText("下载失败，请重试！" + Environment.NewLine);
            }

            SetActionButtonState(true);
        }
        #endregion
    }
}
