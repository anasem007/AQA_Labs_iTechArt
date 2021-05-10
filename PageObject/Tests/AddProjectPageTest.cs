using NUnit.Framework;
using PageObject.BaseEntities;
using PageObject.Services;
using PageObject.Steps;

namespace PageObject.Tests
{
    public class AddProjectPageTest : BaseTest
    {
        private AddProjectSteps _addProjectSteps;
        private ProjectService _projectService;

        [SetUp]
        public new void OneTimeSetUp()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();
            
            _projectService = new ProjectService();
            _addProjectSteps = new AddProjectSteps(Driver);
        }

        [Test]
        public void AddProject()
        {
            var project = _projectService.GetProjectByName("Test Project pgSql");
            _addProjectSteps.AddProject(project);
        }
    }
}