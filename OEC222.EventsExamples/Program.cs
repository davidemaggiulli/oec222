namespace OEC222.EventsExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Events Examples **");

            BLObject obj = new BLObject();
            obj.ProcessCompleted += ObjCompleted;
            obj.ProcessCompleted += ObjCompleted1;
            obj.ProcessStarted += OnStartProcess;
            obj.Process2ndPhase += (sender, e) =>
            {
                Console.WriteLine($"Process 2nd phase. Value: " + e.ToString());
            };
            obj.StartProcess();


            ExtBLObject obj2 = new ExtBLObject();
            obj2.ProcessCompleted += Obj2Completed;
            obj2.StartProcess();
        }

        private static void ObjCompleted()
        {
            Console.WriteLine("Obj has been complted.");
        }

        private static void ObjCompleted1()
        {
            Console.WriteLine("2nd Handler");
        }

        private static void OnStartProcess(object sender, EventArgs e)
        {
            Console.WriteLine("Obj has been started");
            Console.WriteLine(sender);
            Console.WriteLine(e);
        }

        private static void Obj2Completed(object sender, ProcessEventArgs e)
        {
            Console.WriteLine($"Process :{(e.Success ? "completed" : "failed")}");
            if (e.Success && e.CompletationTime.HasValue)
            {
                Console.WriteLine($"Completation Time: {e.CompletationTime.Value:ddd dd-MM-yy HH:mm:ss}");
            }
        }
    }
}