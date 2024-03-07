using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UTAF.Ui.Extensions
{
    public static class WebDriverExtensions
    {
        // An extension method for quickly locating an element with a wait.
        public static IWebElement FindElement(this IWebDriver driver, By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            return wait.Until(drv => drv.FindElement(by));
        }

        // An extension method for checking if an element exists.
        public static bool ElementExists(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // An extension method for quickly navigating to a URL.
        public static void NavigateToUrl(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        // An extension method for executing a JavaScript command.
        public static void ExecuteScript(this IWebDriver driver, string script)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }

        // An extension method for clicking an element using JavaScript.
        public static void ClickByJs(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        // An extension method to scroll into view of an element.
        public static void ScrollIntoView(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        // An extension method to drag and drop an element to another element.
        public static void DragAndDrop(this IWebDriver driver, IWebElement sourceElement, IWebElement targetElement)
        {
            new Actions(driver).DragAndDrop(sourceElement, targetElement).Perform();
        }

        // An extension method to select an item from a dropdown.
        public static void SelectByText(this IWebElement element, string textToSelect)
        {
            new SelectElement(element).SelectByText(textToSelect);
        }


    }
}
