namespace OEC222.OutRefExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ref + Out Examples");
            int[] v = new int[3];
            v[1] = 100;
            foreach (var i in v)
                Console.Write($" {i}");

            //FuncWithOut(ref v);
            Console.WriteLine();
            foreach (var i in v)
                Console.Write($" {i}");

            TestFunc(10, out string msg);
            string msg1;
            TestFunc(100, out msg1);

            DateTime date;
            if(DateTime.TryParse("11/10/2022", out date))
            {
                Console.WriteLine(date);
            }

        }


        static void Func(ref int[] v)
        {
            v = new int[4];
            v[0] = 10;
            v[1] = 20;
            v[2] = 30; 
            v[3] = 40;
        }

        static int[] InitArray(int[] v)
        {
            var result = new int[4];
            //.... Init logic

            return result;
        }

        static void FuncWithOut(out int[] v)
        {
            v = new int[4];
            v[0] = 10;
            v[1] = 20;
            v[2] = 30;
            v[3] = 40;
        }

        static bool TestFunc(int v, out string msg)
        {
            msg = null;
            if(v == 0)
            {
                msg = "v = 0";
                return false;
            }
                
            
            if (v > 10 && v < 40)
                return true;

            msg = "v non valido";
            return false;
        }

        static FuncResult TestFunc1(int v)
        {
            if (v == 0)
                return new FuncResult("v = 0");

            if (v > 10 && v < 40)
                return new FuncResult();

            return new FuncResult("v non valido");
        }
    }
}