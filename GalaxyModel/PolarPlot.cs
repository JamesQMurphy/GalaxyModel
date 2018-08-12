﻿using System;
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
                SetPixel(i, i);
                SetPixel(_bitmapWidth - 1 - i, i);
            }
        }

        public void PlotPolarPoint(double r, double theta, byte brightness = byte.MaxValue)
        {
            double xCart = r * Math.Cos(theta);
            double yCart = r * Math.Sin(theta);
            _PolarToCartesian(r, theta, out double x, out double y);
            PlotCartesianPoint(x, y, brightness);
        }

        public void PlotCartesianPoint(double x, double y, byte brightness = byte.MaxValue)
        {
            _CartesianToBitmap(x, y, out int xBitmap, out int yBitmap);
            SetPixel(xBitmap, yBitmap, brightness);
        }

        public void PlotPolarFunction(Func<double,double> f, byte brightness = byte.MaxValue)
        {
            // Function is theta = f(r)
            // go to 1.5 times r
            double maxR = (_bitmapWidth) * 1.5;
            double increment = 0.5;
            for (double r = 0.0; r < maxR; r = r + increment)
            {
                PlotPolarPoint(r, f(r), brightness);
            }
        }

        public void PlotPolarFunction(Func<double,double,byte> f)
        {
            for (int x = 0; x < _bitmapWidth; x++)
            {
                for (int y = 0; y < _bitmapHeight; y++)
                {
                    _BitmapToCartesian(x, y, out double xCart, out double yCart);
                    _CartesianToPolar(xCart, yCart, out double r, out double theta);
                    _SetPixelNoCheck(x, y, f(r, theta));
                }
            }
        }

        public bool SetPixel(int x, int y, byte brightness = byte.MaxValue)
        {
            if ((x >= 0) && (y >= 0) && (x < _bitmapWidth) && (y < _bitmapWidth))
            {
                _SetPixelNoCheck(x, y, brightness);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void _PolarToCartesian(double r, double theta, out double xCart, out double yCart)
        {
            xCart = r * Math.Cos(theta);
            yCart = r * Math.Sin(theta);
        }

        private void _CartesianToBitmap(double xCart, double yCart, out int xBitmap, out int yBitmap)
        {
            xBitmap = (int)(xCart + _bitmapWidth / 2.0);
            yBitmap = (int)(_bitmapHeight - yCart - _bitmapHeight / 2.0);
        }

        private void _BitmapToCartesian(int xBitmap, int yBitmap, out double xCart, out double yCart)
        {
            xCart = (double)xBitmap - (_bitmapWidth / 2.0);
            yCart = (double)(_bitmapHeight) - (double)yBitmap - (_bitmapHeight / 2.0);
        }

        private void _CartesianToPolar(double xCart, double yCart, out double r, out double theta)
        {
            r = Math.Sqrt(xCart * xCart + yCart * yCart);
            theta = Math.Atan2(yCart, xCart);
        }

        public void _SetPixelNoCheck(int x, int y, byte brightness = byte.MaxValue)
        {
            int idx = (_bitmapStride * y) + (BYTES_PER_PIXEL * x);
            _byteArray[idx] = brightness;
            _byteArray[idx + 1] = brightness;
            _byteArray[idx + 2] = brightness;
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
