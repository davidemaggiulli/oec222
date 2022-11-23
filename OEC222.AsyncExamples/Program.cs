namespace OEC222.AsyncExamples
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Async Examples");

            SynchronousMethod(100, "Proc A");

            var procC = AsynchronousMethod(1000, "Proc C");
            var procD = AsynchronousMethod(2000, "Proc D");
            var procE = AsynchronousMethod(2000, "Proc E");
            var procF = AsynchronousMethod(2000, "Proc F");

            SynchronousMethod(50, "Proc B");

            await procE;

            SynchronousMethod(50, "Proc G");

            
            await procF;
            await procD;
            await procC;

        }

        private static async Task AsynchronousMethod(int iterations, string name)
        {
            Console.WriteLine($"... starting process {name}");

            await Task.Run(() =>
            {
                for (int i = 0; i < iterations; i++)
                    Console.WriteLine($"{name}: {i} - Thread: {Thread.CurrentThread.ManagedThreadId}");
            });
            
            Console.WriteLine($"... ending process {name}");

        }
        private static void SynchronousMethod(int iterations, string name)
        {
            Console.WriteLine($"... starting process {name}");
            for(int i = 0; i < iterations; i++)
            {
                Console.WriteLine($"{name}: {i} - Thread: {Thread.CurrentThread.ManagedThreadId}");
            }

            Console.WriteLine($"... ending process {name}");

        }
    }
}