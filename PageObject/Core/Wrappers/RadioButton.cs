using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace PageObject.Core.Wrappers
{
    public class RadioButton
    {
        private readonly UiElement _uiElement;
        private readonly List<RadioOption> _radioOptionsList = new List<RadioOption>();

        public RadioButton(IWebDriver driver, By by)
        {
            _uiElement = new UiElement(driver, by);
            foreach (var option in _uiElement.FindElements(By.XPath("//div[@class='radio']//input[@type='radio']")))
            {
                var radioOption = new RadioOption(driver, option);
                _radioOptionsList.Add(radioOption);
            }
        }

        public void SelectById(string id)
        {
            foreach (var radioOption in _radioOptionsList.Where(radioOption => radioOption.Id.Equals(id)))
            {
                radioOption.Click();
            }
        }
        
        public void SelectByName(string name)
        {
            foreach (var radioOption in _radioOptionsList.Where(radioOption => radioOption.Name.Equals(name)))
            {
                radioOption.Click();
            }
        }

        public void SelectByValue(string value)
        {
            foreach (var radioOption in _radioOptionsList.Where(radioOption => radioOption.Value.Equals(value)))
            {
                radioOption.Click();
            }
        }
    }
}