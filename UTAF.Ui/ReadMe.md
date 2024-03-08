## Design Patterns 

The implementation of this project involves two major design patterns: Abstract Factory and Factory Method. 

### Abstract Factory

The Abstract Factory design pattern provides a way to encapsulate a group of individual factories that have a common theme without specifying their concrete classes. 

In this project, the `DriverFactory` class represents the Abstract Factory. 

When the `DriverFactory.GetWebDriverFactory()` method is invoked, what you get in return is an instance of `IDriverFactory`. This represents a concrete WebDriver factory (`ChromeDriverFactory`, `FirefoxDriverFactory`, `SafariDriverFactory`, `EdgeDriverFactory`) based on the selected browser.

Each of these concrete factories is responsible for creating a WebDriver instance. This setup makes it easy to introduce a new browser driver - simply create a new factory and update the Abstract Factory to include it.

Below is an example of how to use the `DriverFactory`:

```csharp
var driverFactory = new DriverFactory(webDriverConfiguration, gridConfiguration);
var chromeDriverFactory = driverFactory.GetDriverFactory(); // returns ChromeDriverFactory
var chromeDriver = chromeDriverFactory.CreateDriver(); // returns ChromeDriver
```

## Custom WebDriver Extensions

This project also includes custom extension methods for the `IWebDriver` interface to provide additional functionality and ease of use, making the test automation scripts cleaner and more maintainable.

### TakeScreenshotAsPath

The `TakeScreenshotAsPath()` method is a WebDriver extension that captures a screenshot of the current state in the browser and saves it as a file at the specified path:

```csharp
public string TakeScreenshotAsPath(this IWebDriver driver, string fileName)
{
    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
    var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
    screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
    return path;
}
```
# WebDriver Waiting Mechanisms in UI Test Automation Framework

This document provides details about the `DriverWait` class, a component in our UI Test Automation Framework that drastically simplifies the application of waiting mechanisms in test scripting.

Within test scripts, there are frequently requirements to pause execution until a certain condition is met. This could be waiting for a page to load, an element to be clickable, or an AJAX call to complete.

WebDriver provides two types of waiting mechanisms - implicit wait and explicit wait. The `DriverWait` class provides a sophisticated way to utilize explicit waits, making test scripts cleaner, more manageable, and more reliable. 

## Inside the DriverWait Class

```csharp
public class DriverWait : IDriverFactory
{
    ...

    public DriverWait(IDriverFactory driverFixture, WebDriverConfiguration webDriverConfiguration)
    {
        ...
    }

    public IWebElement FindElement(By elementLocator)
    {
        ...
    }

    public IEnumerable<IWebElement> FindElements(By elementLocator)
    {
        ...
    }

    private WebDriverWait GetWaitDriver()
    {
        ...
    }
}
```
### Example
```
var element = driverWait.FindElement(By.Id("element-id"));
var elements = driverWait.FindElements(By.ClassName("element-class"));
```


