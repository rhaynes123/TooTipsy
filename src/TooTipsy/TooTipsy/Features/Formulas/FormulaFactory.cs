using System;
using System.Collections.Immutable;
using TooTipsy.Features.Formulas.Enums;
using TooTipsy.Features.Formulas.Interfaces;

namespace TooTipsy.Features.Formulas
{
    public class FormulaFactory: IFormulaFactory
    {
        private readonly IImmutableDictionary<FormulaType, IFormula> _formulas;
        public FormulaFactory()
        {
            var formulaTypes = typeof(IFormula).Assembly.ExportedTypes;
            _formulas = formulaTypes.Where( ft => typeof(IFormula).IsAssignableFrom(ft) && IsConcrete(ft))
                .Select(ft => Activator.CreateInstance(ft))
                .Cast<IFormula>()
                .ToImmutableDictionary(ft => ft.Formula, ft => ft);

        }

        public IFormula GetFormula(FormulaType formula)
        {
            return _formulas[formula];
        }

        private static bool IsConcrete(Type type)
        {
            return !type.IsInterface && !type.IsAbstract;
        }
    }
}

