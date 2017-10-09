using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    class Transaction
    {

        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Narrative { get; set; }
        public Decimal Amount { get; set; }



        public Transaction(DateTime date, string nameFrom, string nameTo, string narrative, Decimal amount)
        {
            Date = date;
            From = nameFrom;
            To = nameTo;
            Narrative = narrative;
            Amount = amount;
        }
    }
}
