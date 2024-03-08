using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using UTAF.Ui.Models;
using UTAF.Ui.Providers;

namespace UTAF.Ui.Driver
{
    public class ChromeDriverFactory:BaseDriverFactory
    {
        private const string CHROMEDRIVER = @"\chromedriver";

        public ChromeDriverFactory(IUIConfigurationProvider uiConfigurationProvider) :base
        (
        uiConfigurationProvider.WebDriver.LocalWebDriverPath + CHROMEDRIVER,
        uiConfigurationProvider.GridConfiguration.IsEnabled ? uiConfigurationProvider.GridConfiguration.GridUri : null,
        BuildChromeOptions(uiConfigurationProvider.WebDriver))
        {}
      

        private static ChromeOptions BuildChromeOptions(WebDriverConfiguration webDriverConfiguration)
        {
            var options = new ChromeOptions();
            options.AddArguments(webDriverConfiguration.OptionArgMax,
                                 "enable-automation",
                                 "disable-infobars");
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 1);
            return options;
        }

        protected override IWebDriver CreateLocalDriver()
        {
            this._options.BinaryLocation = this._localDriverPath;
            return new ChromeDriver(this._localDriverPath, this._options as ChromeOptions);
        }

        protected override IWebDriver CreateDefaultDriver() => new ChromeDriver(this._options as ChromeOptions);

    }
}
