using System.ComponentModel.DataAnnotations;

namespace NIIIE_PAY_API.Model
{
    public class Transaction
    {
        [Key]
        public string TransactionId { get; set; }
        public string AccountNumber { get; set; } // FK
        public Account Account { get; set; }

        public decimal Amount { get; set; }
        public DateTime TransactionTime { get; set; }
        public decimal BalanceAfter { get; set; }
        public string Note { get; set; }

    }

}
