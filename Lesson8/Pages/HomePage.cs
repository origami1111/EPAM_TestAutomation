using OpenQA.Selenium;
using System.Linq;

namespace Lesson8
{
    public class HomePage : BasePage
    {
        private By logo = By.XPath("//img[@title='xUnit.net']");
        private By tableOfContents = By.XPath("//div[@class='container']/ul/li/a");

        public HomePage(WebDriver driver) : base(driver) { }

        public bool IsLogoPresent()
        {
            return driver.FindElement(logo).Displayed;
        }

        public bool IsTableOfContentsContainsContent(string content)
        {
            var elements = driver.FindElements(tableOfContents);

            return elements.Any(e => e.Text == content);
        }

    }
}
