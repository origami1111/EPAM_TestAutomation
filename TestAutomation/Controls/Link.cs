using OpenQA.Selenium;

namespace Pages.Controls
{
    public class Link : BaseControl
    {
        public Link(IWebElement webElement, IWebDriver webDriver) : base(webElement, webDriver)
        {
        }

        public string GetText()
        {
            return WebElement.Text;
        }

        public bool IsDisplayed()
        {
            return WebElement.Displayed;
        }

        public void Click()
        {
            WebElement.Click();
        }
    }
}
