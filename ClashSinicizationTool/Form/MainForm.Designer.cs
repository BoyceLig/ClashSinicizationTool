
namespace ClashSinicizationTool
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
            this.label5 = new System.Windows.Forms.Label();
            this.unpackButton = new System.Windows.Forms.Button();
            this.sinicizationButton = new System.Windows.Forms.Button();
            this.packButton = new System.Windows.Forms.Button();
            this.openTranslationFileButton = new System.Windows.Forms.Button();
            this.openClashBrowseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveTranslationScriptButton = new System.Windows.Forms.Button();
            this.translationScriptFileName = new System.Windows.Forms.ComboBox();
            this.clashForWindowsPath = new System.Windows.Forms.ComboBox();
            this.autoCleanButton = new System.Windows.Forms.Button();
            this.OpenClashButton = new System.Windows.Forms.Button();
            this.revertButton = new System.Windows.Forms.Button();
            this.CloseClashButton = new System.Windows.Forms.Button();
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
            this.autoCkeckClashPathButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CheckUpdateButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.githubToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.translationAndLogSplitContainer = new System.Windows.Forms.SplitContainer();
            this.updateTranslationScriptButton = new System.Windows.Forms.Button();
            this.findReplaceButton = new System.Windows.Forms.Button();
            this.checkTranslationScriptButton = new System.Windows.Forms.Button();
            this.jumpLineButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
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
            this.label1.Location = new System.Drawing.Point(19, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "翻译脚本：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clash For Windows 路径：";
            // 
            // ClashBrowseButton
            // 
            this.ClashBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClashBrowseButton.Location = new System.Drawing.Point(1210, 49);
            this.ClashBrowseButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ClashBrowseButton.Name = "ClashBrowseButton";
            this.ClashBrowseButton.Size = new System.Drawing.Size(118, 32);
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
            this.loadTranslationScriptButton.Location = new System.Drawing.Point(1210, 8);
            this.loadTranslationScriptButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.loadTranslationScriptButton.Name = "loadTranslationScriptButton";
            this.loadTranslationScriptButton.Size = new System.Drawing.Size(118, 32);
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
            this.logTextBox.Location = new System.Drawing.Point(5, 27);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.logTextBox.MaxLength = 0;
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(1337, 222);
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
            this.logBoxMenuStrip.Size = new System.Drawing.Size(153, 64);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.CopyToolStripMenuItem.Text = "复制";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // CleanToolStripMenuItem
            // 
            this.CleanToolStripMenuItem.Name = "CleanToolStripMenuItem";
            this.CleanToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.CleanToolStripMenuItem.Text = "清空日志";
            this.CleanToolStripMenuItem.Click += new System.EventHandler(this.CleanToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 99);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(316, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "请严格按照顺序点击，否则可能不成功";
            // 
            // unpackButton
            // 
            this.unpackButton.Enabled = false;
            this.unpackButton.Location = new System.Drawing.Point(19, 131);
            this.unpackButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.unpackButton.Name = "unpackButton";
            this.unpackButton.Size = new System.Drawing.Size(118, 32);
            this.unpackButton.TabIndex = 7;
            this.unpackButton.Text = "1. 解包";
            this.toolTip.SetToolTip(this.unpackButton, "解包 resources\\app.asar 文件到 resources 目录。\r\n解包后文件夹名称为app。\r\n备份app.asar到app.asar.bak，用" +
        "于还原英文版本。");
            this.unpackButton.UseVisualStyleBackColor = true;
            this.unpackButton.Click += new System.EventHandler(this.UnpackButton_Click);
            // 
            // sinicizationButton
            // 
            this.sinicizationButton.Enabled = false;
            this.sinicizationButton.Location = new System.Drawing.Point(146, 131);
            this.sinicizationButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.sinicizationButton.Name = "sinicizationButton";
            this.sinicizationButton.Size = new System.Drawing.Size(118, 32);
            this.sinicizationButton.TabIndex = 7;
            this.sinicizationButton.Text = "2-1. 汉化";
            this.toolTip.SetToolTip(this.sinicizationButton, "根据翻译脚本信息字段替换对应文件相应字段。\r\n将被汉化文件备份到 “我的文档\\Clash Sinicization Tool\\backup_original”。");
            this.sinicizationButton.UseVisualStyleBackColor = true;
            this.sinicizationButton.Click += new System.EventHandler(this.SinicizationButton_Click);
            // 
            // packButton
            // 
            this.packButton.Enabled = false;
            this.packButton.Location = new System.Drawing.Point(273, 131);
            this.packButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.packButton.Name = "packButton";
            this.packButton.Size = new System.Drawing.Size(118, 32);
            this.packButton.TabIndex = 7;
            this.packButton.Text = "3. 打包";
            this.toolTip.SetToolTip(this.packButton, "打包已修改后的app文件夹的内容到app.asar文件。\r\n如果Clash开启状态，则可以一键关闭并打包。");
            this.packButton.UseVisualStyleBackColor = true;
            this.packButton.Click += new System.EventHandler(this.PackButton_Click);
            // 
            // openTranslationFileButton
            // 
            this.openTranslationFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openTranslationFileButton.Enabled = false;
            this.openTranslationFileButton.Location = new System.Drawing.Point(987, 8);
            this.openTranslationFileButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.openTranslationFileButton.Name = "openTranslationFileButton";
            this.openTranslationFileButton.Size = new System.Drawing.Size(214, 32);
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
            this.openClashBrowseButton.Location = new System.Drawing.Point(1021, 49);
            this.openClashBrowseButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.openClashBrowseButton.Name = "openClashBrowseButton";
            this.openClashBrowseButton.Size = new System.Drawing.Size(179, 32);
            this.openClashBrowseButton.TabIndex = 2;
            this.openClashBrowseButton.Text = "打开 Clash 目录";
            this.toolTip.SetToolTip(this.openClashBrowseButton, "需要路径已输入并且存在，才能打开 Clash for Windows 目录。");
            this.openClashBrowseButton.UseVisualStyleBackColor = true;
            this.openClashBrowseButton.Click += new System.EventHandler(this.OpenClashBrowseButton_Click);
            // 
            // saveTranslationScriptButton
            // 
            this.saveTranslationScriptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTranslationScriptButton.Enabled = false;
            this.saveTranslationScriptButton.Location = new System.Drawing.Point(1142, 131);
            this.saveTranslationScriptButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.saveTranslationScriptButton.Name = "saveTranslationScriptButton";
            this.saveTranslationScriptButton.Size = new System.Drawing.Size(185, 32);
            this.saveTranslationScriptButton.TabIndex = 3;
            this.saveTranslationScriptButton.Text = "保存当前翻译脚本";
            this.toolTip.SetToolTip(this.saveTranslationScriptButton, "用于保存下方已修改的翻译脚本信息。\r\n已加设快捷键 Ctrl + S 来保存翻译脚本信息和列表路径。");
            this.saveTranslationScriptButton.UseVisualStyleBackColor = true;
            this.saveTranslationScriptButton.Click += new System.EventHandler(this.SaveTranslationScriptButton_Click);
            // 
            // translationScriptFileName
            // 
            this.translationScriptFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.translationScriptFileName.FormattingEnabled = true;
            this.translationScriptFileName.Location = new System.Drawing.Point(135, 8);
            this.translationScriptFileName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.translationScriptFileName.Name = "translationScriptFileName";
            this.translationScriptFileName.Size = new System.Drawing.Size(681, 32);
            this.translationScriptFileName.TabIndex = 10;
            this.toolTip.SetToolTip(this.translationScriptFileName, "可手动粘贴路径（支持相对路径和绝对路径）。");
            this.translationScriptFileName.TextUpdate += new System.EventHandler(this.TranslationScriptFileName_TextChanged);
            // 
            // clashForWindowsPath
            // 
            this.clashForWindowsPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clashForWindowsPath.FormattingEnabled = true;
            this.clashForWindowsPath.Location = new System.Drawing.Point(278, 47);
            this.clashForWindowsPath.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.clashForWindowsPath.Name = "clashForWindowsPath";
            this.clashForWindowsPath.Size = new System.Drawing.Size(570, 32);
            this.clashForWindowsPath.TabIndex = 10;
            this.toolTip.SetToolTip(this.clashForWindowsPath, "可手动粘贴路径（支持相对路径和绝对路径）。");
            this.clashForWindowsPath.SelectedIndexChanged += new System.EventHandler(this.ClashForWindowsPath_TextUpdate);
            this.clashForWindowsPath.TextUpdate += new System.EventHandler(this.ClashForWindowsPath_TextUpdate);
            // 
            // autoCleanButton
            // 
            this.autoCleanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoCleanButton.Location = new System.Drawing.Point(479, 90);
            this.autoCleanButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.autoCleanButton.Name = "autoCleanButton";
            this.autoCleanButton.Size = new System.Drawing.Size(167, 32);
            this.autoCleanButton.TabIndex = 3;
            this.autoCleanButton.Text = "清理失效列表";
            this.toolTip.SetToolTip(this.autoCleanButton, "清理无效的翻译脚本路径和 Clash for Windows 路径存档。");
            this.autoCleanButton.UseVisualStyleBackColor = true;
            this.autoCleanButton.Click += new System.EventHandler(this.AutoCleanButton_Click);
            // 
            // OpenClashButton
            // 
            this.OpenClashButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenClashButton.Location = new System.Drawing.Point(655, 90);
            this.OpenClashButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.OpenClashButton.Name = "OpenClashButton";
            this.OpenClashButton.Size = new System.Drawing.Size(269, 32);
            this.OpenClashButton.TabIndex = 7;
            this.OpenClashButton.Text = "打开 Clash for Windows";
            this.OpenClashButton.UseVisualStyleBackColor = true;
            this.OpenClashButton.Click += new System.EventHandler(this.OpenClashButton_Click);
            // 
            // revertButton
            // 
            this.revertButton.Enabled = false;
            this.revertButton.Location = new System.Drawing.Point(401, 131);
            this.revertButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.revertButton.Name = "revertButton";
            this.revertButton.Size = new System.Drawing.Size(118, 32);
            this.revertButton.TabIndex = 7;
            this.revertButton.Text = "4. 还原";
            this.toolTip.SetToolTip(this.revertButton, "如果解包后文件夹app存在，则只还原被汉化后的备份文件（备份文件位置在“我的文档\\Clash Sinicization Tool\\backup_original”" +
        "）。\r\n如果不存在，则还原.bak文件。\r\n需要 resources 目录内有 app.asar.bak 文件，还原此文件。\r\n如果Clash开启状态，则可以一" +
        "键关闭并还原。");
            this.revertButton.UseVisualStyleBackColor = true;
            this.revertButton.Click += new System.EventHandler(this.RevertButton_Click);
            // 
            // CloseClashButton
            // 
            this.CloseClashButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseClashButton.Location = new System.Drawing.Point(933, 90);
            this.CloseClashButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CloseClashButton.Name = "CloseClashButton";
            this.CloseClashButton.Size = new System.Drawing.Size(269, 32);
            this.CloseClashButton.TabIndex = 7;
            this.CloseClashButton.Text = "关闭 Clash for Windows";
            this.CloseClashButton.UseVisualStyleBackColor = true;
            this.CloseClashButton.Click += new System.EventHandler(this.CloseClashButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.translationAndLineSplitContainer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(1347, 330);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "翻译脚本信息";
            // 
            // translationAndLineSplitContainer
            // 
            this.translationAndLineSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.translationAndLineSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.translationAndLineSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.translationAndLineSplitContainer.Location = new System.Drawing.Point(5, 27);
            this.translationAndLineSplitContainer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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
            this.translationAndLineSplitContainer.Size = new System.Drawing.Size(1337, 299);
            this.translationAndLineSplitContainer.SplitterDistance = 51;
            this.translationAndLineSplitContainer.SplitterWidth = 6;
            this.translationAndLineSplitContainer.TabIndex = 10;
            // 
            // linePanel
            // 
            this.linePanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.linePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linePanel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linePanel.ForeColor = System.Drawing.Color.White;
            this.linePanel.Location = new System.Drawing.Point(0, 0);
            this.linePanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(51, 299);
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
            this.translationScriptRichTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.translationScriptRichTextBox.Name = "translationScriptRichTextBox";
            this.translationScriptRichTextBox.Size = new System.Drawing.Size(1280, 299);
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
            this.translationScriptRichTextBoxMenuStrip.Size = new System.Drawing.Size(117, 124);
            // 
            // translationScriptRichTextBoxMenuStripCopy
            // 
            this.translationScriptRichTextBoxMenuStripCopy.Name = "translationScriptRichTextBoxMenuStripCopy";
            this.translationScriptRichTextBoxMenuStripCopy.Size = new System.Drawing.Size(116, 30);
            this.translationScriptRichTextBoxMenuStripCopy.Text = "复制";
            this.translationScriptRichTextBoxMenuStripCopy.Click += new System.EventHandler(this.translationScriptRichTextBoxMenuStripCopy_Click);
            // 
            // translationScriptRichTextBoxMenuStripCut
            // 
            this.translationScriptRichTextBoxMenuStripCut.Name = "translationScriptRichTextBoxMenuStripCut";
            this.translationScriptRichTextBoxMenuStripCut.Size = new System.Drawing.Size(116, 30);
            this.translationScriptRichTextBoxMenuStripCut.Text = "剪切";
            this.translationScriptRichTextBoxMenuStripCut.Click += new System.EventHandler(this.translationScriptRichTextBoxMenuStripCut_Click);
            // 
            // translationScriptRichTextBoxMenuStripPaste
            // 
            this.translationScriptRichTextBoxMenuStripPaste.Name = "translationScriptRichTextBoxMenuStripPaste";
            this.translationScriptRichTextBoxMenuStripPaste.Size = new System.Drawing.Size(116, 30);
            this.translationScriptRichTextBoxMenuStripPaste.Text = "粘贴";
            this.translationScriptRichTextBoxMenuStripPaste.Click += new System.EventHandler(this.translationScriptRichTextBoxMenuStripPaste_Click);
            // 
            // translationScriptRichTextBoxMenuStripUndo
            // 
            this.translationScriptRichTextBoxMenuStripUndo.Name = "translationScriptRichTextBoxMenuStripUndo";
            this.translationScriptRichTextBoxMenuStripUndo.Size = new System.Drawing.Size(116, 30);
            this.translationScriptRichTextBoxMenuStripUndo.Text = "撤销";
            this.translationScriptRichTextBoxMenuStripUndo.Click += new System.EventHandler(this.translationScriptRichTextBoxMenuStripUndo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.logTextBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Size = new System.Drawing.Size(1347, 253);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志信息";
            // 
            // autoCkeckClashPathButton
            // 
            this.autoCkeckClashPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoCkeckClashPathButton.Location = new System.Drawing.Point(860, 49);
            this.autoCkeckClashPathButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.autoCkeckClashPathButton.Name = "autoCkeckClashPathButton";
            this.autoCkeckClashPathButton.Size = new System.Drawing.Size(149, 32);
            this.autoCkeckClashPathButton.TabIndex = 3;
            this.autoCkeckClashPathButton.Text = "自动检测目录";
            this.toolTip.SetToolTip(this.autoCkeckClashPathButton, "需要打开 Clash for Windows 程序，来检测已打开的Clash for Windows的目录位置。检测后自动关闭。");
            this.autoCkeckClashPathButton.UseVisualStyleBackColor = true;
            this.autoCkeckClashPathButton.Click += new System.EventHandler(this.AutoCkeckClashPathButton_Click);
            // 
            // CheckUpdateButton
            // 
            this.CheckUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckUpdateButton.Location = new System.Drawing.Point(1210, 90);
            this.CheckUpdateButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CheckUpdateButton.Name = "CheckUpdateButton";
            this.CheckUpdateButton.Size = new System.Drawing.Size(118, 32);
            this.CheckUpdateButton.TabIndex = 16;
            this.CheckUpdateButton.Text = "检查更新";
            this.toolTip.SetToolTip(this.CheckUpdateButton, "检查汉化工具是否存在新版本");
            this.CheckUpdateButton.UseVisualStyleBackColor = true;
            this.CheckUpdateButton.Click += new System.EventHandler(this.CheckUpdateButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel,
            this.githubToolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 760);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 22, 0);
            this.statusStrip.Size = new System.Drawing.Size(1347, 32);
            this.statusStrip.TabIndex = 14;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(283, 24);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(86, 32);
            this.toolStripStatusLabel1.Text = "行1，列1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(817, 25);
            this.toolStripStatusLabel.Spring = true;
            // 
            // githubToolStripStatusLabel
            // 
            this.githubToolStripStatusLabel.AutoToolTip = true;
            this.githubToolStripStatusLabel.Image = global::ClashSinicizationTool.Properties.Resources.GitHub_Logo;
            this.githubToolStripStatusLabel.IsLink = true;
            this.githubToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.githubToolStripStatusLabel.Name = "githubToolStripStatusLabel";
            this.githubToolStripStatusLabel.Size = new System.Drawing.Size(133, 32);
            this.githubToolStripStatusLabel.Text = "GitHub 地址";
            this.githubToolStripStatusLabel.ToolTipText = "点击进入 GitHub 项目地址。";
            this.githubToolStripStatusLabel.Click += new System.EventHandler(this.GithubToolStripStatusLabel_Click);
            // 
            // translationAndLogSplitContainer
            // 
            this.translationAndLogSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.translationAndLogSplitContainer.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.translationAndLogSplitContainer.Location = new System.Drawing.Point(0, 172);
            this.translationAndLogSplitContainer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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
            this.translationAndLogSplitContainer.Size = new System.Drawing.Size(1347, 589);
            this.translationAndLogSplitContainer.SplitterDistance = 330;
            this.translationAndLogSplitContainer.SplitterWidth = 6;
            this.translationAndLogSplitContainer.TabIndex = 15;
            // 
            // updateTranslationScriptButton
            // 
            this.updateTranslationScriptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateTranslationScriptButton.Location = new System.Drawing.Point(828, 8);
            this.updateTranslationScriptButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.updateTranslationScriptButton.Name = "updateTranslationScriptButton";
            this.updateTranslationScriptButton.Size = new System.Drawing.Size(149, 32);
            this.updateTranslationScriptButton.TabIndex = 3;
            this.updateTranslationScriptButton.Text = "更新脚本文件";
            this.updateTranslationScriptButton.UseVisualStyleBackColor = true;
            this.updateTranslationScriptButton.Click += new System.EventHandler(this.UpdateTranslationScriptButton_Click);
            // 
            // findReplaceButton
            // 
            this.findReplaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findReplaceButton.Location = new System.Drawing.Point(1004, 131);
            this.findReplaceButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.findReplaceButton.Name = "findReplaceButton";
            this.findReplaceButton.Size = new System.Drawing.Size(129, 32);
            this.findReplaceButton.TabIndex = 7;
            this.findReplaceButton.Text = "查找和替换";
            this.findReplaceButton.UseVisualStyleBackColor = true;
            this.findReplaceButton.Click += new System.EventHandler(this.findReplaceButton_Click);
            // 
            // checkTranslationScriptButton
            // 
            this.checkTranslationScriptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkTranslationScriptButton.Location = new System.Drawing.Point(728, 131);
            this.checkTranslationScriptButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkTranslationScriptButton.Name = "checkTranslationScriptButton";
            this.checkTranslationScriptButton.Size = new System.Drawing.Size(149, 32);
            this.checkTranslationScriptButton.TabIndex = 7;
            this.checkTranslationScriptButton.Text = "检查翻译脚本";
            this.checkTranslationScriptButton.UseVisualStyleBackColor = true;
            this.checkTranslationScriptButton.Click += new System.EventHandler(this.checkTranslationScriptButton_Click);
            // 
            // jumpLineButton
            // 
            this.jumpLineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jumpLineButton.Location = new System.Drawing.Point(886, 131);
            this.jumpLineButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.jumpLineButton.Name = "jumpLineButton";
            this.jumpLineButton.Size = new System.Drawing.Size(108, 32);
            this.jumpLineButton.TabIndex = 7;
            this.jumpLineButton.Text = "跳转到行";
            this.jumpLineButton.UseVisualStyleBackColor = true;
            this.jumpLineButton.Click += new System.EventHandler(this.jumpLineButton_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 792);
            this.Controls.Add(this.CheckUpdateButton);
            this.Controls.Add(this.translationAndLogSplitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.clashForWindowsPath);
            this.Controls.Add(this.saveTranslationScriptButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.translationScriptFileName);
            this.Controls.Add(this.CloseClashButton);
            this.Controls.Add(this.OpenClashButton);
            this.Controls.Add(this.checkTranslationScriptButton);
            this.Controls.Add(this.jumpLineButton);
            this.Controls.Add(this.findReplaceButton);
            this.Controls.Add(this.revertButton);
            this.Controls.Add(this.packButton);
            this.Controls.Add(this.sinicizationButton);
            this.Controls.Add(this.unpackButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.updateTranslationScriptButton);
            this.Controls.Add(this.loadTranslationScriptButton);
            this.Controls.Add(this.autoCleanButton);
            this.Controls.Add(this.autoCkeckClashPathButton);
            this.Controls.Add(this.ClashBrowseButton);
            this.Controls.Add(this.openClashBrowseButton);
            this.Controls.Add(this.openTranslationFileButton);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(1358, 823);
            this.Name = "MainForm";
            this.Text = "Clash 汉化工具";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button unpackButton;
        private System.Windows.Forms.Button sinicizationButton;
        private System.Windows.Forms.Button packButton;
        private System.Windows.Forms.Button openTranslationFileButton;
        private System.Windows.Forms.Button openClashBrowseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ComboBox translationScriptFileName;
        private System.Windows.Forms.ComboBox clashForWindowsPath;
        private System.Windows.Forms.Button autoCleanButton;
        private System.Windows.Forms.Button OpenClashButton;
        private System.Windows.Forms.Button revertButton;
        private System.Windows.Forms.Button CloseClashButton;
        private System.Windows.Forms.ContextMenuStrip logBoxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CleanToolStripMenuItem;
        private System.Windows.Forms.Button saveTranslationScriptButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button autoCkeckClashPathButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel githubToolStripStatusLabel;
        private System.Windows.Forms.SplitContainer translationAndLogSplitContainer;
        private System.Windows.Forms.Button updateTranslationScriptButton;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ContextMenuStrip translationScriptRichTextBoxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem translationScriptRichTextBoxMenuStripCopy;
        private System.Windows.Forms.ToolStripMenuItem translationScriptRichTextBoxMenuStripCut;
        private System.Windows.Forms.ToolStripMenuItem translationScriptRichTextBoxMenuStripPaste;
        private System.Windows.Forms.ToolStripMenuItem translationScriptRichTextBoxMenuStripUndo;
        private System.Windows.Forms.Button findReplaceButton;
        private System.Windows.Forms.Button checkTranslationScriptButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button jumpLineButton;
        private System.Windows.Forms.Timer timer;
        public System.Windows.Forms.RichTextBox translationScriptRichTextBox;
        private System.Windows.Forms.Button CheckUpdateButton;
        private System.Windows.Forms.SplitContainer translationAndLineSplitContainer;
        private UserComponents.LineNumberPanel linePanel;
    }
}

