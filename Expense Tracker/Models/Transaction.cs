using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter the category.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Range(0.01, long.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public float Amount { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string? CategoryTitleWithIcon 
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;  
            } 
        }
        [NotMapped]
        public string? FormattedAmount 
        { 
            get 
            {
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + Amount.ToString("0.00zł");
            }  
        }

    }
}
