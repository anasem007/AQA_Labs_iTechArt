using System.Threading.Tasks;
using RestSharp;
using TestRailApi.ClientExtensions;
using TestRailApi.Helpers;
using TestRailApi.Models.User;
using TestRailApi.Services;

namespace TestRailApi.Steps
{
    public class ModelResponseSteps<T>
    {
        public async Task<IRestResponse<T>> CreateResponse(string endPoint, Method method,
            User user, object model = null)
        {
            var request = RestRequestBuilder.Build(endPoint, method, user, model);
            var client = user.CreateClient();
            
            return await ClientHelper.GetResponse<T>(client, request);
        }
    }
}