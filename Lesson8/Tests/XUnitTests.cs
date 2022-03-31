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
        public void CheckIsLogoDisplayed()
        {
            Assert.True(homePage.IsLogoDisplayed());
        }

        [Theory]
        [InlineData("Documentation")]
        public void CheckTableOfContentsSectionContent(string content)
        {
            Assert.True(homePage.IsTableOfContentsContainsContent(content));
        }

        public void Dispose()
        {
            QuitDriver();
        }
    }
}
