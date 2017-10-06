using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {

           

            var reader = new StreamReader(File.OpenRead(@"C:\Work\Training\SupportBank\Transactions2014.csv"));

            List<Transaction> Transactions = new List<Transaction>();

            
            Console.WriteLine("Please choose from the following two options");
            Console.WriteLine("1) List accounts and balances");
            Console.WriteLine("2) List all transactions on accounts");

            if (  "1")


            reader.ReadLine();
            while (!reader.EndOfStream)
            {

                var line = reader.ReadLine();
                var splitline = line.Split(',');

                Transaction Eachtransaction = new Transaction(DateTime.Parse(splitline[0]), splitline[1], splitline[2], splitline[3], Decimal.Parse(splitline[4]));



                Console.WriteLine(splitline[0] + " " + splitline[1] + " " + splitline[2] + " " + splitline[3] + " " + splitline[4]);
                
            }
            
            Console.ReadLine();
        }
    }
}
