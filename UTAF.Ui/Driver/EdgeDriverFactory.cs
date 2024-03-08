using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using UTAF.Ui.Models;

namespace UTAF.Ui.Driver
{
    public class EdgeDriverFactory:BaseDriverFactory
    {
        public EdgeDriverFactory(WebDriverConfiguration webDriverConfiguration, GridConfiguration gridConfiguration)
        : base(
            webDriverConfiguration.LocalWebDriverPath + @"\msedgedriver.exe",
            gridConfiguration.IsEnabled ? gridConfiguration.GridUri : null,
            BuildEdgeOptions(webDriverConfiguration))
        {
        }

        private static EdgeOptions BuildEdgeOptions(WebDriverConfiguration webDriverConfiguration)
        {
            var options = new EdgeOptions();
            // If any edge specific options needed, set them up here
            return options;
        }

        protected override IWebDriver CreateLocalDriver()
        {
            if (this._options is EdgeOptions edgeOptions)
            {
                edgeOptions.BinaryLocation = this._localDriverPath;
                return new EdgeDriver(this._localDriverPath, edgeOptions);
            }
            throw new InvalidOperationException("Driver options are not of type EdgeOptions");
        }

        protected override IWebDriver CreateDefaultDriver()
        {
            if (this._options is EdgeOptions edgeOptions)
            {
                return new EdgeDriver(edgeOptions);
            }
            throw new InvalidOperationException("Driver options are not of type EdgeOptions");
        }

    }
}
