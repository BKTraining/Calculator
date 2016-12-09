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

        //[Then(@"the (.*) item should have Age equal to '(.*)'")]
        //public void y(int itemNumber, int expectedAge)
        //{

        //    Assert.AreEqual(expectedAge, _set[itemNumber - 1].Ages);
        //}


        [Then(@"the (.*) item should have Age equal to (.*)")]
        public void y2(int itemNumber, int expectedAge)
        {

            Assert.AreEqual(expectedAge, _set[itemNumber - 1].Age);
        }

        private class myobject
        {
            public string itemNumber
             { get; set; }

            public string itemAge
            { get; set; }
            

        }

        [Then(@"the dynamic list of item will respecte those rules")]
        public void y3(Table table)
        {
            IList<dynamic> set2 = table.CreateDynamicSet().ToList();

            for (int i = 0; i < set2.Count; i++)
            {
                Assert.AreEqual(set2[i].itemAge, _set[set2[i].itemNumber-1].Age);
            }

        }

    }
}
