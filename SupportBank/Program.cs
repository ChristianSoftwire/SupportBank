using System;
using System.Collections.Generic;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // List<Transaction> transactions2014 = null;
            // List<Transaction> dodgyTransactions = null;
            // List<Transaction> transactions2013 = null;
            //
            // var amountsPerPerson = ListAmounts.GetAmounts(transactions2014);
            
            HandleUserInteractions();
        }

        private static void PrintAccountValues(List<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                var date = transaction.Date;
                var narrative = transaction.Narrative;
                var from = transaction.From;
                var to = transaction.To;
                var amount = Math.Round(transaction.Amount, 2);

                Console.WriteLine($"{from} owes {to} £{amount} for {narrative} on {date}");
            }
        }

        private static void PrintOwningAmount(Dictionary<string, float> amountsPerPerson)
        {
            foreach (var amount in amountsPerPerson)
            {
                var amountForCurrentUser = Math.Round(amount.Value, 2);
                var nameOfCurrentUser = amount.Key;

                if (amountForCurrentUser >= 0)
                {
                    Console.WriteLine($"{nameOfCurrentUser} is owed £{amountForCurrentUser}");
                }
                else
                {
                    Console.WriteLine($"{nameOfCurrentUser} owes £{Math.Abs(amountForCurrentUser)}");
                }
            }
        }

        private static List<Transaction> LoadTransactions(string filePath)
        {
            List<Transaction> transactions = null;
            var logger = new Logger(LogManager.GetCurrentClassLogger());
            if (filePath.Contains(".json"))
            {
                try
                {
                    transactions = JsonDataHelper.LoadJsonFile(filePath);
                }
                catch (Exception e)
                {
                    logger.LogError(e);
                }
            }
            else
            {
                try
                {
                    transactions = CsvDataHelper.LoadCsvFile(filePath);
                }
                catch (Exception e)
                {
                    logger.LogError(e);
                }
            }

            return transactions;
        }

        private static void HandleUserInteractions()
        {
            Console.Write("Enter what you want to see ");
            var userInput = Console.ReadLine();

            var transactions2014 = LoadTransactions(@"C:\Work\Training\SupportBank\SupportBank\Transactions2014.csv");
            var amountsPerPerson2014 = ListAmounts.GetAmounts(transactions2014);

            if (userInput == "List All")
            {
                PrintOwningAmount(amountsPerPerson2014);
            }
            else if (userInput != null && userInput.Contains("Import"))
            {
                var transactionsCustomFile = LoadTransactions(userInput);
                var amountsPerPersonCustomFile = ListAmounts.GetAmounts(transactionsCustomFile);
                PrintOwningAmount(amountsPerPersonCustomFile);
            }
            else
            {
                PrintAccountValues(transactions2014);
            }
        }
    }
}