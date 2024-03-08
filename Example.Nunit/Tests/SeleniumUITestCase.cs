using Example.Nunit.DI;
using Example.Nunit.Pages;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using UTAF.Ui.Driver;
using UTAF.Ui.Providers;

namespace Example.Nunit.Tests
{
    public class Tests:BaseTest
    {
        protected IUIConfigurationProvider _uiConfigurationProvider;
        [OneTimeSetUp]
        public void Setup()
        {
            IServiceProvider provider = DependencyInjector.GetServiceProvider();
            _uiConfigurationProvider = provider.GetRequiredService<IUIConfigurationProvider>();
            _driver = provider.GetRequiredService<IDriverFactory>().Driver;
            _blazeHomePage = provider.GetRequiredService<IBalazeHomePage>();
            Trace.Listeners.Add(new ConsoleTraceListener());

        }
        [Test]
        public void UITestToOpenWebpage()
        {
           
            _logger.LogInformation("Starting the test...");
            _blazeHomePage.Launch();
            Trace.WriteLine("Opened a web page");

        }

        [Test]
        public void UITestToOpenWebpageAndSelectCities()
        {

            _logger.LogInformation("Starting the test...");
            _blazeHomePage.Launch();
            Trace.WriteLine("Opened BalzeHome page");
            _blazeHomePage.SelectCities();

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
            
        }


    }
}