using BankAccounts.Models;
using OEC222.Lib;

namespace BankAccounts
{
    internal class Program
    {
        private static ILogger _logger;
        private static IBankAccounts _bankAccounts;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            _logger = new ConsoleLoggerSimple();
            _bankAccounts = new SerializeBankAccounts();

            _logger.Info("Banks App");

            string scelta = string.Empty;

            do
            {
                PrintMenu();
                _logger.Info("Scegli un'opzione:  ");
                scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        _logger.Info(">> Lista conti");
                        foreach (var a in _bankAccounts.GetAllAccounts())
                            _logger.Info(a.ToString());

                        break;

                    case "2":
                        InsertAccount();
                        break;

                    case "3":
                        TakeMoney();

                        break;

                    case "4":
                        StoreMoney();
                        break;
                    case "5":
                        AccountDetails();
                        break;

                    case "H":
                    case "h":
                        PrintMenu();
                        break;

                    case "Q":
                    case "q":
                        _logger.Warning(">> Uscita ... ");
                        break;
                    default:
                        _logger.Error("Scelta non valida");
                        break;

                } 
            }while (scelta != "q" && scelta != "Q");


        }


        private static void PrintMenu()
        {
            _logger.Info("[ 1 ] - Lista Account");
            _logger.Info("[ 2 ] - Inserisci Account");
            _logger.Info("[ 3 ] - Prelievo");
            _logger.Info("[ 4 ] - Deposito");
            _logger.Info("[ 5 ] - Dettagli Account");
            _logger.Info("[ H ] - Help");
            _logger.Info("[ Q ] - Uscita");
        }

        private static void InsertAccount()
        {
            string bankName = ConsoleLib.ReadStringFromConsole("Banca:  ");
            string holder = ConsoleLib.ReadStringFromConsole("Titolare:  ");
            int number = ConsoleLib.ReadNaturalFromConsole("Numero conto:  ");

            Account account = new Account(number, holder, bankName);
            try
            {
                if (_bankAccounts.InsertAccount(account))
                {
                    _logger.Info($"Conto {number:D8} inserito correttamente");
                    _logger.Info(account.Statement());
                }
                else
                {
                    _logger.Error("Errore durante inserimento conto.");
                }
            }
            catch (AccountAlreadyExistsException e1)
            {
                _logger.Error($"Controlla il numero di conto inserito: " + e1.Message);
            }
            catch (Exception e)
            {
                _logger.Error("Errore durante inserimento conto.");
                _logger.Error(e.Message);
            }
        }
        private static void TakeMoney()
        {
            int number = ConsoleLib.ReadNaturalFromConsole("Numero Conto:  ");
            Account account = _bankAccounts.GetAccountByNumber(number);
            if(account == null)
            {
                _logger.Error($"Conto {number:D8} non trovato.");
                return;
            }
            decimal amount = (decimal)ConsoleLib.ReadDoubleFromConsole("Importo:  ");
            string err;
            if(_bankAccounts.TakeMoney(account, amount, out err))
            {
                _logger.Info("Importo prelevato correttamente");
                _logger.Info(account.Statement());
            }
            else
            {
                _logger.Error("Errore durante prelievo: " + err);
            }
        }

        private static void StoreMoney()
        {
            int number = ConsoleLib.ReadNaturalFromConsole("Numero Conto:  ");
            Account account = _bankAccounts.GetAccountByNumber(number);
            if (account == null)
            {
                _logger.Error($"Conto {number:D8} non trovato.");
                return;
            }
            decimal amount = (decimal)ConsoleLib.ReadDoubleFromConsole("Importo:  ");
            if (_bankAccounts.StoreMoney(account, amount))
            {
                _logger.Info("Importo depositato correttamente");
                _logger.Info(account.Statement());
            }
            else
            {
                _logger.Error("Errore durante depositato");
            }
        }

        private static void AccountDetails()
        {
            int number = ConsoleLib.ReadNaturalFromConsole("Numero Conto:  ");
            Account account = _bankAccounts.GetAccountByNumber(number);
            if (account == null)
            {
                _logger.Error($"Conto {number:D8} non trovato.");
                return;
            }
            _logger.Info(account.Statement());
        }

    }
}