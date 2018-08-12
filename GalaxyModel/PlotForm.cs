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

        private Bitmap _bitmap = null;
        public Bitmap Bitmap
        {
            get { return _bitmap; }
            set
            {
                var oldBitmap = _bitmap;
                _bitmap = value;
                this.Invalidate();
                if (oldBitmap != null)
                {
                    oldBitmap.Dispose();
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
            e.Graphics.DrawImage(_bitmap, e.Graphics.VisibleClipBounds);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _bitmap != null)
                _bitmap.Dispose();
            base.Dispose(disposing);
        }
    }
}
