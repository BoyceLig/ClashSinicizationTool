//参考来自 https://www.pianshen.com/article/4661394269/
using System;
using System.Windows.Forms;

namespace ClashSinicizationTool
{
    public partial class FindAndReplaceForm : Form
    {
        MainForm mainForm;
        int start = 0, sun = 0, count = 0;

        public FindAndReplaceForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        //加载时
        private void FindAndReplaceForm_Load(object sender, EventArgs e)
        {
            downRadioButton.Checked = true;
        }

        //查找下一个
        private void FindNextButton_Click(object sender, EventArgs e)
        {
            RichTextBox rbox = mainForm.translationScriptRichTextBox;
            string str = findTextBox.Text;
            if (caseSensitiveCheckBox.Checked)//是否开启区分大小写功能
            {
                FindDownM(rbox, str);//向下查找
            }
            else
            {
                if (downRadioButton.Checked)
                {
                    FindDown(rbox, str);
                }
                else
                {
                    FindUp(rbox, str);//向上查找
                }
            }

        }

        //替换按钮
        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            string str0 = findTextBox.Text, str1 = replaceTextBox.Text;
            replace(str0, str1);
            FindNextButton_Click(sender, e);
        }

        //替换全部按钮
        private void ReplaceAllButton_Click(object sender, EventArgs e)
        {
            RichTextBox rbox = mainForm.translationScriptRichTextBox;
            string str0 = findTextBox.Text, str1 = replaceTextBox.Text;
            ReplaceAll(rbox, str0, str1);
        }

        //取消按钮
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (findTextBox.Text != string.Empty)
            {
                findNextButton.Enabled = true;
                replaceButton.Enabled = true;
                replaceAllButton.Enabled = true;
            }
        }









        private void FindUp(RichTextBox rbox, string str)
        {
            int rbox1 = rbox.SelectionStart;
            int index = rbox.Find(str, 0, rbox1, RichTextBoxFinds.Reverse);
            if (index > -1)
            {
                rbox.SelectionStart = index;
                rbox.SelectionLength = str.Length;
                sun++;
                rbox.Focus();
            }
            else if (index < 0)
            {
                seeks(str);
                sun = 0;
                // rbox.SelectionStart = rbox.Text.Length;
            }
        }
        private void FindDown(RichTextBox rbox, string str)
        {
            int rbox1 = rbox.Text.Length;
            if (start < rbox1)
            {
                start = rbox.Find(str, start, RichTextBoxFinds.None);
                int los = rbox.SelectionStart + str.Length;
                if ((start < 0) || (start > rbox1))
                {
                    if (count == 0)
                    {
                        seeks(str);
                        start = los;
                        sun = 0;
                    }
                    else
                    {
                        seeks(str);
                        start = los;
                        sun = 0;
                    }
                }
                else if (start == rbox1 || start < 0)
                {
                    seeks(str);
                    start = los;
                    sun = 0;
                }
                else
                {
                    sun++;
                    start = los;
                    rbox.Focus();
                }
            }
            else if (start == rbox1 || start < 0)
            {
                int los = rbox.SelectionStart + str.Length;
                seeks(str);
                start = los;
                sun = 0;
            }
            else
            {
                int los = rbox.SelectionStart + str.Length;
                seeks(str);
                start = los;
                sun = 0;
            }
        }
        private void FindDownM(RichTextBox rbox, string str)
        {
            int rbox1 = rbox.Text.Length;
            if (start < rbox1)
            {
                start = rbox.Find(str, start, RichTextBoxFinds.MatchCase);
                int los = rbox.SelectionStart + str.Length;
                if ((start < 0) || (start > rbox1))
                {
                    if (count == 0)
                    {
                        seeks(str);
                        start = los;
                        sun = 0;
                    }
                    else
                    {
                        seeks(str);
                        start = los;
                        sun = 0;
                    }
                }
                else if (start == rbox1 || start < 0)
                {
                    seeks(str);
                    start = los;
                    sun = 0;
                }
                else
                {
                    sun++;
                    start = los;
                    rbox.Focus();
                }
            }
            else if (start == rbox1 || start < 0)
            {
                int los = rbox.SelectionStart + str.Length;
                seeks(str);
                start = los;
                sun = 0;
            }
            else
            {
                int los = rbox.SelectionStart + str.Length;
                seeks(str);
                start = los;
                sun = 0;
            }
        }
        //查找完毕后的弹窗
        private void seeks(string str)
        {
            if (sun != 0)
            {
                MessageBox.Show(string.Format("查找完毕，共[{0}]个\"{1}\"!", sun, str), "查找—温馨提示");
            }
            else
            {
                MessageBox.Show(String.Format("\"{0}\"!", str), "查找—温馨提示");
            }
        }



        //替换全部的函数
        private void ReplaceAll(RichTextBox rbox, string str0, string str1)
        {
            rbox.Text = rbox.Text.Replace(str0, str1);
        }
        private void replace(string str0, string str1)
        {
            RichTextBox rbox = mainForm.translationScriptRichTextBox;
            rbox.SelectionLength = str0.Length;
            rbox.SelectedText = str1;
        }
    }




}

