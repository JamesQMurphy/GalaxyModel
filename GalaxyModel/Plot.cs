using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace GalaxyModel
{
    public class Plot : Form
    {
        private PointF[] _points = new PointF[] {
            new PointF(100, 0),
            new PointF(100, (float)(Math.PI/6f)),
            new PointF(100, (float)(Math.PI/3f)),
            new PointF(100, (float)(Math.PI/2f)),
            new PointF(200, (float)(Math.PI/2f)),
            new PointF(200, (float)(2f*Math.PI/3f)),
            new PointF(200, (float)(5f*Math.PI/6f))

        };

        public Plot()
        {
            this.Text = "Here is the plot";
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            //this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
            //this.ResizeEnd += (s, e) => { this.ResumeLayout(true); };
        }

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var pen = new Pen(ForeColor);

            var g = e.Graphics;

            g.DrawLine(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            g.DrawLine(pen, 0, ClientSize.Height - 1, ClientSize.Width - 1, 0);

            g.PageUnit = GraphicsUnit.Pixel;
            g.PageScale = 1.0f;
            g.TranslateTransform(g.VisibleClipBounds.Width / 2f, g.VisibleClipBounds.Height / 2f);
            g.ScaleTransform(1, -1);
            g.DrawEllipse(pen, -5f, -5f, 10f, 10f);

            foreach (var p in _points)
            {
                float x = p.X * (float)Math.Cos(p.Y);
                float y = p.X * (float)Math.Sin(p.Y);
                g.DrawEllipse(pen, x - 10f, y - 10f, 10f, 10f);
            }

        }
    }
}
