using OpenQA.Selenium;
using Pages.Controls;
using System.Linq;

namespace Pages.Pages.Lesson8Pages
{
    public class HomePage : BasePage
    {
        private By tableOfContents = By.XPath("//div[@class='container']/ul/li/a");

        public Image Logo => FindControl<Image>(By.XPath("//img[@title='xUnit.net']"));

        public HomePage(WebDriver driver) : base(driver) { }

        public bool IsLogoDisplayed()
        {
            return Logo.IsDisplayed();
        }

        public bool IsTableOfContentsContainsContent(string content)
        {
            var elements = driver.FindElements(tableOfContents);

            return elements.Any(e => e.Text == content);
        }

    }
}
