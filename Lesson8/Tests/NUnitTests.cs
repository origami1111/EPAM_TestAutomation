using NUnit.Framework;
using Pages.Entities;

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

        [Test]
        public void CheckThatTableOfContentsSectionContent()
        {
            Assert.IsTrue(homePage.IsTableOfContentsContainsContent(Constants.ExpectedDocumentation));
        }

        [TearDown]
        public void TearDown()
        {
            QuitDriver();
        }
    }
}