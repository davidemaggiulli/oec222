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
            if(op == "+")
            {
                Console.WriteLine("Somma tra : " + c1.ToString() + " e " + c2.ToString() + " : " + c1.Sum(c2).ToString());
            } 
            else if(op == "-")
            {

            } 
            else if(op == "*")
            {

            } 
            else if(op == "/")
            {

            } 
            else
            {

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