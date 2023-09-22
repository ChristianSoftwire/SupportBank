using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SupportBank
{
    public class JsonDataHelper
    {
        public static List<Transaction> LoadJsonFile(string filePath)
        {
            using (StreamReader reader =
                   new StreamReader(filePath))
            {
                var jsonString = reader.ReadToEnd();
                
                var json = JsonConvert.DeserializeObject<List<Transaction>>(jsonString);
                
                return json;
            }
        }
    }
}