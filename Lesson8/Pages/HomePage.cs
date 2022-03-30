using OpenQA.Selenium;
using System.Linq;
using Test;

namespace Lesson8
{
    public class HomePage : BasePage
    {
        private By logo = By.XPath("//img[@title='xUnit.net']");
        private By tableOfContents = By.XPath("//div[@class='container']/ul/li/a");

        public HomePage(WebDriver driver) : base(driver) { }

        public bool IsLogoDisplayed()
        {
            return IsElementDisplayed(logo);
        }

        public bool IsTableOfContentsContainsContent(string content)
        {
            var elements = driver.FindElements(tableOfContents);

            return elements.Any(e => e.Text == content);
        }

    }
}
