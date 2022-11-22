using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.OutRefExample
{
    public class FuncResult
    {
        public bool Success { get; }
        public string Message { get; }

        public FuncResult()
        {
            Success = true;
            Message = null;
        }

        public FuncResult(string error)
        {
            Success = false;
            Message = error;
        }
    }
}
