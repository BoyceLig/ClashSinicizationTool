using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ClashSinicizationTool.UserComponents
{
    public partial class LineNumberPanel : UserControl
    {
        #region 基础变量
        /// <summary>
        /// 最大行号
        /// - 默认为 1
        /// </summary>
        protected int lLargeNumber = 1;

        /// <summary>
        /// 行间距
        /// - 默认为 10
        /// </summary>
        protected int lSpace = 10;

        /// <summary>
        /// 最底部位置
        /// - 即最大行号值所在位置
        /// - 默认为 1
        /// </summary>
        protected int lBottomPosition = 1;

        /// <summary>
        /// 行号的位数
        /// - 限制至少为 1 位
        /// </summary>
        protected int lDigit = 1;
        #endregion

        #region 内部变量
        private readonly StringFormat format = new StringFormat()
        {
            Alignment = StringAlignment.Far,
            LineAlignment = StringAlignment.Center,
        };
        private int controlWidth
        {
            get
            {
                return (int)Math.Ceiling(Font.Size * (lDigit + 0.1f));
            }
        }
        #endregion

        #region 公开属性
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(1), Category("行为"), Description("获取或设置最大行号值")]
        public int LargeNumber
        {
            get { return lLargeNumber; }
            set
            {
                int oldValue = lLargeNumber;
                lLargeNumber = value;
                if (oldValue != value)
                {
                    Invalidate();
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(10), Category("行为"), Description("获取或设置行间距")]
        public int Space
        {
            get { return lSpace; }
            set
            {
                int oldValue = lSpace;
                lSpace = value;
                if (oldValue != value)
                {
                    Invalidate();
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(1), Category("行为"), Description("获取或设置最底部位置")]
        public int BottomPosition
        {
            get { return lBottomPosition; }
            set
            {
                int oldValue = lBottomPosition;
                lBottomPosition = value;
                if (oldValue != value)
                {
                    Invalidate();
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(1), Category("行为"), Description("获取或设置行号的位数，至少为 1 位")]
        public int Digit
        {
            get { return lDigit; }
            set
            {
                int oldValue = lDigit;
                lDigit = value >= 1 ? value : 1;
                if (oldValue != lDigit)
                {
                    Invalidate();
                }
            }
        }
        #endregion

        public LineNumberPanel()
        {
            InitializeComponent();
        }

        public LineNumberPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        public int GetControlWidth()
        {
            return controlWidth;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;

            SolidBrush bBrush = new SolidBrush(BackColor);
            g.FillRectangle(bBrush, new Rectangle(new Point(0, 0), new Size(this.Width, this.Height)));

            if (lBottomPosition > 0)
            {
                SolidBrush tBrush = new SolidBrush(ForeColor);
                for (int pos = lBottomPosition, num = lLargeNumber; pos >= -lSpace && num > 0; pos -= lSpace, num--)
                {
                    g.DrawString(num.ToString(), Font, tBrush, new Rectangle(new Point(0, pos), new Size(this.Width, lSpace)), format);
                }
            }
        }
    }
}
