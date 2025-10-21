using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using NNPTPZ1.Mathematics;
using NNPTPZ1.Utils;

namespace NNPTPZ1.Fractal
{
    public sealed class FractalGenerator
    {
        private readonly Polynomial _p;
        private readonly Polynomial _pd;
        private readonly FractalConfig _cfg;
        private readonly List<ComplexNumber> _roots = new List<ComplexNumber>();

        public FractalGenerator(Polynomial p, FractalConfig cfg)
        {
            _p = p;
            _pd = p.Derivative();
            _cfg = cfg;
        }

        public void Generate()
        {
            using (var bmp = new Bitmap(_cfg.Width, _cfg.Height, PixelFormat.Format24bppRgb))
            {
                using (var fb = new FastBitmap(bmp))
                {
                    for (int y = 0; y < _cfg.Height; y++)
                    {
                        for (int x = 0; x < _cfg.Width; x++)
                        {
                            var z0 = WorldMapper.PixelToComplex(x, y, _cfg);
                            var result = NewtonIterate(z0);
                            int rootId = RootIdentifier.FindOrAdd(_roots, result.Item1);
                            var color = ColorScheme.ColorFor(rootId, result.Item2, _cfg.MaxIterations);
                            fb.SetPixel(x, y, color);
                        }
                    }
                }

                bmp.Save(_cfg.OutputPath, ImageFormat.Png);
            }
        }

        private System.Tuple<ComplexNumber, int> NewtonIterate(ComplexNumber z0)
        {
            var z = z0;
            int i = 0;
            for (; i < _cfg.MaxIterations; i++)
            {
                var f = _p.Eval(z);
                var fp = _pd.Eval(z);
                if (fp.Re == 0.0 && fp.Im == 0.0) break;

                var dz = f / fp;
                z = z - dz;

                if (dz.Abs() < _cfg.Tolerance) break;
            }
            return System.Tuple.Create(z, i);
        }
    }
}
