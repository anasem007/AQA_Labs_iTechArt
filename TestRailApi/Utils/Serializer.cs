using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TestRailApi.Utils
{
    public static class Serializer
    {
        public static string Serialize(object requestModel)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };

            return  JsonConvert.SerializeObject(requestModel, serializerSettings);
        }
    }
}