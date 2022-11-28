using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AccCheck.Controls
{
    public class SwitchPanel : Control
    {
        Rectangle rect;
        Rectangle hrect;
        Rectangle twohrect;
        int TogglePosX_ON;
        int TogglePosX_OFF;
        private StringFormat SF = new StringFormat();
        private StringFormat SF2 = new StringFormat();

        public string Text2 = ("Данные");

        public bool Checked { get; set; } = false;
        public SwitchPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(120, 60);
            Font = new Font("Verdana", 8.25F, FontStyle.Regular);
            ForeColor = Color.White;
            BackColor = Color.White;

            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;

            SF2.Alignment = StringAlignment.Center;
            SF2.LineAlignment = StringAlignment.Center;

            rect = new Rectangle(1, 1, Width, Height);
            TogglePosX_OFF = rect.Y;
            TogglePosX_ON = rect.Height / 2;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            hrect = new Rectangle(1, 1, Width, Height / 2);
            twohrect = new Rectangle(1, 1, Width, (Height * 3) / 2);
            rect = new Rectangle(1, 1, Width, Height);
            TogglePosX_OFF = rect.Y;
            TogglePosX_ON = rect.Height / 2;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);

            //Pen TSPen = new Pen(Color.FromArgb(240, 46, 204, 113), 0);
            Pen TSPenToggle = new Pen(Color.FromArgb(240, 44, 62, 80), 0);

            //GraphicsPath rectGP = new Rectangle(rect, rect.Height);
            Rectangle rectToggle = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height / 2);

            //graph.DrawPath(TSPen, rectGP);
            //graph.DrawString(Text, Font, new SolidBrush(ForeColor), hrect, SF);
            if (Checked == true)
            {
                rectToggle.Location = new Point(rect.X, TogglePosX_ON);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(240, 22, 31, 40)), rect);
                Form1.TwoMenuActive = false;

            }
            else
            {
                rectToggle.Location = new Point(rect.X, TogglePosX_OFF);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(240, 22, 31, 40)), rect);
                Form1.TwoMenuActive = true;
            }

            graph.DrawString(Text, Font, new SolidBrush(ForeColor), hrect, SF);
            graph.DrawString(Text2, Font, new SolidBrush(ForeColor), twohrect, SF2);
            graph.DrawRectangle(TSPenToggle, rectToggle);
            graph.FillRectangle(new SolidBrush(Color.FromArgb(240, 44, 62, 80)), rectToggle);
        }

        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    base.OnMouseEnter(e);

        //    MouseEntered = true;

        //    Invalidate();
        //}
        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);

        //    MouseEntered = false;

        //    Invalidate();
        //}

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            SwitchToggle();
        }

        private void SwitchToggle()
        {
            Checked = !Checked;

            Invalidate();
        }

        //private GraphicsPath RoundedRectangle(Rectangle rect, int RoundSize)
        //{
        //    GraphicsPath gp = new GraphicsPath();

        //    gp.AddArc(rect.X, rect.Y, RoundSize, RoundSize, 180, 90);
        //    gp.AddArc(rect.X + rect.Width - RoundSize, rect.Y, RoundSize, RoundSize, 270, 90);
        //    gp.AddArc(rect.X + rect.Width - RoundSize, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 0, 90);
        //    gp.AddArc(rect.X, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 90, 90);

        //    gp.CloseFigure();

        //    return gp;
        //}

    }
}
