using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Core.Models
{
    public class BLResult
    {

        public BLResult() : this(true, null, null)
        {

        }

        public BLResult(string message) : this(false, message, null)
        {

        }
        public BLResult(bool success, string message, Exception innerException)
        {
            Success = success;
            Message = message;
            InnerException = innerException;
        }

        public bool Success { get;  }
        public string Message { get; }

        public Exception InnerException { get; }
    }
}
