using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Controls;

namespace Pages.Pages.Lesson9Pages
{
    public class PopupPage : BasePage
    {
        public TextField LoginUsernameField => FindControl<TextField>(By.Id("loginusername"));
        public TextField LoginPasswordField => FindControl<TextField>(By.Id("loginpassword"));
        public TextField SignupUsernameField => FindControl<TextField>(By.Id("sign-username"));
        public TextField SignupPasswordField => FindControl<TextField>(By.Id("sign-password"));
        public Button LoginButton => FindControl<Button>(By.XPath("//button[contains(text(), 'Log in')]"));
        public Button SignUpButton => FindControl<Button>(By.XPath("//button[contains(text(), 'Sign up')]"));

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
            SignUpButton.Click();
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

    }
}
