using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashSinicizationTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //加载时执行
        private void MainForm_Load(object sender, EventArgs e)
        {

        }



        //点击清理按钮时执行清空log窗口
        private void CleanLogButton_Click(object sender, EventArgs e)
        {
            logTextBox.Text = string.Empty;
        }


    }
}
