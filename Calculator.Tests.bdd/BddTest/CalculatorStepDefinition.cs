using Calculator.Models;
using Calculator.Tests.BddTest;
using Calculator.Tests.BddTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
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
        private IWebDriver _driver;
        private IndexPage _indexPage;
        private CalculatorItems calc = new CalculatorItems();
        private string calculateResult = string.Empty;

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        [BeforeScenario]
        public void ScenarioSetUp()
        {
            _driver = new DriverFactory().Create();
            _indexPage = new IndexPage(_driver);
            _driver.Navigate().GoToUrl("http://localhost:8080/");
        }

        [AfterScenario]
       public void ScenarioTearDown()
        {
            try
            {
                _driver.Quit();
                _driver.Close();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
        }


        [Given("I have entered (.*) into the first operand of the calculator")]
        public void GivenIHaveEnteredSomethingIntoFirstOperandOfTheCalculator(double number)
        {
            _indexPage.Item1.SendKeys(number.ToString());
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

            _indexPage.Operator.SendKeys(Operator);
        }

        [Given("I have entered (.*) into the second operand of the calculator")]
        public void GivenIHaveEnteredSomethingIntoSecondOperandOfTheCalculator(double number)
        {
            _indexPage.Item2.SendKeys(number.ToString());
        }

        [When("I press result")]
        public void WhenIPressResult()
        {
            _indexPage.btnCalculate.Click();
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(double result)
        {
            Assert.AreEqual(result.ToString(), _indexPage.Result.Text);
        }


        [Then("there is (.*) displayed on the screen")]
        public void ThenTheErrorShouldBe(string message)
        {
            Assert.IsTrue(_indexPage.ValidationSummary.Text.IndexOf(message) >= 0);
        }
    }

}
