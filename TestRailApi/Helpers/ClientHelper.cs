using System.Threading.Tasks;
using RestSharp;

namespace TestRailApi.Helpers
{
    public static class ClientHelper
    {
        public static async Task<IRestResponse<T>> GetResponse<T>(RestClient client, RestRequest request)
        {
            return await client.ExecuteAsync<T>(request);
        }
    }
}