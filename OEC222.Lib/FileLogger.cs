using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Lib
{
    public class FileLogger : ILogger
    {
        private string fileName;

        private static FileLogger instance = null;
        private static object l = new object();
        private FileLogger()
        {
            this.fileName = "log.txt";
        }

        public static FileLogger GetIstance()
        {
            lock (l)
            {
                if (instance == null)
                    instance = new FileLogger();
            }
            return instance;
        }


        public void Error(string message)
        {
            string msg = $"[ERROR]\t{DateTime.Now}\t{message}\n";
            File.AppendAllText(fileName, msg);
        }

        public void Info(string message)
        {
            string msg = $"[INFO]\t{DateTime.Now}\t{message}\n";
            File.AppendAllText(fileName, msg);
        }

        public void Warning(string message)
        {
            string msg = $"[WARNING]\t{DateTime.Now}\t{message}\n";
            File.AppendAllText(fileName, msg);
        }
    }
}
