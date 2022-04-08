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

        public Link LanguageLink => FindControl<Link>(By.XPath("//div[contains(@class, 'languages')]/a"));
        public Link CurrentCityLink => FindControl<Link>(By.XPath("//span[contains(@class, 'currentCity')]"));
        public Search InputSearch => FindControl<Search>(By.XPath("//input[@type='text']"));
        public Button AccountButton => FindControl<Button>(By.XPath("//button[contains(@class, 'account')]"));
        public Button SubmitButton => FindControl<Button>(By.XPath("//button[@type='submit']"));
        public Button SignInByEmailButton => FindControl<Button>(By.XPath("//button/span[text()='Войти по email']"));
        public TextField EmailTextField => FindControl<TextField>(By.XPath("//input[@name='email']"));

        public HomePage(IWebDriver driver) : base(driver) { }

        public void VerifySubmitButtonIsNotClickable()
        {
            Assert.Throws<ElementClickInterceptedException>(SubmitButton.Click, "Verify that submit button is not clickable");
        }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }

        public void VerifySelectedCityDisplayed(string expected)
        {
            string actual = CurrentCityLink.GetText();
            Assert.AreEqual(expected, actual, "Verify that selected city is displayed");
        }

        public void VerifySelectedUaLanguageDisplayed(string expected)
        {
            string actual = driver.Url;
            Assert.AreEqual(expected, actual, "Verify that selected language is displayed");
        }

        public HomePage EnterTextToEmailInput(string email)
        {
            EmailTextField.EnterText(email);
            return this;
        }

        public HomePage ClickSignInByEmailButton()
        {
            SignInByEmailButton.Click();
            return this;
        }

        public HomePage ClickAccountButton()
        {
            AccountButton.Click();
            return this;
        }

        public HomePage SelectFirtsItemFromSearchDropList()
        {
            driver.FindElements(searchDropList).First().Click();
            return this;
        }

        public HomePage EnterTextToSearchInput(string keyword)
        {
            InputSearch.EnterText(keyword);
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
            LanguageLink.Click();
        }

        public void ClickCurrentCityLink()
        {
            CurrentCityLink.Click();
        }

    }
}
