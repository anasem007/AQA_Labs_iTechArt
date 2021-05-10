using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace PageObject.Services
{
    public class WaitService
    {
        [ThreadStatic] protected static IWebDriver _driver;

        private WebDriverWait _wait;
        
        public WaitService(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configurator.Timeout));
        }

        public IWebElement GetVisibleElement(By by)
        {
            try
            {
                return _wait.Until(ElementIsVisible(by));
            }
            catch (Exception e)
            {
                throw new AssertionException(e.Message, e);
            } 
        }
    }
}