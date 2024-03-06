using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTAF.Ui.Models;
using OpenQA.Selenium.Firefox;

namespace UTAF.Ui.Driver
{
    internal class FirefoxDriverFactory
    {
        private readonly string _localDriverPath;
        private readonly FirefoxOptions _options;
        private readonly WebDriverConfiguration _webDriverConfiguration;

        public FirefoxDriverFactory(WebDriverConfiguration configuration)
        {
            _webDriverConfiguration = configuration;
            _localDriverPath = _webDriverConfiguration.LocalWebDriverPath + @"\geckodriver.exe";
            _options = BuildFirefoxOptions();
        }

        private FirefoxOptions BuildFirefoxOptions()
        {
            var options = new FirefoxOptions();
            options.AddArguments(_webDriverConfiguration.OptionArgMax,
                                 "enable-automation",
                                 "disable-infobars");
            return options;
        }

        public IWebDriver CreateDriver()
        {
            if (IsLocalDriverAvailable(_localDriverPath))
            {
                _options.BinaryLocation = _localDriverPath;
                return new FirefoxDriver(_localDriverPath, _options);
            }

            try
            {
                return new FirefoxDriver(_options);
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
