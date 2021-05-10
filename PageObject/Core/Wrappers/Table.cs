using System.Collections.Generic;
using OpenQA.Selenium;

namespace PageObject.Core.Wrappers
{
    public class Table
    {
        private UiElement _uiElement;
        private List<TableRow> _rowList = new List<TableRow>();
        private int _columnsCount;
        
        public Table(IWebDriver driver, By @by)
        {
            _uiElement = new UiElement(driver, @by);
            
            foreach (var row in _uiElement.FindElements(By.TagName("tr")))
            {
                _rowList.Add(new TableRow(driver, row));
            }
        }

        public int RowCount()
        {
            return _rowList.Count;
        }

        public void Click(int column, int row)
        {
            
        }
    }
}