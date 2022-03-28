using NUnit.Framework;
using OpenQA.Selenium;

namespace Lesson9
{

    /// <summary>
    /// login: test28
    /// password: qwerty
    /// </summary>

    public class SignUpPage : BasePage
    {
        private By usernameField = By.Id("sign-username");
        private By passwordField = By.Id("sign-password");
        private By signUpButton = By.XPath("//button[contains(text(), 'Sign up')]");

        public SignUpPage(WebDriver driver) : base(driver)
        {
        }

        public void EnterTextToUsernameField(string username)
        {
            driver.FindElement(usernameField).SendKeys(username);
        }

        public void EnterTextToPasswordField(string password)
        {
            driver.FindElement(passwordField).SendKeys(password);
        }

        public void ClickSignUpButton()
        {
            driver.FindElement(signUpButton).Click();
        }

        public void VerifyThatSignUpIsSuccessful(string expected)
        {
            string actual = driver.SwitchTo().Alert().Text;

            Assert.AreEqual(expected, actual, "Verify that sign up is successful");
        }
    }
}
