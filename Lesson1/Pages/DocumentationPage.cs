using OpenQA.Selenium;
using System.Linq;

namespace Lesson1
{
    public class DocumentationPage : BasePage
    {
        private By languageTabList = By.XPath("//li[@class='nav-item']/a");
        private By codeAreaActive = By.XPath("//div[@class='tab-pane fade active show']/div/div/pre/code");

        public DocumentationPage(WebDriver driver) : base(driver) { }

        public string GetCodeAreaActiveAttributeText()
        {
            return driver.FindElement(codeAreaActive).GetAttribute("data-lang");
        }

        public bool IsLanguageTabDisplayed(string language)
        {
            return GetLanguageTabElement(language).Displayed;
        }

        public void ClickLanguageTab(string language)
        {
            GetLanguageTabElement(language).Click();
        }

        private WebElement GetLanguageTabElement(string language)
        {
            return (WebElement)driver.FindElements(languageTabList)
                .Where(languageTab => languageTab.Text == language)
                .First();

        }

    }
}
