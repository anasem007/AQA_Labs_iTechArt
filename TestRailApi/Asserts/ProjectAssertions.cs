using System;
using FluentAssertions;
using FluentAssertions.Execution;
using TestRailApi.Models.Project;

namespace TestRailApi.Asserts
{
    public static class ProjectAssertions
    {
        public static void ShouldBeValid(this ProjectResponseModel responseModel, ProjectRequestModel requestModel)
        {
            using (new AssertionScope())
            {
                responseModel.Should().BeEquivalentTo(requestModel);
                responseModel.CompletedOn.Should().BeNull();
                responseModel.IsCompleted.Should().BeFalse();
                Uri.IsWellFormedUriString(responseModel.Url, UriKind.Absolute).Should().BeTrue();
            }
        }
    }
}