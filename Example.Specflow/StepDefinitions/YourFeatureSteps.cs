using AventStack.ExtentReports.Gherkin.Model;
using Example.Specflow.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using UTAF.Core.Reporter;


namespace Example.Specflow.StepDefinitions
{
    [Binding]
    public class YourFeatureSteps
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly IBalazeHomePage _balazeHomePage;
        private readonly ISpecFlowOutputHelper _outputHelper;
        public IReporter _reporter;

        public YourFeatureSteps(ScenarioContext scenarioContext, IBalazeHomePage balazeHomePage, ISpecFlowOutputHelper outputHelper, IReporterFactory reporter)

        {
            _scenarioContext = scenarioContext;
            _balazeHomePage = balazeHomePage;
            _outputHelper = outputHelper;
            _reporter = reporter.Reporter;
        }



        [Given(@"I navigate to the homepage")]
        public void GivenINavigateToTheHomepage()
        {
            _balazeHomePage.Launch();
            _outputHelper.WriteLine("Specflow test case executed");

        }

        [When(@"I perform some action")]
        public void WhenIPerformSomeAction()
        {
            _balazeHomePage.SelectCities();
        }

        [Then(@"I should see some result")]
        public void ThenIShouldSeeSomeResult()
        {
            Assert.That(_balazeHomePage.GetTitle(), Is.EqualTo("BlazeDemo - reserve"));
        }

    }
}

