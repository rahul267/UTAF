using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Example.Nunit
{
    [TestFixture]
    public class BlazeDemoTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://blazedemo.com/");
        }

        [Test]
        public void TestHomePageTitle()
        {
            Assert.AreEqual("BlazeDemo", driver.Title);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}