using NUnit.Framework;

namespace Lesson2
{
    [TestFixture]
    public class HomeTests : BaseTest
    {
        private HomePage homePage;

        [SetUp]
        public void SetupPage()
        {
            homePage = new HomePage(driver);
        }

        // negative test case
        [TestCase("")]
        public void CheckThatSubmitButtonDisabledWithBlankEmailField(string email)
        {
            homePage.ClickAccountButton();
            homePage.ClickSignInByEmailButton();
            homePage.EnterTextToEmailInput(email);

            homePage.VerifyThatSubmitButtonDisabled();
        }
    }
}
