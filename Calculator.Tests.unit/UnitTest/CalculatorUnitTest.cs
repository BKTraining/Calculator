using Calculator.Models;
using Calculator.Controllers;
using NUnit.Framework;

namespace Calculator.Tests.UnitTest
{
    [TestFixture]
    public class CalculatorUnitTest
    {
        [Test]
        [TestCase(1, 5, 6)]
        [TestCase(0, 0, 0)]
        [TestCase(-10, -10, -20)]
        [TestCase(10000000000000000011000000000000000001d, 10000000000000000011000000000000000001d, 20000000000000000022000000000000000002d)]
        public void ShouldAddingNumbersGiveTheCorrectRessult(double n1, double n2, double resultat)
        {
            CalculatorItems calc = new CalculatorItems { FirstValue = n1, SecondValue = n2, Operator = CalculatorOperatorEnum.Addition };
            HomeController ctrl = new HomeController();
            ctrl.Index(calc);
            Assert.AreEqual(resultat, calc.Result);
        }

        [Test]
        [TestCase(10, 5, 5)]
        [TestCase(1, 5, -4)]
        [TestCase(0, 0, 0)]
        [TestCase(-10, -10, 0)]
        [TestCase(20000000000000000022000000000000000002d, 10000000000000000011000000000000000001d, 10000000000000000011000000000000000001d)]
        public void ShouldSubstractingNumbersGiveTheCorrectRessult(double n1, double n2, double resultat)
        {
            CalculatorItems calc = new CalculatorItems { FirstValue = n1, SecondValue = n2, Operator = CalculatorOperatorEnum.Subtraction };
            HomeController ctrl = new HomeController();
            ctrl.Index(calc);
            Assert.AreEqual(resultat, calc.Result);
        }

        [Test]
        [TestCase(10, 5, 50)]
        [TestCase(1, -5, -5)]
        [TestCase(0, 5, 0)]
        [TestCase(5, 0, 0)]
        [TestCase(-10, -10, 100)]
        [TestCase(10000000000000000011000000000000000001d, 10000000000000000011000000000000000221d, 1E+74)]
        public void ShouldMultiplyingNumbersGiveTheCorrectRessult(double n1, double n2, double resultat)
        {
            CalculatorItems calc = new CalculatorItems { FirstValue = n1, SecondValue = n2, Operator = CalculatorOperatorEnum.Multiplication };
            HomeController ctrl = new HomeController();
            ctrl.Index(calc);
            Assert.AreEqual(resultat, calc.Result);
        }

        [Test]
        [TestCase(10, 5, 2)]
        [TestCase(1, -5, -0.2)]
        [TestCase(0, 4, 0)]
        [TestCase(-10, -10, 1)]
        public void ShouldDivisingNumbersGiveTheCorrectRessult(double n1, double n2, double resultat)
        {
            CalculatorItems calc = new CalculatorItems { FirstValue = n1, SecondValue = n2, Operator = CalculatorOperatorEnum.Division };
            HomeController ctrl = new HomeController();
            ctrl.Index(calc);
            Assert.AreEqual(resultat, calc.Result);
        }

        [Test]
        public void ShoudDivisingByZeroGiveNoResult()
        {
            CalculatorItems calc = new CalculatorItems { FirstValue = 10, SecondValue = 0, Operator = CalculatorOperatorEnum.Division };
            HomeController ctrl = new HomeController();
            ctrl.Index(calc);
            Assert.AreEqual(null, calc.Result);
        }
    }
}
