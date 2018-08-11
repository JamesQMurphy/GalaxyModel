using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyModel
{
    public class PolarPlot : IDisposable
    {
        private readonly double _radius;
        public Bitmap Bitmap { get; }

        public PolarPlot(double radius)
        {
            _radius = radius;
            int bitmapSize = (int)(2.0 * radius) + 1;
            Bitmap = new Bitmap(bitmapSize, bitmapSize, System.Drawing.Imaging.PixelFormat.Format48bppRgb);
        }

        public void DrawX()
        {
            for (int i = 0; i < Bitmap.Width; i++)
            {
                Bitmap.SetPixel(i, i, Color.White);
                Bitmap.SetPixel(Bitmap.Width - 1 - i, i, Color.White);
            }
        }

        public void Plot(double r, double theta, double intensity = 1.0)
        {
            double xCart = r * Math.Cos(theta);
            double yCart = r * Math.Sin(theta);
            int x = (int)(xCart + Bitmap.Width / 2.0);
            int y = (int)(Bitmap.Height - yCart - Bitmap.Height / 2.0);

            int rgb = Math.Max(Math.Min((int)Math.Truncate(intensity * 255.0), 255), 0);

            Bitmap.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
        }

        public void PlotFunction(Func<double,double,double> f)
        {
            for (double x = 0.0; x < Bitmap.Width; x += 0.5)
                for (double y = 0.0; y < Bitmap.Height; y += 0.5)
                {
                    // first, true Cartesian
                    double xCart = (double)x - (Bitmap.Width / 2.0);
                    double yCart = (double)(Bitmap.Height) - (double)y - (Bitmap.Height / 2.0);

                    // calculate polar coordinates
                    double r = Math.Sqrt(xCart * xCart + yCart * yCart);
                    double theta = Math.Atan2(yCart, xCart);

                    Plot(r, theta, f(r, theta));
                }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Bitmap.Dispose();
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
