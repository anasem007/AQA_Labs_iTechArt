using System;
using OpenQA.Selenium;
using PageObject.BaseEntities;
using PageObject.Core.Wrappers;
using PageObject.Constants;

namespace PageObject.Pages
{
    public class AddProjectPage : BasePage
    {
        private static readonly By AddProjectButtonBy = By.Id("accept");
        private static readonly By RadioButtonBy = By.XPath("//div[@class='radio']");
        private static readonly By NameInputBy = By.Id("name");
        private static readonly By AnnouncementFieldBy = By.Id("announcement");
        private static readonly By ShowAnnouncementCheckBoxBy = By.Id("show_announcement");

        public AddProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl) {}
        
        public AddProjectPage(IWebDriver driver) : base(driver, false) {}
        
        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + EndPoints.AdminAddProjectEndPoint);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return AddProject.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Button AddProject => new Button(Driver, AddProjectButtonBy);
        public RadioButton ModeSuite => new RadioButton(Driver, RadioButtonBy);
        public Input Name => new Input(Driver, NameInputBy);
        public Input Announcement =>new Input(Driver, AnnouncementFieldBy);
        public CheckBox ShowAnnouncement =>new CheckBox(Driver, ShowAnnouncementCheckBoxBy);
    }
}