using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using UTAF.Ui.Driver;
using UTAF.Ui.Models;

public class DriverWait : IDriverWait
{
    private readonly IDriverFactory _driverFixture;
    private readonly WebDriverConfiguration _webDriverConfiguration;

    // Setting up defaults and reuse in the class
    private readonly int _defaultTimeout;
    private readonly int _pollingInterval;
    private readonly Lazy<WebDriverWait> _webDriverWait;
    private readonly object _lock=new object();

    public DriverWait(IDriverFactory driverFixture, WebDriverConfiguration webDriverConfiguration)
    {
        _driverFixture = driverFixture;
        _webDriverConfiguration = webDriverConfiguration;

        _defaultTimeout = webDriverConfiguration.DefaultTimeout ?? 30;
        _pollingInterval = webDriverConfiguration.PollingInterval ?? 1;

        _webDriverWait = new Lazy<WebDriverWait>(GetWaitDriver);
    }

    public IWebElement FindElement(By elementLocator)
    {
        return _webDriverWait.Value.Until(driver => _driverFixture.Driver.FindElement(elementLocator));
    }

    public IEnumerable<IWebElement> FindElements(By elementLocator)
    {
        return _webDriverWait.Value.Until(driver => _driverFixture.Driver.FindElements(elementLocator));
    }

    private WebDriverWait GetWaitDriver()
    {
        lock (_lock)
        {
            return new WebDriverWait(_driverFixture.Driver, TimeSpan.FromSeconds(_defaultTimeout))
            {
                PollingInterval = TimeSpan.FromSeconds(_pollingInterval)
            };
        }
    }

}
