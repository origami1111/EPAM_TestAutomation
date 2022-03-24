using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Lesson1
{
    public class DocumentationPage : BasePage
    {
        private By languageTabList = By.XPath("//li[contains(@class,'nav-item')]/a");

        private By documentationPage = By.XPath("//a[text()='Documentation']");

        private By codeAreaActive = By.XPath("//div[@class='tab-pane fade active show']//code");

        public DocumentationPage(WebDriver driver) : base(driver)
        {

        }

        public void VerifyDocumentationPageIsOpened(bool expected = true)
        {
            bool actual = driver.FindElement(documentationPage).Displayed;

            Assert.AreEqual(expected, actual, "Verify that documentation page is opened");
        }

        public void VerifyAllLanguageTabAndCodeAreaDisplayed(IEnumerable<SupportedLanguage> supportedLanguages, bool expected = true)
        {
            bool actual = false;

            foreach (var supportedLanguage in supportedLanguages)
            {
                ClickLanguageTab(supportedLanguage.LanguageTab);

                actual = supportedLanguage.LanguageArea.Equals(GetCodeAreaActiveAttributeText());
            }

            Assert.AreEqual(expected, actual, "Verify that all language tab and code aread are displayed");
        }

        public void VerifyAllLanguageTabDisplayed(IEnumerable<string> languages, bool expected = true)
        {
            bool actual = languages.All(language => GetLanguageTabElement(language).Displayed);

            Assert.AreEqual(expected, actual, "Verify that all language tab are displayed");
        }

        public void ClickLanguageTab(string language)
        {
            GetLanguageTabElement(language).Click();
        }

        private string GetCodeAreaActiveAttributeText()
        {
            return driver.FindElement(codeAreaActive).GetAttribute("data-lang");
        }

        private WebElement GetLanguageTabElement(string language)
        {
            return (WebElement)driver.FindElements(languageTabList)
                .First(languageTab => languageTab.Text == language);
        }
    }
}