using System.Collections.Generic;

namespace SupportBank
{
    public class ListAmounts
    {
        public static Dictionary<string, float> GetAmounts(List<Transaction> transactions)
        {
            var amountsPerPerson = new Dictionary<string, float>();

            foreach (var transaction in transactions)
            {
                var nameTo = transaction.To;
                var nameFrom = transaction.From;
                var amountOfTransaction = transaction.Amount;

                if (!amountsPerPerson.ContainsKey(nameTo))
                {
                    amountsPerPerson.Add(nameTo, 0);
                }

                if (!amountsPerPerson.ContainsKey(nameFrom))
                {
                    amountsPerPerson.Add(nameFrom, 0);
                }

                amountsPerPerson[nameTo] += amountOfTransaction;
                amountsPerPerson[nameFrom] -= amountOfTransaction;
            }
            
            return amountsPerPerson;
        }
    }
}