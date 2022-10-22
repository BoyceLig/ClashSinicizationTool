using ClashSinicizationTool;
using ClashSinicizationToolBase;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ReplaceTool
{
    public partial class MainForm : Form
    {
        string filePath;
        private readonly string cacheList = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Clash Sinicization Tool\ReplaceToolCacheList.ini";
        private readonly string backup_original = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Clash Sinicization Tool\replace_backup_original";
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
                Text = "字符替换工具 " + " v" + currentVersion + " 64-bit ";
            }
            else
            {
                //32位
                Text = "字符替换工具 " + " v" + currentVersion + " 32-bit ";
            }
            #endregion

            #region 翻译脚本内容输入框字体
            translationScriptRichTextBox.LanguageOption = RichTextBoxLanguageOptions.DualFont;
            #endregion

            translationAndLineSplitContainer.Panel1MinSize = linePanel.GetControlWidth();
            translationAndLineSplitContainer.SplitterDistance = linePanel.GetControlWidth();
            translationScriptRichTextBox.MouseWheel += translationScriptRichTextBox_MouseWheel;

            //自动选择字词关闭（面板关闭按钮失效）
            translationScriptRichTextBox.AutoWordSelection = false;
            timer.Start();

            ReplaceScriptFile translationScriptFile = new ReplaceScriptFile();

            //检查创建列表文件
            if (!File.Exists(cacheList))
            {
                if (!Directory.Exists(Path.GetDirectoryName(cacheList)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(cacheList));
                }
                //创建cacheList文件
                File.Create(cacheList).Close();
                File.WriteAllText(cacheList, Properties.Resources.ReplaceCacheList);
            }

            #region 检查创建clash目录列表

            translationScriptFile.LoadReplaceFileList(replaceFilePath, cacheList);
            if (Directory.Exists(replaceFilePath.Text))
            {
                filePath = replaceFilePath.Text;
            }

            #endregion

            #region 检查创建翻译脚本列表文件

            //加载列表文件
            translationScriptFile.LoadScriptList(replaceScriptFileName, cacheList);
            //自动加载第一个文件
            if (replaceScriptFileName.Items.Count != 0)
            {
                string curTransFile = replaceScriptFileName.Items[0].ToString();
                if (File.Exists(curTransFile))
                {
                    translationScriptFile.LoadScript(curTransFile, translationScriptRichTextBox, logTextBox);
                    loadTranslationScriptButton.Enabled = true;
                    openTranslationFileButton.Enabled = true;
                    SetActionButtonState(true);
                }
            }
            #endregion          
        }

        #region 按钮
        //保存当前翻译脚本的修改
        private void SaveTranslationScriptButton_Click(object sender, EventArgs e)
        {
            ReplaceScriptFile translationScriptFile = new();
            translationScriptFile.SaveScript(replaceScriptFileName.Text, translationScriptRichTextBox, logTextBox);
            saveTranslationScriptButton.Enabled = false;
        }

        //加载按钮
        private void LoadTranslationScriptButton_Click(object sender, EventArgs e)
        {
            ReplaceScriptFile translationScriptFile = new ReplaceScriptFile();
            translationScriptFile.LoadScript(replaceScriptFileName.Text, translationScriptRichTextBox, logTextBox);

            //把文件名加载到列表
            //如果item没有值
            if (replaceScriptFileName.Items.Count == 0)
            {
                //把文件名加载到列表
                replaceScriptFileName.Items.Add(replaceScriptFileName.Text);
            }
            else
            {
                //察看是否有重复名字
                for (int i = 0; i < replaceScriptFileName.Items.Count; i++)
                {
                    if (replaceScriptFileName.Text != replaceScriptFileName.Items[i].ToString())
                    {
                        //把文件名加载到列表
                        replaceScriptFileName.Items.Add(replaceScriptFileName.Text);
                    }
                }
            }
        }

        //点击浏览文件夹并将path传递给clash path
        private void ClashBrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "请选择要替换的根路径";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                replaceFilePath.Text = filePath;
                openClashBrowseButton.Enabled = true;
                SetActionButtonState(true);
                if (replaceFilePath.Items.Count == 0)
                {
                    //把文件名加载到列表
                    replaceFilePath.Items.Add(replaceFilePath.Text);
                }
                else
                {
                    for (int i = 0; i < replaceFilePath.Items.Count; i++)
                    {
                        if (replaceFilePath.Text == replaceFilePath.Items[i].ToString())
                        {
                            return;
                        }
                    }
                    replaceFilePath.Items.Add(replaceFilePath.Text);
                }

                IniList ini = new();
                ini.AddSectionValue(GlobalData.IniSection.replacePath, cacheList, replaceFilePath.Text);
            }
        }

        //自动清理失效目录和文件
        private void AutoCleanButton_Click(object sender, EventArgs e)
        {
            IniList ini = new();
            ini.CleanSectionValue(GlobalData.IniSection.scriptPath, cacheList);
            ini.CleanSectionValue(GlobalData.IniSection.replacePath, cacheList);
            replaceScriptFileName.Items.Clear();
            replaceScriptFileName.Text = string.Empty;
            replaceFilePath.Items.Clear();
            replaceFilePath.Text = string.Empty;

            ReplaceScriptFile translationScriptFile = new ReplaceScriptFile();

            translationScriptFile.LoadReplaceFileList(replaceFilePath, cacheList, true);
            for (int i = 0; i < replaceFilePath.Items.Count; i++)
            {
                ini.AddSectionValue(GlobalData.IniSection.replacePath, cacheList, replaceFilePath.Items[i].ToString());
            }
            if (File.Exists(replaceFilePath.Text))
            {
                openClashBrowseButton.Enabled = true;
                filePath = replaceFilePath.Text;
            }

            translationScriptFile.LoadScriptList(replaceScriptFileName, cacheList, true);
            for (int i = 0; i < replaceScriptFileName.Items.Count; i++)
            {
                ini.AddSectionValue(GlobalData.IniSection.scriptPath, cacheList, replaceScriptFileName.Items[i].ToString());
            }
            if (File.Exists(replaceScriptFileName.Text) && File.Exists(filePath))
            {
                openClashBrowseButton.Enabled = true;
                filePath = replaceFilePath.Text;
                SetActionButtonState(true);
            }

            logTextBox.AppendText("清理列表成功" + Environment.NewLine);
        }

        //替换按钮
        private void replaceButton_Click(object sender, EventArgs e)
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

        //用外界程序打开脚本
        private void OpenTranslationFileButton_Click(object sender, EventArgs e)
        {
            Process process = new();
            process.StartInfo.FileName = replaceScriptFileName.Text;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        //打开文件夹目录
        private void OpenClashBrowseButton_Click(object sender, EventArgs e)
        {
            Process.Start("Explorer.exe", Path.GetDirectoryName(filePath));
            logTextBox.AppendText("已打开Clash文件夹" + Environment.NewLine);
        }

        //还原按钮
        private void RevertButton_Click(object sender, EventArgs e)
        {
            SetActionButtonState(false);
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Revert_RunWorkerCompleted);
                bw.DoWork += new DoWorkEventHandler(Revert_DoWork);
                bw.RunWorkerAsync();
            }
        }

        //检查翻译脚本完整性
        private void checkTranslationScriptButton_Click(object sender, EventArgs e)
        {
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Minimum = 0;
            toolStripProgressBar.Maximum = translationScriptRichTextBox.Lines.Length;

            //拆分string加快速度
            string transText = translationScriptRichTextBox.Text;
            string[] transTexts = transText.Split('\n');

            for (int i = 0; i < transTexts.Length; i++)
            {
                if (!transTexts[i].StartsWith("#") && transTexts[i] != string.Empty)
                {
                    if (!transTexts[i].Contains('='))
                    {
                        logTextBox.AppendText($"第{i + 1}行 ‘{transTexts[i]}’ 缺失‘=’" + Environment.NewLine);
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
            //控件加载事件
            ShowLineNo();

            string scriptFile = replaceScriptFileName.Text.Trim();
            if (!string.IsNullOrEmpty(scriptFile) && File.Exists(scriptFile))
            {
                StreamReader streamReader = new(scriptFile, Encoding.UTF8);
                if (translationScriptRichTextBox.Text == streamReader.ReadToEnd())
                {
                    saveTranslationScriptButton.Enabled = false;
                }
                else
                {
                    saveTranslationScriptButton.Enabled = true;
                }
                streamReader.Close();
                openTranslationFileButton.Enabled = true;
            }
            else
            {
                openTranslationFileButton.Enabled = false;
            }
        }

        //判定加载按钮和用外部程序打开按钮开关
        private void replaceScriptFileName_TextChanged(object sender, EventArgs e)
        {
            if (replaceScriptFileName.Text == string.Empty)
            {
                loadTranslationScriptButton.Enabled = false;
                openTranslationFileButton.Enabled = false;
                SetActionButtonState(false);
            }
            else
            {
                if (File.Exists(replaceScriptFileName.Text))
                {
                    loadTranslationScriptButton.Enabled = true;
                    openTranslationFileButton.Enabled = true;
                    SetActionButtonState(true);
                    foreach (string item in replaceScriptFileName.Items)
                    {
                        if (item == replaceScriptFileName.Text)
                        {
                            return;
                        }
                    }
                    replaceScriptFileName.Items.Add(replaceScriptFileName.Text);
                    IniList ini = new();
                    ini.AddSectionValue(GlobalData.IniSection.scriptPath, cacheList, replaceScriptFileName.Text);
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
            if (replaceFilePath.Text == string.Empty)
            {
                openClashBrowseButton.Enabled = false;
                SetActionButtonState(false);
            }
            else
            {
                if (File.Exists(replaceFilePath.Text))
                {
                    openClashBrowseButton.Enabled = true;
                    filePath = replaceFilePath.Text;

                    #region 解包……按钮使用权控制
                    if (File.Exists(replaceScriptFileName.Text))
                    {
                        SetActionButtonState(true);
                    }
                    #endregion

                    foreach (string item in replaceFilePath.Items)
                    {
                        if (item == replaceFilePath.Text)
                        {
                            return;
                        }
                    }
                    replaceFilePath.Items.Add(replaceFilePath.Text);
                    IniList ini = new();
                    ini.AddSectionValue(GlobalData.IniSection.replacePath, cacheList, replaceFilePath.Text);
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

        #region 右下角链接跳转
        //GitHub链接点击进入
        private void GithubToolStripStatusLabel_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", GlobalData.Url.projectUrl);
        }

        private void TGNoticeBoardToolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", GlobalData.Url.m_TGNoticeBoardUrl);
        }

        private void TGDiscussionGroupToolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", GlobalData.Url.m_TGDiscussionGroup);
        }
        #endregion

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
            replaceButton.Enabled = state;
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
        /// 后台汉化工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Trans_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string transText = e.Argument.ToString();
            string[] transArr = transText.Split('\n');

            //创建备份目录
            if (!Directory.Exists(backup_original))
            {
                Directory.CreateDirectory(backup_original);
            }

            CharacterReplacement characterReplacement = new(transArr);
            if (File.Exists(filePath))
            {
                string[] s = filePath.Split(@"\");
                string fileName = s[^1];
                File.Copy(filePath, backup_original + @"\" + fileName, true);
                worker.ReportProgress(3, "已备份文件 " + filePath + Environment.NewLine);
                string resText = characterReplacement.CharacterReplace(filePath);
                worker.ReportProgress(4, resText);
            }
            else
            {
                worker.ReportProgress(3, "被替换文件不存在 " + filePath + Environment.NewLine);
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
            logTextBox.AppendText("替换完成" + Environment.NewLine);
            toolStripProgressBar.Value = 0;//恢复默认值
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
                string[] s = replaceFilePath.Text.Split(@"\");
                string fileName = s[^1];
                if (File.Exists(backup_original + @"\" + fileName))
                {
                    File.Move(backup_original + @"\" + fileName, filePath, true);
                    logTextBox.AppendText("已还原被汉化文件 " + filePath + Environment.NewLine);
                }
                else
                {
                    logTextBox.AppendText(backup_original + @"\" + fileName + "不存在，无法还原" + Environment.NewLine);
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

                    switch (MessageBox.Show(this, "存在新版本 " + GlobState.AppUpdateTag + "，是否下载更新程序？", "更新提示", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            DownloadForm df = new DownloadForm(GlobState.AppUpdateTag);
                            df.ShowDialog(this);
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
            }));
        }
        #endregion

        //准备Panel画布，当接到文件字符后进行坐标解析，绘制行号
        private void ShowLineNo()
        {
            //获得当前坐标信息
            Point p = translationScriptRichTextBox.Location;
            int crntFirstIndex = translationScriptRichTextBox.GetCharIndexFromPosition(p);
            int crntFirstLine = translationScriptRichTextBox.GetLineFromCharIndex(crntFirstIndex);
            Point crntFirstPos = translationScriptRichTextBox.GetPositionFromCharIndex(crntFirstIndex);
            p.Y += translationScriptRichTextBox.Height;
            int crntLastIndex = translationScriptRichTextBox.GetCharIndexFromPosition(p) + 1;
            int crntLastLine = translationScriptRichTextBox.GetLineFromCharIndex(crntLastIndex);
            Point crntLastPos = translationScriptRichTextBox.GetPositionFromCharIndex(crntLastIndex);

            int space;
            if (crntFirstLine != crntLastLine)
            {
                space = (crntLastPos.Y - crntFirstPos.Y) / (crntLastLine - crntFirstLine);
            }
            else
            {
                Size charSize = TextRenderer.MeasureText("8", translationScriptRichTextBox.Font);
                space = (int)(charSize.Height * 1.5);
            }
            linePanel.Space = space;
            linePanel.LargeNumber = crntLastLine + 1;
            linePanel.BottomPosition = crntLastPos.Y;

            int nowDigit = translationScriptRichTextBox.Lines.Length.ToString().Length;
            if (nowDigit != linePanel.Digit)
            {
                linePanel.Digit = nowDigit;
                translationAndLineSplitContainer.Panel1MinSize = linePanel.GetControlWidth();
                translationAndLineSplitContainer.SplitterDistance = linePanel.GetControlWidth();
            }
        }

        //滚动调整
        private void translationScriptRichTextBox_VScroll(object sender, EventArgs e)
        {
            ShowLineNo();
        }

        private void translationScriptRichTextBox_SizeChanged(object sender, EventArgs e)
        {
            ShowLineNo();
        }

        private void translationScriptRichTextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) != 0)
            {
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }

    }
}
