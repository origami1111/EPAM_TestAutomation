using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pages.Entities;

namespace Lesson8
{
    [TestClass]
    public class MSTests : BaseTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            InitDriver();
        }

        [TestMethod]
        public void CheckThatLogoIsPresent()
        {
            Assert.IsTrue(homePage.IsLogoDisplayed());
        }

        [TestMethod]
        public void CheckThatTableOfContentsSectionContent()
        {
            Assert.IsTrue(homePage.IsTableOfContentsContainsContent(Constants.ExpectedDocumentation));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            QuitDriver();
        }
    }
}
