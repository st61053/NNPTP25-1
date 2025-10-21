using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace NNPTPZ1.Utils
{
    public sealed class FastBitmap : IDisposable
    {
        private readonly Bitmap _bmp;
        private readonly BitmapData _data;
        private readonly int _stride;
        private readonly IntPtr _scan0;
        private bool _disposed;

        public int Width  => _bmp.Width;
        public int Height => _bmp.Height;

        public FastBitmap(Bitmap bmp)
        {
            _bmp = bmp ?? throw new ArgumentNullException(nameof(bmp));
            var rect = new Rectangle(0, 0, _bmp.Width, _bmp.Height);
            _data = _bmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            _stride = _data.Stride;
            _scan0 = _data.Scan0;
        }

        public unsafe void SetPixel(int x, int y, Color c)
        {
            if ((uint)x >= (uint)Width || (uint)y >= (uint)Height) return;
            byte* row = (byte*)_scan0 + (y * _stride);
            int idx = x * 3;
            row[idx + 0] = c.B;
            row[idx + 1] = c.G;
            row[idx + 2] = c.R;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _bmp.UnlockBits(_data);
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
