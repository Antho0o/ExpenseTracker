using System.Collections.Generic;

namespace ExpenseTracker.Models
{
    public class DashboardViewModel
    {
        public decimal Balance { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpenses { get; set; }

        public List<Transaction> RecentTransactions { get; set; }
            = new List<Transaction>();

        public Dictionary<string, decimal> ExpensesByCategory { get; set; }
            = new Dictionary<string, decimal>();
    }
}