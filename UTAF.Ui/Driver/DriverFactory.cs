using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using UTAF.Ui.Models;

namespace UTAF.Ui.Driver
{
    public class DriverFactory : IDriverFactory, IDisposable
    {
        private readonly WebDriverConfiguration webDriverConfiguration;
        public IWebDriver Driver { get; }

        public DriverFactory(WebDriverConfiguration _webDriverConfiguration)
        {
            webDriverConfiguration = _webDriverConfiguration;
            Driver = GetWebDriver();
        }


        private IWebDriver GetWebDriver()
        {
            return webDriverConfiguration.BrowserName switch
            {
                BrowserType.Chrome => ChromeFactory.GetWebDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Safari => new SafariDriver(),
                _ => new ChromeDriver()
            };
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
public enum BrowserType
{
    Chrome,
    Firefox,
    Safari,
    EdgeChromium
}
