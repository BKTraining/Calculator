using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
namespace Calculator.Tests.bdd.BddTest
{

    [Binding]
    public class TagemonstrationSteps
    {
        private bool _noTags = false;
        private bool _testTag1 = false;
        private bool _testTag2 = false;
        private bool _testTag3 = false;
        private bool _testTags = false;

        [BeforeScenario]
        public void ThisHookRunBeforeAllScenariosRegardlessOfTheirTags()
        {
            _noTags = true;
        }

        [BeforeScenario("testTag1")]
        public void ThisHookRunBeforeScenariosWithTestTag1()
        {
            _testTag1 = true;
        }

        [BeforeScenario("testTag2")]
        public void ThisHookRunBeforeScenariosWithTestTag2()
        {
            _testTag2 = true;
        }

        [BeforeScenario("testTag3")]
        public void ThisHookRunBeforeScenariosWithTestTag3()
        {
            _testTag3 = true;
        }

        [BeforeScenario("testTag1", "testTag2", "testTag3")]
        public void ThisHookRunBeforeScenariosWithTestTag1_2_or_3()
        {
            _testTags = true;
        }

        [When(@"I run the scenario")]
        public void WhenIRunTheScenario()
        {
            // Nothing to do here
        }

        [Given(@"that my scenario has (\d) tags")]
        public void GivenThatMyScenarioHas1Tag(int numberOfExpectedTags)
        {
            if (numberOfExpectedTags <= 0)
            {
                Assert.IsEmpty(ScenarioContext.Current.ScenarioInfo.Tags);
            }
            else
            {
                Assert.IsNotNull(ScenarioContext.Current.ScenarioInfo.Tags);
                Assert.IsTrue(ScenarioContext.Current.ScenarioInfo.Tags.ToList().Count() == numberOfExpectedTags);
            }
        }

        [Then("before scenario hook with '(.*)' is run")]
        public void AssertCorrectHooksHasBeenRun(string expectedTags)
        {
            var tags = from t in expectedTags.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                       select t.Trim();

            if (tags.Count() == 0)
            {
                // If no tags was set the only hook that is to be run is the
                // hook with no tags is run
                Assert.IsTrue(_noTags);

                // And all the other hooks are not run
                Assert.IsFalse(_testTag1);
                Assert.IsFalse(_testTag2);
                Assert.IsFalse(_testTag3);
                Assert.IsFalse(_testTags);
            }

            if (tags.Count() > 0)
            {
                // If there were any tags set
                // the no tag hook is still run (!)
                // and also the hook with all the tags 
                Assert.IsTrue(_noTags);
                Assert.IsTrue(_testTags);

            }

            // Finally the hooks for each tag is set in their respective hook
            if (tags.Contains("testTag1"))
            {
                Assert.IsTrue(_testTag1);
            }

            if (tags.Contains("testTag2"))
            {
                Assert.IsTrue(_testTag2);
            }

            if (tags.Contains("testTag3"))
            {
                Assert.IsTrue(_testTag3);
            }
        }

    }
}
