using System.Linq;
using OpenQA.Selenium;
using TestRailApi.Models.Project;
using TestRailApi.Models.Suite;
using TestRailApi.Models.User;

namespace TestRailApi.Helpers
{
    public static class ModelGeneratorHelper
    {
        public static ProjectRequestModel GetProject(string name)
        {
            foreach (var project in TestData.Projects.Where(project => project.Name == name))
            {
                return project;
            }

            throw new NotFoundException();
        }

        public static ProjectRequestModel GetProjectWithoutName(string name)
        {
            var project = GetProject(name);
            return new ProjectRequestModel
            {
                Announcement = project.Announcement,
                ShowAnnouncement = project.ShowAnnouncement,
                SuiteMode = project.SuiteMode
            };
        }
        
        public static ProjectRequestModel GetProjectWithoutAnnouncement(string name)
        {
            var project = GetProject(name);
            return new ProjectRequestModel
            {
                Name = project.Name,
                ShowAnnouncement = project.ShowAnnouncement,
                SuiteMode = project.SuiteMode
            };
        }
        
        public static ProjectRequestModel GetProjectWithoutSuiteMode(string name)
        {
            var project = GetProject(name);
            return new ProjectRequestModel
            {
                Name = project.Name,
                Announcement = project.Announcement,
                ShowAnnouncement = project.ShowAnnouncement
            };
        }
        
        public static SuiteRequestModel GetSuite(string name)
        {
            foreach (var suite in TestData.Suites.Where(suite => suite.Name == name))
            {
                return suite;
            }

            throw new NotFoundException();
        }
        
        public static User GetUser(string id)
        {
            foreach (var user in TestData.Users.Where(user => user.Id == id))
            {
                return user;
            }

            throw new NotFoundException();
        }
    }
}