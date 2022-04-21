using OpenQA.Selenium;

namespace Pages.Controls
{
    public abstract class BaseControl
    {
        public IWebElement WebElement { get; set; }
        public IWebDriver WebDriver { get; set; }

        public BaseControl(IWebElement webElement, IWebDriver webDriver)
        {
            WebElement = webElement;
            WebDriver = webDriver;
        }

    }
}
