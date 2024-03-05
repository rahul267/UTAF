using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.Extensions;
using System.Reflection;
using UTAF.Ui.Models;

namespace UTAF.Ui.Driver
{
    public  class DriverFactory : IDriverFactory
    {
        protected readonly WebDriverConfiguration _webDriverConfiguration;
        public IWebDriver Driver { get; protected set; }

        public DriverFactory(WebDriverConfiguration webDriverConfiguration)
        {
            _webDriverConfiguration = webDriverConfiguration;
            Driver = GetWebDriver();
        }
        private IWebDriver GetWebDriver()
        {
            return _webDriverConfiguration.BrowserName switch
            {
                BrowserType.Chrome => new ChromeDriverFactory(_webDriverConfiguration).CreateDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Safari => new SafariDriver(),
                BrowserType.Edge => new EdgeDriverFactory(_webDriverConfiguration).CreateDriver(),
                _ => new ChromeDriver()
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
