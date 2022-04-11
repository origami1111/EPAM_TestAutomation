using OpenQA.Selenium;

namespace Pages.Controls
{
    public class TextArea : BaseControl
    {
        public TextArea(IWebElement webElement, IWebDriver webDriver) : base(webElement, webDriver)
        {
        }

        public string GetAttributeText(string attributeName)
        {
            return WebElement.GetAttribute(attributeName);
        }
    }
}
