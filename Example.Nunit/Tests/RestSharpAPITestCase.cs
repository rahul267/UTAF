using Example.Nunit.DI;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System.Text.Json;
using UTAF.Api;
using UTAF.Core.Logger;
using UTAF.Core.Reporter;
using HttpMethod = UTAF.Api.HttpMethod;
using JsonSerializer = System.Text.Json.JsonSerializer;

[assembly: Parallelizable(ParallelScope.All)]
namespace Example.Nunit.Tests
{
    internal class RestSharpAPITestCase :BaseTest
    {
        protected RestClient _restClient;
        protected ILoggerService _logger;
        protected IReporter _reporter;
       
        [OneTimeSetUp]
        public void Setup()
        {
             IServiceProvider provider = DependencyInjector.GetServiceProvider();
            _restClient = provider.GetRequiredService<IRestSharpClient>().Client;
           
        }

        

        [Test]
        // Getting response with validation      
        public async Task TestingDogApiGetAsync()
        {

            RestApiRequest.createRequestWithBaseUrl("https://dog.ceo/api/");
            RestApiResponse.SendRequest(HttpMethod.GET,_restClient);
            Assert.That(RestApiResponse.response.IsSuccessful,Is.True);
        }
        [Test]
        public async Task TestingProductApiGetAsync()
        {
            RestApiRequest
                .createRequestWithBaseUrl("https://testapi.jasonwatmore.com")
                .AddUrlSegment("products",1)
                .AddBody(new
                {
                    name = "RestSharp POST Request Example"
                });

            var response = RestApiResponse.SendRequest(HttpMethod.GET, _restClient);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var product = JsonSerializer.Deserialize<Product>(response.Content!, options)!;

           
           Assert.That(product.Id,Is.EqualTo(1));
        }

       
        

    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
