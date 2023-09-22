using System;
using System.Collections.Generic;

namespace SupportBank
{
    internal class Program
    {
        public static void Main(string[] args)
        { 
            var transactions = CSVDataHelper.LoadCsvFile("C:\\Work\\Training\\SupportBank\\SupportBank\\Transactions2014.csv");
            
            //take data and print the relevant info 
            
            
            //make a big object of all the names as properties and the values they owe as the property value eg
            //valuesOwed = {christian : 19, james: 23}...
            Dictionary<string, int> amountsPerPerson = new Dictionary<string, int>();
            Console.WriteLine($"AmountsPerPerson above {amountsPerPerson}");
            foreach (var transaction in transactions)
            {
                var nameTo = transaction.To;
                var nameFrom = transaction.From;
                
                if (!amountsPerPerson.ContainsKey(nameTo)) amountsPerPerson.Add(nameTo, 0);
                if (!amountsPerPerson.ContainsKey(nameFrom)) amountsPerPerson.Add(nameFrom, 0);
                //check if name of (from) && (to) transaction is included in valuesOwed[name]
                //if not
                //add the relevant (from) or (to) to valuesOwed
                //add or subtract the values based on (from) or (to)
                //else if 
                //find the name of the person in valuesOwed
                //add or subtract the values based on (from) or (to)
            }
            Console.WriteLine($"AmountsPerPerson {amountsPerPerson}");
           
            // logging
            // exception handling

        }
        
        
    }
}