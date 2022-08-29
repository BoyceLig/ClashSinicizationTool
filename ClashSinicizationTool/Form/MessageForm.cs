using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashSinicizationTool
{
    public partial class MessageForm : Form
    {
        private readonly string msgText;
        private readonly string msgTitle;

        public MessageForm(string msgText, string msgTitle)
        {
            InitializeComponent();
            this.msgText = msgText;
            this.msgTitle = msgTitle;
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            this.LabelMsg.Text = msgText;
            this.Text = msgTitle;
        }
    }
}
