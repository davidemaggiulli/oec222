namespace OEC222.LinqExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Linq Examples **");


            IList<Employee> employees = new List<Employee>
            {
                new Employee("Davide","Maggiulli", new DateOnly(1987,6,27),178,73,Gender.Male, 1500,"Developer"),
                new Employee("Emanuela","Maggiulli", new DateOnly(1984,8,20),158,55,Gender.Female, 900),
                new Employee("Pamela","Prati", new DateOnly(1964,8,20),155,50,Gender.Female, 500),
                new Employee("Giuseppe","Conte", new DateOnly(1965,5,10),175,70,Gender.Male, 25000),
                new Employee("Pluto","Disney", new DateOnly(1900,5,10),190,80,Gender.Undefined, 250000),
                new Employee("Minni","Disney", new DateOnly(1900,5,10),158,25,Gender.Female, 250000)
            };

            //La lista di tutte le impiegatE
            var emps = employees.Where(x => x.Gender == Gender.Female);

            //Lo stipendio medio dell'azienda
            var ralAvg = employees.Average(x => x.Ral);

            //Lo stipendio medio degli uomini
            ralAvg = employees
                .Where(x => x.Gender == Gender.Male)
                .Average(x => x.Ral);

            //Il primo impiegato che non ha un ufficio assegnato
            var emp = employees.FirstOrDefault(x => x.Office == null);

            //La lista di tutti gli impiegati over 40
            emps = employees.Where(x => x.Age >= 40);  //Lambda  
            /*
             * SELECT E.*
             * FROM employees E
             * WHERE E.Age >= 40
             * */
            emps = from e in employees
                   where e.Age >= 40
                   select e;

            //La lista di tutti gli impiegati ordinati per altezza
            emps = employees.OrderBy(x => x.Height);

            //La lista di tutti gli impiegati ordinati per altezza. A parità di altezza si ordini per peso crescente
            emps = employees
                .OrderBy(x => x.Height)
                .ThenBy(x => x.Weight);

            //La lista di tutti gli impiegati ordinati per altezza. A parità di altezza per stipendio decrescente
            emps = employees
                .OrderBy(x => x.Height)
                .ThenByDescending(x => x.Ral);

            //La lista di tutti gli impiegati ordinati per peso decrescente
            emps = employees
                .OrderByDescending(x => x.Weight);

            //La lista di tutti gli impiegati "al contrario"
            emps = employees.Reverse();

            //I primi due impiegati
            emps = employees.Take(2);

            //Gli ultimi due impiegati
            emps = employees.Reverse().Take(2);

            //I "secondi" due impiegati
            emps = employees.Skip(2).Take(2);

            //Il 5 e il 6 impiegato
            emps = employees.Skip(4).Take(2);


            //Lo stipendio minimo
            decimal min = employees.Min(x => x.Ral);

            //Lo stipendio massimo
            decimal max = employees.Max(x => x.Ral);

            //La somma di tutti gli stipendi
            decimal sum = employees.Sum(x => x.Ral);

            //Quandi impiegati hanno peso maggiore del peso medio?
            var weightAvg = employees.Average(x => x.Weight);
            int count = employees.Count(x => x.Weight > weightAvg);

            //Tutti gli impiegati hanno il genere "valorizzato" ?   SI/NO ??
            bool result = employees.All(x => x.Gender != Gender.Undefined);

            //Esiste almeno un impiegato con ufficio assegnato?  SI/NO ?
            result = employees.Any(x => !string.IsNullOrEmpty(x.Office));




        }
    }
}