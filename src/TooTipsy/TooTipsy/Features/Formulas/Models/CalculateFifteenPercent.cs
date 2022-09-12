using System;
using TooTipsy.Features.Formulas.Enums;
using TooTipsy.Features.Formulas.Interfaces;

namespace TooTipsy.Features.Formulas.Models
{
    public class CalculateFifteenPercent : IFormula
    {
        public CalculateFifteenPercent()
        {
        }

        public FormulaType Formula { get; } = FormulaType.FifteenPercentOfBill;

        public decimal CalculateTip(decimal bill, decimal tax)
        {
            var pretip = Math.Round(bill / 10, 2, MidpointRounding.AwayFromZero);
            var tip = Math.Round(pretip + (pretip / 2), 2);
            return tip;
        }
    }
}

