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

        [Given("I'm browsing the calculator website")]
        public void GivenINavigateCalculatorWebsite()
        {
            _driver.Navigate().GoToUrl("http://localhost:8081/");
        }

        [Given("I'm on the Multiline calculator page")]
        public void GivenINavigateMultilineCalculatorWebsite()
        {
            _driver.Navigate().GoToUrl("http://localhost:8081/MultilineCalculator");
        }


        [Given("I have entered the following value in the textbox calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(Table number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see http://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 
            myNumbers = number.CreateSet<CalculatorItems>();
           
        }

        [When("I press result")]
        public void WhenIPressAdd()
        {
            //TODO: implement act (action) logic
            _pageMultiLine.btnCalculate.Click();
            ScenarioContext.Current.Pending();
        }

        [Then("the result should be on the screen")]
        public void ThenTheResultShouldBe(Table result)
        {
            //TODO: implement assert (verification) logic
            Assert.AreEqual(result, _pageMultiLine.Result.Text);
            ScenarioContext.Current.Pending();
        }
    }
}
