using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Controls;
using System.Collections.Generic;
using System.Linq;

namespace Pages.Pages.Lesson1Pages
{
    public class DocumentationPage : BasePage
    {
        private By languageTabList = By.XPath("//li[contains(@class,'nav-item')]/a");
        public Link DocumentationPageLink => FindControl<Link>(By.XPath("//a[text()='Documentation']"));
        public TextArea CodeAreaActive => FindControl<TextArea>(By.XPath("//div[@class='tab-pane fade active show']//code"));

        public DocumentationPage(IWebDriver driver) : base(driver)
        {
        }

        public void VerifyDocumentationPageOpened(bool expected = true)
        {
            bool actual = DocumentationPageLink.IsDisplayed();
            Assert.AreEqual(expected, actual, "Verify that documentation page is opened");
        }

        public void VerifyAllLanguageTabAndCodeAreaDisplayed(Dictionary<string, string> supportedLanguages, bool expected = true)
        {
            bool actual = false;

            foreach (var supportedLanguage in supportedLanguages)
            {
                ClickLanguageTab(supportedLanguage.Value);

                actual = supportedLanguage.Key.Equals(CodeAreaActive.GetAttributeText("data-lang"));
            }

            Assert.AreEqual(expected, actual, "Verify that all language tab and code area are displayed");
        }

        public void VerifyAllLanguageTabDisplayed(List<string> languages, bool expected = true)
        {
            bool actual = languages.All(language => GetLanguageTabElement(language).Displayed);
            Assert.AreEqual(expected, actual, "Verify that all language tab are displayed");
        }

        public void ClickLanguageTab(string language)
        {
            GetLanguageTabElement(language).Click();
        }

        private WebElement GetLanguageTabElement(string language)
        {
            return (WebElement)driver.FindElements(languageTabList)
                .First(languageTab => languageTab.Text == language);
        }
    }
}