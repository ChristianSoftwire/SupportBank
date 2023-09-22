namespace SupportBank
{
    public class Transaction
    {
        public string Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Narrative { get; set; }
        public float Amount { get; set; }
        
        //can override default methods such as ToString on a class
        // public override string ToString()
        // {
        //     return From + " ==> " + To;
        // }
    }
}