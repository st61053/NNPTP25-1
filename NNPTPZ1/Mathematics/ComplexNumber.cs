using System;

namespace NNPTPZ1.Mathematics
{
    public struct ComplexNumber
    {
        public double Re { get; }
        public double Im { get; }

        public ComplexNumber(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public static ComplexNumber Zero { get { return new ComplexNumber(0, 0); } }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Re + b.Re, a.Im + b.Im);
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Re - b.Re, a.Im - b.Im);
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + a.Im * b.Re);
        }

        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            double d = b.Re * b.Re + b.Im * b.Im;
            return new ComplexNumber((a.Re * b.Re + a.Im * b.Im) / d,
                                     (a.Im * b.Re - a.Re * b.Im) / d);
        }

        public double Abs()
        {
            return Math.Sqrt(Re * Re + Im * Im);
        }

        public double Arg()
        {
            return Math.Atan2(Im, Re);
        }

        public override string ToString()
        {
            return "(" + Re + " + " + Im + "i)";
        }
    }
}
