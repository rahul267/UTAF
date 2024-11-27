using OpenQA.Selenium;

namespace Example.Nunit
{
    public class BlazeDemoPage
    {
        private IWebDriver driver;

        public BlazeDemoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement DepartureCity => driver.FindElement(By.Name("fromPort"));
        public IWebElement DestinationCity => driver.FindElement(By.Name("toPort"));
        public IWebElement FindFlightsButton => driver.FindElement(By.CssSelector("input[type='submit']"));
    }
}