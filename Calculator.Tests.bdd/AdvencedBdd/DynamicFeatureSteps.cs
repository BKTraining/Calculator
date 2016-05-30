using BoDi;
using Calculator.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Calculator.Tests.bdd.AdvencedBdd
{
    [Binding]
    public class DynamicFeatureSteps
    {
        private IList<dynamic> _set; // holds state between steps for this example

        [When(@"I create a set of dynamic instances from this table")]
        public void x(Table table)
        {
            _set = table.CreateDynamicSet().ToList();
        }

        [Then(@"the (.*) item should have Age equal to '(.*)'")]
        public void y(int itemNumber, int expectedAge)
        {
            Assert.AreEqual(expectedAge, _set[itemNumber - 1].Age);
        }
    }
}
