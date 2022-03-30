using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using Test;

namespace Lesson2
{
    public class HomePage : BasePage
    {
        private By languageLink = By.XPath("//div[contains(@class, 'languages')]/a");
        private By currentCityLink = By.XPath("//span[contains(@class, 'currentCity')]");
        private By popup = By.XPath("//div[contains(@class,'popup')]");
        private By citiesList = By.XPath("//ul[contains(@class, 'list')]//p");

        private By searchInput = By.XPath("//input[@type='text']");
        private By searchDropList = By.XPath("//a[contains(@class,'search-drop-keywords')]");

        private By accountButton = By.XPath("//button[contains(@class, 'account')]");
        private By signInByEmailButton = By.XPath("//button/span[text()='Войти по email']");
        private By emailInput = By.XPath("//input[@name='email']");
        private By submitButton = By.XPath("//button[@type='submit']");

        public HomePage(WebDriver driver) : base(driver) { }

        public void VerifySubmitButtonDisabled(bool expected = true)
        {
            bool actual = IsElementEnabled(submitButton);

            Assert.AreEqual(expected, actual, "Verify that submit button disabled");
        }

        public void VerifySelectedCityDisplayed(string expected)
        {
            string actual = GetElementText(currentCityLink);

            Assert.AreEqual(expected, actual, "Verify that selected city is displayed");
        }

        public void VerifySelectedUaLanguageDisplayed(string expected)
        {
            string actual = driver.Url;

            Assert.AreEqual(expected, actual, "Verify that selected language is displayed");
        }

        public HomePage EnterTextToEmailInput(string email)
        {
            driver.FindElement(emailInput).SendKeys(email);
            return this;
        }

        public HomePage ClickSignInByEmailButton()
        {
            ClickElement(signInByEmailButton);
            return this;
        }

        public HomePage ClickAccountButton()
        {
            ClickElement(accountButton);
            return this;
        }

        public HomePage SelectFirtsItemFromSearchDropList()
        {
            driver.FindElements(searchDropList).First().Click();
            return this;
        }

        public HomePage EnterTextToSearchInput(string keyword)
        {
            driver.FindElement(searchInput).SendKeys(keyword);
            return this;
        }

        public void ChangeCityTo(string cityName)
        {
            var cities = driver.FindElements(citiesList);

            cities.First(city => city.Text == cityName)
                .Click();
        }

        public By GetPopupLocator()
        {
            return popup;
        }

        public void ChangeLanguageToUa()
        {
            ClickElement(languageLink);
        }

        public void ClickCurrentCityLink()
        {
            ClickElement(currentCityLink);
        }

    }
}
