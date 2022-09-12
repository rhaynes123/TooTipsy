using System;
using TooTipsy.Features.Formulas.Enums;
namespace TooTipsy.Features.Formulas.Interfaces
{
    public interface IFormula
    {
        FormulaType Formula { get; }
        /// <summary>
        /// Calculates a tip based off chosen formula
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="tax"></param>
        /// <returns>Decimal of determined result</returns>
        decimal CalculateTip(decimal bill, decimal tax);
    }
}

