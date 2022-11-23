using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Conversions
{
    internal readonly struct Digit
    {
        private readonly byte digit;

        public Digit(byte digit) { 
            if(digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit),"Digit cannot be greather than nine.");
            }
            this.digit = digit;
        }

        public override string ToString() => $"{digit}";

        public static implicit operator byte(Digit d) => d.digit;
        public static explicit operator Digit(byte b) => new Digit(b);
        //public static implicit operator Digit(byte b) => new Digit(b);


    }
}
