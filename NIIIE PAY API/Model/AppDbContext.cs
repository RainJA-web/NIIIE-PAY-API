using Microsoft.EntityFrameworkCore;
using NIIIE_PAY_API.Model;

namespace NIIEPayAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
               : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Savings> Savings { get; set; }
        public DbSet<InterestRate> InterestRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Khóa chính cho TransactionId
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);

            // Khóa chính cho SavingId
            modelBuilder.Entity<Savings>()
                .HasKey(s => s.SavingId);

            // Seed lãi suất nếu cần
            modelBuilder.Entity<InterestRate>().HasData(
                new InterestRate { TermMonths = 1, InterestRateValue = 3.5 },
                new InterestRate { TermMonths = 2, InterestRateValue = 3.7 },
                new InterestRate { TermMonths = 3, InterestRateValue = 3.8 },
                new InterestRate { TermMonths = 6, InterestRateValue = 4.8 },
                new InterestRate { TermMonths = 9, InterestRateValue = 4.9 },
                new InterestRate { TermMonths = 12, InterestRateValue = 5.2 },
                new InterestRate { TermMonths = 18, InterestRateValue = 5.5 },
                new InterestRate { TermMonths = 24, InterestRateValue = 5.8 },
                new InterestRate { TermMonths = 36, InterestRateValue = 5.8 }
            );
        }
    }
}
