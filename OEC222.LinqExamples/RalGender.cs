using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.LinqExamples
{
    internal class RalGender
    {
        public decimal Ral { get; }
        public Gender Gender { get; }
        public RalGender(decimal ral, Gender gender)
        {
            Ral = ral;
            Gender = gender;
        }
    }
}
