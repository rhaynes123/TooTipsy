using System;
using TooTipsy.Features.Formulas.Enums;
using TooTipsy.Features.Formulas.Interfaces;

namespace TooTipsy.Features.Formulas.Models
{
    public class CalculateDoubleTax: IFormula
    {
        public CalculateDoubleTax()
        {
        }

        public FormulaType Formula => FormulaType.DoubleTax;

        public decimal CalculateTip(decimal bill, decimal tax)
        {
            var roundedTax = Math.Round(tax, 2);
            return roundedTax * 2;
        }
    }
}

