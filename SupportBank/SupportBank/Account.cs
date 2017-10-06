using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    class Accounts

    {
        public string Name { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Decimal GetBalance()
        {
            Decimal balance = 0;
            foreach (var transaction in Transactions)
            {
                if (transaction.From == Name)
                {
                    balance = balance - transaction.Amount;
                }
                else if (transaction.To == Name)
                {
                    balance = balance + transaction.Amount;
                }
            }
            return balance;



        }

    }
}  
 

