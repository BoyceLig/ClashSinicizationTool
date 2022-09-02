namespace ClashSinicizationTool
{
    partial class UpgradeForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateAppButton = new System.Windows.Forms.Button();
            this.AutoCheckBox = new System.Windows.Forms.CheckBox();
            this.RemVerLabel = new System.Windows.Forms.Label();
            this.CurVerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.0367F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.9633F));
            this.tableLayoutPanel1.Controls.Add(this.UpdateAppButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.AutoCheckBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.RemVerLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.CurVerLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(218, 129);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // UpdateAppButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.UpdateAppButton, 2);
            this.UpdateAppButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpdateAppButton.Location = new System.Drawing.Point(3, 99);
            this.UpdateAppButton.Name = "UpdateAppButton";
            this.UpdateAppButton.Size = new System.Drawing.Size(212, 27);
            this.UpdateAppButton.TabIndex = 1;
            this.UpdateAppButton.Text = "更新程序";
            this.UpdateAppButton.UseVisualStyleBackColor = true;
            this.UpdateAppButton.Click += new System.EventHandler(this.UpdateAppButton_Click);
            // 
            // AutoCheckBox
            // 
            this.AutoCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.AutoCheckBox, 2);
            this.AutoCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoCheckBox.Location = new System.Drawing.Point(25, 67);
            this.AutoCheckBox.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.AutoCheckBox.Name = "AutoCheckBox";
            this.AutoCheckBox.Size = new System.Drawing.Size(190, 26);
            this.AutoCheckBox.TabIndex = 1;
            this.AutoCheckBox.Text = "启动时自动检查更新";
            this.AutoCheckBox.UseVisualStyleBackColor = true;
            this.AutoCheckBox.CheckedChanged += new System.EventHandler(this.AutoCheckBox_CheckedChanged);
            // 
            // RemVerLabel
            // 
            this.RemVerLabel.AutoSize = true;
            this.RemVerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemVerLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemVerLabel.Location = new System.Drawing.Point(99, 32);
            this.RemVerLabel.Name = "RemVerLabel";
            this.RemVerLabel.Size = new System.Drawing.Size(116, 32);
            this.RemVerLabel.TabIndex = 3;
            this.RemVerLabel.Text = "0.0.0";
            this.RemVerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurVerLabel
            // 
            this.CurVerLabel.AutoSize = true;
            this.CurVerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurVerLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurVerLabel.Location = new System.Drawing.Point(99, 0);
            this.CurVerLabel.Name = "CurVerLabel";
            this.CurVerLabel.Size = new System.Drawing.Size(116, 32);
            this.CurVerLabel.TabIndex = 2;
            this.CurVerLabel.Text = "0.0.0";
            this.CurVerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前版本：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "最新版本：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpgradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 129);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpgradeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "检查更新";
            this.Load += new System.EventHandler(this.UpgradeForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label RemVerLabel;
        private System.Windows.Forms.Label CurVerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox AutoCheckBox;
        private System.Windows.Forms.Button UpdateAppButton;
    }
}