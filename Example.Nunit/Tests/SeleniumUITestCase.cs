using RestSharp;
using UTAF.Api;

namespace Example.Nunit.Tests
{
    public class Tests:BaseTest
    {
        [Test]
        public void UITestToOpenWebpage()
        {
            _reporter.StartTest("Your Test Name");
            _logger.LogInformation("Starting the test...");
            _blazeHomePage.Launch();

        }

        
    }
}