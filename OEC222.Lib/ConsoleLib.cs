using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Lib
{
    public static class ConsoleLib
    {
        public static double ReadDoubleFromConsole(string msg)
        {
            double result;
            string input = null;
            do
            {
                Console.Write(msg);
                input = Console.ReadLine();
            } while (!double.TryParse(input, out result));
            return result;
        }

        public static int ReadNaturalFromConsole(string msg)
        {
            int result;
            string input = string.Empty;
            do
            {
                Console.Write(msg);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out result) || result <= 0);
            return result;
        }

        public static string ReadStringFromConsole(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }
    }
}
