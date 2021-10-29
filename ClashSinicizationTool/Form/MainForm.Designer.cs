
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
            this.simplifyButton = new System.Windows.Forms.Button();
            this.packButton = new System.Windows.Forms.Button();
            this.openTranslationFileButton = new System.Windows.Forms.Button();
            this.openClashBrowseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.translationScriptText = new System.Windows.Forms.TextBox();
            this.saveTranslationScriptButton = new System.Windows.Forms.Button();
            this.translationScriptFileName = new System.Windows.Forms.ComboBox();
            this.clashForWindowsPath = new System.Windows.Forms.ComboBox();
            this.autoCleanButton = new System.Windows.Forms.Button();
            this.OpenClashButton = new System.Windows.Forms.Button();
            this.revertButton = new System.Windows.Forms.Button();
            this.CloseClashButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.logBoxMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "翻译脚本：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clash For Windows 路径：";
            // 
            // ClashBrowseButton
            // 
            this.ClashBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClashBrowseButton.Location = new System.Drawing.Point(770, 35);
            this.ClashBrowseButton.Name = "ClashBrowseButton";
            this.ClashBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.ClashBrowseButton.TabIndex = 3;
            this.ClashBrowseButton.Text = "浏览";
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
            this.loadTranslationScriptButton.UseVisualStyleBackColor = true;
            this.loadTranslationScriptButton.Click += new System.EventHandler(this.loadTranslationScriptButton_Click);
            // 
            // logBoxMenuStrip
            // 
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "请严格按照顺序点击，否则可能不成功";
            // 
            // unpackButton
            // 
            this.unpackButton.Enabled = false;
            this.unpackButton.Location = new System.Drawing.Point(12, 96);
            this.unpackButton.Name = "unpackButton";
            this.unpackButton.Size = new System.Drawing.Size(75, 23);
            this.unpackButton.TabIndex = 7;
            this.unpackButton.Text = "1. 解包";
            this.unpackButton.UseVisualStyleBackColor = true;
            this.unpackButton.Click += new System.EventHandler(this.unpackButton_Click);
            // 
            // sinicizationButton
            // 
            this.sinicizationButton.Enabled = false;
            this.sinicizationButton.Location = new System.Drawing.Point(93, 96);
            this.sinicizationButton.Name = "sinicizationButton";
            this.sinicizationButton.Size = new System.Drawing.Size(75, 23);
            this.sinicizationButton.TabIndex = 7;
            this.sinicizationButton.Text = "2-1. 汉化";
            this.sinicizationButton.UseVisualStyleBackColor = true;
            this.sinicizationButton.Click += new System.EventHandler(this.sinicizationButton_Click);
            // 
            // simplifyButton
            // 
            this.simplifyButton.Enabled = false;
            this.simplifyButton.Location = new System.Drawing.Point(177, 96);
            this.simplifyButton.Name = "simplifyButton";
            this.simplifyButton.Size = new System.Drawing.Size(283, 23);
            this.simplifyButton.TabIndex = 7;
            this.simplifyButton.Text = "2-2. 精简包体（慎点，删除无用文件）（可选）";
            this.simplifyButton.UseVisualStyleBackColor = true;
            this.simplifyButton.Click += new System.EventHandler(this.simplifyButton_Click);
            // 
            // packButton
            // 
            this.packButton.Enabled = false;
            this.packButton.Location = new System.Drawing.Point(466, 96);
            this.packButton.Name = "packButton";
            this.packButton.Size = new System.Drawing.Size(75, 23);
            this.packButton.TabIndex = 7;
            this.packButton.Text = "3. 打包";
            this.packButton.UseVisualStyleBackColor = true;
            this.packButton.Click += new System.EventHandler(this.packButton_Click);
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
            this.openTranslationFileButton.UseVisualStyleBackColor = true;
            this.openTranslationFileButton.Click += new System.EventHandler(this.openTranslationFileButton_Click);
            // 
            // openClashBrowseButton
            // 
            this.openClashBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openClashBrowseButton.Enabled = false;
            this.openClashBrowseButton.Location = new System.Drawing.Point(628, 35);
            this.openClashBrowseButton.Name = "openClashBrowseButton";
            this.openClashBrowseButton.Size = new System.Drawing.Size(136, 23);
            this.openClashBrowseButton.TabIndex = 2;
            this.openClashBrowseButton.Text = "打开 Clash 目录";
            this.openClashBrowseButton.UseVisualStyleBackColor = true;
            this.openClashBrowseButton.Click += new System.EventHandler(this.openClashBrowseButton_Click);
            // 
            // translationScriptFileName
            // 
            this.translationScriptFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.translationScriptFileName.FormattingEnabled = true;
            this.translationScriptFileName.Location = new System.Drawing.Point(86, 6);
            this.translationScriptFileName.Name = "translationScriptFileName";
            this.translationScriptFileName.Size = new System.Drawing.Size(537, 25);
            this.translationScriptFileName.TabIndex = 10;
            this.translationScriptFileName.TextUpdate += new System.EventHandler(this.translationScriptFileName_SelectedIndexChanged);
            // 
            // clashForWindowsPath
            // 
            this.clashForWindowsPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clashForWindowsPath.FormattingEnabled = true;
            this.clashForWindowsPath.Location = new System.Drawing.Point(177, 33);
            this.clashForWindowsPath.Name = "clashForWindowsPath";
            this.clashForWindowsPath.Size = new System.Drawing.Size(446, 25);
            this.clashForWindowsPath.TabIndex = 10;
            this.clashForWindowsPath.TextUpdate += new System.EventHandler(this.clashForWindowsPath_TextUpdate);
            // 
            // autoCleanButton
            // 
            this.autoCleanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoCleanButton.Location = new System.Drawing.Point(385, 64);
            this.autoCleanButton.Name = "autoCleanButton";
            this.autoCleanButton.Size = new System.Drawing.Size(106, 23);
            this.autoCleanButton.TabIndex = 3;
            this.autoCleanButton.Text = "清理失效列表";
            this.autoCleanButton.UseVisualStyleBackColor = true;
            this.autoCleanButton.Click += new System.EventHandler(this.autoCleanButton_Click);
            // 
            // OpenClashButton
            // 
            this.OpenClashButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenClashButton.Location = new System.Drawing.Point(497, 64);
            this.OpenClashButton.Name = "OpenClashButton";
            this.OpenClashButton.Size = new System.Drawing.Size(171, 23);
            this.OpenClashButton.TabIndex = 7;
            this.OpenClashButton.Text = "打开 Clash for Windows";
            this.OpenClashButton.UseVisualStyleBackColor = true;
            this.OpenClashButton.Click += new System.EventHandler(this.OpenClashButton_Click);
            // 
            // revertButton
            // 
            this.revertButton.Enabled = false;
            this.revertButton.Location = new System.Drawing.Point(547, 96);
            this.revertButton.Name = "revertButton";
            this.revertButton.Size = new System.Drawing.Size(75, 23);
            this.revertButton.TabIndex = 7;
            this.revertButton.Text = "4. 还原";
            this.revertButton.UseVisualStyleBackColor = true;
            this.revertButton.Click += new System.EventHandler(this.revertButton_Click);
            // 
            // CloseClashButton
            // 
            this.CloseClashButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseClashButton.Location = new System.Drawing.Point(674, 64);
            this.CloseClashButton.Name = "CloseClashButton";
            this.CloseClashButton.Size = new System.Drawing.Size(171, 23);
            this.CloseClashButton.TabIndex = 7;
            this.CloseClashButton.Text = "关闭 Clash for Windows";
            this.CloseClashButton.UseVisualStyleBackColor = true;
            this.CloseClashButton.Click += new System.EventHandler(this.CloseClashButton_Click);
            // 
            // saveTranslationScriptButton
            // 
            this.saveTranslationScriptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTranslationScriptButton.Enabled = false;
            this.saveTranslationScriptButton.Location = new System.Drawing.Point(727, 96);
            this.saveTranslationScriptButton.Name = "saveTranslationScriptButton";
            this.saveTranslationScriptButton.Size = new System.Drawing.Size(118, 23);
            this.saveTranslationScriptButton.TabIndex = 3;
            this.saveTranslationScriptButton.Text = "保存当前翻译脚本";
            this.saveTranslationScriptButton.UseVisualStyleBackColor = true;
            this.saveTranslationScriptButton.Click += new System.EventHandler(this.saveTranslationScriptButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.translationScriptText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(851, 218);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "翻译脚本信息";
            // 
            // translationScriptText
            // 
            this.translationScriptText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.translationScriptText.Location = new System.Drawing.Point(3, 19);
            this.translationScriptText.MaxLength = 0;
            this.translationScriptText.Multiline = true;
            this.translationScriptText.Name = "translationScriptText";
            this.translationScriptText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.translationScriptText.Size = new System.Drawing.Size(845, 196);
            this.translationScriptText.TabIndex = 8;
            this.translationScriptText.WordWrap = false;
            this.translationScriptText.TextChanged += new System.EventHandler(this.translationScriptText_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 125);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(857, 408);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.logTextBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(851, 178);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志信息";
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
            this.logTextBox.Size = new System.Drawing.Size(845, 156);
            this.logTextBox.TabIndex = 4;
            this.logTextBox.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 533);
            this.Controls.Add(this.clashForWindowsPath);
            this.Controls.Add(this.saveTranslationScriptButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.translationScriptFileName);
            this.Controls.Add(this.CloseClashButton);
            this.Controls.Add(this.OpenClashButton);
            this.Controls.Add(this.revertButton);
            this.Controls.Add(this.packButton);
            this.Controls.Add(this.simplifyButton);
            this.Controls.Add(this.sinicizationButton);
            this.Controls.Add(this.unpackButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.loadTranslationScriptButton);
            this.Controls.Add(this.autoCleanButton);
            this.Controls.Add(this.ClashBrowseButton);
            this.Controls.Add(this.openClashBrowseButton);
            this.Controls.Add(this.openTranslationFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(873, 572);
            this.Name = "MainForm";
            this.Text = "Clash 汉化工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.logBoxMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button simplifyButton;
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
        private System.Windows.Forms.TextBox translationScriptText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox logTextBox;
    }
}

