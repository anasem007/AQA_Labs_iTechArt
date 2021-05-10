using System.Linq;
using OpenQA.Selenium;
using TestRailApi.Helpers;
using TestRailApi.Models.Suite;

namespace TestRailApi.Services
{
    public class SuiteService
    {
        public static SuiteRequestModel GetSuite(string name)
        {
            foreach (var suite in TestData.Suites.Where(suite => suite.Name == name))
            {
                return suite;
            }

            throw new NotFoundException();
        }
        
        public static SuiteRequestModel GetSuiteWithoutName(string name)
        {
            var suite = GetSuite(name);
            
            return new SuiteRequestModel
            {
                Description = suite.Description
            };
        }
        
        public static SuiteRequestModel GetSuiteWithoutDescription(string name)
        {
            var suite = GetSuite(name);
            
            return new SuiteRequestModel
            {
                Name = suite.Name
            };
        }
    }
}