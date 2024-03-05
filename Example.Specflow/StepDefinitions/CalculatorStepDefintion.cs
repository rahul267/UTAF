using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow;
using UTAF.Core.Reporter;
using Example.Specflow.Pages;
using NUnit.Framework;

namespace Example.Specflow.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefintion
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ICalculatorPageObject _calculatorPageObject;
        private readonly ISpecFlowOutputHelper _outputHelper;
        public IReporter _reporter;


        public CalculatorStepDefintion(ScenarioContext scenarioContext, ICalculatorPageObject calculatorPageObject, ISpecFlowOutputHelper outputHelper, IReporterFactory reporter)

        {
            _scenarioContext = scenarioContext;
            _calculatorPageObject = calculatorPageObject;
            _outputHelper = outputHelper;
            _reporter = reporter.Reporter;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //delegate to Page Object
            _calculatorPageObject.EnterFirstNumber(number.ToString());
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //delegate to Page Object
            _calculatorPageObject.EnterSecondNumber(number.ToString());
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //delegate to Page Object
            _calculatorPageObject.ClickAdd();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            
            var actualResult = _calculatorPageObject.WaitForNonEmptyResult();

            Assert.That(actualResult , Is.EqualTo(expectedResult.ToString()));
        }


    }
}