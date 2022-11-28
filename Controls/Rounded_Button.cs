using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AccCheck.Controls
{
    public class Rounded_Button : Control
    {
        private StringFormat SF = new StringFormat();

        private bool MouseEntered = false;
        public bool Mousepressed = false;

        private bool roundingEnable = false;
        [Description("Вкл/Выкл закругление объекта")]
        public bool RoundingEnable
        { 
            get => roundingEnable;
            set
            { 
                roundingEnable = value;
                Refresh();
            }
        }
        private int roundingPercent = 100;
        [DisplayName("Rounding [%]")]
        [DefaultValue(100)]
        [Description("Указывает радиус закругления объекта в процентном соотношении")]
        public int Rounding
        {
            get => roundingPercent;
            set
            {
                if (value >= 0 && value <= 100)
                {
                    roundingPercent = value;

                    Refresh();
                }
            }
        }
        public Rounded_Button()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(100, 30);

            Font = new Font("Verdana", 8.25F, FontStyle.Regular);

            BackColor = Color.Tomato;
            ForeColor = Color.White;

            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            //Закругление
            float roundingValue = 0.1F;
            if (RoundingEnable && roundingPercent > 0)
            {
                roundingValue = Height / 100F * roundingPercent;
            }
            GraphicsPath rectPath = Drawer.RoundedRectangle(rect, roundingValue);

            graph.DrawPath(new Pen(BackColor), rectPath);
            graph.FillPath(new SolidBrush(BackColor), rectPath);

            graph.SetClip(rectPath);

            if (MouseEntered)
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(60, Color.White)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.White)), rect);
            }

            if (Mousepressed == true)
            {
                Form1.MousePressed = true;
                graph.DrawRectangle(new Pen(Color.FromArgb(255, 52, 73, 94)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(255, 52, 73, 94)), rect);

                Mousepressed = false;
                Form1.GlobalBody();
            }

            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rect, SF);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            MouseEntered = true;

            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            MouseEntered = false;

            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Mousepressed = true;

            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            Mousepressed = false;

            Invalidate();
        }
    }
}
