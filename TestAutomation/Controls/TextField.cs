using OpenQA.Selenium;

namespace Pages.Controls
{
    public class TextField : BaseControl
    {
        public TextField(IWebElement webElement, IWebDriver webDriver) : base(webElement, webDriver)
        {
        }

        public void EnterText(string text)
        {
            WebElement.SendKeys(text);
        }
    }
}
