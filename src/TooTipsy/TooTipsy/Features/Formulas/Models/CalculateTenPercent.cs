using System;
using TooTipsy.Features.Formulas.Enums;
using TooTipsy.Features.Formulas.Interfaces;

namespace TooTipsy.Features.Formulas.Models
{
    public class CalculateTenPercent: IFormula
    {
        public CalculateTenPercent()
        {
        }

        public Formula Formula => Formula.TwentyPercentOfBill;

        public decimal CalculateTip(decimal bill, decimal tax)
        {
            var percent = bill * 0.10m;
            return percent * 2;
        }
    }
}

