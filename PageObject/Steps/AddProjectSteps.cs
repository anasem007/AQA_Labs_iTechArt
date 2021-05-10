using OpenQA.Selenium;
using PageObject.BaseEntities;
using PageObject.Models;
using PageObject.Pages;

namespace PageObject.Steps
{
    public class AddProjectSteps : BaseStep
    {
        private readonly AddProjectPage _addProjectPage;

        public AddProjectSteps(IWebDriver driver) : base(driver)
        {
            _addProjectPage = new AddProjectPage(Driver, true);
        }
        
        public void AddProject(Project project)
        {
            _addProjectPage.Name.SendKeys(project.Name);
            _addProjectPage.ModeSuite.SelectById(project.ModeSuite);
            _addProjectPage.AddProject.Click();
        }
    }
}