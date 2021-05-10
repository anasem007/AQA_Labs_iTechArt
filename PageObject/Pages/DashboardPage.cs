using System;
using OpenQA.Selenium;
using PageObject.BaseEntities;
using PageObject.Core.Wrappers;
using PageObject.Constants;

namespace PageObject.Pages
{
    public class DashboardPage : BasePage
    {
        private static readonly By  SidebarProjectsAddButtonBy = By.Id("sidebar-projects-add");
        private static readonly By UserDropdownButtonBy = By.Id("navigation-user");
        private static readonly By HelpDropdownButtonBy = By.Id("navigation-menu");
        private static readonly By InProgressDropDownButtonBy = By.Id("inProgressLink");
        private static readonly By UserDropdownBy = By.Id("userDropdown");
        private static readonly By HelpDropdownBy = By.Id("helpDropdown");
        private static readonly By InProgressDropdownBy = By.XPath("//div[@class='dropdown progress-popup']");

        public DashboardPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        public DashboardPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + EndPoints.DashboardEndPoint);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return SidebarProjectsAdd.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Button SidebarProjectsAdd => new Button(Driver, SidebarProjectsAddButtonBy);
        public Button UserDropdownButton => new Button(Driver, UserDropdownButtonBy);
        public Button HelpDropdownButton => new Button(Driver, HelpDropdownButtonBy);
        public Button InProgressDropdownButton => new Button(Driver, InProgressDropDownButtonBy);
        public DropDownMenu UserDropdown => new DropDownMenu(Driver, UserDropdownBy);
        public DropDownMenu HelpDropdown => new DropDownMenu(Driver, HelpDropdownBy);
        public DropDownMenu InProgressDropdown => new DropDownMenu(Driver, InProgressDropdownBy);
    }
}