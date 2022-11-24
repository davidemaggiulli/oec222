using System.Threading.Tasks;

namespace OEC222.TPLExamples
{
    internal class Program
    {
        static int N;
        const int MaxIteration = 10000000;
        static readonly object semaforo = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("TPL Examples");

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 5
            };
            ParallelLoopResult result = Parallel.For(0, 10, options, i =>
            {
                Console.WriteLine($"S: {i} - Thread: {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(10).Wait();
                Console.WriteLine($"E: {i} - Thread: {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"Is Completed: {result.IsCompleted}");

            IList<int> ints = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
                ints.Add(rnd.Next(0, 11));

            result = Parallel.ForEach<int>(ints, options, num =>
            {
                Console.WriteLine($"Proc: {num} - Thread: {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(10).Wait();
            });
            Console.WriteLine($"Is Completed: {result.IsCompleted}");

            Parallel.Invoke(options, ProcA, ProcB, ProcA, ProcA, ProcA, ProcA);
            Parallel.Invoke(options, () => Proc(0, 10), () => Proc(12, 20), () => Proc(21, 30));

            N = 0;
            Console.WriteLine($"Valore di N prima: {N}");
            
            Parallel.Invoke(Incrementa, Decrementa);

            Console.WriteLine($"Valore di N dopo: {N}");

            var taskFactory = new TaskFactory();
            Task t1 = taskFactory.StartNew(ProcA);
            Task t2 = Task.Factory.StartNew(ProcB);
            Task t3 = new Task(ProcA);
            t3.Start();
            Task t4 = Task.Run(ProcB);

            Console.WriteLine("\n\n\n");
            N = 0;
            Thread tr1 = new Thread(Incrementa);
            Thread tr2 = new Thread(Decrementa);

            tr1.Start();
            tr2.Start();


            tr1.Join();
            tr2.Join();
            Console.WriteLine("Ho finito");

        }

        private static void ProcA()
        {
            Console.WriteLine($"processo A - Thread: {Thread.CurrentThread.ManagedThreadId}");
            Task.Delay(100).Wait();
        }

        private static void ProcB()
        {
            Console.WriteLine($"processo B - Thread: {Thread.CurrentThread.ManagedThreadId}");
            Task.Delay(100).Wait();
        }

        public static void MyMethod(params int[] a)
        {
            foreach (var n in a)
                Console.Write(n);
        }

        private static void Proc(int min, int max)
        {

        }


        private static void Incrementa()
        {
            int temp;
            int i = 0;
            while(i < MaxIteration)
            {
                lock (semaforo)
                {
                    temp = N;
                    temp = temp + 1;
                    N = temp;
                }
                i++;
            }

            Console.WriteLine($"Incrementa ha terminato - {Thread.CurrentThread.ManagedThreadId}");
        }
        private static void Decrementa()
        {
            int temp;
            int i = 0;
            while (i < MaxIteration)
            {
                lock (semaforo)
                {
                    temp = N;
                    temp = temp - 1;
                    N = temp;
                }
                i++;
            }

            Console.WriteLine($"Decrementa ha terminato - {Thread.CurrentThread.ManagedThreadId}");

        }
    }
}