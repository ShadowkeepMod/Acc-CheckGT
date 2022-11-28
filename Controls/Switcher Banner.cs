using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AccCheck.Controls
{
    public class Switcher_Banner : Control
    {
        Rectangle rect;
        int TogglePosX_ON;
        int TogglePosX_OFF;


        public bool Checked { get; set; } = false;
        public Switcher_Banner()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(40, 15);
            Font = new Font("Verdana", 8.25F, FontStyle.Regular);
            BackColor = Color.White;

            rect = new Rectangle(1, 1, Width - 3, Height - 3);
            TogglePosX_OFF = rect.X;
            TogglePosX_ON = rect.Width - rect.Height;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            rect = new Rectangle(1, 1, Width - 3, Height - 3);
            TogglePosX_OFF = rect.X;
            TogglePosX_ON = rect.Width - rect.Height;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);

            Pen TSPen = new Pen(Color.FromArgb(240, 22, 31, 40), 1);
            Pen TSPenToggle = new Pen(Color.FromArgb(240, 240, 243, 244), 1);

            GraphicsPath rectGP = RoundedRectangle(rect, rect.Height);
            Rectangle rectToggle = new Rectangle(rect.X, rect.Y, rect.Height, rect.Height);

            graph.DrawPath(TSPen, rectGP);

            if (Checked == true)
            {
                rectToggle.Location = new Point(TogglePosX_ON, rect.Y);
                graph.FillPath(new SolidBrush(Color.FromArgb(240, 46, 204, 113)), rectGP);
                Form1.banner = true;
            }
            else
            {
                rectToggle.Location = new Point(TogglePosX_OFF, rect.Y);
                graph.FillPath(new SolidBrush(Color.FromArgb(240, 22, 31, 40)), rectGP);
                Form1.banner = false;
            }

            graph.DrawEllipse(TSPenToggle, rectToggle);
            graph.FillEllipse(new SolidBrush(Color.FromArgb(240, 240, 243, 244)), rectToggle);
        }

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

        private GraphicsPath RoundedRectangle(Rectangle rect, int RoundSize)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(rect.X, rect.Y, RoundSize, RoundSize, 180, 90);
            gp.AddArc(rect.X + rect.Width - RoundSize, rect.Y, RoundSize, RoundSize, 270, 90);
            gp.AddArc(rect.X + rect.Width - RoundSize, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 0, 90);
            gp.AddArc(rect.X, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 90, 90);

            gp.CloseFigure();

            return gp;
        }
    }
}
