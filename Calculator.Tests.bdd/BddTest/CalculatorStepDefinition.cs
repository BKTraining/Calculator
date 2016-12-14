using Calculator.Models;
using Calculator.Tests.bdd.Common;
using Calculator.Tests.BddTest;
using Calculator.Tests.BddTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Calculator.Tests.Features
{
    [Binding]
    [Scope(Feature = "Calculator")]
    [Scope(Feature = "CalculatorOutlineScenario")]
    public sealed class CalculatorStepDefinition
    {
        private static IWebDriver _driver;
        private static IndexPage _indexPage;
        private CalculatorItems calc = new CalculatorItems();
        private static string calculateResult = string.Empty;
        private static IISExpress iis;

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
      [BeforeFeature]
        public static void ScenarioSetUp()
        {
            iis = new IISExpress();
            iis.Start();

            _driver = new DriverFactory().Create();
            _indexPage = new IndexPage(_driver);
        }

        [AfterFeature]
        public static void ScenarioTearDown()
        {
            try
            {
                _driver.Quit();
                _driver.Close();
                iis.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
        }

        [Given("I'm browsing the calculator website")]
        public void GivenINavigateCalculatorWebsite()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080/Home/");
        }


        [Given("I have entered (.*) into the first operand of the calculator")]
        public void GivenIHaveEnteredSomethingIntoFirstOperandOfTheCalculator(double number)
        {
            _indexPage.Item1.SendKeys(number.ToString());
        }

        [Given("I have choose (.*) as an operation into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(string Operator)
        {
            _indexPage.Operator.SendKeys(Operator.Trim()[0].ToString());
        }



        [Given("I have entered (.*) into the second operand of the calculator")]
        public void GivenIHaveEnteredSomethingIntoSecondOperandOfTheCalculator(double number)
        {
            _indexPage.Item2.SendKeys(number.ToString());
        }
        
        [When("I press result")]
        public void WhenIpressresult()
        {
            _indexPage.btnCalculate.Click();
            System.Threading.Thread.Sleep(800);
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(String result)
        {
            string tmp = _indexPage.Result.Text;

            Assert.AreEqual(result, _indexPage.Result.Text);
        }


        [Then("there is (.*) displayed on the screen")]
        public void ThenTheErrorShouldBe(string message)
        {
            Assert.IsTrue(_indexPage.ValidationSummary.Text.IndexOf(message) >= 0);
        }


    }

}
