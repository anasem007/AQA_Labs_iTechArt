using OpenQA.Selenium;

namespace PageObject.Core.Wrappers
{
    public class TableRow
    {
        private UiElement _uiElement;
        
        public TableRow(IWebDriver driver, By @by)
        {
            _uiElement = new UiElement(driver, @by);
        }
        
        public TableRow(IWebDriver driver, IWebElement webElement)
        {
            _uiElement = new UiElement(driver, webElement);
        }
    }
}