using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public float Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
    }
}
