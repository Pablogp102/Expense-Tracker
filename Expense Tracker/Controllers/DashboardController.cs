using System.Globalization;

using Expense_Tracker.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ExpenseTrackerDbContext _context;
        public DashboardController(ExpenseTrackerDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //Last 7 Days 
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransaction = await _context.Transactions
                .Include(c => c.Category)
                .Where(d => d.Date >= StartDate && d.Date <= EndDate)
                .ToListAsync();
            //Total Income 

            float TotalIncome = SelectedTransaction
                .Where(i => i.Category.Type == "Income")
                .Sum(j => j.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("0.00zł");

            //Total Expense

            float TotalExpense = SelectedTransaction
               .Where(i => i.Category.Type == "Expense")
               .Sum(j => j.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("0.00zł");

            //Balance 
            float Balance = TotalIncome - TotalExpense;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("pl-PL");
            culture.NumberFormat.CurrencyNegativePattern = 1;
            ViewBag.Balance = String.Format(culture, "{0:C}", Balance);

            return View();
        }
    }
}
