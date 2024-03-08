using OpenQA.Selenium.Safari;
using OpenQA.Selenium;
using UTAF.Ui.Models;

namespace UTAF.Ui.Driver
{
    internal class SafariDriverFactory:BaseDriverFactory
    {
        public SafariDriverFactory(WebDriverConfiguration webDriverConfiguration, GridConfiguration gridConfiguration)
    : base(
        webDriverConfiguration.LocalWebDriverPath + @"\safaridriver.exe",
        gridConfiguration.IsEnabled ? gridConfiguration.GridUri : null,
        new SafariOptions())
        {
        }

        protected override IWebDriver CreateLocalDriver()
        {
            // As of now, SafariDriver does not support setting a binary location in SafariOptions
            return new SafariDriver();
        }

        protected override IWebDriver CreateDefaultDriver()
        {
            return new SafariDriver();
        }

    }
}
