using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace SupportBank
{
    public static class CSVDataHelper
    {
        
        public static IEnumerable<Transaction> LoadCsvFile(string filePath)
        {
            // open the file
            // read the data out to a list
            // return the list

            using (var reader = new StreamReader(filePath))
            {
       
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))


                {
                    return csv.GetRecords<Transaction>().ToList();
                }
            }
        }
    }
}