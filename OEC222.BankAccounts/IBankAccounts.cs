using BankAccounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    internal interface IBankAccounts
    {
        IList<Account> GetAllAccounts();

        Account GetAccountByNumber(int number);

        /// <summary>
        /// Inserisce un nuovo conto
        /// </summary>
        /// <param name="account">Conto da inserire</param>
        /// <exception cref="AccountAlreadyExistsException">Se il conto identificato dal numero esiste già</exception>
        /// <returns></returns>
        bool InsertAccount(Account account);

        /// <summary>
        /// Prelevo un importo dal conto
        /// </summary>
        /// <param name="account">Conto da cui prelevare</param>
        /// <param name="amount">Importo da prelevare</param>
        /// <param name="error">Errore</param>
        /// <exception cref="BalanceNotSufficientException">Nel caso in cui l'importo non sia sufficiente</exception>
        /// <returns></returns>
        bool TakeMoney(Account account, decimal amount, out string error);

        bool StoreMoney(Account account, decimal amount);
    }
}
