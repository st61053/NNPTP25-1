using System;
using System.Linq;

namespace NNPTPZ1.Mathematics
{
    public sealed class Polynomial
    {
        public ComplexNumber[] Coefficients { get; private set; }

        public Polynomial(params ComplexNumber[] coeffs)
        {
            if (coeffs == null || coeffs.Length == 0)
                Coefficients = new ComplexNumber[] { ComplexNumber.Zero };
            else
                Coefficients = coeffs.ToArray();
        }

        public static Polynomial Default()
        {
            return new Polynomial(
                new ComplexNumber(1, 0),
                ComplexNumber.Zero,
                ComplexNumber.Zero,
                new ComplexNumber(1, 0)
            );
        }

        public Polynomial Derivative()
        {
            if (Coefficients.Length <= 1)
                return new Polynomial(ComplexNumber.Zero);

            var d = new ComplexNumber[Coefficients.Length - 1];
            for (int i = 1; i < Coefficients.Length; i++)
            {
                var c = Coefficients[i];
                d[i - 1] = new ComplexNumber(c.Re * i, c.Im * i);
            }
            return new Polynomial(d);
        }

        public ComplexNumber Eval(ComplexNumber x)
        {
            var acc = ComplexNumber.Zero;
            for (int i = Coefficients.Length - 1; i >= 0; i--)
            {
                acc = acc * x + Coefficients[i];
            }
            return acc;
        }

        public override string ToString()
        {
            string[] parts = new string[Coefficients.Length];
            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (i == 0) parts[i] = Coefficients[i].ToString();
                else if (i == 1) parts[i] = Coefficients[i] + "x";
                else parts[i] = Coefficients[i] + "x^" + i;
            }
            return string.Join(" + ", parts);
        }
    }
}
