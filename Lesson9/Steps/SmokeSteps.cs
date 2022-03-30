using System;
using TechTalk.SpecFlow;

namespace Lesson9
{
    [Binding]
    public class SmokeSteps
    {
        private HomePage homePage;
        private ProductPage productPage;
        private PopupPage popupPage;

        public SmokeSteps(BrowserDriver browserDriver)
        {
            homePage = new HomePage(browserDriver.driver);
            productPage = new ProductPage(browserDriver.driver);
            popupPage = new PopupPage(browserDriver.driver);
        }

        [Given(@"user clicks sign up link")]
        public void GivenUserClicksSignUpLink()
        {
            homePage.ClickSignUpLink();
        }

        [Given(@"user enter (.*) on username field for sign up")]
        public void GivenUserEnterUsernameOnUsernameFieldForSignUp(string username)
        {
            popupPage.EnterTextToUsernameField(popupPage.GetSignupUsernameField(), username);
        }

        [Given(@"user enter (.*) on password field for sign up")]
        public void GivenUserEnterPasswordOnPasswordFieldForSignUp(string password)
        {
            popupPage.EnterTextToPasswordField(popupPage.GetSignupPasswordField(), password);
        }

        [When(@"user clicks on sign up button")]
        public void WhenUserClicksOnSignUpButton()
        {
            popupPage.ClickSignUpButton();
        }

        [Then(@"user checks that sign up is successful")]
        public void ThenUserChecksThatSignUpIsSuccessful()
        {
            homePage.WaitAlertIsPresent(TimeSpan.FromSeconds(3));
            popupPage.VerifyThatSignUpIsSuccessful(Constants.ExpectedAlertMessage);
        }

        [Given(@"user clicks login link")]
        public void GivenUserClicksLoginLink()
        {
            homePage.ClickLoginLink();
        }

        [Given(@"user enter (.*) on username field for login")]
        public void GivenUserEnterUsernameOnUsernameFieldForLogin(string username)
        {
            popupPage.EnterTextToUsernameField(popupPage.GetLoginUsernameField(), username);
        }

        [Given(@"user enter (.*) on password field for login")]
        public void GivenUserEnterPasswordOnPasswordFieldForLogin(string password)
        {
            popupPage.EnterTextToPasswordField(popupPage.GetLoginPasswordField(), password);
        }

        [When(@"user clicks on login button")]
        public void WhenUserCkicksOnLoginButton()
        {
            popupPage.ClickLoginButton();
        }

        [Then(@"user checks for successful log in")]
        public void ThenUserChecksForSuccessfulLogin()
        {
            homePage.WaitVisibilityOfElement(TimeSpan.FromSeconds(5), homePage.GetUserNameLocator());
            homePage.VerifyThatUserLoggedIn(Constants.ExpectedSuccessfulText);
        }

        [Given(@"user clicks (.*) category")]
        public void GivenUserClicksOnCategory(string category)
        {
            homePage.ClickCategory(category);
        }

        [Given(@"user select first product from list")]
        public void GivenUserSelectFirstProductFromList()
        {
            homePage.SelectFirstProduct();
        }

        [When(@"user clicks on add to cart button")]
        public void WhenUserClicksOnAddToCartButton()
        {
            productPage.ClickAddToCartButton();
        }

        [Then(@"user checks possibility to purchase product")]
        public void ThenUserChecksPossibilityToPurchaseProduct()
        {
            homePage.WaitAlertIsPresent(TimeSpan.FromSeconds(3));
            productPage.VerifyThatProductAdded(Constants.ExpectedProductAddedText);
        }
    }
}
