using NNPTPZ1.Mathematics;

namespace NNPTPZ1.Fractal
{
    public static class WorldMapper
    {
        public static ComplexNumber PixelToComplex(int px, int py, FractalConfig cfg)
        {
            double x = cfg.XMin + px * (cfg.XMax - cfg.XMin) / cfg.Width;
            double y = cfg.YMin + py * (cfg.YMax - cfg.YMin) / cfg.Height;
            return new ComplexNumber(x, y);
        }
    }
}
