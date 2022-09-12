using System;
using TooTipsy.Features.Formulas.Enums;

namespace TooTipsy.Features.Formulas.Interfaces
{
    public interface IFormulaFactory
    {
        IFormula GetFormula(Formula formula);
    }
}

