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
            driver.Navigate().GoToUrl(Constants.SeleniumUrl);
            homePage = new HomePage(driver);
            documentationPage = new DocumentationPage(driver);
        }

        [Test]
        public void CheckSamplesForEachSupportedLanguageAndCodeAreaDisplayedOnPage()
        {
            #region TestCases

            List<string> languageCases = new List<string>
            {
                "Kotlin",
                "JavaScript",
                "Ruby",
                "CSharp",
                "Python",
                "Java"
            };

            Dictionary<string, string> languageAndCodeAreaCases = new Dictionary<string, string>()
            {
                { "kt", "Kotlin" },
                { "js", "JavaScript" },
                { "rb", "Ruby" },
                { "cs", "CSharp" },
                { "py", "Python" },
                { "java", "Java" },
            };

            #endregion

            homePage.DocumentationLink.Click();
            documentationPage.VerifyDocumentationPageOpened();
            documentationPage.VerifyAllLanguageTabDisplayed(languageCases);
            documentationPage.VerifyAllLanguageTabAndCodeAreaDisplayed(languageAndCodeAreaCases);
        }

    }

}
