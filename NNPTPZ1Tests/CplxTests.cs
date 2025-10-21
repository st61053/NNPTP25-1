using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNPTPZ1.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNPTPZ1;

namespace NNPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class CplxTests
    {

        [TestMethod()]
        public void AddTest()
        {
            var a = new ComplexNumber(10, 20);
            var b = new ComplexNumber(1, 2);

            var actual = a + b; 

            var shouldBe = new ComplexNumber(11, 22);
            Assert.AreEqual(shouldBe, actual);

            var e2 = "(10 + 20i)";
            var r2 = a.ToString();
            Assert.AreEqual(e2, r2);

            e2 = "(1 + 2i)";
            r2 = b.ToString();
            Assert.AreEqual(e2, r2);

            a = new ComplexNumber(1, -1);
            b = ComplexNumber.Zero;
            shouldBe = new ComplexNumber(1, -1);
            actual = a + b;
            Assert.AreEqual(shouldBe, actual);

            e2 = "(1 + -1i)";
            r2 = a.ToString();
            Assert.AreEqual(e2, r2);

            e2 = "(0 + 0i)";
            r2 = b.ToString();
            Assert.AreEqual(e2, r2);
        }

        [TestMethod()]
        public void AddTestPolynome()
        {
            var poly = new Polynomial(
                new ComplexNumber(1, 0),
                ComplexNumber.Zero,
                new ComplexNumber(1, 0)
            );

            var result   = poly.Eval(new ComplexNumber(0, 0));
            var expected = new ComplexNumber(1, 0);
            Assert.AreEqual(expected, result);

            result   = poly.Eval(new ComplexNumber(1, 0));
            expected = new ComplexNumber(2, 0);
            Assert.AreEqual(expected, result);

            result   = poly.Eval(new ComplexNumber(2, 0));
            expected = new ComplexNumber(5.0000000000, 0);
            Assert.AreEqual(expected, result);

            var r2 = poly.ToString();
            var e2 = "(1 + 0i) + (0 + 0i)x + (1 + 0i)x^2";
            Assert.AreEqual(e2, r2);
        }
    }
}


