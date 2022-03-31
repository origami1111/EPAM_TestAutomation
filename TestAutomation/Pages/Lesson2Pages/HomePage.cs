using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Controls;
using System.Linq;

namespace Pages.Pages.Lesson2Pages
{
    public class HomePage : BasePage
    {
        private By citiesList = By.XPath("//ul[contains(@class, 'list')]//p");
        private By popup = By.XPath("//div[contains(@class,'popup')]");
        private By searchDropList = By.XPath("//a[contains(@class,'search-drop-keywords')]");

        public Link languageLink => FindControl<Link>(By.XPath("//div[contains(@class, 'languages')]/a"));
        public Link currentCityLink => FindControl<Link>(By.XPath("//span[contains(@class, 'currentCity')]"));
        public Search inputSearch => FindControl<Search>(By.XPath("//input[@type='text']"));
        public Button accountButton => FindControl<Button>(By.XPath("//button[contains(@class, 'account')]"));
        public Button submitButton => FindControl<Button>(By.XPath("//button[@type='submit']"));
        public Button signInByEmailButton => FindControl<Button>(By.XPath("//button/span[text()='Войти по email']"));
        public TextField emailTextField => FindControl<TextField>(By.XPath("//input[@name='email']"));

        public HomePage(IWebDriver driver) : base(driver) { }

        public void VerifySubmitButtonDisabled(bool expected = true)
        {
            bool actual = submitButton.IsEnabled();

            Assert.AreEqual(expected, actual, "Verify that submit button disabled");
        }

        public void VerifySelectedCityDisplayed(string expected)
        {
            string actual = currentCityLink.GetText();

            Assert.AreEqual(expected, actual, "Verify that selected city is displayed");
        }

        public void VerifySelectedUaLanguageDisplayed(string expected)
        {
            string actual = driver.Url;

            Assert.AreEqual(expected, actual, "Verify that selected language is displayed");
        }

        public HomePage EnterTextToEmailInput(string email)
        {
            emailTextField.EnterText(email);
            return this;
        }

        public HomePage ClickSignInByEmailButton()
        {
            signInByEmailButton.Click();
            return this;
        }

        public HomePage ClickAccountButton()
        {
            accountButton.Click();
            return this;
        }

        public HomePage SelectFirtsItemFromSearchDropList()
        {
            driver.FindElements(searchDropList).First().Click();
            return this;
        }

        public HomePage EnterTextToSearchInput(string keyword)
        {
            inputSearch.EnterText(keyword);
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
            languageLink.Click();
        }

        public void ClickCurrentCityLink()
        {
            currentCityLink.Click();
        }

    }
}
