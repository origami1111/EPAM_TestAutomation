using OpenQA.Selenium;

namespace Pages.Controls
{
    public class Label : BaseControl
    {
        public Label(IWebElement webElement, IWebDriver webDriver) : base(webElement, webDriver)
        {
        }

        public IWebElement GetElement()
        {
            return WebElement;
        }

        public string GetText()
        {
            return WebElement.Text;
        }
    }
}
