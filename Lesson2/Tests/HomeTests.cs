using NUnit.Framework;
using Test;

namespace Lesson2
{
    [TestFixture]
    public class HomeTests : BaseTest
    {
        private HomePage homePage;

        [SetUp]
        public new void SetUp()
        {
            driver.Navigate().GoToUrl("https://www.ctrs.com.ua/");
            homePage = new HomePage(driver);
        }

        // negative test case
        [Test]
        public void CheckSubmitButtonDisabledWithBlankEmailField()
        {
            homePage.ClickAccountButton()
                .ClickSignInByEmailButton()
                .EnterTextToEmailInput(string.Empty)
                .VerifySubmitButtonDisabled();
        }
    }
}
