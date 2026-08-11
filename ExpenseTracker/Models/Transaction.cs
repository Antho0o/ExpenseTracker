using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(
            100,
            MinimumLength = 2,
            ErrorMessage = "Description must be between 2 and 100 characters."
        )]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Please enter an amount.")]
        [Range(
            0.01,
            100000000,
            ErrorMessage = "Amount must be greater than R0."
        )]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public string Category { get; set; } = "";

        [Required(ErrorMessage = "Please select a transaction type.")]
        [RegularExpression(
            "^(Income|Expense)$",
            ErrorMessage = "Please select a valid transaction type."
        )]
        public string Type { get; set; } = "";

        [Required(ErrorMessage = "Please select a date.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        [StringLength(
            500,
            ErrorMessage = "Notes cannot exceed 500 characters."
        )]
        public string? Notes { get; set; }
    }
}