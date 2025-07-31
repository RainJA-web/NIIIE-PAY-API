namespace NIIIE_PAY_API.Model
{
    public class Account
    {
        public int SavingId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public string Phone { get; set; }
        public string CitizenId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal AvailableBalance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Savings> Savings { get; set; }
    }
}
