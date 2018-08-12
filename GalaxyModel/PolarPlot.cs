using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyModel
{
    public class PolarPlot : IDisposable
    {
        const PixelFormat PIXEL_FORMAT = PixelFormat.Format24bppRgb;

        private readonly double _radius;
        private int _lockCount = 0;
        private object _lockObj = new object();
        private IntPtr _ptr = IntPtr.Zero;
        private byte[] _byteArray = null;
        private BitmapData bitmapData = null;
        public Bitmap Bitmap { get; }

        public PolarPlot(double radius)
        {
            _radius = radius;
            int bitmapSize = (int)(2.0 * radius) + 1;
            Bitmap = new Bitmap(bitmapSize, bitmapSize, PIXEL_FORMAT);
        }

        public int Lock()
        {
            lock(_lockObj)
            {
                ++_lockCount;
                if (_lockCount == 1)
                {
                    Rectangle rect = new Rectangle(0, 0, Bitmap.Width, Bitmap.Height);
                    bitmapData = Bitmap.LockBits(rect, ImageLockMode.ReadWrite, PIXEL_FORMAT);
                    _ptr = bitmapData.Scan0;
                    int bytes = Math.Abs(bitmapData.Stride) * Bitmap.Height;
                    _byteArray = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(_ptr, _byteArray, 0, bytes);
                }
                return _lockCount;
            }
        }

        public int Unlock()
        {
            lock(_lockObj)
            {
                if (_lockCount == 1)
                {
                    System.Runtime.InteropServices.Marshal.Copy(_byteArray, 0, _ptr, _byteArray.Length);
                    Bitmap.UnlockBits(bitmapData);
                }
                return --_lockCount;
            }
        }

        public void DrawX()
        {
            for (int i = 0; i < Bitmap.Width; i++)
            {
                _SetPixel(i, i, 1.0);
                _SetPixel(Bitmap.Width - 1 - i, i, 1.0);
            }
        }

        public void PlotCartesian(double x, double y, double intensity = 1.0)
        {
            _SetPixel((int)x, (int)y, intensity);
        }

        public void PlotPolar(double r, double theta, double intensity = 1.0)
        {
            double xCart = r * Math.Cos(theta);
            double yCart = r * Math.Sin(theta);
            PlotCartesian((xCart + Bitmap.Width / 2.0), (Bitmap.Height - yCart - Bitmap.Height / 2.0), intensity);
        }

        public void PlotPolarFunction(Func<double,double,double> f)
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

                    PlotPolar(r, theta, f(r, theta));
                }
        }

        private void _SetPixel(int x, int y, double intensity = 1.0)
        {
            byte rgb = (byte)Math.Max(Math.Min((int)Math.Truncate(intensity * 255.0), 255), 0);
            if (_lockCount == 0)
            {
                Bitmap.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
            }
            else
            {
                int idx = Math.Abs(bitmapData.Stride) * y + x;
                _byteArray[idx++] = rgb;
                _byteArray[idx++] = rgb;
                _byteArray[idx] = rgb;
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
