using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

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

        public void VerifyThatSubmitButtonDisabled(bool expected = true)
        {
            bool actual = IsSubmitButtonDisabled();

            Assert.IsTrue(actual, "Verify that submit button disabled");
        }

        public void VerifyThatSelectedCityIsPresent(string expected)
        {
            string actual = GetCurrentCityText();

            Assert.AreEqual(expected, actual, "check that selected city is present");
        }

        public void VerifyThatSelectedUaLanguageIsPresent(string expected)
        {
            string actual = driver.Url;

            Assert.AreEqual(expected, actual, "Verify that selected language is present");
        }

        /////////////////////////////////////////////////////////////////////////////////////////

        public bool IsSubmitButtonDisabled()
        {
            return driver.FindElement(submitButton).Enabled;
        }

        public void EnterTextToEmailInput(string email)
        {
            driver.FindElement(emailInput).SendKeys(email);
        }

        public void ClickSignInByEmailButton()
        {
            driver.FindElement(signInByEmailButton).Click();
        }

        public void ClickAccountButton()
        {
            driver.FindElement(accountButton).Click();
        }

        public void SelectFirtsItemFromSearchDropList()
        {
            driver.FindElements(searchDropList).First().Click();
        }

        public void EnterTextToSearchInput(string keyword)
        {
            driver.FindElement(searchInput).SendKeys(keyword);
        }

        public string GetCurrentCityText()
        {
            return driver.FindElement(currentCityLink).Text;
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
            driver.FindElement(languageLink).Click();
        }

        public void ClickCurrentCityLink()
        {
            driver.FindElement(currentCityLink).Click();
        }

    }
}
