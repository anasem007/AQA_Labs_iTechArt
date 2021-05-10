using System.Net;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using TestRailApi.BaseEntities;
using TestRailApi.Constants;
using TestRailApi.Helpers;
using TestRailApi.Models.Project;
using TestRailApi.Steps;
using static RestSharp.Method;

namespace TestRailApi.Tests.ProjectsTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("DeleteProjectTests")]
    public class DeleteProjectTest : BaseTest
    {
        private const Method Method = POST;

        private ModelResponseSteps<ProjectResponseModel> _modelResponseSteps;
        
        [SetUp]
        public void SetUp()
        {
            _modelResponseSteps = new ModelResponseSteps<ProjectResponseModel>();

            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, Method,
                ModelGeneratorHelper.GetUser("Admin"), ModelGeneratorHelper.GetProject("Valid Test Project")).Result;
            ProjectId = response.Data.Id;
        }

        [Test(Description = "Delete existent project and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        //[AllureSubSuite("Delete Project")]
        public void DeleteProject_ExistentProject_ShouldReturnOk()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.DeleteProjectEndPoint + ProjectId, 
                Method, ModelGeneratorHelper.GetUser("Admin")).Result;
            
            Assert.Multiple(() =>
            { 
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Data.Should().BeNull();
            });
        }

        [Test(Description = "Delete non existent project and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void DeleteProject_NonExistentProject_ShouldReturnBadRequest()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.DeleteProjectEndPoint + FakeProjectId,
                Method, ModelGeneratorHelper.GetUser("Admin")).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Test(Description = "Delete project when user no access and returns HttpStatus Forbidden")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void DeleteProject_UserNoAccess_ShouldReturnForbidden()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.DeleteProjectEndPoint + ProjectId, 
                Method, ModelGeneratorHelper.GetUser("UserNoAccess")).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
        
        [Test(Description = "Delete project when user is unauthorized and returns HttpStatus Unauthorized")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void DeleteProject_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.DeleteProjectEndPoint + ProjectId,
                Method, ModelGeneratorHelper.GetUser("FakeUser")).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Test(Description = "Delete project with invalid id and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void DeleteProject_InvalidProjectId_ShouldReturnBadRequest()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.DeleteProjectEndPoint + InvalidId, 
                Method, ModelGeneratorHelper.GetUser("Admin")).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}