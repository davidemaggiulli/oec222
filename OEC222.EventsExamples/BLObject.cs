using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.EventsExamples
{
    internal class BLObject
    {
        public delegate void Notify();
        public event Notify ProcessCompleted;
        public event EventHandler ProcessStarted;
        public event EventHandler<bool> Process2ndPhase;
        public void StartProcess()
        {
            ProcessStarted?.Invoke(this, EventArgs.Empty);

            Thread.Sleep(150);
            int num = 0;
            int num2 = 10;
            try
            {
                var b = num / num2;
                Process2ndPhase?.Invoke(this, true);
            }
            catch
            {
                Process2ndPhase?.Invoke(this, false);
            }
            

            Thread.Sleep(100);


            ProcessCompleted?.Invoke();
        }
    }
}
