using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Controls;
using System.Linq;

namespace Pages.Pages.Lesson9Pages
{
    public class HomePage : BasePage
    {
        public Link signUpLink => FindControl<Link>(By.Id("signin2"));
        public Link loginLink => FindControl<Link>(By.Id("login2"));

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

        public void VerifyUserLoggedIn(string expected)
        {
            string actual = GetUserNameText();

            Assert.IsTrue(actual.Contains(expected), "Verify that user logged in successfully");
        }

        public void ClickLoginLink()
        {
            loginLink.Click();
        }

        public void ClickSignUpLink()
        {
            signUpLink.Click();
        }

        private string GetUserNameText()
        {
            return driver.FindElement(userName).Text;
        }

    }
}
