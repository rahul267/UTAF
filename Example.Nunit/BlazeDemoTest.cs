using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Example.Nunit
{
    [TestFixture]
    public class BlazeDemoTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://blazedemo.com/");
        }

        [Test]
        public void TestFlightSearch()
        {
            var blazeDemoPage = new BlazeDemoPage(driver);
            blazeDemoPage.DepartureCity.SendKeys("San Francisco");
            blazeDemoPage.DestinationCity.SendKeys("London");
            blazeDemoPage.FindFlightsButton.Click();

            Assert.IsTrue(driver.PageSource.Contains("Flights from San Francisco to London:"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}