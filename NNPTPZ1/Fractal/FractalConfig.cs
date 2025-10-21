using System;

namespace NNPTPZ1.Fractal
{
    public sealed record FractalConfig(
        int Width,
        int Height,
        double XMin,
        double XMax,
        double YMin,
        double YMax,
        string OutputPath,
        int MaxIterations,
        double Tolerance
    )
    {
        public static FractalConfig ParseArgs(string[] args)
        {
            if (args is null || args.Length < 7)
                throw new ArgumentException("Usage: <width> <height> <xmin> <xmax> <ymin> <ymax> <outputPath> [maxIter] [tolerance]");

            return new FractalConfig(
                int.Parse(args[0]),
                int.Parse(args[1]),
                double.Parse(args[2]),
                double.Parse(args[3]),
                double.Parse(args[4]),
                double.Parse(args[5]),
                args[6],
                args.Length > 7 ? int.Parse(args[7]) : 30,
                args.Length > 8 ? double.Parse(args[8]) : 1e-6
            );
        }
    }
}
