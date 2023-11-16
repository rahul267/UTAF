using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UTAF.Ui.Models;

namespace UTAF.Ui.Driver
{
    public class DriverWait : IDriverWait
    {
        private readonly IDriverFactory _driverFixture;
        private readonly WebDriverConfiguration _webDriverConfiguration;
        private readonly Lazy<WebDriverWait> _webDriverWait;

        public DriverWait(IDriverFactory driverFixture, WebDriverConfiguration webDriverConfiguration)
        {
            _driverFixture = driverFixture;
            _webDriverConfiguration = webDriverConfiguration;
            _webDriverWait = new Lazy<WebDriverWait>(GetWaitDriver);
        }

        public IWebElement FindElement(By elementLocator)
        {
            return _webDriverWait.Value.Until(_ => _driverFixture.Driver.FindElement(elementLocator));
        }

        public IEnumerable<IWebElement> FindElements(By elementLocator)
        {
            return _webDriverWait.Value.Until(_ => _driverFixture.Driver.FindElements(elementLocator));
        }

        private WebDriverWait GetWaitDriver()
        {
            return new(_driverFixture.Driver, timeout: TimeSpan.FromSeconds(_webDriverConfiguration.DefaultTimeout ?? 30))
            {
                PollingInterval = TimeSpan.FromSeconds(_webDriverConfiguration.DefaultTimeout ?? 1)
            };
        }

    }
}
