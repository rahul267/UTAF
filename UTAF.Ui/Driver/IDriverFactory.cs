using OpenQA.Selenium;

namespace UTAF.Ui.Driver
{
    public interface IDriverFactory : IDisposable
    {
        public IWebDriver Driver { get; }
        string TakeScreenshotAsPath(string fileName);
       
    }
}

