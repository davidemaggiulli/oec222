using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.Models
{
    [Serializable]
    internal class Movement
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Description { get; }

        public Movement(decimal amount, string description, DateTime date)
        {
            Amount = amount;
            Date = date;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Date:d}\t{Amount:C}\t{Description}";
        }
    }
}
