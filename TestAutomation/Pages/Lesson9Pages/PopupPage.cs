using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Controls;

namespace Pages.Pages.Lesson9Pages
{
    public class PopupPage : BasePage
    {
        public TextField loginUsernameField => FindControl<TextField>(By.Id("loginusername"));
        public TextField loginPasswordField => FindControl<TextField>(By.Id("loginpassword"));
        public TextField signupUsernameField => FindControl<TextField>(By.Id("sign-username"));
        public TextField signupPasswordField => FindControl<TextField>(By.Id("sign-password"));
        public Button loginButton => FindControl<Button>(By.XPath("//button[contains(text(), 'Log in')]"));
        public Button signUpButton => FindControl<Button>(By.XPath("//button[contains(text(), 'Sign up')]"));

        public PopupPage(WebDriver driver) : base(driver)
        {
        }

        public void VerifySignUpIsSuccessful(string expected)
        {
            string actual = driver.SwitchTo().Alert().Text;

            Assert.AreEqual(expected, actual, "Verify that sign up is successful");
        }

        public void ClickSignUpButton()
        {
            signUpButton.Click();
        }

        public void ClickLoginButton()
        {
            loginButton.Click();
        }

    }
}
