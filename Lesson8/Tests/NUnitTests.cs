using NUnit.Framework;

namespace Lesson8
{
    [TestFixture]
    public class NUnitTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            InitDriver();
        }

        [Test]
        public void CheckThatLogoIsPresent()
        {
            Assert.IsTrue(homePage.IsLogoDisplayed());
        }

        [TestCase("Documentation")]
        public void CheckThatTableOfContentsSectionContent(string content)
        {
            Assert.IsTrue(homePage.IsTableOfContentsContainsContent(content));
        }

        [TearDown]
        public void TearDown()
        {
            QuitDriver();
        }
    }
}