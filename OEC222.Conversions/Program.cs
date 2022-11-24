namespace OEC222.Conversions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Conversions ** ");

            Digit d = new Digit(10);

            byte number = d;        //Conversione implicita

            //Digit d1 = number;


        }
    }
}