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
        public void CheckThatSamplesForEachSupportedLanguageAndCodeAreaIsPresentOnPage()
        {
            homePage.GoToDocumentationPage();

            documentationPage.VerifyDocumentationPageIsOpened();

            documentationPage.VerifyAllLanguageTabDisplayed(languageCases);

            documentationPage.VerifyAllLanguageTabAndCodeAreaDisplayed(languageAndCodeAreaCases);
        }

        private List<string> languageCases = new List<string>
        {
            "Kotlin",
            "JavaScript",
            "Ruby",
            "CSharp",
            "Python",
            "Java"
        };

        private List<SupportedLanguage> languageAndCodeAreaCases = new List<SupportedLanguage>
        {
            new SupportedLanguage
            {
                LanguageTab = "Kotlin",
                LanguageArea = "kt"
            },
            new SupportedLanguage
            {
                LanguageTab = "JavaScript",
                LanguageArea = "js"
            },
            new SupportedLanguage
            {
                LanguageTab = "Ruby",
                LanguageArea = "rb"
            },
            new SupportedLanguage
            {
                LanguageTab = "CSharp",
                LanguageArea = "cs"
            },
            new SupportedLanguage
            {
                LanguageTab = "Python",
                LanguageArea = "py"
            },
            new SupportedLanguage
            {
                LanguageTab = "Java",
                LanguageArea = "java"
            },
        };

    }

}
