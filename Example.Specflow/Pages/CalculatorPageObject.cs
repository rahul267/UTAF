﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UTAF.Core.Logger;
using UTAF.Ui.Driver;
using UTAF.Ui.Providers;

namespace Example.Specflow.Pages
{
    public interface ICalculatorPageObject
    {
        public void Launch();
        public void EnterFirstNumber(string number);
        public void EnterSecondNumber(string number);
        public void ClickAdd();
        public string WaitForEmptyResult();
        public string WaitForNonEmptyResult();

    }
    public class CalculatorPageObject : ICalculatorPageObject
    {
        private IWebDriver _driver;
        private IDriverFactory _driverFactory;
        private ILoggerService _logger;
        public const int DefaultWaitInSeconds = 5;
        private static Uri _calculatorUrl;

        public CalculatorPageObject(IDriverFactory driverFactory, ILoggerService logger, IUIConfigurationProvider conf)
        {
            _driverFactory = driverFactory;
            _driver = _driverFactory.Driver;
            _logger = logger;
            _calculatorUrl = new Uri("https://specflowoss.github.io/Calculator-Demo/Calculator.html");

        }

        private IWebElement FirstNumberElement => _driver.FindElement(By.Id("first-number"));
        private IWebElement SecondNumberElement => _driver.FindElement(By.Id("second-number"));
        private IWebElement AddButtonElement => _driver.FindElement(By.Id("add-button"));
        private IWebElement ResultElement => _driver.FindElement(By.Id("result"));
        private IWebElement ResetButtonElement => _driver.FindElement(By.Id("reset-button"));

        public void Launch()
        {
            _driver.Navigate().GoToUrl(_calculatorUrl);
        }
        public void EnterFirstNumber(string number)
        {
            FirstNumberElement.Clear();
            FirstNumberElement.SendKeys(number);
        }

        public void EnterSecondNumber(string number)
        {
            SecondNumberElement.Clear();
            SecondNumberElement.SendKeys(number);
        }

        public void ClickAdd()
        {
            AddButtonElement.Click();
        }

        

        public string WaitForNonEmptyResult()
        {
            
            return WaitUntil(
                () => ResultElement.GetAttribute("value"),
                result => !string.IsNullOrEmpty(result));
        }

        public string WaitForEmptyResult()
        {
            
            return WaitUntil(
                () => ResultElement.GetAttribute("value"),
                result => result == string.Empty);
        }

       
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(_driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });

        }

    }
}
