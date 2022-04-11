using OpenQA.Selenium;

namespace Pages.Controls
{
    public class Popup : BaseControl
    {
        public Popup(IWebElement webElement, IWebDriver webDriver) : base(webElement, webDriver)
        {
        }

        public bool IsDisplayed()
        {
            return WebElement.Displayed;
        }
    }
}
