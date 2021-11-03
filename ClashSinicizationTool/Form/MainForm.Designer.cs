
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
            this.autoCkeckClashPathButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.logBoxMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // ClashBrowseButton
            // 
            resources.ApplyResources(this.ClashBrowseButton, "ClashBrowseButton");
            this.ClashBrowseButton.Name = "ClashBrowseButton";
            this.toolTip.SetToolTip(this.ClashBrowseButton, resources.GetString("ClashBrowseButton.ToolTip"));
            this.ClashBrowseButton.UseVisualStyleBackColor = true;
            this.ClashBrowseButton.Click += new System.EventHandler(this.ClashBrowseButton_Click);
            // 
            // loadTranslationScriptButton
            // 
            resources.ApplyResources(this.loadTranslationScriptButton, "loadTranslationScriptButton");
            this.loadTranslationScriptButton.Name = "loadTranslationScriptButton";
            this.toolTip.SetToolTip(this.loadTranslationScriptButton, resources.GetString("loadTranslationScriptButton.ToolTip"));
            this.loadTranslationScriptButton.UseVisualStyleBackColor = true;
            this.loadTranslationScriptButton.Click += new System.EventHandler(this.loadTranslationScriptButton_Click);
            // 
            // logTextBox
            // 
            resources.ApplyResources(this.logTextBox, "logTextBox");
            this.logTextBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.logTextBox.ContextMenuStrip = this.logBoxMenuStrip;
            this.logTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.toolTip.SetToolTip(this.logTextBox, resources.GetString("logTextBox.ToolTip"));
            // 
            // logBoxMenuStrip
            // 
            resources.ApplyResources(this.logBoxMenuStrip, "logBoxMenuStrip");
            this.logBoxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToolStripMenuItem,
            this.CleanToolStripMenuItem});
            this.logBoxMenuStrip.Name = "contextMenuStrip";
            this.toolTip.SetToolTip(this.logBoxMenuStrip, resources.GetString("logBoxMenuStrip.ToolTip"));
            // 
            // CopyToolStripMenuItem
            // 
            resources.ApplyResources(this.CopyToolStripMenuItem, "CopyToolStripMenuItem");
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // CleanToolStripMenuItem
            // 
            resources.ApplyResources(this.CleanToolStripMenuItem, "CleanToolStripMenuItem");
            this.CleanToolStripMenuItem.Name = "CleanToolStripMenuItem";
            this.CleanToolStripMenuItem.Click += new System.EventHandler(this.CleanToolStripMenuItem_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.toolTip.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // unpackButton
            // 
            resources.ApplyResources(this.unpackButton, "unpackButton");
            this.unpackButton.Name = "unpackButton";
            this.toolTip.SetToolTip(this.unpackButton, resources.GetString("unpackButton.ToolTip"));
            this.unpackButton.UseVisualStyleBackColor = true;
            this.unpackButton.Click += new System.EventHandler(this.unpackButton_Click);
            // 
            // sinicizationButton
            // 
            resources.ApplyResources(this.sinicizationButton, "sinicizationButton");
            this.sinicizationButton.Name = "sinicizationButton";
            this.toolTip.SetToolTip(this.sinicizationButton, resources.GetString("sinicizationButton.ToolTip"));
            this.sinicizationButton.UseVisualStyleBackColor = true;
            this.sinicizationButton.Click += new System.EventHandler(this.sinicizationButton_Click);
            // 
            // simplifyButton
            // 
            resources.ApplyResources(this.simplifyButton, "simplifyButton");
            this.simplifyButton.Name = "simplifyButton";
            this.toolTip.SetToolTip(this.simplifyButton, resources.GetString("simplifyButton.ToolTip"));
            this.simplifyButton.UseVisualStyleBackColor = true;
            this.simplifyButton.Click += new System.EventHandler(this.simplifyButton_Click);
            // 
            // packButton
            // 
            resources.ApplyResources(this.packButton, "packButton");
            this.packButton.Name = "packButton";
            this.toolTip.SetToolTip(this.packButton, resources.GetString("packButton.ToolTip"));
            this.packButton.UseVisualStyleBackColor = true;
            this.packButton.Click += new System.EventHandler(this.packButton_Click);
            // 
            // openTranslationFileButton
            // 
            resources.ApplyResources(this.openTranslationFileButton, "openTranslationFileButton");
            this.openTranslationFileButton.Name = "openTranslationFileButton";
            this.toolTip.SetToolTip(this.openTranslationFileButton, resources.GetString("openTranslationFileButton.ToolTip"));
            this.openTranslationFileButton.UseVisualStyleBackColor = true;
            this.openTranslationFileButton.Click += new System.EventHandler(this.openTranslationFileButton_Click);
            // 
            // openClashBrowseButton
            // 
            resources.ApplyResources(this.openClashBrowseButton, "openClashBrowseButton");
            this.openClashBrowseButton.Name = "openClashBrowseButton";
            this.toolTip.SetToolTip(this.openClashBrowseButton, resources.GetString("openClashBrowseButton.ToolTip"));
            this.openClashBrowseButton.UseVisualStyleBackColor = true;
            this.openClashBrowseButton.Click += new System.EventHandler(this.openClashBrowseButton_Click);
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // translationScriptText
            // 
            resources.ApplyResources(this.translationScriptText, "translationScriptText");
            this.translationScriptText.Name = "translationScriptText";
            this.toolTip.SetToolTip(this.translationScriptText, resources.GetString("translationScriptText.ToolTip"));
            this.translationScriptText.TextChanged += new System.EventHandler(this.translationScriptText_TextChanged);
            // 
            // saveTranslationScriptButton
            // 
            resources.ApplyResources(this.saveTranslationScriptButton, "saveTranslationScriptButton");
            this.saveTranslationScriptButton.Name = "saveTranslationScriptButton";
            this.toolTip.SetToolTip(this.saveTranslationScriptButton, resources.GetString("saveTranslationScriptButton.ToolTip"));
            this.saveTranslationScriptButton.UseVisualStyleBackColor = true;
            this.saveTranslationScriptButton.Click += new System.EventHandler(this.saveTranslationScriptButton_Click);
            // 
            // translationScriptFileName
            // 
            resources.ApplyResources(this.translationScriptFileName, "translationScriptFileName");
            this.translationScriptFileName.FormattingEnabled = true;
            this.translationScriptFileName.Name = "translationScriptFileName";
            this.toolTip.SetToolTip(this.translationScriptFileName, resources.GetString("translationScriptFileName.ToolTip"));
            this.translationScriptFileName.TextUpdate += new System.EventHandler(this.translationScriptFileName_TextChanged);
            // 
            // clashForWindowsPath
            // 
            resources.ApplyResources(this.clashForWindowsPath, "clashForWindowsPath");
            this.clashForWindowsPath.FormattingEnabled = true;
            this.clashForWindowsPath.Name = "clashForWindowsPath";
            this.toolTip.SetToolTip(this.clashForWindowsPath, resources.GetString("clashForWindowsPath.ToolTip"));
            this.clashForWindowsPath.TextUpdate += new System.EventHandler(this.clashForWindowsPath_TextUpdate);
            // 
            // autoCleanButton
            // 
            resources.ApplyResources(this.autoCleanButton, "autoCleanButton");
            this.autoCleanButton.Name = "autoCleanButton";
            this.toolTip.SetToolTip(this.autoCleanButton, resources.GetString("autoCleanButton.ToolTip"));
            this.autoCleanButton.UseVisualStyleBackColor = true;
            this.autoCleanButton.Click += new System.EventHandler(this.autoCleanButton_Click);
            // 
            // OpenClashButton
            // 
            resources.ApplyResources(this.OpenClashButton, "OpenClashButton");
            this.OpenClashButton.Name = "OpenClashButton";
            this.toolTip.SetToolTip(this.OpenClashButton, resources.GetString("OpenClashButton.ToolTip"));
            this.OpenClashButton.UseVisualStyleBackColor = true;
            this.OpenClashButton.Click += new System.EventHandler(this.OpenClashButton_Click);
            // 
            // revertButton
            // 
            resources.ApplyResources(this.revertButton, "revertButton");
            this.revertButton.Name = "revertButton";
            this.toolTip.SetToolTip(this.revertButton, resources.GetString("revertButton.ToolTip"));
            this.revertButton.UseVisualStyleBackColor = true;
            this.revertButton.Click += new System.EventHandler(this.revertButton_Click);
            // 
            // CloseClashButton
            // 
            resources.ApplyResources(this.CloseClashButton, "CloseClashButton");
            this.CloseClashButton.Name = "CloseClashButton";
            this.toolTip.SetToolTip(this.CloseClashButton, resources.GetString("CloseClashButton.ToolTip"));
            this.CloseClashButton.UseVisualStyleBackColor = true;
            this.CloseClashButton.Click += new System.EventHandler(this.CloseClashButton_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.translationScriptText);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.toolTip.SetToolTip(this.tableLayoutPanel1, resources.GetString("tableLayoutPanel1.ToolTip"));
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.logTextBox);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // autoCkeckClashPathButton
            // 
            resources.ApplyResources(this.autoCkeckClashPathButton, "autoCkeckClashPathButton");
            this.autoCkeckClashPathButton.Name = "autoCkeckClashPathButton";
            this.toolTip.SetToolTip(this.autoCkeckClashPathButton, resources.GetString("autoCkeckClashPathButton.ToolTip"));
            this.autoCkeckClashPathButton.UseVisualStyleBackColor = true;
            this.autoCkeckClashPathButton.Click += new System.EventHandler(this.autoCkeckClashPathButton_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Controls.Add(this.autoCkeckClashPathButton);
            this.Controls.Add(this.ClashBrowseButton);
            this.Controls.Add(this.openClashBrowseButton);
            this.Controls.Add(this.openTranslationFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
        private System.Windows.Forms.Button autoCkeckClashPathButton;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

