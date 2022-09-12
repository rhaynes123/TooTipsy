using System;
using System.ComponentModel.DataAnnotations;
using TooTipsy.Features.Formulas.Enums;
namespace TooTipsy.Features.Calculations.Models
{
    public class Calculation
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Description { get; set; } = default!;
        [Required]
        public decimal BillAmount { get; set; }
        [Required]
        public decimal TaxAmount { get; set; }
        [Required]
        public decimal TipAmount { get; set; }
        [Required]
        public FormulaType FormulaId { get; set; } = FormulaType.None;
        [Required]
        public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public string? Username { get; set; }
    }
}

