using OpenQA.Selenium;

namespace Lesson1
{
    public class HomePage : BasePage
    {
        private By documentationLink = By.XPath("//span[text() = 'Documentation']");

        public HomePage(WebDriver driver) : base(driver)
        {

        }

        public DocumentationPage ClickDocumentationLink()
        {
            driver.FindElement(documentationLink).Click();

            return new DocumentationPage(driver);
        }
    }
}
