using System.ComponentModel.DataAnnotations;

namespace NIIIE_PAY_API.Model
{
    public class InterestRate
    {
        public int TermMonths { get; set; } // kỳ hạn
        public double InterestRateValue { get; set; } // lãi suất

        // ⚠️ Nếu em muốn seed data, nhớ thêm ID:
        public int Id { get; set; }  // bắt buộc nếu dùng .HasData()
    }

}
