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
        const int BYTES_PER_PIXEL = 3;

        private readonly int _bitmapWidth;
        private readonly int _bitmapHeight;
        private readonly int _bitmapStride;
        private byte[] _byteArray = null;

        public PolarPlot(double radius)
        {
            _bitmapWidth = (int)(2.0 * radius) + 1;
            _bitmapHeight = _bitmapWidth;

            var sampleBitmap = new Bitmap(_bitmapWidth, _bitmapHeight, PIXEL_FORMAT);
            var bitmapData = sampleBitmap.LockBits(new Rectangle(0, 0, _bitmapWidth, _bitmapHeight), ImageLockMode.ReadOnly, PIXEL_FORMAT);
            _bitmapStride = bitmapData.Stride;
            sampleBitmap.UnlockBits(bitmapData);
            sampleBitmap.Dispose();

            int arraySize = _bitmapStride * _bitmapHeight;
            _byteArray = new byte[arraySize];
        }

        public Bitmap GenerateBitmap()
        {
            var bitmap = new Bitmap(_bitmapWidth, _bitmapHeight, PIXEL_FORMAT);
            var rect = new Rectangle(0, 0, _bitmapWidth, _bitmapHeight);
            var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PIXEL_FORMAT);
            System.Runtime.InteropServices.Marshal.Copy(_byteArray, 0, bitmapData.Scan0, _byteArray.Length);
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }

        public void DrawX()
        {
            for (int i = 0; i < _bitmapWidth; i++)
            {
                _SetPixel(i, i, 1.0);
                _SetPixel(_bitmapWidth - 1 - i, i, 1.0);
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
            PlotCartesian((xCart + _bitmapWidth / 2.0), (_bitmapHeight - yCart - _bitmapHeight / 2.0), intensity);
        }

        public void PlotPolarFunction(Func<double,double,double> f)
        {
            for (double x = 0.0; x < _bitmapWidth; x += 0.5)
                for (double y = 0.0; y < _bitmapHeight; y += 0.5)
                {
                    // first, true Cartesian
                    double xCart = (double)x - (_bitmapWidth / 2.0);
                    double yCart = (double)(_bitmapHeight) - (double)y - (_bitmapHeight / 2.0);

                    // calculate polar coordinates
                    double r = Math.Sqrt(xCart * xCart + yCart * yCart);
                    double theta = Math.Atan2(yCart, xCart);

                    PlotPolar(r, theta, f(r, theta));
                }
        }

        private void _SetPixel(int x, int y, double intensity = 1.0)
        {
            byte rgb = (byte)Math.Max(Math.Min((int)Math.Truncate(intensity * 255.0), 255), 0);
            int idx = (_bitmapStride * y) + (BYTES_PER_PIXEL * x);
            _byteArray[idx++] = rgb;
            _byteArray[idx++] = rgb;
            _byteArray[idx] = rgb;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //Bitmap.Dispose();
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
