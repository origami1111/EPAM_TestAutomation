using OpenQA.Selenium;

namespace Lesson9
{
    public class LoginPage : BasePage
    {
        private By usernameField = By.Id("loginusername");
        private By passwordField = By.Id("loginpassword");
        private By loginButton = By.XPath("//button[contains(text(), 'Log in')]");

        public LoginPage(WebDriver driver) : base(driver)
        {
        }

        public void ClickLoginButton()
        {
            driver.FindElement(loginButton).Click();
        }

        public void EnterTextToUsernameField(string username)
        {
            driver.FindElement(usernameField).SendKeys(username);
        }

        public void EnterTextToPasswordField(string password)
        {
            driver.FindElement(passwordField).SendKeys(password);
        }

    }
}
