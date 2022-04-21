using Lesson3.Pages;
using Pages.Pages.Lesson9Pages;
using TechTalk.SpecFlow;

namespace Lesson9
{
    [Binding]
    public class SmokeSteps
    {
        private BrowserDriver browserDriver;
        private HomePage homePage;
        private ProductPage productPage;
        private PopupPage popupPage;

        public SmokeSteps(BrowserDriver browserDriver)
        {
            this.browserDriver = browserDriver;
            homePage = new HomePage(this.browserDriver.driver);
            productPage = new ProductPage(this.browserDriver.driver);
            popupPage = new PopupPage(this.browserDriver.driver);
        }

        [Given(@"user clicks sign up link")]
        public void GivenUserClicksSignUpLink()
        {
            homePage.ClickSignUpLink();
        }

        [Given(@"user enter (.*) on username field for sign up")]
        public void GivenUserEnterUsernameOnUsernameFieldForSignUp(string username)
        {
            popupPage.SignupUsernameField.EnterText(username);
        }

        [Given(@"user enter (.*) on password field for sign up")]
        public void GivenUserEnterPasswordOnPasswordFieldForSignUp(string password)
        {
            popupPage.SignupPasswordField.EnterText(password);
        }

        [When(@"user clicks on sign up button")]
        public void WhenUserClicksOnSignUpButton()
        {
            popupPage.ClickSignUpButton();
        }

        [Then(@"user checks that sign up is successful")]
        public void ThenUserChecksThatSignUpIsSuccessful()
        {
            const string ExpectedAlertMessage = "Sign up successful.";

            Wait.WaitAlertIsPresent(browserDriver.driver);
            popupPage.VerifySignUpIsSuccessful(ExpectedAlertMessage);
        }

        [Given(@"user clicks login link")]
        public void GivenUserClicksLoginLink()
        {
            homePage.ClickLoginLink();
        }

        [Given(@"user enter (.*) on username field for login")]
        public void GivenUserEnterUsernameOnUsernameFieldForLogin(string username)
        {
            popupPage.LoginUsernameField.EnterText(username);
        }

        [Given(@"user enter (.*) on password field for login")]
        public void GivenUserEnterPasswordOnPasswordFieldForLogin(string password)
        {
            popupPage.LoginPasswordField.EnterText(password);
        }

        [When(@"user clicks on login button")]
        public void WhenUserCkicksOnLoginButton()
        {
            popupPage.ClickLoginButton();
        }

        [Then(@"user checks for successful log in")]
        public void ThenUserChecksForSuccessfulLogin()
        {
            const string ExpectedSuccessfulText = "Welcome";

            Wait.WaitVisibilityOfElement(browserDriver.driver, homePage.GetUserNameLocator());
            homePage.VerifyUserLoggedIn(ExpectedSuccessfulText);
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
            const string ExpectedProductAddedText = "Product added";

            Wait.WaitAlertIsPresent(browserDriver.driver);
            productPage.VerifyProductAdded(ExpectedProductAddedText);
        }
    }
}
