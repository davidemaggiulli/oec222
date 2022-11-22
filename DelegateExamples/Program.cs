namespace DelegateExamples
{
    internal class Program
    {
        //delegate bool SearchCondition(int num);
        //delegate bool SearchCondition1(Employee employee);
        delegate bool SearchCondition<T>(T item);


        static void Main(string[] args)
        {
            Console.WriteLine("Delegate Examples");

            #region Integer Examples
            int[] numbers = new int[50];
            
            Random rnd = new Random(10);
            for(int i = 0; i < numbers.Length; i++)
                numbers[i] = rnd.Next(-100,101);

            Print(numbers);


            //Selezione E stampa tutti i numeri maggiori di 50
            var numbers2 = Search(numbers, NumberGreatherThan50);
            Print(numbers2);

            //Selezione E stampa tutti i numeri tra -20 e +20
            numbers2 = Search(numbers, NumberBetweenM20And20);
            Print(numbers2);


            //Selezione E stampa tutti i numeri negativi
            numbers2 = Search(numbers, NumberIsNegative);
            Print(numbers2);


            //Seleziona E stampa tutti i numeri > 100
            numbers2 = Search(numbers, n => n > 100);
            Print(numbers2);

            //Seleziona i numeri tra -20 e -25 o tra 15 e 16
            numbers2 = Search(numbers, n => (n <= -20 && n >= -25) || (n >= 15 && n <= 16));


            //Restituire il primo numero positivo
            int num = GetFirstOrDefault(numbers, n => n > 0);
            if(num != 0)
                Console.WriteLine(num);


            //Restituire il primo numero tra 40 e 50
            num = GetFirstOrDefault(numbers, n => n >= 40 && n <= 50);
            if (num != 0)
                Console.WriteLine(num);

            //Restituire il primo numero maggiore di -20
            num = GetFirstOrDefault(numbers, n => n > -20);
            if (num != 0)
                Console.WriteLine(num);

            //Quanti elementi sono positivi?
            Console.WriteLine(Count(numbers, n => n >= 0));


            //Quanti elementi sono negativi?
            Console.WriteLine(Count(numbers, n => n < 0));

            //Qaunti elementi tra -15 e 75?
            Console.WriteLine(Count(numbers, n => n >= -15 && n <= 75));

            #endregion


            IList<Employee> employees = new List<Employee>
            {
                new Employee("Davide","Maggiulli", new DateOnly(1987,6,27),178,73,Gender.Male, 1500,"Developer"),
                new Employee("Emanuela","Maggiulli", new DateOnly(1984,8,20),158,55,Gender.Female, 900),
                new Employee("Pamela","Prati", new DateOnly(1964,8,20),155,50,Gender.Female, 500),
                new Employee("Giuseppe","Conte", new DateOnly(1965,5,10),175,70,Gender.Male, 25000),
                new Employee("Pluto","Disney", new DateOnly(1900,5,10),190,80,Gender.Undefined, 250000)
            };

            //La lista di tutti gli uomini
            IEnumerable<Employee> employees2 = Search(employees, e => e.Gender == Gender.Male);

            //La lista di tutti gli uomini alti almeno 180cm
            employees2 = Search<Employee>(employees, e => e.Gender == Gender.Male && e.Height >= 180);

            //La lista di tutte le persone tra 150cm e 170cm
            employees2 = Search(employees, e => e.Height >= 150 && e.Height <= 170);

            //La lista di tutte le donne che guadagnano almeno 1000€
            employees2 = Search(employees, e => e.Gender == Gender.Female && e.Ral >= 1000);

            //La lista di tutte le persone della famiglia Maggiulli
            employees2 = Search(employees, e => e.LastName == "Maggiulli");

            //L'altezza media delle persone

            //Il peso medio delle persone

            //La RAL media delle persone

            //La RAL media di tutte le donne

        }

        private static bool NumberGreatherThan50(int n)
        {
            return n >= 50;
        }
        private static bool NumberBetweenM20And20(int n)
        {
            return n >= -20 && n <= 20;
        }

        private static bool NumberIsNegative(int n)
        {
            return n < 0;
        }
        private static void Print(IEnumerable<int> numbers)
        {
            Console.WriteLine();
            foreach (var n in numbers)
                Console.Write($" {n}");
        }

        //private static int[] Search(int[] numbers, SearchCondition searchCondition)
        //{
        //    IList<int> numbers2 = new List<int>();
        //    foreach (var n in numbers)
        //        if (searchCondition(n))
        //            numbers2.Add(n);
        //    return numbers2.ToArray();
        //}
        //private static IList<Employee> Search(IList<Employee> employees, SearchCondition1 searchCondition)
        //{
        //    IList<Employee> employees1 = new List<Employee>();
        //    foreach (var e in employees)
        //        if (searchCondition(e))
        //            employees1.Add(e);
        //    return employees1;
        //}

        private static IEnumerable<T> Search<T>(IEnumerable<T> items, SearchCondition<T> searchCondition)
        {
            IList<T> result = new List<T>();
            foreach (var item in items)
                if (searchCondition(item))
                    result.Add(item);
            return result;
        }

        private static T GetFirstOrDefault<T>(IEnumerable<T> items, SearchCondition<T> searchCondition)
        {
            foreach (var n in items)
                if (searchCondition(n))
                    return n;

            return default(T);
        }

        private static int Count<T>(IEnumerable<T> items, SearchCondition<T> searchCondition)
        {
            int count = 0;
            foreach (var n in items)
            {
                if (searchCondition(n))
                    count++;
            }
            return count;
        }
    }
}