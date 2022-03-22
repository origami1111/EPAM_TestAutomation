using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsTrue(homePage.IsLogoPresent());
        }

        [TestMethod]
        [DataRow("Documentation")]
        public void CheckThatTableOfContentsSectionContent(string content)
        {
            Assert.IsTrue(homePage.IsTableOfContentsContainsContent(content));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            QuitDriver();
        }
    }
}
