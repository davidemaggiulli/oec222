using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.Models
{
    internal class BalanceNotSufficientException : Exception
    {
        public Account Account { get; }
        public decimal Amount { get; }

        public BalanceNotSufficientException(Account account, decimal amount) : base($"L'account {account.Number:D8} ha un saldo di {account.Amount:C2} non sufficiente per la gestone dell'importo {amount:C2}")
        {
            Amount = amount;
            Account = account;
        }
    }
}
