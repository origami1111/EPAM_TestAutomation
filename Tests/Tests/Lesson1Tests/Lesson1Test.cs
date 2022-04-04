using NUnit.Framework;
using Pages.Entities;
using Pages.Pages.Lesson1Pages;
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

namespace Tests.Tests.Lesson1Tests
{
    [TestFixture]
    public class Lesson1Test : BaseTest
    {
        private HomePage homePage;
        private DocumentationPage documentationPage;

        [SetUp]
        public new void SetUp()
        {
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            homePage = new HomePage(driver);
            documentationPage = new DocumentationPage(driver);
        }

        [Test]
        public void CheckSamplesForEachSupportedLanguageAndCodeAreaDisplayedOnPage()
        {
            homePage.DocumentationLink.Click();

            documentationPage.VerifyDocumentationPageOpened();

            documentationPage.VerifyAllLanguageTabDisplayed(TestCase.languageCases);

            documentationPage.VerifyAllLanguageTabAndCodeAreaDisplayed(TestCase.languageAndCodeAreaCases);
        }

    }

    public class TestCase
    {
        public static List<string> languageCases = new List<string>
        {
            "Kotlin",
            "JavaScript",
            "Ruby",
            "CSharp",
            "Python",
            "Java"
        };

        public static List<SupportedLanguage> languageAndCodeAreaCases = new List<SupportedLanguage>
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
