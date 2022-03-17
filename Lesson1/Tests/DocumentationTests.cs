using NUnit.Framework;

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

            Assert.Multiple(() =>
            {
                Assert.IsTrue(documentationPage.IsLanguageDisplayed(documentationPage.GetJavaLanguageElement()));
                Assert.IsTrue(documentationPage.IsLanguageDisplayed(documentationPage.GetCSharpLanguageElement()));
                Assert.IsTrue(documentationPage.IsLanguageDisplayed(documentationPage.GetJavaScriptLanguageElement()));
                Assert.IsTrue(documentationPage.IsLanguageDisplayed(documentationPage.GetKotlinLanguageElement()));
                Assert.IsTrue(documentationPage.IsLanguageDisplayed(documentationPage.GetPythonLanguageElement()));
                Assert.IsTrue(documentationPage.IsLanguageDisplayed(documentationPage.GetRubyLanguageElement()));
            });
        }

        [Test]
        public void CheckSupportedLanguagesAndAreaWithCode()
        {
            homePage.ClickDocumentationLink();

            foreach (var supportedLanguage in documentationPage.GetListSupportedLanguages())
            {
                Assert.AreEqual(supportedLanguage.LanguageArea, supportedLanguage.LanguageTab);
            }
        }
    }
}
