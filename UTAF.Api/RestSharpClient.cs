using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
    }
}
