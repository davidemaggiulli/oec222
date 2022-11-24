using BankAccounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    internal class SerializeBankAccounts : IBankAccounts
    {
        private IList<Account> _accounts;
        private const string fileName = "accounts.bin";

        public SerializeBankAccounts()
        {
            if(!LoadFromFile())
                _accounts = new List<Account>();
        }
        public Account GetAccountByNumber(int number)
        {
            foreach(Account account in _accounts)
                if(account.Number == number)
                    return account;
            return null;
        }

        public IList<Account> GetAllAccounts()
        {
            return _accounts;
        }

        public bool InsertAccount(Account account)
        {
            Account existing = GetAccountByNumber(account.Number);
            if (existing != null)
            {
                throw new AccountAlreadyExistsException(account);
            }
            _accounts.Add(account);
            return SaveToFile();
        }

        public bool StoreMoney(Account account, decimal amount)
        {
            return account + amount && SaveToFile();
        }

        public bool TakeMoney(Account account, decimal amount, out string error)
        {
            error = null;
            try
            {
                return account - amount && SaveToFile();
            }catch(BalanceNotSufficientException e)
            {
                error = e.Message;
                return false;
            }
        }

        private bool LoadFromFile()
        {
            IFormatter formatter = new BinaryFormatter();
            try
            {
                using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    _accounts = (IList<Account>)formatter.Deserialize(stream);
                } 
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private bool SaveToFile()
        {
            IFormatter formatter = new BinaryFormatter();
            using(var stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, _accounts);
                stream.Close();
            }
            return true;
        }

    }
}
