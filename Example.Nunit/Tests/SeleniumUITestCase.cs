using Example.Nunit.DI;
using Example.Nunit.Pages;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using UTAF.Ui.Driver;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace Example.Nunit.Tests
{
    public class Tests:BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            IServiceProvider provider = DependencyInjector.GetServiceProvider();
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

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
            
        }


    }
}