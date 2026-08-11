using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{
    public class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext(
            DbContextOptions<ExpenseTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);
        }
    }
}