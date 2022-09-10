namespace ClashSinicizationTool
{
    partial class FindAndReplaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.downRadioButton = new System.Windows.Forms.RadioButton();
            this.upRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.findNextButton = new System.Windows.Forms.Button();
            this.caseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.replaceButton = new System.Windows.Forms.Button();
            this.replaceAllButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.downRadioButton);
            this.groupBox1.Controls.Add(this.upRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(117, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 62);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "方向";
            // 
            // downRadioButton
            // 
            this.downRadioButton.AutoSize = true;
            this.downRadioButton.Checked = true;
            this.downRadioButton.Location = new System.Drawing.Point(62, 22);
            this.downRadioButton.Name = "downRadioButton";
            this.downRadioButton.Size = new System.Drawing.Size(50, 21);
            this.downRadioButton.TabIndex = 5;
            this.downRadioButton.TabStop = true;
            this.downRadioButton.Text = "向下";
            this.downRadioButton.UseVisualStyleBackColor = true;
            // 
            // upRadioButton
            // 
            this.upRadioButton.AutoSize = true;
            this.upRadioButton.Location = new System.Drawing.Point(6, 22);
            this.upRadioButton.Name = "upRadioButton";
            this.upRadioButton.Size = new System.Drawing.Size(50, 21);
            this.upRadioButton.TabIndex = 5;
            this.upRadioButton.Text = "向上";
            this.upRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "替换内容：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "查找内容：";
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceTextBox.Location = new System.Drawing.Point(86, 33);
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.Size = new System.Drawing.Size(177, 23);
            this.replaceTextBox.TabIndex = 10;
            // 
            // findTextBox
            // 
            this.findTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findTextBox.Location = new System.Drawing.Point(86, 6);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(177, 23);
            this.findTextBox.TabIndex = 11;
            this.findTextBox.TextChanged += new System.EventHandler(this.FindTextBox_TextChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(280, 91);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // findNextButton
            // 
            this.findNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findNextButton.Enabled = false;
            this.findNextButton.Location = new System.Drawing.Point(280, 6);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(88, 23);
            this.findNextButton.TabIndex = 9;
            this.findNextButton.Text = "查找下一个";
            this.findNextButton.UseVisualStyleBackColor = true;
            this.findNextButton.Click += new System.EventHandler(this.FindNextButton_Click);
            // 
            // caseSensitiveCheckBox
            // 
            this.caseSensitiveCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.caseSensitiveCheckBox.AutoSize = true;
            this.caseSensitiveCheckBox.Location = new System.Drawing.Point(12, 77);
            this.caseSensitiveCheckBox.Name = "caseSensitiveCheckBox";
            this.caseSensitiveCheckBox.Size = new System.Drawing.Size(87, 21);
            this.caseSensitiveCheckBox.TabIndex = 15;
            this.caseSensitiveCheckBox.Text = "区分大小写";
            this.caseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // replaceButton
            // 
            this.replaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceButton.Enabled = false;
            this.replaceButton.Location = new System.Drawing.Point(280, 33);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(88, 23);
            this.replaceButton.TabIndex = 9;
            this.replaceButton.Text = "替换";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // replaceAllButton
            // 
            this.replaceAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceAllButton.Enabled = false;
            this.replaceAllButton.Location = new System.Drawing.Point(280, 62);
            this.replaceAllButton.Name = "replaceAllButton";
            this.replaceAllButton.Size = new System.Drawing.Size(88, 23);
            this.replaceAllButton.TabIndex = 9;
            this.replaceAllButton.Text = "全部替换";
            this.replaceAllButton.UseVisualStyleBackColor = true;
            this.replaceAllButton.Click += new System.EventHandler(this.ReplaceAllButton_Click);
            // 
            // FindAndReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(388, 144);
            this.Controls.Add(this.caseSensitiveCheckBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.replaceTextBox);
            this.Controls.Add(this.findTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.replaceAllButton);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.findNextButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(10000, 183);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(404, 183);
            this.Name = "FindAndReplaceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "查找和替换";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FindAndReplaceForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton downRadioButton;
        private System.Windows.Forms.RadioButton upRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox replaceTextBox;
        private System.Windows.Forms.TextBox findTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.CheckBox caseSensitiveCheckBox;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Button replaceAllButton;
    }
}