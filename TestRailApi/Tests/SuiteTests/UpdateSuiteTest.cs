using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using TestRailApi.Asserts;
using TestRailApi.BaseEntities;
using TestRailApi.Constants;
using TestRailApi.Models.Project;
using TestRailApi.Models.Suite;
using TestRailApi.Services;
using TestRailApi.Steps;
using static RestSharp.Method;

namespace TestRailApi.Tests.SuiteTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("UpdateSuiteTests")]
    public class UpdateSuiteTest : BaseTest
    {
        private const Method Method = POST;
        
        private ModelResponseSteps<SuiteResponseModel> _suiteResponseSteps;

        [OneTimeSetUp]
        public void SetUp()
        {
            var projectResponseSteps = new ModelResponseSteps<ProjectResponseModel>();
            var projectResponse = projectResponseSteps
                .CreateResponse(EndPoints.AddProjectEndPoint, POST,  UserService.GetUser("Admin"), 
                    ProjectService.GetProject("Valid Test Project")).Result;
            ProjectId = projectResponse.Data.Id; 
            
            _suiteResponseSteps = new ModelResponseSteps<SuiteResponseModel>();
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, Method, 
                UserService.GetUser("Admin"), SuiteService.GetSuite("Suite")).Result;
            SuiteId = response.Data.Id;
        }
        
        [Test(Description = "Add valid suite and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_ValidSuite_ShouldReturnOk()
        {
            var expectedSuite = SuiteService.GetSuite("Update Suite");
            var response = _suiteResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + SuiteId, Method,
                UserService.GetUser("Admin"), expectedSuite).Result;
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);  
                response.Data.ShouldBeValid(expectedSuite);
                response.Data.ProjectId.Should().Be(ProjectId);
                response.Data.Id.Should().Be(SuiteId);
            }
        }
        
        [Test(Description = "Try update suite with invalid id and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_InvalidSuiteId_ShouldReturnBadRequest()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + InvalidId, Method,  
                UserService.GetUser("Admin"), SuiteService.GetSuite("Update Suite")).Result;
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Test(Description = "Try update suite when user doesn't have access and returns HttpStatus Forbidden")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_UserNoAccess_ShouldReturnForbidden()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + SuiteId, Method,  
                UserService.GetUser("UserNoAccess"),SuiteService.GetSuite("Update Suite")).Result;
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
        
        [Test(Description = "Try update suite when user is unauthorized and returns HttpStatus Unauthorized")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + SuiteId, Method,
                UserService.GetUser("FakeUser"), SuiteService.GetSuite("Update Suite")).Result;
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Test(Description = "Update suite excluding name and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_RequestWithoutName_ShouldReturnOk()
        {
            var expectedResult = SuiteService.GetSuiteWithoutName("Update Suite");
           
            var response = _suiteResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + SuiteId, Method,
                UserService.GetUser("Admin"), expectedResult).Result;
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
                response.Data.Name.Should().Be(expectedResult.Name);
                response.Data.Description.Should().Be(expectedResult.Description);
            }
        }
        
        [Test(Description = "Update suite excluding description and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_RequestWithoutDescription_ShouldReturnOk()
        {
            var expectedResult = SuiteService.GetSuiteWithoutDescription("Update Suite"); 
            
            var response = _suiteResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + SuiteId, Method, 
                UserService.GetUser("Admin"), expectedResult).Result;
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Data.Description.Should().Be(expectedResult.Description);
                response.Data.Name.Should().Be(expectedResult.Name);
            }
        }
    }
}