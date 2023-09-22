using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using NLog;

namespace SupportBank
{
    public static class CsvDataHelper
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        
        public static List<Transaction> LoadCsvFile(string filePath)
        {
   
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