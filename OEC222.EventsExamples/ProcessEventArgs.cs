using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.EventsExamples
{
    internal class ProcessEventArgs : EventArgs
    {
        public bool Success { get; set; }

        public DateTime? CompletationTime { get; set; }
    }
}
