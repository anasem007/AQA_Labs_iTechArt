using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
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
    [AllureSuite("AddSuiteTests")]
    public class AddSuiteTest : BaseTest
    {
        private const Method Method = POST;

        private ModelResponseSteps<SuiteResponseModel> _suiteResponseSteps;
        
        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            _suiteResponseSteps = new ModelResponseSteps<SuiteResponseModel>();

            var projectResponseSteps = new ModelResponseSteps<ProjectResponseModel>();
            var response = projectResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, Method, 
                UserService.GetUser("Admin"), ProjectService.GetProject("Valid Test Project")).Result;

            ProjectId = response.Data.Id;
        }
        
        [Test(Description = "Add valid suite and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_ValidSuite_ShouldReturnOk()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, Method,
                UserService.GetUser("Admin"), SuiteService.GetSuite("Suite")).Result;

            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Data.Id.Should().NotBe(null);
                response.Data.ProjectId.Should().Be(ProjectId);
            }
        }
        
        [Test(Description = "Add suite in non existent project and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_NonExistentProject_ShouldReturnBadRequest()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + FakeProjectId, Method, 
                UserService.GetUser("Admin"), SuiteService.GetSuite("Suite")).Result;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Test(Description = "Add suite when user no access and returns HttpStatus Forbidden")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_UserNoAccess_ShouldReturnForbidden()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, Method, 
                UserService.GetUser("UserNoAccess"),SuiteService.GetSuite("Suite")).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
        
        [Test(Description = "Add suite when user is unauthorized and returns HttpStatus Unauthorized")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, Method, 
                UserService.GetUser("FakeUser"), SuiteService.GetSuite("Suite")).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Test(Description = "Add suite when project id is invalid and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_InvalidProjectId_ShouldReturnBadRequest()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + InvalidId, Method, 
                UserService.GetUser("Admin"), SuiteService.GetSuite("Suite")).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Test(Description = "Add suite without name (invalid data) and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_SuiteWithoutName_ShouldReturnBadRequest()
        {
            var expectedSuite = SuiteService.GetSuiteWithoutName("Suite");
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, Method,
                UserService.GetUser("Admin"), expectedSuite).Result;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Test(Description = "Add suite without description (invalid data) and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_SuiteWithoutDescription_ShouldReturnOk()
        {
            var expectedSuite = SuiteService.GetSuiteWithoutDescription("Suite");
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, Method,
                UserService.GetUser("Admin"), expectedSuite).Result;

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}