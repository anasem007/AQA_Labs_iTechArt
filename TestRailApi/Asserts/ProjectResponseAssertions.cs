using System;
using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using RestSharp;
using TestRailApi.Models.Project;

namespace TestRailApi.Asserts
{
    public class ProjectResponseAssertions
    {
        private readonly RestResponse<ProjectResponseModel> _response;
        
        public ProjectResponseAssertions(RestResponse<ProjectResponseModel> response)
        {
            _response = response;
        }
        
        [CustomAssertion]
        public void BeValid(ProjectRequestModel requestModel, string because = "", params  object[] becauseArgs)
        {
            using (new AssertionScope())
            {
                _response.StatusCode.Should().Be(HttpStatusCode.OK);  
                _response.Data.Should().BeEquivalentTo(requestModel);
                _response.Data.CompletedOn.Should().BeNull();
                _response.Data.IsCompleted.Should().BeFalse();
                _response.Data.Id.Should().BeOfType(typeof(int), "", typeof(int));
                Uri.IsWellFormedUriString(_response.ResponseUri.ToString(), UriKind.Absolute).Should().BeTrue();
            }
        }
    }
}