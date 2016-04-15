using Calculator.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Calculator.Tests.Features
{
    [Binding]
    public sealed class CalculatorStepDefinition
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        private CalculatorItems calc = new CalculatorItems();
        private string calculateResult = string.Empty;

        [Given("I have entered (.*) into the first operand of the calculator")]
        public void GivenIHaveEnteredSomethingIntoFirstOperandOfTheCalculator(double number)
        {
            calc.Item1 = number;
        }


        [Given("I have choose (.*) as an operation into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(string Operator)
        {
            CalculatorOperatorEnum result;
            switch (Operator)
            {
                default:
                case "Addition":
                    result = CalculatorOperatorEnum.Addition;
                    break;
                case "Subtraction":
                    result = CalculatorOperatorEnum.Subtraction;
                    break;
                case "Multiplication":
                    result = CalculatorOperatorEnum.Multiplication;
                    break;
                case "Division":
                    result = CalculatorOperatorEnum.Division;
                    break;
            }

            calc.Operator = result;
        }

        [Given("I have entered (.*) into the second operand of the calculator")]
        public void GivenIHaveEnteredSomethingIntoSecondOperandOfTheCalculator(double number)
        {
            calc.Item2 = number;
        }

        [When("I press result")]
        public void WhenIPressResult()
        {
            calculateResult = calc.calculate().ToString();
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(double result)
        {
            Assert.AreEqual(result, calculateResult);
        }
    }
}
