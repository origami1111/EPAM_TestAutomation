using OpenQA.Selenium;

namespace Pages.Controls
{
    public class Button : BaseControl
    {
        public Button(IWebElement webElement, IWebDriver webDriver) : base(webElement, webDriver)
        {
        }

        public bool IsEnabled()
        {
            return WebElement.Enabled;
        }

        public void Click()
        {
            WebElement.Click();
        }

        public void ClickJs()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            js.ExecuteScript("arguments[0].click();", WebElement);
        }
    }
}
