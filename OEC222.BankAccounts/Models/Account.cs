using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.Models
{
    [Serializable]
    internal class Account
    {
        public int Number { get; }

        public string BankName { get; }

        public string Holder { get; }

        public decimal Amount { get; private set; }

        public DateTime LastOperationDate { get; private set; }

        public IList<Movement> Movements { get; }

        public Account(int number, string holder, string bankName, decimal amount, DateTime lastOp)
        {
            Number = number;
            Holder = holder;
            BankName = bankName;
            Amount = amount;
            LastOperationDate = lastOp;
            Movements = new List<Movement>();
        }

        public Account(int number, string holder, string bankName) : this(number, holder, bankName, 0, DateTime.Now)
        {

        }

        public override string ToString()
        {
            return $"{Number:D8}\t{Holder}\t{BankName}\t{Amount:C3}\t{LastOperationDate}";
        }

        public void AddAmount(decimal amount)
        {
            Movement movement = new Movement(amount, "Deposito", DateTime.Now);
            Movements.Add(movement);
            Amount += movement.Amount;  //Amount = Amount + amount;
            LastOperationDate = movement.Date;
        }

        public void RemoveAmount(decimal amount)
        {
            if(Amount - amount < 0)
            {
                throw new BalanceNotSufficientException(this, amount);
            }
            Movement movement = new Movement(-amount, "Prelievo", DateTime.Now);
            Movements.Add(movement);
            Amount -= amount;
            LastOperationDate = movement.Date;
        }

        public static bool operator +(Account account, decimal amount)
        {
            account.AddAmount(amount);
            return true;
        }

        public static bool operator -(Account account, decimal amount)
        {
            account.RemoveAmount(amount);
            return true;
        }

        public string Statement()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Numbero conto:\t{Number:D8}");
            sb.AppendLine($"Titolare:\t{Holder}");
            sb.AppendLine($"Banca:\t{BankName}");
            sb.AppendLine($"Saldo:\t{Amount:C}");
            sb.AppendLine($"Data Ultima Operazione:\t{LastOperationDate}");
            sb.AppendLine($"Numero Movimenti:\t{Movements.Count}");

            if (Movements.Count > 0)
            {
                sb.AppendLine("\nMovimenti");
                sb.AppendLine("Data\t\tImporto\t\tDescrizione");
                foreach (var m in Movements)
                    sb.AppendLine($"{m}");
            }
            
            return sb.ToString();
        }
    }
}
