using System;
using TooTipsy.Features.Formulas;
using TooTipsy.Features.Formulas.Enums;
using TooTipsy.Features.Formulas.Interfaces;
using TooTipsy.Features.Formulas.Models;
namespace TooTipsyTests.Features.Formulas
{
    public class FormulaFactoryTests
    {
        private readonly IFormulaFactory _sut;
        public FormulaFactoryTests()
        {
            _sut = new FormulaFactory();
        }
        [Theory]
        [MemberData(nameof(FormulaTypeData))]
        public void ForumlaFactoryShouldReturnCorrectType(FormulaType formulaType, Type type)
        {
            //Arrange & Act
            var formula = _sut.GetFormula(formulaType);
            //Assert
            Assert.True(formula.GetType() == type);
        }

        private static IEnumerable<object[]> FormulaTypeData()
        {
            return new List<object[]>
            {
                new object[] { FormulaType.TwentyPercentOfBill, typeof(CalculateTwentyPercent) },
                new object[] { FormulaType.FifteenPercentOfBill, typeof(CalculateFifteenPercent) },
                new object[] { FormulaType.DoubleTax, typeof(CalculateDoubleTax) },
            };
        }
    }
}

