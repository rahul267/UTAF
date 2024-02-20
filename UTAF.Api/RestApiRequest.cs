using RestSharp;


namespace UTAF.Api
{
    public class RestApiRequest
    {
        public static RestRequest? APIRequest { get; set; }

        public static RestRequest createRequestWithBaseUrl(string url)
        {
            APIRequest = new RestRequest(url);
            return APIRequest;
        }
    }

    public enum HttpMethod
    {
        GET, PUT, POST, DELETE, DELETE_WITH_BODY, OPTIONS, HEAD, CONNECT, TRACE, PATCH
    }
}
