using OpenQA.Selenium;

namespace Pages.Controls
{
    public class Text : BaseControl
    {
        public Text(IWebElement webElement, IWebDriver webDriver) : base(webElement, webDriver)
        {
        }

        public string GetText()
        {
            return WebElement.Text;
        }
    }
}
