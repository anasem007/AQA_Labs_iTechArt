using OpenQA.Selenium;
using PageObject.BaseEntities;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Steps
{
    public class LoginSteps : BaseStep
    {
        private readonly LoginPage _loginPage;
        public LoginSteps(IWebDriver driver) : base(driver)
        {
            _loginPage = new LoginPage(Driver, true);
        }
        
        public void Login()
        {
            _loginPage.Email.SendKeys(Configurator.Username);
            _loginPage.Password.SendKeys(Configurator.Password);
            _loginPage.Login.Click();
        }
    }
}