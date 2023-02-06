namespace Bank
{
    public class Transaction
    {
        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Notes = note;
        }

        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }
    }
}
