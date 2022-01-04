using System;
using System.Windows.Forms;

namespace ClashSinicizationTool
{
    public partial class JumpLineForm : Form
    {
        MainForm mainForm;
        public JumpLineForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void targetLineNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && this.targetLineNumberTextBox.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }

            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void targetingButton_Click(object sender, EventArgs e)
        {
            mainForm.translationScriptRichTextBox.SelectionStart = mainForm.translationScriptRichTextBox.GetFirstCharIndexFromLine(Convert.ToInt16(targetLineNumberTextBox.Text) - 1);
            mainForm.translationScriptRichTextBox.SelectionLength = 0;
            mainForm.translationScriptRichTextBox.Focus();
            mainForm.translationScriptRichTextBox.ScrollToCaret();
        }

        private void targetLineNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (targetLineNumberTextBox.Text != string.Empty)
            {
                if (Convert.ToInt16(targetLineNumberTextBox.Text) > mainForm.translationScriptRichTextBox.Lines.Length || Convert.ToInt16(targetLineNumberTextBox.Text) == 0)
                {
                    targetingButton.Enabled = false;
                }
                else
                {
                    targetingButton.Enabled = true;
                }
            }
            else
            {
                targetingButton.Enabled = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
