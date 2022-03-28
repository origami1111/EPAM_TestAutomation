using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace Lesson9
{
    public class HomePage : BasePage
    {
        private By signUpLink = By.Id("signin2");
        private By loginLink = By.Id("login2");

        private By signUpPopup = By.Id("signInModal");
        private By loginPopup = By.Id("logInModal");

        private By userName = By.Id("nameofuser");

        private By categories = By.Id("itemc");

        private By products = By.XPath("//h4[@class='card-title']");

        public HomePage(WebDriver driver) : base(driver)
        {
        }

        public void SelectFirstProduct()
        {
            driver.FindElements(products)
                .First().Click();
        }

        public void ClickCategory(string category)
        {
            driver.FindElements(categories)
                .First(cat => cat.Text == category).Click();
        }

        public By GetUserNameLocator()
        {
            return userName;
        }

        public void VerifyThatUserLoggedIn(string expected)
        {
            string actual = GetUserNameText();

            Assert.IsTrue(actual.Contains(expected), "Verify that user logged in successfully");
        }

        public By GetLoginPopupLocator()
        {
            return loginPopup;
        }

        public By GetSignUpPopupLocator()
        {
            return signUpPopup;
        }

        public void ClickLoginLink()
        {
            driver.FindElement(loginLink).Click();
        }

        public void ClickSignUpLink()
        {
            driver.FindElement(signUpLink).Click();
        }

        private string GetUserNameText()
        {
            return driver.FindElement(userName).Text;
        }

    }
}
