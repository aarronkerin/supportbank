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
            Dictionary<string, Accounts> accounts = new Dictionary<string, Accounts>();
            List<Transaction> Transactions = new List<Transaction>();

            
            Console.WriteLine("Please choose from the following two options");
            Console.WriteLine("1) List accounts and balances");
            Console.WriteLine("2) List all transactions on accounts");

            


            reader.ReadLine();
            while (!reader.EndOfStream)
            {

                var line = reader.ReadLine();
                var splitline = line.Split(',');

                Transaction Eachtransaction = new Transaction(DateTime.Parse(splitline[0]), splitline[1], splitline[2], splitline[3], Decimal.Parse(splitline[4]));
                Transactions.Add(Eachtransaction);



                Console.WriteLine(splitline[0] + " " + splitline[1] + " " + splitline[2] + " " + splitline[3] + " " + splitline[4]);
                
            }

            foreach (var transaction in Transactions)
            {
                // accounts dictionary has the key "transaction.From"
                if (accounts.ContainsKey(transaction.From))
                {
                    accounts[transaction.From].Transactions.Add(transaction);
                }
                else
                {
                    List<Transaction> accounttrans = new List<Transaction>();
                    accounttrans.Add(transaction);

                    Accounts account = new Accounts();
                    account.Name = transaction.From;
                    account.Transactions = accounttrans;


                    string name = transaction.From;

                    accounts.Add(name, account);



                    // Add new Account to dictionary with key: account.Name, value: account 

                }
                if (accounts.ContainsKey(transaction.To))

                {
                    accounts[transaction.To].Transactions.Add(transaction);
                }
                else
                { 
                    List<Transaction> accounttrans = new List<Transaction>();
                    accounttrans.Add(transaction);

                    Accounts account = new Accounts();
                    account.Name = transaction.To;
                    account.Transactions = accounttrans;


                    string name = transaction.To;

                    accounts.Add(name, account);
                }

            }

            foreach (var account in accounts.Values)
            {
                Console.WriteLine(account.Name + ": £" + account.GetBalance());
            }
            
            Console.ReadLine();
        }
    }
}
