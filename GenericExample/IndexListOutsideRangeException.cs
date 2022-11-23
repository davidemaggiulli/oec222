using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    internal class IndexListOutsideRangeException : Exception
    {
        public int Position { get; }
        public int Index { get; }
        public int ArrayLength { get; }

        public IndexListOutsideRangeException(int position, int index, int arrayLength) : base($"Indice {index} non valido. Position: {position}, ArrayLength: {arrayLength}")
        {
            Position = position;
            Index = index;
            ArrayLength = arrayLength;
        }
    }
}
