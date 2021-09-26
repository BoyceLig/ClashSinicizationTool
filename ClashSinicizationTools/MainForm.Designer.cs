
namespace ClashSinicizationTools
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
            this.label1 = new System.Windows.Forms.Label();
            this.translationScriptBrowseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ClashBrowseButton = new System.Windows.Forms.Button();
            this.autoClashPathButton = new System.Windows.Forms.Button();
            this.autoTranslationButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CleanLogButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.unpackButton = new System.Windows.Forms.Button();
            this.sinicizationButton = new System.Windows.Forms.Button();
            this.simplifyButton = new System.Windows.Forms.Button();
            this.packButton = new System.Windows.Forms.Button();
            this.openTranslationFileButton = new System.Windows.Forms.Button();
            this.openClashBrowseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.translationScriptText = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.saveTranslationScriptButton = new System.Windows.Forms.Button();
            this.translationScriptPath = new System.Windows.Forms.ComboBox();
            this.clashForWindowsPath = new System.Windows.Forms.ComboBox();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "翻译脚本：";
            // 
            // translationScriptBrowseButton
            // 
            this.translationScriptBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.translationScriptBrowseButton.Location = new System.Drawing.Point(682, 6);
            this.translationScriptBrowseButton.Name = "translationScriptBrowseButton";
            this.translationScriptBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.translationScriptBrowseButton.TabIndex = 2;
            this.translationScriptBrowseButton.Text = "浏览";
            this.translationScriptBrowseButton.UseVisualStyleBackColor = true;
            this.translationScriptBrowseButton.Click += new System.EventHandler(this.translationScriptBrowseButton_Click);
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
            this.ClashBrowseButton.Location = new System.Drawing.Point(682, 35);
            this.ClashBrowseButton.Name = "ClashBrowseButton";
            this.ClashBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.ClashBrowseButton.TabIndex = 3;
            this.ClashBrowseButton.Text = "浏览";
            this.ClashBrowseButton.UseVisualStyleBackColor = true;
            this.ClashBrowseButton.Click += new System.EventHandler(this.ClashBrowseButton_Click);
            // 
            // autoClashPathButton
            // 
            this.autoClashPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoClashPathButton.Location = new System.Drawing.Point(763, 35);
            this.autoClashPathButton.Name = "autoClashPathButton";
            this.autoClashPathButton.Size = new System.Drawing.Size(75, 23);
            this.autoClashPathButton.TabIndex = 3;
            this.autoClashPathButton.Text = "自动检测";
            this.autoClashPathButton.UseVisualStyleBackColor = true;
            // 
            // autoTranslationButton
            // 
            this.autoTranslationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoTranslationButton.Location = new System.Drawing.Point(763, 6);
            this.autoTranslationButton.Name = "autoTranslationButton";
            this.autoTranslationButton.Size = new System.Drawing.Size(75, 23);
            this.autoTranslationButton.TabIndex = 3;
            this.autoTranslationButton.Text = "自动检测";
            this.autoTranslationButton.UseVisualStyleBackColor = true;
            this.autoTranslationButton.Click += new System.EventHandler(this.autoTranslationButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.logTextBox.Location = new System.Drawing.Point(0, 344);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(850, 157);
            this.logTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "日志信息：";
            // 
            // CleanLogButton
            // 
            this.CleanLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CleanLogButton.Location = new System.Drawing.Point(775, 321);
            this.CleanLogButton.Name = "CleanLogButton";
            this.CleanLogButton.Size = new System.Drawing.Size(75, 23);
            this.CleanLogButton.TabIndex = 3;
            this.CleanLogButton.Text = "清空日志";
            this.CleanLogButton.UseVisualStyleBackColor = true;
            this.CleanLogButton.Click += new System.EventHandler(this.CleanLogButton_Click);
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
            this.unpackButton.Location = new System.Drawing.Point(12, 96);
            this.unpackButton.Name = "unpackButton";
            this.unpackButton.Size = new System.Drawing.Size(75, 23);
            this.unpackButton.TabIndex = 7;
            this.unpackButton.Text = "1. 解包";
            this.unpackButton.UseVisualStyleBackColor = true;
            // 
            // sinicizationButton
            // 
            this.sinicizationButton.Location = new System.Drawing.Point(93, 96);
            this.sinicizationButton.Name = "sinicizationButton";
            this.sinicizationButton.Size = new System.Drawing.Size(75, 23);
            this.sinicizationButton.TabIndex = 7;
            this.sinicizationButton.Text = "2-1. 汉化";
            this.sinicizationButton.UseVisualStyleBackColor = true;
            // 
            // simplifyButton
            // 
            this.simplifyButton.Location = new System.Drawing.Point(177, 96);
            this.simplifyButton.Name = "simplifyButton";
            this.simplifyButton.Size = new System.Drawing.Size(283, 23);
            this.simplifyButton.TabIndex = 7;
            this.simplifyButton.Text = "2-2. 精简包体（慎点，删除无用文件）（可选）";
            this.simplifyButton.UseVisualStyleBackColor = true;
            // 
            // packButton
            // 
            this.packButton.Location = new System.Drawing.Point(466, 96);
            this.packButton.Name = "packButton";
            this.packButton.Size = new System.Drawing.Size(75, 23);
            this.packButton.TabIndex = 7;
            this.packButton.Text = "3. 打包";
            this.packButton.UseVisualStyleBackColor = true;
            // 
            // openTranslationFileButton
            // 
            this.openTranslationFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openTranslationFileButton.Enabled = false;
            this.openTranslationFileButton.Location = new System.Drawing.Point(540, 6);
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
            this.openClashBrowseButton.Location = new System.Drawing.Point(540, 35);
            this.openClashBrowseButton.Name = "openClashBrowseButton";
            this.openClashBrowseButton.Size = new System.Drawing.Size(136, 23);
            this.openClashBrowseButton.TabIndex = 2;
            this.openClashBrowseButton.Text = "打开当前目录";
            this.openClashBrowseButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // translationScriptText
            // 
            this.translationScriptText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.translationScriptText.Location = new System.Drawing.Point(0, 147);
            this.translationScriptText.Multiline = true;
            this.translationScriptText.Name = "translationScriptText";
            this.translationScriptText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.translationScriptText.Size = new System.Drawing.Size(850, 174);
            this.translationScriptText.TabIndex = 8;
            this.translationScriptText.TextChanged += new System.EventHandler(this.translationScriptText_TextChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 501);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(850, 22);
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "当前进度";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 16);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "翻译脚本信息";
            // 
            // saveTranslationScriptButton
            // 
            this.saveTranslationScriptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTranslationScriptButton.Enabled = false;
            this.saveTranslationScriptButton.Location = new System.Drawing.Point(732, 123);
            this.saveTranslationScriptButton.Name = "saveTranslationScriptButton";
            this.saveTranslationScriptButton.Size = new System.Drawing.Size(118, 23);
            this.saveTranslationScriptButton.TabIndex = 3;
            this.saveTranslationScriptButton.Text = "保存当前翻译脚本";
            this.saveTranslationScriptButton.UseVisualStyleBackColor = true;
            this.saveTranslationScriptButton.Click += new System.EventHandler(this.saveTranslationScriptButton_Click);
            // 
            // translationScriptPath
            // 
            this.translationScriptPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.translationScriptPath.FormattingEnabled = true;
            this.translationScriptPath.Location = new System.Drawing.Point(86, 6);
            this.translationScriptPath.Name = "translationScriptPath";
            this.translationScriptPath.Size = new System.Drawing.Size(448, 25);
            this.translationScriptPath.TabIndex = 10;
            this.translationScriptPath.TextUpdate += new System.EventHandler(this.translationScriptPath_TextChanged);
            // 
            // clashForWindowsPath
            // 
            this.clashForWindowsPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clashForWindowsPath.FormattingEnabled = true;
            this.clashForWindowsPath.Location = new System.Drawing.Point(177, 33);
            this.clashForWindowsPath.Name = "clashForWindowsPath";
            this.clashForWindowsPath.Size = new System.Drawing.Size(357, 25);
            this.clashForWindowsPath.TabIndex = 10;
            this.clashForWindowsPath.TextUpdate += new System.EventHandler(this.clashForWindowsPath_TextUpdate);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 523);
            this.Controls.Add(this.clashForWindowsPath);
            this.Controls.Add(this.translationScriptPath);
            this.Controls.Add(this.translationScriptText);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.packButton);
            this.Controls.Add(this.simplifyButton);
            this.Controls.Add(this.sinicizationButton);
            this.Controls.Add(this.unpackButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.autoTranslationButton);
            this.Controls.Add(this.CleanLogButton);
            this.Controls.Add(this.saveTranslationScriptButton);
            this.Controls.Add(this.autoClashPathButton);
            this.Controls.Add(this.ClashBrowseButton);
            this.Controls.Add(this.openClashBrowseButton);
            this.Controls.Add(this.openTranslationFileButton);
            this.Controls.Add(this.translationScriptBrowseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Clash 汉化工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button translationScriptBrowseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ClashBrowseButton;
        private System.Windows.Forms.Button autoClashPathButton;
        private System.Windows.Forms.Button autoTranslationButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CleanLogButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button unpackButton;
        private System.Windows.Forms.Button sinicizationButton;
        private System.Windows.Forms.Button simplifyButton;
        private System.Windows.Forms.Button packButton;
        private System.Windows.Forms.Button openTranslationFileButton;
        private System.Windows.Forms.Button openClashBrowseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox translationScriptText;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Button saveTranslationScriptButton;
        private System.Windows.Forms.ComboBox translationScriptPath;
        private System.Windows.Forms.ComboBox clashForWindowsPath;
    }
}

