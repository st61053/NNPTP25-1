using System.Collections.Generic;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1.Fractal
{
    public static class RootIdentifier
    {
        public static int FindOrAdd(List<ComplexNumber> roots, ComplexNumber z, double eps = 1e-3)
        {
            for (int i = 0; i < roots.Count; i++)
            {
                if ((z - roots[i]).Abs() < eps) return i;
            }
            roots.Add(z);
            return roots.Count - 1;
        }
    }
}
