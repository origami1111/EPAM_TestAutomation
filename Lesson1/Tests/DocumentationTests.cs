using NUnit.Framework;

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
                Assert.IsTrue(documentationPage.IsDisplayedJavaLanguage());
                Assert.IsTrue(documentationPage.IsDisplayedCSharpLanguage());
                Assert.IsTrue(documentationPage.IsDisplayedJavaScriptLanguage());
                Assert.IsTrue(documentationPage.IsDisplayedKotlinLanguage());
                Assert.IsTrue(documentationPage.IsDisplayedPythonLanguage());
                Assert.IsTrue(documentationPage.IsDisplayedRubyLanguage());
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
