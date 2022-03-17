using OpenQA.Selenium;
using System.Collections.Generic;

namespace Lesson1
{
    public class DocumentationPage : BasePage
    {
        private By javaLanguage = By.XPath("//a[text()='Java']");
        private By pythonLanguage = By.XPath("//a[text()='Python']");
        private By cSharpLanguage = By.XPath("//a[text()='CSharp']");
        private By rubyLanguage = By.XPath("//a[text()='Ruby']");
        private By javaScriptLanguage = By.XPath("//a[text()='JavaScript']");
        private By kotlinLanguage = By.XPath("//a[text()='Kotlin']");

        private By languageAreas = By.XPath("//code[contains(@class, 'language')]");
        private By languageTabs = By.XPath("//li[@class='nav-item']");

        public DocumentationPage(WebDriver driver) : base(driver) { }

        public List<SupportedLanguage> GetListSupportedLanguages()
        {
            var languageTabElements = driver.FindElements(languageTabs);
            var languageAreaElements = driver.FindElements(languageAreas);
            var supportedLanguages = new List<SupportedLanguage>();

            for (int i = 0; i < languageTabElements.Count; i++)
            {
                languageTabElements[i].Click();

                supportedLanguages.Add(new SupportedLanguage
                {
                    LanguageTab = languageTabElements[i].Text,
                    LanguageArea = languageAreaElements[i].GetAttribute("data-lang")
                });
            }

            return supportedLanguages;
        }

        public By GetJavaLanguageElement()
        {
            return javaLanguage;
        }

        public By GetPythonLanguageElement()
        {
            return pythonLanguage;
        }

        public By GetCSharpLanguageElement()
        {
            return cSharpLanguage;
        }

        public By GetRubyLanguageElement()
        {
            return rubyLanguage;
        }

        public By GetJavaScriptLanguageElement()
        {
            return javaScriptLanguage;
        }

        public By GetKotlinLanguageElement()
        {
            return kotlinLanguage;
        }

        public bool IsLanguageDisplayed(By language)
        {
            return driver.FindElement(language).Displayed;
        }
    }
}
