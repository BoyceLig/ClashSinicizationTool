
namespace ReplaceTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClashBrowseButton = new System.Windows.Forms.Button();
            this.loadTranslationScriptButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.logBoxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceButton = new System.Windows.Forms.Button();
            this.openTranslationFileButton = new System.Windows.Forms.Button();
            this.openClashBrowseButton = new System.Windows.Forms.Button();
            this.saveTranslationScriptButton = new System.Windows.Forms.Button();
            this.replaceScriptFileName = new System.Windows.Forms.ComboBox();
            this.replaceFilePath = new System.Windows.Forms.ComboBox();
            this.autoCleanButton = new System.Windows.Forms.Button();
            this.revertButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.translationAndLineSplitContainer = new System.Windows.Forms.SplitContainer();
            this.linePanel = new ClashSinicizationTool.UserComponents.LineNumberPanel(this.components);
            this.translationScriptRichTextBox = new System.Windows.Forms.RichTextBox();
            this.translationScriptRichTextBoxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.translationScriptRichTextBoxMenuStripCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.translationScriptRichTextBoxMenuStripCut = new System.Windows.Forms.ToolStripMenuItem();
            this.translationScriptRichTextBoxMenuStripPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.translationScriptRichTextBoxMenuStripUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.githubToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TGNoticeBoardToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DiscussionGroupToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.translationAndLogSplitContainer = new System.Windows.Forms.SplitContainer();
            this.checkTranslationScriptButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.logBoxMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.translationAndLineSplitContainer)).BeginInit();
            this.translationAndLineSplitContainer.Panel1.SuspendLayout();
            this.translationAndLineSplitContainer.Panel2.SuspendLayout();
            this.translationAndLineSplitContainer.SuspendLayout();
            this.translationScriptRichTextBoxMenuStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.translationAndLogSplitContainer)).BeginInit();
            this.translationAndLogSplitContainer.Panel1.SuspendLayout();
            this.translationAndLogSplitContainer.Panel2.SuspendLayout();
            this.translationAndLogSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "替换脚本：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "被替换文件：";
            // 
            // ClashBrowseButton
            // 
            this.ClashBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClashBrowseButton.Location = new System.Drawing.Point(770, 35);
            this.ClashBrowseButton.Name = "ClashBrowseButton";
            this.ClashBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.ClashBrowseButton.TabIndex = 3;
            this.ClashBrowseButton.Text = "浏览";
            this.toolTip.SetToolTip(this.ClashBrowseButton, "手动浏览 Clash for Windows 目录。");
            this.ClashBrowseButton.UseVisualStyleBackColor = true;
            this.ClashBrowseButton.Click += new System.EventHandler(this.ClashBrowseButton_Click);
            // 
            // loadTranslationScriptButton
            // 
            this.loadTranslationScriptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadTranslationScriptButton.Enabled = false;
            this.loadTranslationScriptButton.Location = new System.Drawing.Point(770, 6);
            this.loadTranslationScriptButton.Name = "loadTranslationScriptButton";
            this.loadTranslationScriptButton.Size = new System.Drawing.Size(75, 23);
            this.loadTranslationScriptButton.TabIndex = 3;
            this.loadTranslationScriptButton.Text = "加载";
            this.toolTip.SetToolTip(this.loadTranslationScriptButton, "如果文件用外部程序修改过，汉化前请点击加载按钮将修改内容加载到当前软件。");
            this.loadTranslationScriptButton.UseVisualStyleBackColor = true;
            this.loadTranslationScriptButton.Click += new System.EventHandler(this.LoadTranslationScriptButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.logTextBox.ContextMenuStrip = this.logBoxMenuStrip;
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.logTextBox.Location = new System.Drawing.Point(3, 19);
            this.logTextBox.MaxLength = 0;
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(851, 133);
            this.logTextBox.TabIndex = 4;
            this.logTextBox.WordWrap = false;
            this.logTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.logTextBox_MouseDown);
            // 
            // logBoxMenuStrip
            // 
            this.logBoxMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.logBoxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToolStripMenuItem,
            this.CleanToolStripMenuItem});
            this.logBoxMenuStrip.Name = "contextMenuStrip";
            this.logBoxMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.CopyToolStripMenuItem.Text = "复制";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // CleanToolStripMenuItem
            // 
            this.CleanToolStripMenuItem.Name = "CleanToolStripMenuItem";
            this.CleanToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.CleanToolStripMenuItem.Text = "清空日志";
            this.CleanToolStripMenuItem.Click += new System.EventHandler(this.CleanToolStripMenuItem_Click);
            // 
            // replaceButton
            // 
            this.replaceButton.Enabled = false;
            this.replaceButton.Location = new System.Drawing.Point(12, 64);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(75, 23);
            this.replaceButton.TabIndex = 7;
            this.replaceButton.Text = "替换";
            this.toolTip.SetToolTip(this.replaceButton, "解包 resources\\app.asar 文件到 resources 目录。\r\n解包后文件夹名称为app。\r\n备份app.asar到app.asar.bak，用" +
        "于还原英文版本。");
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // openTranslationFileButton
            // 
            this.openTranslationFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openTranslationFileButton.Enabled = false;
            this.openTranslationFileButton.Location = new System.Drawing.Point(628, 6);
            this.openTranslationFileButton.Name = "openTranslationFileButton";
            this.openTranslationFileButton.Size = new System.Drawing.Size(136, 23);
            this.openTranslationFileButton.TabIndex = 2;
            this.openTranslationFileButton.Text = "用外部程序打开文件";
            this.toolTip.SetToolTip(this.openTranslationFileButton, "用外部程序打开当前翻译脚本。");
            this.openTranslationFileButton.UseVisualStyleBackColor = true;
            this.openTranslationFileButton.Click += new System.EventHandler(this.OpenTranslationFileButton_Click);
            // 
            // openClashBrowseButton
            // 
            this.openClashBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openClashBrowseButton.Enabled = false;
            this.openClashBrowseButton.Location = new System.Drawing.Point(650, 35);
            this.openClashBrowseButton.Name = "openClashBrowseButton";
            this.openClashBrowseButton.Size = new System.Drawing.Size(114, 23);
            this.openClashBrowseButton.TabIndex = 2;
            this.openClashBrowseButton.Text = "打开所在目录";
            this.toolTip.SetToolTip(this.openClashBrowseButton, "需要路径已输入并且存在，才能打开 Clash for Windows 目录。");
            this.openClashBrowseButton.UseVisualStyleBackColor = true;
            this.openClashBrowseButton.Click += new System.EventHandler(this.OpenClashBrowseButton_Click);
            // 
            // saveTranslationScriptButton
            // 
            this.saveTranslationScriptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTranslationScriptButton.Enabled = false;
            this.saveTranslationScriptButton.Location = new System.Drawing.Point(746, 64);
            this.saveTranslationScriptButton.Name = "saveTranslationScriptButton";
            this.saveTranslationScriptButton.Size = new System.Drawing.Size(99, 23);
            this.saveTranslationScriptButton.TabIndex = 3;
            this.saveTranslationScriptButton.Text = "保存当前脚本";
            this.toolTip.SetToolTip(this.saveTranslationScriptButton, "用于保存下方已修改的翻译脚本信息。\r\n已加设快捷键 Ctrl + S 来保存翻译脚本信息和列表路径。");
            this.saveTranslationScriptButton.UseVisualStyleBackColor = true;
            this.saveTranslationScriptButton.Click += new System.EventHandler(this.SaveTranslationScriptButton_Click);
            // 
            // replaceScriptFileName
            // 
            this.replaceScriptFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceScriptFileName.FormattingEnabled = true;
            this.replaceScriptFileName.Location = new System.Drawing.Point(86, 6);
            this.replaceScriptFileName.Name = "replaceScriptFileName";
            this.replaceScriptFileName.Size = new System.Drawing.Size(536, 25);
            this.replaceScriptFileName.TabIndex = 10;
            this.toolTip.SetToolTip(this.replaceScriptFileName, "可手动粘贴路径（支持相对路径和绝对路径）。");
            this.replaceScriptFileName.TextUpdate += new System.EventHandler(this.replaceScriptFileName_TextChanged);
            // 
            // replaceFilePath
            // 
            this.replaceFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceFilePath.FormattingEnabled = true;
            this.replaceFilePath.Location = new System.Drawing.Point(98, 33);
            this.replaceFilePath.Name = "replaceFilePath";
            this.replaceFilePath.Size = new System.Drawing.Size(546, 25);
            this.replaceFilePath.TabIndex = 10;
            this.toolTip.SetToolTip(this.replaceFilePath, "可手动粘贴路径（支持相对路径和绝对路径）。");
            this.replaceFilePath.SelectedIndexChanged += new System.EventHandler(this.ClashForWindowsPath_TextUpdate);
            this.replaceFilePath.TextUpdate += new System.EventHandler(this.ClashForWindowsPath_TextUpdate);
            // 
            // autoCleanButton
            // 
            this.autoCleanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoCleanButton.Location = new System.Drawing.Point(280, 64);
            this.autoCleanButton.Name = "autoCleanButton";
            this.autoCleanButton.Size = new System.Drawing.Size(106, 23);
            this.autoCleanButton.TabIndex = 3;
            this.autoCleanButton.Text = "清理失效列表";
            this.toolTip.SetToolTip(this.autoCleanButton, "清理无效的翻译脚本路径和 Clash for Windows 路径存档。");
            this.autoCleanButton.UseVisualStyleBackColor = true;
            this.autoCleanButton.Click += new System.EventHandler(this.AutoCleanButton_Click);
            // 
            // revertButton
            // 
            this.revertButton.Enabled = false;
            this.revertButton.Location = new System.Drawing.Point(98, 64);
            this.revertButton.Name = "revertButton";
            this.revertButton.Size = new System.Drawing.Size(75, 23);
            this.revertButton.TabIndex = 7;
            this.revertButton.Text = "还原";
            this.toolTip.SetToolTip(this.revertButton, "如果解包后文件夹app存在，则只还原被汉化后的备份文件（备份文件位置在“我的文档\\Clash Sinicization Tool\\backup_original”" +
        "）。\r\n如果不存在，则还原.bak文件。\r\n需要 resources 目录内有 app.asar.bak 文件，还原此文件。\r\n如果Clash开启状态，则可以一" +
        "键关闭并还原。");
            this.revertButton.UseVisualStyleBackColor = true;
            this.revertButton.Click += new System.EventHandler(this.RevertButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.translationAndLineSplitContainer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 200);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "翻译脚本信息";
            // 
            // translationAndLineSplitContainer
            // 
            this.translationAndLineSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.translationAndLineSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.translationAndLineSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.translationAndLineSplitContainer.Location = new System.Drawing.Point(3, 19);
            this.translationAndLineSplitContainer.Name = "translationAndLineSplitContainer";
            // 
            // translationAndLineSplitContainer.Panel1
            // 
            this.translationAndLineSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.translationAndLineSplitContainer.Panel1.Controls.Add(this.linePanel);
            this.translationAndLineSplitContainer.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.translationAndLineSplitContainer.Panel1MinSize = 20;
            // 
            // translationAndLineSplitContainer.Panel2
            // 
            this.translationAndLineSplitContainer.Panel2.Controls.Add(this.translationScriptRichTextBox);
            this.translationAndLineSplitContainer.Size = new System.Drawing.Size(851, 178);
            this.translationAndLineSplitContainer.SplitterDistance = 51;
            this.translationAndLineSplitContainer.TabIndex = 10;
            // 
            // linePanel
            // 
            this.linePanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.linePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linePanel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linePanel.ForeColor = System.Drawing.Color.White;
            this.linePanel.Location = new System.Drawing.Point(0, 0);
            this.linePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(51, 178);
            this.linePanel.TabIndex = 0;
            // 
            // translationScriptRichTextBox
            // 
            this.translationScriptRichTextBox.AcceptsTab = true;
            this.translationScriptRichTextBox.ContextMenuStrip = this.translationScriptRichTextBoxMenuStrip;
            this.translationScriptRichTextBox.DetectUrls = false;
            this.translationScriptRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.translationScriptRichTextBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.translationScriptRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.translationScriptRichTextBox.Name = "translationScriptRichTextBox";
            this.translationScriptRichTextBox.Size = new System.Drawing.Size(796, 178);
            this.translationScriptRichTextBox.TabIndex = 9;
            this.translationScriptRichTextBox.Text = "";
            this.translationScriptRichTextBox.WordWrap = false;
            this.translationScriptRichTextBox.VScroll += new System.EventHandler(this.translationScriptRichTextBox_VScroll);
            this.translationScriptRichTextBox.SizeChanged += new System.EventHandler(this.translationScriptRichTextBox_SizeChanged);
            this.translationScriptRichTextBox.TextChanged += new System.EventHandler(this.TranslationScriptText_TextChanged);
            this.translationScriptRichTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.translationScriptRichTextBox_MouseDown);
            // 
            // translationScriptRichTextBoxMenuStrip
            // 
            this.translationScriptRichTextBoxMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.translationScriptRichTextBoxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.translationScriptRichTextBoxMenuStripCopy,
            this.translationScriptRichTextBoxMenuStripCut,
            this.translationScriptRichTextBoxMenuStripPaste,
            this.translationScriptRichTextBoxMenuStripUndo});
            this.translationScriptRichTextBoxMenuStrip.Name = "translationScriptRichTextBoxMenuStrip";
            this.translationScriptRichTextBoxMenuStrip.Size = new System.Drawing.Size(101, 92);
            // 
            // translationScriptRichTextBoxMenuStripCopy
            // 
            this.translationScriptRichTextBoxMenuStripCopy.Name = "translationScriptRichTextBoxMenuStripCopy";
            this.translationScriptRichTextBoxMenuStripCopy.Size = new System.Drawing.Size(100, 22);
            this.translationScriptRichTextBoxMenuStripCopy.Text = "复制";
            this.translationScriptRichTextBoxMenuStripCopy.Click += new System.EventHandler(this.translationScriptRichTextBoxMenuStripCopy_Click);
            // 
            // translationScriptRichTextBoxMenuStripCut
            // 
            this.translationScriptRichTextBoxMenuStripCut.Name = "translationScriptRichTextBoxMenuStripCut";
            this.translationScriptRichTextBoxMenuStripCut.Size = new System.Drawing.Size(100, 22);
            this.translationScriptRichTextBoxMenuStripCut.Text = "剪切";
            this.translationScriptRichTextBoxMenuStripCut.Click += new System.EventHandler(this.translationScriptRichTextBoxMenuStripCut_Click);
            // 
            // translationScriptRichTextBoxMenuStripPaste
            // 
            this.translationScriptRichTextBoxMenuStripPaste.Name = "translationScriptRichTextBoxMenuStripPaste";
            this.translationScriptRichTextBoxMenuStripPaste.Size = new System.Drawing.Size(100, 22);
            this.translationScriptRichTextBoxMenuStripPaste.Text = "粘贴";
            this.translationScriptRichTextBoxMenuStripPaste.Click += new System.EventHandler(this.translationScriptRichTextBoxMenuStripPaste_Click);
            // 
            // translationScriptRichTextBoxMenuStripUndo
            // 
            this.translationScriptRichTextBoxMenuStripUndo.Name = "translationScriptRichTextBoxMenuStripUndo";
            this.translationScriptRichTextBoxMenuStripUndo.Size = new System.Drawing.Size(100, 22);
            this.translationScriptRichTextBoxMenuStripUndo.Text = "撤销";
            this.translationScriptRichTextBoxMenuStripUndo.Click += new System.EventHandler(this.translationScriptRichTextBoxMenuStripUndo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.logTextBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(857, 155);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志信息";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel,
            this.githubToolStripStatusLabel,
            this.TGNoticeBoardToolStripStatusLabel2,
            this.DiscussionGroupToolStripStatusLabel3});
            this.statusStrip.Location = new System.Drawing.Point(0, 455);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(857, 25);
            this.statusStrip.TabIndex = 14;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(180, 19);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 25);
            this.toolStripStatusLabel1.Text = "行1，列1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(338, 20);
            this.toolStripStatusLabel.Spring = true;
            // 
            // githubToolStripStatusLabel
            // 
            this.githubToolStripStatusLabel.AutoToolTip = true;
            this.githubToolStripStatusLabel.Image = ((System.Drawing.Image)(resources.GetObject("githubToolStripStatusLabel.Image")));
            this.githubToolStripStatusLabel.IsLink = true;
            this.githubToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.githubToolStripStatusLabel.Name = "githubToolStripStatusLabel";
            this.githubToolStripStatusLabel.Size = new System.Drawing.Size(96, 25);
            this.githubToolStripStatusLabel.Text = "GitHub 地址";
            this.githubToolStripStatusLabel.ToolTipText = "点击进入 GitHub 项目地址。";
            this.githubToolStripStatusLabel.Click += new System.EventHandler(this.GithubToolStripStatusLabel_Click);
            // 
            // TGNoticeBoardToolStripStatusLabel2
            // 
            this.TGNoticeBoardToolStripStatusLabel2.Image = ((System.Drawing.Image)(resources.GetObject("TGNoticeBoardToolStripStatusLabel2.Image")));
            this.TGNoticeBoardToolStripStatusLabel2.IsLink = true;
            this.TGNoticeBoardToolStripStatusLabel2.Name = "TGNoticeBoardToolStripStatusLabel2";
            this.TGNoticeBoardToolStripStatusLabel2.Size = new System.Drawing.Size(84, 20);
            this.TGNoticeBoardToolStripStatusLabel2.Text = "TG 公告板";
            this.TGNoticeBoardToolStripStatusLabel2.Click += new System.EventHandler(this.TGNoticeBoardToolStripStatusLabel2_Click);
            // 
            // DiscussionGroupToolStripStatusLabel3
            // 
            this.DiscussionGroupToolStripStatusLabel3.Image = ((System.Drawing.Image)(resources.GetObject("DiscussionGroupToolStripStatusLabel3.Image")));
            this.DiscussionGroupToolStripStatusLabel3.IsLink = true;
            this.DiscussionGroupToolStripStatusLabel3.Name = "DiscussionGroupToolStripStatusLabel3";
            this.DiscussionGroupToolStripStatusLabel3.Size = new System.Drawing.Size(84, 20);
            this.DiscussionGroupToolStripStatusLabel3.Text = "TG 讨论组";
            this.DiscussionGroupToolStripStatusLabel3.Click += new System.EventHandler(this.TGDiscussionGroupToolStripStatusLabel3_Click);
            // 
            // translationAndLogSplitContainer
            // 
            this.translationAndLogSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.translationAndLogSplitContainer.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.translationAndLogSplitContainer.Location = new System.Drawing.Point(0, 93);
            this.translationAndLogSplitContainer.Name = "translationAndLogSplitContainer";
            this.translationAndLogSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // translationAndLogSplitContainer.Panel1
            // 
            this.translationAndLogSplitContainer.Panel1.Controls.Add(this.groupBox1);
            // 
            // translationAndLogSplitContainer.Panel2
            // 
            this.translationAndLogSplitContainer.Panel2.Controls.Add(this.groupBox2);
            this.translationAndLogSplitContainer.Size = new System.Drawing.Size(857, 359);
            this.translationAndLogSplitContainer.SplitterDistance = 200;
            this.translationAndLogSplitContainer.TabIndex = 15;
            // 
            // checkTranslationScriptButton
            // 
            this.checkTranslationScriptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkTranslationScriptButton.Location = new System.Drawing.Point(179, 64);
            this.checkTranslationScriptButton.Name = "checkTranslationScriptButton";
            this.checkTranslationScriptButton.Size = new System.Drawing.Size(95, 23);
            this.checkTranslationScriptButton.TabIndex = 7;
            this.checkTranslationScriptButton.Text = "检查替换脚本";
            this.checkTranslationScriptButton.UseVisualStyleBackColor = true;
            this.checkTranslationScriptButton.Click += new System.EventHandler(this.checkTranslationScriptButton_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 480);
            this.Controls.Add(this.translationAndLogSplitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.replaceFilePath);
            this.Controls.Add(this.saveTranslationScriptButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.replaceScriptFileName);
            this.Controls.Add(this.checkTranslationScriptButton);
            this.Controls.Add(this.revertButton);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.loadTranslationScriptButton);
            this.Controls.Add(this.autoCleanButton);
            this.Controls.Add(this.ClashBrowseButton);
            this.Controls.Add(this.openClashBrowseButton);
            this.Controls.Add(this.openTranslationFileButton);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(870, 519);
            this.Name = "MainForm";
            this.Text = "字符替换工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.logBoxMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.translationAndLineSplitContainer.Panel1.ResumeLayout(false);
            this.translationAndLineSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.translationAndLineSplitContainer)).EndInit();
            this.translationAndLineSplitContainer.ResumeLayout(false);
            this.translationScriptRichTextBoxMenuStrip.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.translationAndLogSplitContainer.Panel1.ResumeLayout(false);
            this.translationAndLogSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.translationAndLogSplitContainer)).EndInit();
            this.translationAndLogSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ClashBrowseButton;
        private System.Windows.Forms.Button loadTranslationScriptButton;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Button openTranslationFileButton;
        private System.Windows.Forms.Button openClashBrowseButton;
        private System.Windows.Forms.ComboBox replaceScriptFileName;
        private System.Windows.Forms.ComboBox replaceFilePath;
        private System.Windows.Forms.Button autoCleanButton;
        private System.Windows.Forms.Button revertButton;
        private System.Windows.Forms.ContextMenuStrip logBoxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CleanToolStripMenuItem;
        private System.Windows.Forms.Button saveTranslationScriptButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel githubToolStripStatusLabel;
        private System.Windows.Forms.SplitContainer translationAndLogSplitContainer;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ContextMenuStrip translationScriptRichTextBoxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem translationScriptRichTextBoxMenuStripCopy;
        private System.Windows.Forms.ToolStripMenuItem translationScriptRichTextBoxMenuStripCut;
        private System.Windows.Forms.ToolStripMenuItem translationScriptRichTextBoxMenuStripPaste;
        private System.Windows.Forms.ToolStripMenuItem translationScriptRichTextBoxMenuStripUndo;
        private System.Windows.Forms.Button checkTranslationScriptButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer;
        public System.Windows.Forms.RichTextBox translationScriptRichTextBox;
        private System.Windows.Forms.SplitContainer translationAndLineSplitContainer;
        private ClashSinicizationTool.UserComponents.LineNumberPanel linePanel;
        private System.Windows.Forms.ToolStripStatusLabel TGNoticeBoardToolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel DiscussionGroupToolStripStatusLabel3;
        private OpenFileDialog openFileDialog;
    }
}

