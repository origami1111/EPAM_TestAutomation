using System.Linq;
using OpenQA.Selenium;

namespace Lesson1
{
    public class DocumentationPage : BasePage
    {
        //TODO Use "Contains" method in xpath
        //Move to Main page
        private By languageTabList = By.XPath("//li[@class='nav-item']/a");

        //TODO Use shorter xpath
        private By codeAreaActive = By.XPath("//div[@class='tab-pane fade active show']/div/div/pre/code");

        public DocumentationPage(WebDriver driver) : base(driver)
        {
        }

        public string GetCodeAreaActiveAttributeText()
        {
            return driver.FindElement(codeAreaActive).GetAttribute("data-lang");
        }

        //TODO Verify name convention. It's better to rename (e.g VerifyLanguageTabDisplayed)
        public bool IsLanguageTabDisplayed(string language)
        {
            return GetLanguageTabElement(language).Displayed;
        }

        public void ClickLanguageTab(string language)
        {
            GetLanguageTabElement(language).Click();
        }

//TODO Replace with single call to First(..)
        private WebElement GetLanguageTabElement(string language)
        {
            return (WebElement) driver.FindElements(languageTabList)
                .Where(languageTab => languageTab.Text == language)
                .First();
        }
    }
}