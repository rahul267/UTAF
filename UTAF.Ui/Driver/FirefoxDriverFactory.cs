using OpenQA.Selenium;
using UTAF.Ui.Models;
using OpenQA.Selenium.Firefox;

namespace UTAF.Ui.Driver
{
    public class FirefoxDriverFactory:BaseDriverFactory
    {
       public FirefoxDriverFactory(WebDriverConfiguration webDriverConfiguration, GridConfiguration gridConfiguration) : base
        (
         webDriverConfiguration.LocalWebDriverPath + @"\geckodriver.exe",
         gridConfiguration.IsEnabled ? gridConfiguration.GridUri : null,
          BuildFirefoxOptions(webDriverConfiguration))
        { }

        private static FirefoxOptions BuildFirefoxOptions(WebDriverConfiguration webDriverConfiguration)
        {
            var options = new FirefoxOptions();
            options.AddArguments(webDriverConfiguration.OptionArgMax,
                                 "enable-automation",
                                 "disable-infobars");
            return options;
        }

        protected override IWebDriver CreateLocalDriver()
        {
            this._options.BinaryLocation = this._localDriverPath;
            return new FirefoxDriver(this._localDriverPath, this._options as FirefoxOptions);
        }

        protected override IWebDriver CreateDefaultDriver() => new FirefoxDriver(this._options as FirefoxOptions);
    }
}
