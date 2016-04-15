using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Models;

namespace Calculator.Tests.UnitTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        [TestMethod]
        public void ShouldAddingToNumberDisplayTheCorrectRessult()
        {
            CalculatorItems calc = new CalculatorItems { Item1 = 1, Item2 = 5, Operator = CalculatorOperatorEnum.Addition };

            Assert.AreEqual(6, calc.calculate());
        }
    }
}
