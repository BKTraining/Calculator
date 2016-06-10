using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests.BddTest.PageObjects
{
    class IndexPage
    {
        private readonly IWebDriver _driver;

        public IndexPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "FirstValue")]
        public IWebElement Item1 { get; set; }

        [FindsBy(How = How.Id, Using = "SecondValue")]
        public IWebElement Item2 { get; set; }

        [FindsBy(How = How.Id, Using = "Operator")]
        public IWebElement Operator { get; set; }


        [FindsBy(How = How.Id, Using = "btnCalculate")]
        public IWebElement btnCalculate { get; set; }

        [FindsBy(How = How.Id, Using = "Result")]
        public IWebElement Result { get; set; }

        [FindsBy(How = How.Id, Using = "ValidationSummary")]
        public IWebElement ValidationSummary { get; set; }
    }
}
