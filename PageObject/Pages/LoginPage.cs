using System;
using OpenQA.Selenium;
using PageObject.BaseEntities;
using PageObject.Constants;
using PageObject.Core.Wrappers;

namespace PageObject.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By EmailInputBy = By.Id("name");
        private static readonly By PswInputBy = By.Id("password");
        private static readonly By RememberMeCheckboxBy = By.Id("rememberme");
        private static readonly By LogInButtonBy = By.Id("button_primary");

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + EndPoints.LoginEndPoint);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Login.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Input Email => new Input(Driver, EmailInputBy);
        public Input Password => new Input(Driver, PswInputBy);
        public CheckBox RememberMeCheckbox => new CheckBox(Driver, RememberMeCheckboxBy);
        public Button Login => new Button(Driver, LogInButtonBy);
    }
}