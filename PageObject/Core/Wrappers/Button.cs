using OpenQA.Selenium;

namespace PageObject.Core.Wrappers
{
    public class Button
    {
        private readonly UiElement _uiElement;
        
        public Button(IWebDriver driver, By @by)
        {
            _uiElement = new UiElement(driver, @by);
        }

        public void Click() => _uiElement.Click();
        public bool Enabled => _uiElement.Enabled;
        public bool Displayed => _uiElement.Displayed;

    }
}