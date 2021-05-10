using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.BaseEntities;
using PageObject.Core.Wrappers;
using PageObject.Pages;
using PageObject.Steps;

namespace PageObject.Tests
{
    public class RadioButtonTest : BaseTest
    {
        [Test]
        public void Test1()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            var dashBoardPage = new DashboardPage(Driver);
            dashBoardPage.SidebarProjectsAdd.Click();

            var addProjectPage = new AddProjectPage(Driver);
            addProjectPage.Name.SendKeys("test-wrappers-radioButton");

            addProjectPage.ModeSuite.SelectById("suite_mode_single_baseline");
            addProjectPage.AddProject.Click();
        }
        
        [Test]
        public void Test3()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            var dashBoardPage = new DashboardPage(Driver);
            dashBoardPage.SidebarProjectsAdd.Click();

            var addProjectPage = new AddProjectPage(Driver);
            
            addProjectPage.Name.SendKeys("radioBut2");
            
            addProjectPage.ModeSuite.SelectByValue("2");

            /*var radioButton = new RadioButton(Driver, By.XPath("//div[@class='radio']"));
            radioButton.SelectByValue("2");*/
          //  addProjectPage.AddProjectButton.Click();
            Thread.Sleep(1000);
        }
        
        [Test]
        public void Test2()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            var dashBoardPage = new DashboardPage(Driver);
            dashBoardPage.SidebarProjectsAdd.Click();

            var addProjectPage = new AddProjectPage(Driver);
            addProjectPage.AddProject.Click();

            var checkBox = new CheckBox(Driver, By.Id("show_announcement"));
            //var radioButton = new RadioButton(Driver, By.ClassName("radio"));
           // radioButton.SelectById("suite_mode_single_baseline");
           Console.Out.WriteLine(checkBox.Selected);
           checkBox.Click();
           Console.Out.WriteLine(checkBox.Selected);
        }
    }
}