using System;
using NUnit.Framework;
using PageObject.BaseEntities;
using PageObject.Pages;
using PageObject.Steps;

namespace PageObject.Tests
{
    public class DropDownTest : BaseTest
    {
        [Test]
        public void TestUserDropdownSelectByText()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            var dashboardPage = new DashboardPage(Driver);
            dashboardPage.UserDropdownButton.Click();
            Assert.IsTrue( dashboardPage.UserDropdown.Displayed);
            dashboardPage.UserDropdown.SelectByText("My Settings");
        }

        [Test]
        public void TestHelpDropdownSelectByText()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            var dashboardPage = new DashboardPage(Driver);
            dashboardPage.HelpDropdownButton.Click();
            Console.Out.WriteLine(dashboardPage.HelpDropdown.Displayed);
            dashboardPage.HelpDropdown.SelectByText("TestRail User Guide");
        }
        
        [Test]
        public void TestProgressDropDown()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            var dashboardPage = new DashboardPage(Driver);
            dashboardPage.InProgressDropdownButton.Click();
            Console.Out.WriteLine(dashboardPage.InProgressDropdown.Displayed);
            Console.Out.WriteLine(dashboardPage.InProgressDropdown.Text);
            Assert.AreEqual(dashboardPage.InProgressDropdown.Text, $"In Progress\n There are no tests you are currently working on." +
                                           $" You can use the Progress  feature to indicate that you are working on a test.");
        }

    }
}