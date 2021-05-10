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
using TestRailApi.Services;
using TestRailApi.Steps;
using static RestSharp.Method;

namespace TestRailApi.Tests.ProjectsTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("GetProjectsTests")]
    public class GetProjectTest : BaseTest
    {
        private const Method Method = GET;

        private ModelResponseSteps<ProjectResponseModel> _modelResponseSteps;

        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            _modelResponseSteps = new ModelResponseSteps<ProjectResponseModel>();
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, POST, 
                UserService.GetUser("Admin"), ProjectService.GetProject("Valid Test Project")).Result;

            ProjectId = response.Data.Id;
        }
        
        [Test(Description = "Get valid project and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void GetProject_ExistentProject_ShouldReturnOk()
        {
            var response = _modelResponseSteps
                .CreateResponse(EndPoints.GetProjectEndPoint + ProjectId, Method, UserService.GetUser("Admin")).Result; 
            
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK); 
                response.Data.ShouldBeValid(ProjectService.GetProject("Valid Test Project"));
                response.Data.Id.Should().Be(ProjectId);
            }
        }

        [Test(Description = "Get project fake id and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void GetProject_ProjectWithFakeId_ShouldReturnBadRequest()
        {
            var response = _modelResponseSteps
                .CreateResponse(EndPoints.GetProjectEndPoint + FakeProjectId, Method, UserService.GetUser("Admin")).Result;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test(Description = "Get project when user no access and returns HttpStatus Forbidden")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void GetProject_UserNoAccess_ShouldReturnForbidden()
        {
            var response = _modelResponseSteps
                .CreateResponse(EndPoints.GetProjectEndPoint + ProjectId, Method, 
                    UserService.GetUser("UserNoAccess")).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
        
        [Test(Description = "Get project when user is unauthorized and returns HttpStatus Unauthorized")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void GetProject_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.GetProjectEndPoint + ProjectId, Method, 
                UserService.GetUser("FakeUser")).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}