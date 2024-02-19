using RestSharp;


namespace UTAF.Api
{
    public class RestApiResponse
    {
        static RestApiRequest restAPIRequest;
        public static RestResponse response;

        public static RestResponse SendRequest(HttpMethod requestType)
        {

            var client = new RestClient();

            if (RestApiRequest.APIRequest == null)
            {
                return response;
            }

            switch (requestType)
            {
                case HttpMethod.GET:
                    response = client.Get(RestApiRequest.APIRequest);
                    break;
                case HttpMethod.POST:
                    response = client.Post(RestApiRequest.APIRequest);
                    break;
                case HttpMethod.DELETE:
                    response = client.Delete(RestApiRequest.APIRequest);
                    break;
                case HttpMethod.PUT:
                    response = client.Put(RestApiRequest.APIRequest);
                    break;
                case HttpMethod.PATCH:
                    response = client.Patch(RestApiRequest.APIRequest);
                    break;
                case HttpMethod.OPTIONS:
                    response = client.Options(RestApiRequest.APIRequest);
                    break;
                default:
                 
                    break;
            }
            return response;
        }
    }
}
