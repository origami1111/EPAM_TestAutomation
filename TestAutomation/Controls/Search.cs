using OpenQA.Selenium;

namespace Pages.Controls
{
    public class Search : BaseControl
    {
        public Search(IWebElement webElement, IWebDriver webDriver) : base(webElement, webDriver)
        {
        }

        public void EnterText(string text)
        {
            WebElement.SendKeys(text);
        }
    }
}
