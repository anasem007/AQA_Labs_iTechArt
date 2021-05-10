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
using TestRailApi.Helpers;
using TestRailApi.Models.Project;
using TestRailApi.Services;
using TestRailApi.Steps;
using static RestSharp.Method;

namespace TestRailApi.Tests.ProjectsTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("AddProjectTests")]
    public class AddProjectTest : BaseTest
    {
        private const Method Method = POST;

        private ModelResponseSteps<ProjectResponseModel> _modelResponseSteps;

        [SetUp]
        public void SetUp()
        {
            _modelResponseSteps = new ModelResponseSteps<ProjectResponseModel>();
        }

        [Test(Description = "Add valid project and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_ExistentProject_ShouldReturnOk()
        {
            var expectedProject = ProjectService.GetProject("Valid Test Project");
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint,
                Method, ModelGeneratorHelper.GetUser("Admin"), expectedProject).Result;
           
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);  
                response.Data.ShouldBeValid(expectedProject);
            }
        }

        [Test(Description = "Add project without name and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_ProjectWithoutName_ShouldReturnBadRequest()
        {
            var expectedProject = ProjectService.GetProjectWithoutName("Valid Test Project");
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, Method,
                ModelGeneratorHelper.GetUser("Admin"), expectedProject).Result;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test(Description = "Add project without announcement and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_ProjectWithoutAnnouncement_ShouldReturnOk()
        {
            var expectedProject = ProjectService.GetProjectWithoutAnnouncement("Valid Test Project");
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, Method, 
                ModelGeneratorHelper.GetUser("Admin"), expectedProject).Result;

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Test(Description = "Add project without suite mode and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_ProjectWithoutSuiteMode_ShouldReturnBadRequest()
        {
            var expectedProject = ProjectService.GetProjectWithoutSuiteMode("Valid Test Project");
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, Method, 
                ModelGeneratorHelper.GetUser("Admin"), expectedProject).Result;
            
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                response.Data.SuiteMode.Should().Be(1);
            }
        }

        [Test(Description = "Add project with invalid suite mode and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_ProjectWithInvalidSuiteMode_ShouldReturnBadRequest()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, Method, 
                ModelGeneratorHelper.GetUser("Admin"), 
                ProjectService.GetProjectWithoutAnnouncement("Invalid Test Project")).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test(Description = "Add project when user no access and returns HttpStatus Forbidden")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_UserNoAccess_ShouldReturnForbidden()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, 
                Method, ModelGeneratorHelper.GetUser("UserNoAccess"), ProjectService.GetProject("Valid Test Project")).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
        
        [Test(Description = "Add project when user unauthorized and returns HttpStatus Unauthorized")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, Method,
                ModelGeneratorHelper.GetUser("FakeUser")).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}