using NUnit.Framework;
using System;

namespace Lesson2
{
    [TestFixture]
    public class HomeTests : BaseTest
    {
        private HomePage homePage;

        [SetUp]
        public void SetupPage()
        {
            homePage = new HomePage(driver);
        }

        // 2. Switch header theme to light/ city/ language and verify that it has been worked;​
        [TestCase("https://www.ctrs.com.ua/uk/")]
        public void CheckThatSelectedUaLanguageIsPresent(string expectedResult)
        {
            homePage.ChangeLanguageToUa();

            homePage.WaitUrlToBe(TimeSpan.FromSeconds(10), expectedResult);

            Assert.IsTrue(driver.Url.Equals(expectedResult));
        }

        [TestCase("Днепр")]
        [TestCase("Харьков")]
        public void CheckThatSelectedCityIsPresent(string city)
        {
            homePage.ClickCurrentCityLink();

            homePage.WaitVisibilityOfElement(TimeSpan.FromSeconds(10), homePage.GetPopupLocator());
            homePage.ChangeCityTo(city);

            Assert.AreEqual(city, homePage.GetCurrentCityText());
        }

        // negative test case
        [TestCase("")]
        public void CheckThatSubmitButtonDisabledWithBlankEmailField(string email)
        {
            homePage.ClickAccountButton();
            homePage.ClickSignInByEmailButton();
            homePage.EnterTextToEmailInput(email);

            Assert.IsTrue(homePage.IsSubmitButtonDisabled());
        }
    }
}
