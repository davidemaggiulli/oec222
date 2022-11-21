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
    }
}
