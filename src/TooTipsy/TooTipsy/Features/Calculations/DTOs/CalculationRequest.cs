using System;
using System.ComponentModel.DataAnnotations;
using TooTipsy.Features.Formulas.Enums;

namespace TooTipsy.Features.Calculations.DTOs
{
    public record CalculationRequest()
    {
        [Required, StringLength(200)]
        public string Description { get; init; } = default!;
        [Required]
        public decimal BillAmount { get; init; }
        [Required]
        public decimal TaxAmount { get; init; }
        [Required]
        public DateTime CreatedDate { get; init; } = DateTime.Today;
        public string? UserId { get; init; }
    }

}

