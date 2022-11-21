using OEC222.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Day1.Test
{
    public class ComplexNumberTests
    {
        [Fact]
        public void ComplexNumberSum()
        {
            ComplexNumber n1 = new ComplexNumber(10, 10);
            ComplexNumber n2 = new ComplexNumber(20, -5);

            ComplexNumber sum = n1.Sum(n2);

            Assert.NotNull(sum);
            Assert.Equal(30, sum.Real);
            Assert.Equal(5, sum.Imaginary);
        }

        [Fact]
        public void ComplexNumberSub()
        {
            ComplexNumber n1 = new ComplexNumber(10, 10);
            ComplexNumber n2 = new ComplexNumber(20, -5);

            ComplexNumber sub = n1.Sub(n2);

            Assert.NotNull(sub);
            Assert.Equal(-10, sub.Real);
            Assert.Equal(15, sub.Imaginary);
        }

        [Fact]
        public void ComplexNumberDiv()
        {
            ComplexNumber n1 = new ComplexNumber(1, -3);
            ComplexNumber n2 = new ComplexNumber(1,2);

            ComplexNumber div = n1.Div(n2);
            Assert.NotNull(div);
            Assert.Equal(-1, div.Real);
            Assert.Equal(-1, div.Imaginary);
        }

        [Fact]
        public void ComplexNumberDiv2()
        {
            ComplexNumber n1 = new ComplexNumber(1, -3);
            ComplexNumber n2 = new ComplexNumber(0,0);

            ComplexNumber div = n1.Div(n2);
            
            Assert.NotNull(div);
            Assert.Equal(double.NaN, div.Real);
            Assert.Equal(double.NaN, div.Imaginary);
            //TODO Rivedere con la lamba expression + gestione delle eccezioni.
        }
    }
}
