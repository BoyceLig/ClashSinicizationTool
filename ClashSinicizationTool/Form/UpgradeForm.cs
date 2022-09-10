using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashSinicizationTool
{
    public partial class UpgradeForm : Form
    {
        public UpdateCheck Upgrade { get; private set; }

        private readonly string curVer = Application.ProductVersion.ToString();

        private readonly Form mainForm;

        public UpgradeForm(Form mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            Upgrade = new UpdateCheck(curVer);
            Upgrade.HasUpdated += Upgrade_HasUpdated;
        }

        private void UpgradeForm_Load(object sender, EventArgs e)
        {
            this.CurVerLabel.Text = curVer;
            this.AutoCheckBox.Checked = GlobState.ConfAutoCheck;

            if (GlobState.HadAppUpdate)
            {
                this.RemVerLabel.Text = GlobState.AppUpdateTag;
                this.UpdateAppButton.Text = "更新程序";
                this.UpdateAppButton.Tag = "update";
            }
            else
            {
                this.RemVerLabel.Text = "待检查";
                this.UpdateAppButton.Text = "检查更新";
                this.UpdateAppButton.Tag = "check";
            }
        }

        private void Upgrade_HasUpdated(object sender, bool isU, bool isE)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                this.UpdateAppButton.Enabled = true;

                if (isE)
                {
                    this.RemVerLabel.Text = "检查出错！";
                    this.UpdateAppButton.Text = "检查更新";
                    this.UpdateAppButton.Tag = "check";
                }
                else
                {
                    this.RemVerLabel.Text = this.Upgrade.ToString();
                    if (isU)
                    {
                        this.UpdateAppButton.Text = "更新程序";
                        this.UpdateAppButton.Tag = "update";
                        GlobState.HadAppUpdate = true;
                        GlobState.AppUpdateTag = this.Upgrade.ToString();
                        this.mainForm.Text += $" (存在新版本)";
                    }
                }
            }));
        }

        private void UpdateAppButton_Click(object sender, EventArgs e)
        {
            if (this.UpdateAppButton.Tag.ToString() == "check")
            {
                this.UpdateAppButton.Enabled = false;
                this.RemVerLabel.Text = "检查中...";
                Task task = Task.Run(() => Upgrade.UpdateChecking());
                task.Wait(TimeSpan.FromSeconds(5));
            }
            else if (this.UpdateAppButton.Tag.ToString() == "update")
            {
                DownloadForm df = new DownloadForm(GlobState.AppUpdateTag);
                df.ShowDialog(mainForm);
            }
        }

        private void AutoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GlobState.ConfAutoCheck = (sender as CheckBox).Checked;
            AppConfig.SetValue("AutoCheck", GlobState.ConfAutoCheck ? "1" : "0");
        }
    }
}
