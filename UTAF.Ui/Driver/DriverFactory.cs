using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.Extensions;
using System.Reflection;
using UTAF.Ui.Models;
using UTAF.Ui.Providers;

namespace UTAF.Ui.Driver
{
    public  class DriverFactory : IDriverFactory
    {
        protected readonly WebDriverConfiguration _webDriverConfiguration;
        protected readonly GridConfiguration _gridConfiguration;
        protected readonly IUIConfigurationProvider _uiConfigurationProvider;
        public IWebDriver Driver { get; protected set; }

        public DriverFactory(IUIConfigurationProvider uiConfigurationProvider)
        {
            _uiConfigurationProvider = uiConfigurationProvider;
            _webDriverConfiguration = _uiConfigurationProvider.WebDriver;
            _gridConfiguration = _uiConfigurationProvider.GridConfiguration;
            Driver = GetWebDriver();
        }
       
        
        private IWebDriver GetWebDriver()
        {
            return _webDriverConfiguration.BrowserName switch
            {
                BrowserType.Chrome => new ChromeDriverFactory(_uiConfigurationProvider).CreateDriver(),
                BrowserType.Firefox => new FirefoxDriverFactory(_webDriverConfiguration, _gridConfiguration).CreateDriver(),
                BrowserType.Safari => new SafariDriver(),
                BrowserType.Edge => new EdgeDriverFactory(_webDriverConfiguration, _gridConfiguration).CreateDriver(),
                _ => throw new NotSupportedException($"Browser type {_webDriverConfiguration.BrowserName} is not supported")

            };
        }

        public string TakeScreenshotAsPath(string fileName)
        {
            var screenshot = Driver.TakeScreenshot();
            var path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}//{fileName}";
            screenshot.SaveAsFile(path);
            return path;
        }

        

        public void Dispose()
        {
            Driver?.Quit();
        }
    }
}
public enum BrowserType
{
    Chrome,
    Firefox,
    Safari,
    Edge
}
