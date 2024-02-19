using Example.Nunit.DI;
using Example.Nunit.Pages;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System.Threading;
using UTAF.Api;
using UTAF.Core.Logger;
using UTAF.Core.Reporter;

namespace Example.Nunit.Tests
{
    internal class RestSharpAPITestCase
    {
        protected IRestSharpClient _restClient;
        protected ILoggerService _logger;
        protected IReporter _reporter;
        [OneTimeSetUp]
        public void Setup()
        {
            IServiceProvider provider = DependencyInjector.GetServiceProvider();
            _restClient = provider.GetRequiredService<IRestSharpClient>();
            _logger = provider.GetRequiredService<ILoggerService>();
            _reporter = provider.GetRequiredService<IReporterFactory>().Reporter;
        }

        [Test]
        // Getting response with validation      
        public async Task TestingDogApiGetAsync()
        {
            
            RestApiRequest.createRequest("https://dog.ceo/api/");
            RestApiResponse.SendRequest(UTAF.Api.HttpMethod.GET);
            var response = await _restClient.Client.ExecuteAsync(RestApiRequest.APIRequest);
            Assert.IsTrue(RestApiResponse.response.IsSuccessful);
        }
    }
}
