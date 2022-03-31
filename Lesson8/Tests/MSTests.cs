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
        public void CheckIsLogoDisplayed()
        {
            Assert.IsTrue(homePage.IsLogoDisplayed());
        }

        [TestMethod]
        [DataRow("Documentation")]
        public void CheckTableOfContentsSectionContent(string content)
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
