using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Calculator.Models;
using Calculator.Tests.bdd.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using Calculator.Tests.BddTest;

namespace Calculator.Tests.bdd.AdvencedBdd
{

    [Binding]
    [Scope(Feature = "MultiLineCalculator")]
    public sealed class MultiLineCalculatorStepDefinition
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        private IEnumerable<CalculatorItems> myNumbers;
        private static PageMultiLine _pageMultiLine;
        private static IWebDriver _driver;

        [BeforeFeature]
        public static void ScenarioSetUp()
        {
            _driver = new DriverFactory().Create();
            _pageMultiLine = new PageMultiLine(_driver);
        }

        [AfterFeature]
        public static void ScenarioTearDown()
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


        [StepArgumentTransformation]
        public IEnumerable<CalculatorItems> BooksTransform(Table CalculatorItemsList)
        {
            return CalculatorItemsList.CreateSet<CalculatorItems>();
        }


        [Given("I'm browsing the calculator website")]
        public void GivenINavigateCalculatorWebsite()
        {
            _driver.Navigate().GoToUrl("http://localhost:8081/");
        }

        [Given("I'm on the Multiline calculator page")]
        public void GivenINavigateMultilineCalculatorWebsite()
        {
            _driver.Navigate().GoToUrl("http://localhost:8081/Home/MultilineCalculator");
        }

        [Given("I have entered the following value in the textbox calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(IEnumerable<CalculatorItems> numberList)
        {
<<<<<<< HEAD
            StringBuilder sb = new StringBuilder();
            string operat = "";
            foreach (var item in numberList)
            {
                switch (item.Operator.ToString().ToLower())
                {
                    case "addition":
                        operat = "+";
                        break;
                    case "subtraction":
                        operat = "-";
                        break;
                    case "multiplication":
                        operat = "*";
                        break;
                    case "division":
                        operat = "/";
                        break;
                }
                sb.AppendFormat("{0}{1}{2}\n", item.FirstValue.ToString(), operat, item.SecondValue.ToString());

            }
            _pageMultiLine.AllCalculation.SendKeys(sb.ToString());
=======
            myNumbers = number.CreateSet<CalculatorItems>();
            var toInsert = string.Empty;

            foreach (CalculatorItems ci in myNumbers)
            {
                toInsert += ci.FirstValue + ci.OperatorChar + ci.SecondValue + "\r\n";
            }

            _pageMultiLine.AllCalculation.SendKeys(toInsert);
>>>>>>> 1ebac0a15b74a2202fd4ab45b58a313fc7763b5e
        }



        [When("I press result")]
        public void WhenIPressAdd()
        {
            _pageMultiLine.btnCalculate.Click();
        }

        [Then("the result should be on the screen")]
<<<<<<< HEAD
        public void ThenTheResultShouldBe(IEnumerable<CalculatorItems> result)
        {
            StringBuilder sb = new StringBuilder();
            string operat = "";
            foreach (var item in result)
            {
                switch (item.Operator.ToString().ToLower())
                {
                    case "addition":
                        operat = "+";
                        break;
                    case "subtraction":
                        operat = "-";
                        break;
                    case "multiplication":
                        operat = "*";
                        break;
                    case "division":
                        operat = "/";
                        break;
                }
                sb.AppendFormat("{0} {1} {2} = {3}\r\n", item.FirstValue.ToString(), operat, item.SecondValue.ToString(), item.Result.ToString());
            }

            string test = _pageMultiLine.Result.Text;
            Assert.AreEqual(sb.ToString().TrimEnd(new char[] { '\r', '\n'}), _pageMultiLine.Result.Text);
=======
        public void ThenTheResultShouldBe(Table expectedResult)
        {
            var temp = _pageMultiLine.Result.Text;

            myNumbers = expectedResult.CreateSet<CalculatorItems>();

            var expectedResultStr = string.Empty;

            foreach (var ci in myNumbers)
            {
                expectedResultStr += ci.FirstValue + ci.OperatorChar + ci.SecondValue + "=" + ci.Result + "\r\n";
            }

            temp = _pageMultiLine.Result.Text.Replace(" ", "");
            temp = temp.Replace(",", ".");
            temp += "\r\n";

            Assert.AreEqual(expectedResultStr, temp);
>>>>>>> 1ebac0a15b74a2202fd4ab45b58a313fc7763b5e
        }
    }
}
