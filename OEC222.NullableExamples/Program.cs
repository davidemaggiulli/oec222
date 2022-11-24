namespace OEC222.NullableExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nullable Examples");

            int a = 2;
            long b = 2l;
            decimal c = 2.5m;

            Nullable<int> d = null;
            d = 10;
            if (d.HasValue)
            {
                Console.WriteLine(d.Value);
            }

            Nullable<long> e = 10l;
            e = null;
            if(e != null)
            {
                Console.WriteLine(e.Value);
            }

            int? f = 10;

            DateTime? d1 = null;
            d1 = new DateTime(1987, 10, 12);

            Person p1 = new Person("Davide", "Maggiulli",178, 35);
            Person p2 = new Person("Pippo", "Pluto",120);
            Person p3 = null;

            string p1Name = p1.FirstName;
            var p1Age = p1.Age;

            
            var age = p3?.Age;   //Null-propagation operator ?.
            int? h = p3?.Height;
            int? h1 = p3 != null ? p3.Height : null;
            int? h3 = null;
            if (p3 != null)
                h3 = p3.Height;

            int h4 = p3 != null ? p3.Height : 0;
            int h5 = p3?.Height ?? 0;    //Null-coalescing
            int? h6 = p3?.Height ?? p2?.Height;

            string hs = h?.ToString();
            IList<string> s = null;

            foreach (var x in (s ?? new List<string>()))
            {

            }

            Point point = new Point();
            Point? point1 = null;

            var x1 = point1?.X;
            //var x2 = point?.X;  //NON CONSENTITO A COMPILE-TIME
            int num = 10;
            int? num2 = num;

            dynamic myVar = 2;
            Console.WriteLine("Value: {0}, Type: {1}",myVar, myVar.GetType());
            
            myVar = "I am a string";
            Console.WriteLine("Value: {0}, Type: {1}", myVar, myVar.GetType());


            myVar = true;
            Console.WriteLine("Value: {0}, Type: {1}", myVar, myVar.GetType());


            myVar = new DateTime(1987, 10, 12);
            Console.WriteLine("Value: {0}, Type: {1}", myVar, myVar.GetType());

            dynamic dyn1 = 100;
            int i = dyn1;
            dyn1 = "stringa";
            string ss = dyn1;
            //i = dyn1;   //Non consentito a run-time

            dyn1 = new Point(10, 10);
            dyn1.CalcolaDistanza();

            Console.ReadLine();

        }
    }
}