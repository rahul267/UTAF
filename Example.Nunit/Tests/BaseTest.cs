﻿using Example.Nunit.DI;
using Example.Nunit.Pages;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using UTAF.Core.Logger;
using UTAF.Core.Reporter;
using UTAF.Ui.Driver;

namespace Example.Nunit.Tests
{
    public class BaseTest
    {
        protected IBalazeHomePage _blazeHomePage;
        protected IWebDriver _driver;
        protected ILoggerService _logger;
        protected IReporter _reporter;
        [OneTimeSetUp]
        public void Setup()
        {
            IServiceProvider provider = DependencyInjector.GetServiceProvider();
            _logger = provider.GetRequiredService<ILoggerService>();
            _reporter = provider.GetRequiredService<IReporterFactory>().Reporter;
            _driver = provider.GetRequiredService<IDriverFactory>().Driver;
            _blazeHomePage = provider.GetRequiredService<IBalazeHomePage>();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
            _reporter.StopTest();
        }
    }
}
