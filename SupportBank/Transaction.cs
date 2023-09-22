using Newtonsoft.Json;

namespace SupportBank
{
    public class Transaction
    {
        public string Date { get; set; }
        [JsonProperty("FromAccount")] 
        public string From { get; set; }
        [JsonProperty("ToAccount")] public string To { get; set; }
        public string Narrative { get; set; }
        public float Amount { get; set; }

        //can override default methods such as ToString on a class
        // public override string ToString()
        // {
        //     return From + " ==> " + To;
        // }
    }
}