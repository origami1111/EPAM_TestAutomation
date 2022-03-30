using NUnit.Framework;
using OpenQA.Selenium;

namespace Lesson9
{
    public class PopupPage : BasePage
    {
        private By loginUsernameField = By.Id("loginusername");
        private By loginPasswordField = By.Id("loginpassword");
        private By loginButton = By.XPath("//button[contains(text(), 'Log in')]");

        private By signupUsernameField = By.Id("sign-username");
        private By signupPasswordField = By.Id("sign-password");
        private By signUpButton = By.XPath("//button[contains(text(), 'Sign up')]");

        public PopupPage(WebDriver driver) : base(driver)
        {
        }

        public By GetSignupPasswordField()
        {
            return signupPasswordField;
        }

        public By GetSignupUsernameField()
        {
            return signupUsernameField;
        }

        public By GetLoginPasswordField()
        {
            return loginPasswordField;
        }

        public By GetLoginUsernameField()
        {
            return loginUsernameField;
        }

        public void VerifySignUpIsSuccessful(string expected)
        {
            string actual = driver.SwitchTo().Alert().Text;

            Assert.AreEqual(expected, actual, "Verify that sign up is successful");
        }

        public void ClickSignUpButton()
        {
            driver.FindElement(signUpButton).Click();
        }

        public void ClickLoginButton()
        {
            driver.FindElement(loginButton).Click();
        }

        public void EnterTextToUsernameField(By locator, string username)
        {
            driver.FindElement(locator).SendKeys(username);
        }

        public void EnterTextToPasswordField(By locator, string password)
        {
            driver.FindElement(locator).SendKeys(password);
        }
    }
}
