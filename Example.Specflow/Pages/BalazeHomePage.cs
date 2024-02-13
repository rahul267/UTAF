using OpenQA.Selenium;
using UTAF.Core.Logger;
using UTAF.Ui.Driver;
using UTAF.Ui.Providers;

namespace Example.Specflow.Pages

{
    public interface IBalazeHomePage
    {
        public void Launch();
    }
    public class BalazeHomePage : IBalazeHomePage
    {
        private IWebDriver _driver;
        private IDriverFactory _driverFactory;
        private ILoggerService _logger;
        private static Uri blazorUrl => new Uri(UIConfigurationProvider.Environment.ApplicationUrl);

        public BalazeHomePage(IDriverFactory driverFactory, ILoggerService logger)
        {
            _driverFactory = driverFactory;
            _driver = _driverFactory.Driver;
            _logger = logger;
        }


        private IWebElement homeWebElement => _driver.FindElement(By.XPath("/html/body/div[1]/div/div/a[3]"));
        private IWebElement rememberMeWebElement => _driver.FindElement(By.XPath("//*[@id='app']/div/div/div/div/div[2]/form/div[3]/div/div/label/input"));
        private IWebElement departureCityCombo => _driver.FindElement(By.Name("fromPort"));
        private IWebElement destinationCityCombo => _driver.FindElement(By.Name("toPort"));
        private IWebElement searchFlightsButton => _driver.FindElement(By.CssSelector(".btn.btn-primary"));

        public void Launch()
        {
            _logger.LogInformation($"Navigating to: {blazorUrl.AbsoluteUri}");
            _driver.Navigate().GoToUrl(blazorUrl.AbsoluteUri);
        }
    }
}
