using OpenQA.Selenium;

namespace Pages.Controls
{
    public class Image : BaseControl
    {
        public Image(IWebElement webElement, IWebDriver webDriver) : base(webElement, webDriver)
        {
        }

        public bool IsDisplayed()
        {
            return WebElement.Displayed;
        }
    }
}
