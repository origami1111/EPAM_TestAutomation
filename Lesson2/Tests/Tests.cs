using NUnit.Framework;
using Test;

namespace Lesson2.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        private HomePage homePage;
        private SearchResultPage searchResultPage;
        private ProductPage productPage;

        [SetUp]
        public new void SetUp()
        {
            driver.Navigate().GoToUrl("https://www.ctrs.com.ua/");
            homePage = new HomePage(driver);
            searchResultPage = new SearchResultPage(driver);
            productPage = new ProductPage(driver);
        }

        [Test]
        public void AllTests()
        {
            // 2. Switch header language and verify that it has been worked;​
            homePage.ChangeLanguageToUa();
            homePage.WaitUrlToBe(Constants.ExpectedUrl);
            homePage.VerifySelectedUaLanguageDisplayed(Constants.ExpectedUrl);

            // 2. Switch header city and verify that it has been worked;​
            homePage.ClickCurrentCityLink();
            homePage.WaitVisibilityOfElement(homePage.GetPopupLocator());
            homePage.ChangeCityTo(Constants.ExpectedCity);
            homePage.VerifySelectedCityDisplayed(Constants.ExpectedCity);

            // 3. Enter 2 appropriated letters in the search bar, for example,
            //    “lg” and select the first item of the popup list;
            homePage.EnterTextToSearchInput(Constants.ExpectedKeyword)
                .SelectFirtsItemFromSearchDropList();

            // 4. Verify that items list for first page contains elements with appropriate title;
            searchResultPage.VerifySearchResultProductsContainsSearchKeyword(Constants.ExpectedKeyword);

            // 5. Filter items (price, manufacturer, discount);​
            searchResultPage.SetFilterPriceRangeToField(Constants.ExpectedPrice)
                .ClickSubmitButton();

            // 6. Click on first element and verify headers and description;​
            searchResultPage.SelectFirtsProductFromSearchResult();
            productPage.VerifyFilteredProductsContainsKeywords(Constants.ExpectedKeyword, Constants.ExpectedPrice);

            // 7. Choose the color of device and verify that it has been changed;
            var oldTitle = productPage.GetProductTitle();
            productPage.SelectProductColor(Constants.ExpectedColor);
            productPage.WaitInvisibilityOfELementWithText(productPage.GetProductTitleElement(), oldTitle);
            productPage.VerifySelectedColorDisplayed(Constants.ExpectedColor);

            // 8. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;
            productPage.WaitElementExists(productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton();
            productPage.VerifyPopupCartDisplayed();
            productPage.VerifyPopupCartContainsAppropriatedFields(Constants.ExpectedKeyword);

            // 9. Return to the items search and choose another product;​
            productPage.ClickClosePopupButton();
            NavigateBack();
            NavigateBack();
            searchResultPage.SelectRandomProductFromSearchResult();

            // 10. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;
            productPage.WaitElementExists(productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton();
            productPage.VerifyPopupCartDisplayed();
            productPage.VerifyPopupCartContainsAppropriatedFields(Constants.ExpectedKeyword);

            // 11. Close popup and verify that your bucket contains two products;
            productPage.ClickClosePopupButton();
            productPage.WaitTextToBePresentInElement(productPage.GetAmountOfProductsInCartLocator(), Constants.ExpectedAmountOfProducts.ToString());
            productPage.VerifyCartContainsTwoProducts(Constants.ExpectedAmountOfProducts);
        }

    }
}
