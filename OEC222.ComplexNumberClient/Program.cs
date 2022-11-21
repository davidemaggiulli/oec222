using OEC222.Lib;

namespace OEC222.ComplexNumberClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Complex Number Test");


            double real1 = ConsoleLib.ReadDoubleFromConsole("Parte reale 1:  ");
            double imaginary1 = ConsoleLib.ReadDoubleFromConsole("Parte immaginaria 1:  ");

            double real2 = ConsoleLib.ReadDoubleFromConsole("Parte reale 2:  ");
            double imaginary2 = ConsoleLib.ReadDoubleFromConsole("Parte immaginaria 2:  ");

            ComplexNumber c1 = new ComplexNumber(real1, imaginary1);
            ComplexNumber c2 = new ComplexNumber(real2, imaginary2);

            Console.Write("Indicare operazione (+,-,*,/):  ");
            string op = Console.ReadLine();

            ILogger logger = FileLogger.GetIstance();
            //ILogger logger = new ConsoleLogger();
            if (op == "+")
            {
                logger.Info("Somma tra : " + c1.ToString() + " e " + c2.ToString() + " : " + c1.Sum(c2).ToString());
            } 
            else if(op == "-")
            {
                string res = $"Differenza tra {c1} e {c2}: {c1.Sub(c2)}";
                string res1 = string.Format("Differenza tra {0} e {1}: {2}", c1, c2, c1.Sub(c2));
                logger.Info(res);
            }
            else if(op == "*")
            {
                logger.Info($"Prodotto tra {c1} e {c2}: {c1.Mult(c2)}");
            } 
            else if(op == "/")
            {
                logger.Info($"Quoziente tra {c1} e {c2}: {c1.Div(c2)}");

            }
            else
            {
                logger.Error("operazione non valida");
            }

            //switch (op)
            //{
            //    case "+":
            //        var result = c1.Sum(c2);
            //        break;
            //    case "-":
            //        var result = c1.Sub(c2);
            //        break;

            //}

           

            Console.ReadLine();

        }
    }
}