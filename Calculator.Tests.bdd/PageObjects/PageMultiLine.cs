﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests.bdd.PageObjects
{
   

    class PageMultiLine
    {
        private readonly IWebDriver _driver;

        public PageMultiLine(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "allCalculation")]
        public IWebElement allCalculation { get; set; }

        [FindsBy(How = How.Id, Using = "btnCalculate")]
        public IWebElement btnCalculate { get; set; }

        [FindsBy(How = How.Id, Using = "Result")]
        public IWebElement Result { get; set; }

    }
}