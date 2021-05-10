using OpenQA.Selenium;

namespace PageObject.Core.Wrappers
{
    public class CheckBox 
    {
        private readonly UiElement _uiElement;

        public CheckBox(IWebDriver driver, By @by)
        {
            _uiElement = new UiElement(driver, @by);
        }

        public void Click() => _uiElement.Click();

        public bool Selected => _uiElement.Selected;
        
    }
}