using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using PageObject.Models;

namespace PageObject.Services
{
    public class ProjectService
    {
        private readonly List<Project> _projects;

        public ProjectService()
        {
            _projects = ModelFactory.GenerateProjects();
        }

        public Project GetProjectByName(string name)
        {
            foreach (var project in _projects.Where(project => project.Name == name))
            {
                return project;
            }
            throw new NotFoundException();
        }
    }
}