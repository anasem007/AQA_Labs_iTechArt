using System;
using FluentAssertions;
using FluentAssertions.Execution;
using TestRailApi.Models.Suite;

namespace TestRailApi.Asserts
{
    public static class SuiteAssertions
    {
        public static void ShouldBeValid(this SuiteResponseModel response, SuiteRequestModel request)
        {
            using (new AssertionScope())
            {
                response.Should().BeEquivalentTo(request);
                response.IsMaster.Should().BeFalse();
                response.IsBaseline.Should().BeFalse();
                response.IsCompleted.Should().BeFalse();
                response.CompletedOn.Should().BeNull();
                Uri.IsWellFormedUriString(response.Url, UriKind.Absolute).Should().BeTrue();
            }
        }
    }
}