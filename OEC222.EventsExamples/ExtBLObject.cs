using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.EventsExamples
{
    internal class ExtBLObject
    {
        public event EventHandler<ProcessEventArgs> ProcessCompleted;
        public void StartProcess()
        {
            Thread.Sleep(1500);
            try
            {
                throw new Exception();
                ProcessEventArgs args = new ProcessEventArgs
                {
                    Success = true,
                    CompletationTime = DateTime.Now
                };
                ProcessCompleted?.Invoke(this, args);
            }
            catch
            {
                ProcessCompleted?.Invoke(this, new ProcessEventArgs { Success = false});
            }
        }
    }
}
