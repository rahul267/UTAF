using RestSharp;


namespace UTAF.Api
{
    
    public interface IRestSharpClient
    {
        public RestClient Client { get; }
    }
    public class RestSharpClient : IRestSharpClient
    {
        public RestClient Client { get; }

        public RestSharpClient() 
        {
         Client = new RestClient();
        }

        public RestSharpClient(String url)
        {
            Client = new RestClient(url);
        }
    }
}
