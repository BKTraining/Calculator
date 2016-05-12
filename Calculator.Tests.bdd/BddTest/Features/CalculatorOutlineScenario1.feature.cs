﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Calculator.Tests.bdd.BddTest.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CalculatorOutlineScenario")]
    public partial class CalculatorOutlineScenarioFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CalculatorOutlineScenario.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CalculatorOutlineScenario", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the resul" +
                    "t of an operation with two number", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting the result of an operation with two numbers")]
        [NUnit.Framework.CategoryAttribute("Calculator")]
        [NUnit.Framework.TestCaseAttribute("40", "70", "Addition", "110", new string[0])]
        [NUnit.Framework.TestCaseAttribute("50", "30", "Addition", "80", new string[0])]
        [NUnit.Framework.TestCaseAttribute("-10", "10", "Addition", "0", new string[0])]
        [NUnit.Framework.TestCaseAttribute("-10", "10", "Subtraction", "-20", new string[0])]
        [NUnit.Framework.TestCaseAttribute("-10", "-10", "Subtraction", "0", new string[0])]
        [NUnit.Framework.TestCaseAttribute("50", "10", "Subtraction", "40", new string[0])]
        [NUnit.Framework.TestCaseAttribute("-10", "-10", "Multiplication", "100", new string[0])]
        [NUnit.Framework.TestCaseAttribute("-10", "10", "Multiplication", "-100", new string[0])]
        [NUnit.Framework.TestCaseAttribute("1", "-5", "Division", "-0.2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("50", "10", "Division", "5", new string[0])]
        [NUnit.Framework.TestCaseAttribute("0", "10", "Division", "0", new string[0])]
        public virtual void GettingTheResultOfAnOperationWithTwoNumbers(string firstValue, string secondValue, string operation, string result, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Calculator"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting the result of an operation with two numbers", @__tags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given(string.Format("I have entered {0} into the first operand of the calculator", firstValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And(string.Format("I have choose  {0} as an operation into the calculator", operation), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And(string.Format("I have entered {0} into the second operand of the calculator", secondValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("I press result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then(string.Format("the result should be {0} on the screen", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Division by 0 is not allowed")]
        [NUnit.Framework.CategoryAttribute("Calculator")]
        public virtual void DivisionBy0IsNotAllowed()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Division by 0 is not allowed", new string[] {
                        "Calculator"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
 testRunner.Given("I have entered 75 into the first operand of the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.And("I have choose Division as an operation into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("I have entered 0 into the second operand of the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.When("I press result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.Then("there is Division by zero is not allowed displayed on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
