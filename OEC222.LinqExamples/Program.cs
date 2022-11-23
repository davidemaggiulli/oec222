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
                new Employee("Luca","Rossi", new DateOnly(1984,8,20),158,55,Gender.Male, 900),
                new Employee("Pamela","Prati", new DateOnly(1964,8,20),155,50,Gender.Female, 500),
                new Employee("Marco","Bianchi", new DateOnly(1964,8,20),155,50,Gender.Male, 500),
                new Employee("Giuseppe","Conte", new DateOnly(1965,5,10),175,70,Gender.Male, 25000),
                new Employee("Pluto","Disney", new DateOnly(1900,5,10),190,80,Gender.Undefined, 250000),
                new Employee("Minni","Disney", new DateOnly(1900,5,10),158,25,Gender.Female, 250000),
                new Employee("Francesca","Dal Ponte", new DateOnly(1984,5,10),158,25,Gender.Female, 900)
            };

            //La lista di tutte le impiegatE
            var emps = employees.Where(x => x.Gender == Gender.Female);

            //Lo stipendio medio dell'azienda
            var ralAvg = employees.Average(x => x.Ral);

            //Lo stipendio medio degli uomini
            ralAvg = employees
                .Where(x => x.Gender == Gender.Male)
                .Average(x => x.Ral);

            //Il primo impiegato (o defualt) che non ha un ufficio assegnato
            var emp = employees.FirstOrDefault(x => x.Office == null);

            //Il primo impiegato alto 120cm 
            try
            {
                emp = employees.First(x => x.Height == 120);
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            

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


            //Restituire la lista di altezza dei dipendenti
            /*
             * SELECT E.Height
             * FROM Employees E
             * */
            IEnumerable<int> heights = employees.Select(x => x.Height).OrderBy(x => x);

            //Restituire la lista di nomi completi dei dipendenti
            IList<string> names = new List<string>();
            foreach (var e in employees)
                names.Add($"{e.FirstName} {e.LastName}");

            var names2 = employees.Select(x => $"{x.FirstName} {x.LastName}");

            //Restituire la lista di dipendenti con la loro RAL
            /*
             * SELECT E.FirstName + ' ' + E.LastName AS Name, E.RAL
             * FROM Employees E
             * */

            IList<EmployeeWithRal> emps2 = new List<EmployeeWithRal>();
            foreach (var e in employees)
                emps2.Add(new EmployeeWithRal
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    Ral = e.Ral
                });
            var emps3 = employees.Select(e => new EmployeeWithRal
            {
                Name = $"{e.FirstName} {e.LastName}",
                Ral = e.Ral
            });
            Print(emps3);
            var emp4 = employees.Select(e => new
            {
                Name = $"{e.FirstName} {e.LastName}",
                Ral = e.Ral
            });

            //La lista di donne ordinate per altezza (fornire nome completo, ral e altezza)
            var emps5 = employees
                .Where(x => x.Gender == Gender.Female)
                .Select(x => new
                {
                    Name = $"{x.FirstName} {x.LastName}",
                    x.Ral,
                    EmployeeHeight = x.Height
                })
                .OrderBy(x => x.EmployeeHeight);


            //Raggruppa gli impiegati per stipendio e indica quanti impiegati prendono quello stipendio
            /*
             * 250000 2
             * 25000 1
             * 1500 1
             * 900 1
             * 500 1
             * */
            var empsGrouped = employees.GroupBy(x => x.Ral)
                .OrderByDescending(x => x.Key);
            foreach(var e in empsGrouped)
            {
                Console.WriteLine($"{e.Key} \t\t {e.Count()}");
            }

            //Raggruppa gli impiegati per stipendio e indica l'altezza media degli impiegati
            foreach (var e in empsGrouped)
            {
                decimal ral = e.Key;
                double avg = e.Average(x => x.Height);
                Console.WriteLine($"{ral} \t\t {avg:F2}");
            }

            //Raggruppa gli impiegati per stipendio-genere e indica quanti elementi ci sono per ogni gruppo.
            var empsGrouped2 = employees.GroupBy(x => new RalGender(x.Ral, x.Gender))
            //{
            //    x.Ral,
            //    x.Gender
            //})
            .OrderBy(x => x.Key.Ral);
            
            foreach(var i in empsGrouped2)
            {
                Console.WriteLine($"{i.Key.Ral}:C2 # {i.Key.Gender}  --> {i.Count()}");
            }

            //Quali sono i distinti stipendi erogati ?
            var rals = employees.GroupBy(x => x.Ral)
                .Select(x => x.Key);

            var rals2 = employees
                .Select(x => x.Ral)
                .Distinct();

            var rals3 = rals.Union(rals2);
            var rals4 = rals.Union(new List<decimal> { 100,200 });
            var rals5 = rals.ToList();
            rals5.AddRange(rals3.ToList());
            var rals6 = rals5.Intersect(rals);
            var rals7 = rals4.Except(rals);

            var item = employees.Single(x => x.Gender == Gender.Female);
        }

        private static void Print(IEnumerable<EmployeeWithRal> items)
        {
            foreach (var i in items)
                Console.WriteLine($"{i.Name}\t\t{i.Ral:C3}");
        }
    }
}