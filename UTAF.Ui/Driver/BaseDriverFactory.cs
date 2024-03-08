using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace UTAF.Ui.Driver
{
    public abstract class BaseDriverFactory
    {
        protected readonly string _localDriverPath;
        private readonly Uri? _remoteWebDriverUri;
        protected readonly DriverOptions _options;

        protected BaseDriverFactory(string localDriverPath, Uri? remoteWebDriverUri, DriverOptions options)
        {
            _localDriverPath = localDriverPath;
            _remoteWebDriverUri = remoteWebDriverUri;
            _options = options;
        }

        public IWebDriver CreateDriver()
        {
            try
            {
                if (_remoteWebDriverUri != null)
                {
                    return CreateRemoteDriver();
                }

                if (IsLocalDriverAvailable())
                {
                    return CreateLocalDriver();
                }

                return CreateDefaultDriver();
            }
            catch (Exception ex)
            {
                LogError($"Failed to create WebDriver: {ex}");
                throw;
            }
        }

        protected abstract IWebDriver CreateLocalDriver();
        protected abstract IWebDriver CreateDefaultDriver();

        private IWebDriver CreateRemoteDriver() => new RemoteWebDriver(_remoteWebDriverUri, _options);
        private bool IsLocalDriverAvailable() => File.Exists(_localDriverPath);
        private void LogError(string message) { } //
    }
}
