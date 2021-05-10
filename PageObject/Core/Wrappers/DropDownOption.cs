using OpenQA.Selenium;

namespace PageObject.Core.Wrappers
{
    public class DropDownOption
    {
        private UiElement _uiElement;
        
        public DropDownOption(IWebDriver driver, By @by)
        {
            _uiElement = new UiElement(driver, @by);
        }
        
        public DropDownOption(IWebDriver driver, IWebElement webElement)
        {
            _uiElement = new UiElement(driver, webElement);
        }
        
        public void Click() => _uiElement.Click();
        
        public string Text => _uiElement.Text;
        public string Name => _uiElement.GetAttribute("name"); 
        public string Id => _uiElement.GetAttribute("id"); 
        public string Value => _uiElement.GetAttribute("value");
    }
}