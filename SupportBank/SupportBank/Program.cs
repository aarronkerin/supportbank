
using NLog;
using NLog.Config;
using NLog.Targets;
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
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {

            {
                var config = new LoggingConfiguration();
                var target = new FileTarget { FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
                config.AddTarget("File Logger", target);
                config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
                LogManager.Configuration = config;

            }
            

            

            var reader = new StreamReader(File.OpenRead(@"C:\Work\Training\SupportBank\DodgyTransactions2015.csv"));
            Dictionary<string, Accounts> accounts = new Dictionary<string, Accounts>();
            List<Transaction> Transactions = new List<Transaction>();




                reader.ReadLine();
           
           
            while (!reader.EndOfStream)
            {

                var line = reader.ReadLine();
                var splitline = line.Split(',');

                try
                {

                    Transaction Eachtransaction = new Transaction(DateTime.Parse(splitline[0]), splitline[1], splitline[2], splitline[3], Decimal.Parse(splitline[4]));
                    Transactions.Add(Eachtransaction);
                }
                catch (Exception e)
                {
                    logger.Warn("Error occured on the following line: " + line);
                    logger.Warn("error message was " + e.Message);
                }


                Console.WriteLine(splitline[0] + " " + splitline[1] + " " + splitline[2] + " " + splitline[3] + " " + splitline[4]);
                
            }

            foreach (var transaction in Transactions)
            {
                
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
            Console.WriteLine("Who's account would you like to view?");
            var accountname = Console.ReadLine();

            if (accounts.ContainsKey(accountname))
            {
                foreach (var transaction in accounts[accountname].Transactions)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", transaction.Date.ToLongDateString(), transaction.From, transaction.To, transaction.Narrative, transaction.Amount);


                }
            }
            else
            {
                Console.WriteLine("Name does not exist. Sorry");
            }
            Console.ReadLine();
        }

    }
}
