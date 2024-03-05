using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using UTAF.Ui.Models;

namespace UTAF.Ui.Driver
{
    internal class EdgeDriverFactory
    {
        private readonly string _localDriverPath;
        private readonly EdgeOptions _options;
        private readonly WebDriverConfiguration _webDriverConfiguration;

        public EdgeDriverFactory(WebDriverConfiguration configuration)
        {
            _webDriverConfiguration = configuration;
            _localDriverPath = _webDriverConfiguration.LocalWebDriverPath;
            _options = BuildChromeOptions();
        }

        private EdgeOptions BuildChromeOptions()
        {
            var options = new EdgeOptions();
            options.AddArguments(_webDriverConfiguration.OptionArgMax,
                                 "enable-automation",
                                 "disable-infobars");
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 1);
            return options;
        }

        public IWebDriver CreateDriver()
        {
            if (IsLocalDriverAvailable(_localDriverPath))
            {
                _options.BinaryLocation = _localDriverPath;
                return new EdgeDriver(_localDriverPath, _options);
            }

            try
            {
                return new EdgeDriver(_options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initiate Remote WebDriver: {ex}");
            }

            return null; 
        }

        private static bool IsLocalDriverAvailable(string driverPath)
        {
            return File.Exists(driverPath);
        }
    }
}
