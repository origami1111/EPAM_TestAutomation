using Pages.Entities;
using System;
using Xunit;

namespace Lesson8
{
    public class XUnitTests : BaseTest, IDisposable
    {
        public XUnitTests()
        {
            InitDriver();
        }

        [Fact]
        public void CheckThatLogoIsPresent()
        {
            Assert.True(homePage.IsLogoDisplayed());
        }

        [Fact]
        public void CheckThatTableOfContentsSectionContent()
        {
            Assert.True(homePage.IsTableOfContentsContainsContent(Constants.ExpectedDocumentation));
        }

        public void Dispose()
        {
            QuitDriver();
        }
    }
}
