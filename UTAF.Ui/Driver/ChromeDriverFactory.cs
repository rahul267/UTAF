using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using UTAF.Ui.Models;

namespace UTAF.Ui.Driver
{
    public class ChromeDriverFactory
    {
        private readonly string _localDriverPath;
        private readonly ChromeOptions _options;
        private readonly WebDriverConfiguration _webDriverConfiguration;

        public ChromeDriverFactory(WebDriverConfiguration configuration)
        {
            _webDriverConfiguration = configuration;
            _localDriverPath = _webDriverConfiguration.LocalWebDriverPath;
            _options = BuildChromeOptions();
        }

        private ChromeOptions BuildChromeOptions()
        {
            var options = new ChromeOptions();
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
                return new ChromeDriver(_localDriverPath, _options);
            }

            try
            {
                return new ChromeDriver(_options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initiate Remote WebDriver: {ex}");
            }

            return null; // optionally, you may want to throw an exception here, instead of returning null
        }

        private static bool IsLocalDriverAvailable(string driverPath)
        {
            return File.Exists(driverPath);
        }
    }
}
