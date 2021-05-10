using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObject.BaseEntities
{
    public abstract class BasePage
    {
        protected const int WaitForPageLoadingTime = 60;
        [ThreadStatic] protected static IWebDriver Driver;

        protected abstract void OpenPage();
        public abstract bool IsPageOpened();

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;

            if (openPageByUrl)
            {
                OpenPage();
            }

            WaitForOpen();
        }

        protected void WaitForOpen()
        {
            var secondsCount = 0;
            var isPageOpenedIndicator = IsPageOpened();

            while (isPageOpenedIndicator && secondsCount < WaitForPageLoadingTime)
            {
                Thread.Sleep(10);
                secondsCount++;
                isPageOpenedIndicator = IsPageOpened();
            }

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page was not opened.");
            }
        }
    }
}