using System.ComponentModel.DataAnnotations;

namespace NIIIE_PAY_API.Model
{
    public class Savings
    {
        [Key]
        public string SavingId { get; set; }

        public string AccountNumber { get; set; }
        public Account Account { get; set; }

        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public double InterestRate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public bool AutoRenew { get; set; }
    }

}
