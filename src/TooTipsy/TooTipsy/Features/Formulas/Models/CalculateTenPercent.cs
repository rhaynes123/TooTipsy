using System;
using TooTipsy.Features.Formulas.Enums;
using TooTipsy.Features.Formulas.Interfaces;

namespace TooTipsy.Features.Formulas.Models
{
    public class CalculateTwentyPercent: IFormula
    {
        public CalculateTwentyPercent()
        {
        }

        public FormulaType Formula => FormulaType.TwentyPercentOfBill;

        public decimal CalculateTip(decimal bill, decimal tax)
        {
            var percent = bill * 0.10m;
            return percent * 2;
        }
    }
}

