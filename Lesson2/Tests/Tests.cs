using NUnit.Framework;
using System;

namespace Lesson2.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        private HomePage homePage;
        private SearchResultPage searchResultPage;
        private ProductPage productPage;

        [SetUp]
        public void SetupPage()
        {
            homePage = new HomePage(driver);
            searchResultPage = new SearchResultPage(driver);
            productPage = new ProductPage(driver);
        }

        [Test]
        public void AllTests()
        {
            // 2. Switch header language and verify that it has been worked;​
            homePage.ChangeLanguageToUa();
            homePage.WaitUrlToBe(TimeSpan.FromSeconds(10), Constants.ExpectedUrl);
            homePage.VerifyThatSelectedUaLanguageIsPresent(Constants.ExpectedUrl);

            // 2. Switch header city and verify that it has been worked;​
            homePage.ClickCurrentCityLink();
            homePage.WaitVisibilityOfElement(TimeSpan.FromSeconds(10), homePage.GetPopupLocator());
            homePage.ChangeCityTo(Constants.ExpectedCity);
            homePage.VerifyThatSelectedCityIsPresent(Constants.ExpectedCity);

            // 3. Enter 2 appropriated letters in the search bar, for example,
            //    “lg” and select the first item of the popup list;
            homePage.EnterTextToSearchInput(Constants.ExpectedKeyword);
            homePage.SelectFirtsItemFromSearchDropList();

            // 4. Verify that items list for first page contains elements with appropriate title;
            searchResultPage.VerifyThatSearchResultProductsContainsSearchKeyword(Constants.ExpectedKeyword);

            // 5. Filter items (price, manufacturer, discount);​
            searchResultPage.SetFilterPriceRangeToField(Constants.ExpectedPrice);
            searchResultPage.ClickSubmitButton();

            // 6. Click on first element and verify headers and description;​
            searchResultPage.SelectFirtsProductFromSearchResult();
            productPage.VerifyThatFilteredProductsContainsKeywords(Constants.ExpectedKeyword, Constants.ExpectedPrice);

            // 7. Choose the color of device and verify that it has been changed;
            var oldTitle = productPage.GetProductTitle();
            productPage.SelectProductColor(Constants.ExpectedColor);
            productPage.WaitInvisibilityOfELementWithText(TimeSpan.FromSeconds(10), productPage.GetProductTitleElement(), oldTitle);
            productPage.VerifyThatSelectedColorIsPresent(Constants.ExpectedColor);

            // 8. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;
            productPage.WaitElementExists(TimeSpan.FromSeconds(10), productPage.GetBuyButtonLocator());
            productPage.ClickBuyButtonJs();
            productPage.VerifyThatPopupCartIsDisplayedAndContainsAppropriatedFields(Constants.ExpectedKeyword);

            // 9. Return to the items search and choose another product;​
            productPage.ClickClosePopupButtonJs();
            NavigateBack();
            NavigateBack();
            searchResultPage.SelectRandomProductFromSearchResult();

            // 10. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;
            productPage.WaitElementExists(TimeSpan.FromSeconds(10), productPage.GetBuyButtonLocator());
            productPage.ClickBuyButtonJs();
            productPage.VerifyThatPopupCartIsDisplayedAndContainsAppropriatedFields(Constants.ExpectedKeyword);

            // 11. Close popup and verify that your bucket contains two products;
            productPage.ClickClosePopupButtonJs();
            productPage.WaitTextToBePresentInElement(TimeSpan.FromSeconds(10), productPage.GetAmountOfProductsInCartLocator(), Constants.ExpectedAmountOfProducts.ToString());
            productPage.VerifyThatCartContainsTwoProducts(Constants.ExpectedAmountOfProducts);
        }

    }
}
