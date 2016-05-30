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
namespace Calculator.Tests.bdd.AdvencedBdd.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Calculator")]
    public partial class CalculatorFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "MultiLineCalculator.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Calculator", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void FeatureBackground()
        {
#line 6
 #line 7
  testRunner.Given("I\'m browsing the calculator website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
    testRunner.And("I\'m on the Multiline calculator page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calculate a list of operation")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("MultilineCalculator")]
        public virtual void CalculateAListOfOperation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate a list of operation", new string[] {
                        "MultilineCalculator",
                        "ignore"});
#line 12
this.ScenarioSetup(scenarioInfo);
#line 6
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstValue",
                        "Operator",
                        "SecondValue"});
            table1.AddRow(new string[] {
                        "3",
                        "+",
                        "2"});
            table1.AddRow(new string[] {
                        "1",
                        "-",
                        "1"});
            table1.AddRow(new string[] {
                        "1",
                        "*",
                        "18"});
#line 13
 testRunner.Given("I have entered the following value in the textbox calculator", ((string)(null)), table1, "Given ");
#line 18
 testRunner.When("I press result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstValue",
                        "Operator",
                        "SecondValue",
                        "Result"});
            table2.AddRow(new string[] {
                        "3",
                        "+",
                        "2",
                        "5"});
            table2.AddRow(new string[] {
                        "1",
                        "-",
                        "1",
                        "0"});
            table2.AddRow(new string[] {
                        "1",
                        "*",
                        "18",
                        "0"});
#line 19
 testRunner.Then("the result should be on the screen", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
