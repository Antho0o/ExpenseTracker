using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExpenseTrackerContext _context;

        public HomeController(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var transactions = await _context.Transactions
                .AsNoTracking()
                .OrderByDescending(t => t.Date)
                .ThenByDescending(t => t.Id)
                .ToListAsync();

            var totalIncome = transactions
                .Where(t => t.Type == "Income")
                .Sum(t => t.Amount);

            var totalExpenses = transactions
                .Where(t => t.Type == "Expense")
                .Sum(t => t.Amount);

            var dashboard = new DashboardViewModel
            {
                Balance = totalIncome - totalExpenses,

                TotalIncome = totalIncome,

                TotalExpenses = totalExpenses,

                RecentTransactions = transactions
                    .Take(5)
                    .ToList(),

                ExpensesByCategory = transactions
                    .Where(t => t.Type == "Expense")
                    .GroupBy(t => t.Category)
                    .ToDictionary(
                        group => group.Key,
                        group => group.Sum(t => t.Amount)
                    )
            };

            return View(dashboard);
        }
    }
}