using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Lib
{
    public class ComplexNumber
    {
        public double Real { get; private set; }
        public double Imaginary { get; private set; }

        public ComplexNumber(double real, double imaginary) {
            Real = real;
            Imaginary = imaginary;
        }

        public ComplexNumber() : this(0,0)
        {

        }
        public ComplexNumber(double real) : this(real, 0)
        {

        }


        public override string ToString()
        {
            if (Real == 0 && Imaginary == 0)
                return "0";
            if(Real != 0 && Imaginary == 0)
                return Real.ToString("F2");
            if(Real == 0 && Imaginary != 0)
                return Imaginary.ToString("F2") + "i";

            ////r e i diversi da 0
            //if (Imaginary < 0)
            //    return Real.ToString() + " - " + Math.Abs(Imaginary).ToString() + "i";
            //return Real.ToString() + " + " + Imaginary.ToString() + "i";

            //r e i diversi da 0
            if (Imaginary < 0)
                return $"{Real:F2} - {Math.Abs(Imaginary):F2}i";
            return $"{Real:F2} + {Imaginary:F2}i";

        }

        //public double Modulo
        //{
        //    get
        //    {
        //        return Math.Sqrt(Real * Real + Imaginary * Imaginary);
        //    }
        //}

        public double Modulo => Math.Sqrt(Real * Real + Imaginary * Imaginary);

        public ComplexNumber Coniugato => new ComplexNumber(Real, -Imaginary);

        #region Methods

        public ComplexNumber Sum(ComplexNumber c)
        {
            return new ComplexNumber(Real + c.Real, Imaginary + c.Imaginary);
        }

        public static ComplexNumber Sum(ComplexNumber c1, ComplexNumber c2)
        {
            return c1.Sum(c2);
        }

        public static ComplexNumber operator +(ComplexNumber n1, ComplexNumber n2)
        {
            return n1.Sum(n2);
        }


        public ComplexNumber Sub(ComplexNumber n2)
        {
            return new ComplexNumber(Real - n2.Real, Imaginary - n2.Imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            return c1.Sub(c2);
        }

        public ComplexNumber Mult(ComplexNumber c)
        {
            return new ComplexNumber(
                Real * c.Real - Imaginary * c.Imaginary,
                Real * c.Imaginary + Imaginary * c.Real
            );
        }

        public ComplexNumber Div(ComplexNumber c)
        {
            double div = c.Real * c.Real + c.Imaginary * c.Imaginary;
            if(div == 0)
            {
                ILogger logger = FileLogger.GetIstance();
                logger.Error("Stai dividendo per zero");
            }
            double real = (Real * c.Real + Imaginary * c.Imaginary) / div;
            double imaginary = (Imaginary * c.Real - Real * c.Imaginary) / div;

            return new ComplexNumber(real, imaginary);
        }

        public static ComplexNumber operator ~(ComplexNumber c)
        {
            return c.Coniugato;
        }

        #endregion
    }
}
