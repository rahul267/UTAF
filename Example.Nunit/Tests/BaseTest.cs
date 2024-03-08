using core.Providers;
using Example.Nunit.DI;
using Example.Nunit.Pages;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using System.Diagnostics;
using UTAF.Core.Logger;
using UTAF.Core.Reporter;


namespace Example.Nunit.Tests
{
    [AllureNUnit]
    public class BaseTest
    {
        protected IBalazeHomePage _blazeHomePage;
        protected IWebDriver _driver;
        protected ILoggerService _logger;
        protected IReporter _reporter;
        protected ICoreConfigurationProvider _coreConfigurationProvider;
        
        
        [OneTimeSetUp]
        public void Setup()
        {
            IServiceProvider provider = DependencyInjector.GetServiceProvider();
            _coreConfigurationProvider=provider.GetRequiredService<ICoreConfigurationProvider>();
           _logger = provider.GetRequiredService<ILoggerService>();
            _reporter = provider.GetRequiredService<IReporterFactory>().Reporter;
            Trace.Listeners.Add(new ConsoleTraceListener());
            
        }

        [SetUp]
        public void SetupBeforeEachTest()
        {
            _reporter.StartTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            var log = TestContext.CurrentContext.Result.ToString();
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                        ? ""
                        : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            _reporter.LogNunit(status, log, stacktrace);
        }

       

        [OneTimeTearDown]
        public void TearDown()
        {
            _reporter.StopTest();
            Trace.Flush();
        }
    }
}
