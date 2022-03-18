using OpenQA.Selenium;
using System.Linq;

namespace Lesson1
{
    public class DocumentationPage : BasePage
    {
        private By languageTabList = By.XPath("//li[@class='nav-item']/a");
        private By codeAreaList = By.XPath("//code[contains(@class, 'language')]");

        public DocumentationPage(WebDriver driver) : base(driver) { }

        public bool IsLanguageTabDisplayed(string language)
        {
            return GetLanguageTabElement(language).Displayed;
        }

        public void ClickLanguageTab(string language)
        {
            GetLanguageTabElement(language).Click();
        }

        public string GetCodeAreaText()
        {
            return driver.FindElements(codeAreaList)
                .Where(codeArea => codeArea.Displayed)
                .Select(codeArea => codeArea.GetAttribute("data-lang"))
                .First();
        }

        private WebElement GetLanguageTabElement(string language)
        {
            return (WebElement)driver.FindElements(languageTabList)
                .Where(languageTab => languageTab.Text == language)
                .First();

        }

    }
}
