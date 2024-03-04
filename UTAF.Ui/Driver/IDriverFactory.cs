using OpenQA.Selenium;

namespace UTAF.Ui.Driver
{
    public interface IDriverFactory
    {
        public IWebDriver Driver { get; }
        string TakeScreenshotAsPath(string fileName);

    }
}

