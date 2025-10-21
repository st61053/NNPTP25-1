using System;
using System.Drawing;

namespace NNPTPZ1.Fractal
{
    public static class ColorScheme
    {
        private static readonly Color[] Palette =
        {
            Color.Red, Color.Blue, Color.Green, Color.Yellow,
            Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
        };

        public static Color ColorFor(int rootIndex, int iter, int maxIter)
        {
            var baseColor = Palette[(rootIndex % Palette.Length + Palette.Length) % Palette.Length];
            double t = Math.Clamp(maxIter > 0 ? (double)iter / maxIter : 0.0, 0.0, 1.0);

            int r = (int)(baseColor.R * (1 - t));
            int g = (int)(baseColor.G * (1 - t));
            int b = (int)(baseColor.B * (1 - t));

            return Color.FromArgb(r, g, b);
        }
    }
}
