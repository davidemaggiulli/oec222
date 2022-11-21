using OEC222.Lib;

namespace OEC222.StaticExample
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ILogger logger = FileLogger.GetIstance();

            logger.Info("Static Examples");
            logger.Info("log info");
            logger.Warning("log warning");
            logger.Error("log error");


            var c1 = new NonStaticClass();
            var c2 = new NonStaticClass();

            NonStaticClass.MyPropStatic = "STATO INTERNO CONDIVISO";
            c1.MyPropNonStatic = "A";
            c2.MyPropNonStatic = "B";

            NonStaticClass.MyPropStatic = "STATO INTERNO CONDIVISO - AGGIORNATO";

        }
    }
}