using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using TestRailApi.Models.Project;
using TestRailApi.Models.Suite;
using TestRailApi.Models.User;

namespace TestRailApi.Helpers
{
    public static class TestData
    {
        private const string ProjectsFileName = "projects";
        private const string SuitesFileName = "suites";
        private const string UsersFileName = "users";

        public static IEnumerable<ProjectRequestModel> Projects => GenerateModels<ProjectRequestModel>(ProjectsFileName);
        public static IEnumerable<SuiteRequestModel> Suites => GenerateModels<SuiteRequestModel>(SuitesFileName);
        public static IEnumerable<User> Users => GenerateModels<User>(UsersFileName);
        private static List<T> GenerateModels<T>(string name)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPathToFile = Path.Combine(basePath ?? string.Empty, $"TestData{Path.DirectorySeparatorChar}", $@"{name}.json");

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            var jsonStream = File.ReadAllText(fullPathToFile);
            
            return JsonSerializer.Deserialize<List<T>>(jsonStream);
        }
    }
}