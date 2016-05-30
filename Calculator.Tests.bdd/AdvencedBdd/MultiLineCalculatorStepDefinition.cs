using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Calculator.Tests.bdd.AdvencedBdd
{

    [Binding]
    [Scope(Feature = "MultiLineCalculator")]
    public sealed class MultiLineCalculatorStepDefinition
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
      

        [Given("I have entered the following value in the textbox calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see http://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            ScenarioContext.Current.Pending();
        }

        [When("I press result")]
        public void WhenIPressAdd()
        {
            //TODO: implement act (action) logic

            ScenarioContext.Current.Pending();
        }

        [Then("the result should be on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            ScenarioContext.Current.Pending();
        }
    }
}
