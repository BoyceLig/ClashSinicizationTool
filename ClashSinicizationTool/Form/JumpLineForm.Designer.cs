namespace ClashSinicizationTool
{
    partial class JumpLineForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.targetLineNumberTextBox = new System.Windows.Forms.TextBox();
            this.targetingButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标行号：";
            // 
            // targetLineNumberTextBox
            // 
            this.targetLineNumberTextBox.Location = new System.Drawing.Point(86, 6);
            this.targetLineNumberTextBox.Name = "targetLineNumberTextBox";
            this.targetLineNumberTextBox.Size = new System.Drawing.Size(91, 23);
            this.targetLineNumberTextBox.TabIndex = 1;
            this.targetLineNumberTextBox.TextChanged += new System.EventHandler(this.targetLineNumberTextBox_TextChanged);
            this.targetLineNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.targetLineNumberTextBox_KeyPress);
            // 
            // targetingButton
            // 
            this.targetingButton.Enabled = false;
            this.targetingButton.Location = new System.Drawing.Point(183, 6);
            this.targetingButton.Name = "targetingButton";
            this.targetingButton.Size = new System.Drawing.Size(75, 23);
            this.targetingButton.TabIndex = 2;
            this.targetingButton.Text = "定位";
            this.targetingButton.UseVisualStyleBackColor = true;
            this.targetingButton.Click += new System.EventHandler(this.targetingButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(183, 35);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // JumpLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 71);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.targetingButton);
            this.Controls.Add(this.targetLineNumberTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JumpLineForm";
            this.ShowIcon = false;
            this.Text = "跳转到行";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox targetLineNumberTextBox;
        private System.Windows.Forms.Button targetingButton;
        private System.Windows.Forms.Button cancelButton;
    }
}