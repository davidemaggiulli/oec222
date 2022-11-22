using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.Models
{
    internal class AccountAlreadyExistsException : Exception
    {
        public Account Account { get; }

        public AccountAlreadyExistsException(Account account) : base($"L'account {account.Number} esiste già")
        {
            Account = account;
        }
    }
}
