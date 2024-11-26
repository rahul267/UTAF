using OpenQA.Selenium;

public class BlazeDemoPage
{
    private IWebDriver driver;

    public BlazeDemoPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public IWebElement FindFlightsButton => driver.FindElement(By.CssSelector("input[value='Find Flights']"));
    public IWebElement ChooseThisFlightButton => driver.FindElement(By.CssSelector("input[value='Choose This Flight']"));
    public IWebElement PurchaseFlightButton => driver.FindElement(By.CssSelector("input[value='Purchase Flight']"));
}