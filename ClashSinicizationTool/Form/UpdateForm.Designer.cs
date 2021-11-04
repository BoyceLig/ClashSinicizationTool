
namespace ClashSinicizationTool
{
    partial class UpdateForm
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.stateLabel = new System.Windows.Forms.Label();
            this.manualUpdateButton = new System.Windows.Forms.Button();
            this.retryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(42, 69);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(314, 23);
            this.progressBar.TabIndex = 0;
            // 
            // stateLabel
            // 
            this.stateLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stateLabel.Location = new System.Drawing.Point(42, 26);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(314, 24);
            this.stateLabel.TabIndex = 1;
            this.stateLabel.Text = "下载中……";
            this.stateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // manualUpdateButton
            // 
            this.manualUpdateButton.Location = new System.Drawing.Point(79, 111);
            this.manualUpdateButton.Name = "manualUpdateButton";
            this.manualUpdateButton.Size = new System.Drawing.Size(117, 23);
            this.manualUpdateButton.TabIndex = 2;
            this.manualUpdateButton.Text = "手动下载";
            this.manualUpdateButton.UseVisualStyleBackColor = true;
            this.manualUpdateButton.Click += new System.EventHandler(this.manualUpdateButton_Click);
            // 
            // retryButton
            // 
            this.retryButton.Location = new System.Drawing.Point(202, 111);
            this.retryButton.Name = "retryButton";
            this.retryButton.Size = new System.Drawing.Size(117, 23);
            this.retryButton.TabIndex = 2;
            this.retryButton.Text = "重试";
            this.retryButton.UseVisualStyleBackColor = true;
            this.retryButton.Click += new System.EventHandler(this.retryButton_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 160);
            this.Controls.Add(this.retryButton);
            this.Controls.Add(this.manualUpdateButton);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.progressBar);
            this.Name = "UpdateForm";
            this.Text = "自动更新";
            this.Load += new System.EventHandler(this.Update_Load);
            this.Shown += new System.EventHandler(this.UpdateForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Button manualUpdateButton;
        private System.Windows.Forms.Button retryButton;
    }
}