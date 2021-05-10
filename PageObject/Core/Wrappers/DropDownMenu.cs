using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Core.Wrappers
{
    public class DropDownMenu
    {
        private readonly UiElement _uiElement;
        private readonly By _by;
        private WaitService _waits;
       // private Button _dropDown;
        private List<DropDownOption> _options = new List<DropDownOption>();

        public DropDownMenu(IWebDriver driver, By @by)
        {
            _waits = new WaitService(driver);
            _by = by;
            _uiElement = new UiElement(driver, by);
           // _dropDown = new Button(driver, By.("//span[contains(@class, 'caret')]//parent::a"));
            foreach (var option in _uiElement.FindElements(By.TagName("li")))
            {
                _options.Add(new DropDownOption(driver, option));
            }
        }

        public void SelectByText(string text)
        {
            try
            {
                foreach (var option in _options.Where(option => option.Text.Contains(text)))
                {
                    option.Click();
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new NotFoundException("No such element");
            }
        }

        /*public void SelectByValue(string value)
        {
            _selectElement.SelectByValue(value);
        }*/

        public void SelectById(int id)
        {
            foreach (var option in _options.Where(option => option.Id.Equals(id)))
            {
                option.Click();
            }
        }

        public bool Displayed => _uiElement.Displayed;

        // public void Display()
        // {
        //     _dropDown.Click();
        // }
        
        public string Text => _uiElement.Text;

    }
}