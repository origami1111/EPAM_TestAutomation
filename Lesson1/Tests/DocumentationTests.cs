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
        public void CheckThatSamplesForEachSupportedLanguageIsPresentOnAPage()
        {
            homePage.ClickDocumentationLink();

            foreach (var language in LanguageCases())
            {
                Assert.IsTrue(documentationPage.IsLanguageTabDisplayed(language));
            }
        }

        [Test]
        public void CheckSupportedLanguagesAndAreaWithCode()
        {
            homePage.ClickDocumentationLink();

            foreach (var supportedLanguage in LanguageAndCodeAreaCases())
            {
                documentationPage.ClickLanguageTab(supportedLanguage.LanguageTab);

                Assert.AreEqual(supportedLanguage.LanguageArea, documentationPage.GetCodeAreaActiveAttributeText());
            }
        }

        private static IEnumerable<string> LanguageCases()
        {
            yield return "Kotlin";
            yield return "JavaScript";
            yield return "Ruby";
            yield return "CSharp";
            yield return "Python";
            yield return "Java";
        }

        private static IEnumerable<SupportedLanguage> LanguageAndCodeAreaCases()
        {
            yield return new SupportedLanguage { LanguageTab = "Kotlin", LanguageArea = "kt" };
            yield return new SupportedLanguage { LanguageTab = "JavaScript", LanguageArea = "js" };
            yield return new SupportedLanguage { LanguageTab = "Ruby", LanguageArea = "rb" };
            yield return new SupportedLanguage { LanguageTab = "CSharp", LanguageArea = "cs" };
            yield return new SupportedLanguage { LanguageTab = "Python", LanguageArea = "py" };
            yield return new SupportedLanguage { LanguageTab = "Java", LanguageArea = "java" };
        }

    }

}
