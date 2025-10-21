using System;
using NNPTPZ1.Fractal;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    /// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    static class Program
    {
        static int Main(string[] args)
        {
            try
            {
                var cfg = FractalConfig.ParseArgs(args);
                var poly = Polynomial.Default();
                var gen = new FractalGenerator(poly, cfg);
                gen.Generate();
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }
    }
}
