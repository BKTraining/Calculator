using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Models;
using Calculator.Controllers;

namespace Calculator.Tests.UnitTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        [TestMethod]
        public void ShouldAddingToNumberDisplayTheCorrectRessult()
        {
            CalculatorItems calc = new CalculatorItems { Item1 = 1, Item2 = 5, Operator = CalculatorOperatorEnum.Addition };
            HomeController ctrl = new HomeController();
            ctrl.Index(calc);
            Assert.AreEqual(6, calc.Result);
        }
    }
}
