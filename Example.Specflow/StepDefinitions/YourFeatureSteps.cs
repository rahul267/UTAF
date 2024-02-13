using BoDi;
using Example.Specflow.DI;
using Example.Specflow.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using UTAF.Core.Logger;

namespace Example.Specflow.StepDefinitions
{
    [Binding]
    public class YourFeatureSteps
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly IBalazeHomePage _balazeHomePage;

        public YourFeatureSteps(ScenarioContext scenarioContext, IBalazeHomePage balazeHomePage)
        {


            _scenarioContext = scenarioContext;
            _balazeHomePage = balazeHomePage;
        }

        [Given(@"I navigate to the homepage")]
        public void GivenINavigateToTheHomepage()
        {
           _balazeHomePage.Launch();
           
        }

        [When(@"I perform some action")]
        public void WhenIPerformSomeAction()
        {
            // Perform some action
        }

        [Then(@"I should see some result")]
        public void ThenIShouldSeeSomeResult()
        {
            // Assert some result
           // Assert.IsTrue(_driver.FindElement(By.XPath("//some/xpath")).Displayed);
        }

    }
}
