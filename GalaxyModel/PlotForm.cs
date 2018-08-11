using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace GalaxyModel
{
    public class PlotForm : Form
    {
        public PlotForm()
        {
            this.Text = "Here is the plot";
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.ControlBox = false;
            //this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
            //this.ResizeEnd += (s, e) => { this.ResumeLayout(true); };
        }

        private PolarPlot _polarPlot = null;
        public PolarPlot PolarPlot
        {
            get { return _polarPlot; }
            set
            {
                var oldPolarPlot = _polarPlot;
                _polarPlot = value;
                this.Invalidate();
                if (oldPolarPlot != null)
                {
                    oldPolarPlot.Dispose();
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(_polarPlot.Bitmap, e.Graphics.VisibleClipBounds);
        }

        protected override void Dispose(bool disposing)
        {
            _polarPlot.Dispose();
            base.Dispose(disposing);
        }
    }
}
