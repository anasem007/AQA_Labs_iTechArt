using System.Linq;
using OpenQA.Selenium;
using TestRailApi.Helpers;
using TestRailApi.Models.Project;

namespace TestRailApi.Services
{
    public class ProjectService
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
            foreach (var project in TestData.Projects.Where(project => project.Name == name))
            {
                return new ProjectRequestModel
                {
                    Announcement = project.Announcement,
                    ShowAnnouncement = project.ShowAnnouncement,
                    SuiteMode = project.SuiteMode
                };
            }

            throw new NotFoundException();
        }
        
        public static ProjectRequestModel GetProjectWithoutAnnouncement(string name)
        {
            foreach (var project in TestData.Projects.Where(project => project.Name == name))
            {
                return new ProjectRequestModel
                {
                    Name = project.Name,
                    ShowAnnouncement = project.ShowAnnouncement,
                    SuiteMode = project.SuiteMode
                };
            }

            throw new NotFoundException();
        }
        
        public static ProjectRequestModel GetProjectWithoutSuiteMode(string name)
        {
            foreach (var project in TestData.Projects.Where(project => project.Name == name))
            {
                return new ProjectRequestModel
                {
                    Name = project.Name,
                    Announcement = project.Announcement,
                    ShowAnnouncement = project.ShowAnnouncement
                };
            }

            throw new NotFoundException();
        }
        
    }
}