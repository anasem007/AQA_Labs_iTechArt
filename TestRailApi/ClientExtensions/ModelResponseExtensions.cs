using System.Threading.Tasks;
using RestSharp;
using TestRailApi.Helpers;
using TestRailApi.Models;
using TestRailApi.Services;

namespace TestRailApi.ClientExtensions
{
    public class ModelResponseExtensions<T>
    {
        public async Task<IRestResponse<T>> CreateResponse(string endPoint, Method method,
            User user, object model = null)
        {
            var request = RestRequestBuilder.Build(endPoint, method, user, model);
            var client = user.CreateClient();
            
            return ClientHelper.GetResponse<T>(client, request).Result;
        }
    }
}