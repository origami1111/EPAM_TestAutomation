using NUnit.Framework;
using System.Collections.Generic;

/// <summary>
/// Hometask:
/// - Open https://www.selenium.dev ;​
/// - Navigate to the documentation page;​
/// - Check that samples for each supported language is present on a page 
///   (Java, Python, C#, Ruby, JavaScript, Kotlin)​
/// - Check supported languages and area with code a little bit down the page;​
/// - Please, use Page Object pattern in your project.​
/// 
/// </summary>

namespace Lesson1
{
    [TestFixture]
    public class DocumentationTests : BaseTest
    {
        private HomePage homePage;
        private DocumentationPage documentationPage;

        [SetUp]
        public void SetupPage()
        {
            homePage = new HomePage(driver);
            documentationPage = new DocumentationPage(driver);
        }

        [Test]
        public void CheckThatSamplesForEachSupportedLanguageAndCodeAreaIsPresentOnAPage()
        {
            homePage.GoToDocumentationPage();

            documentationPage.VerifyDocumentationPageIsOpened();

            documentationPage.VerifyAllLanguageTabDisplayed(LanguageCases());

            documentationPage.VerifyAllLanguageTabAndCodeAreaDisplayed(LanguageAndCodeAreaCases());
        }

        private static IEnumerable<string> LanguageCases()
        {
            yield return Constants.KotlinLanguageTab;
            yield return Constants.JavaScriptLanguageTab;
            yield return Constants.RubyLanguageTab;
            yield return Constants.CSharpLanguageTab;
            yield return Constants.PythonLanguageTab;
            yield return Constants.JavaLanguageTab;
        }

        private static IEnumerable<SupportedLanguage> LanguageAndCodeAreaCases()
        {
            yield return new SupportedLanguage
            {
                LanguageTab = Constants.KotlinLanguageTab,
                LanguageArea = Constants.KotlinLanguageArea
            };
            yield return new SupportedLanguage
            {
                LanguageTab = Constants.JavaScriptLanguageTab,
                LanguageArea = Constants.JavaScriptLanguageArea
            };
            yield return new SupportedLanguage
            {
                LanguageTab = Constants.RubyLanguageTab,
                LanguageArea = Constants.RubyLanguageArea
            };
            yield return new SupportedLanguage
            {
                LanguageTab = Constants.CSharpLanguageTab,
                LanguageArea = Constants.CSharpLanguageArea
            };
            yield return new SupportedLanguage
            {
                LanguageTab = Constants.PythonLanguageTab,
                LanguageArea = Constants.PythonLanguageArea
            };
            yield return new SupportedLanguage
            {
                LanguageTab = Constants.JavaLanguageTab,
                LanguageArea = Constants.JavaLanguageArea
            };
        }

    }

}
