using NUnit.Framework;
using Pages;
using Pages.Entities;
using Pages.Pages.Lesson2Pages;

namespace Tests.Tests.Lesson2Tests
{

    /// <summary>
    /// Lesson 2:
    /// Implement several auto tests (positive, negative) according to this scenario:​
    /// 1. Go to https://allo.ua/ru/ ;​
    /// 2. Switch header theme to light/ city/ language and verify that it has been worked;​
    /// 3. Enter 2 appropriated letters in the search bar, for example, “lg” and select the first item of the popup list;​
    /// 4. Verify that items list for first page contains elements with appropriate title;​
    /// 5. Filter items(price, manufacturer, discount);​
    /// 6. Click on first element and verify headers and description;​
    /// 7. Choose the color of device and verify that it has been changed;​
    /// 8. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;​
    /// 9. Return to the items search and choose another product;​
    /// 10. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;​
    /// 11. Close popup and verify that your bucket contains two products.
    /// </summary>

    /// <summary>
    /// Lesson 3:
    /// As you are already familiar with waits, try to use different types of waits and mix them to investigate test behavior. ​
    /// Also, try to be using different expected conditions for the explicit waits.​
    /// </summary>

    [TestFixture]
    public class Lesson2Test : BaseTest
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

        // negative test case
        [Test]
        public void CheckSubmitButtonDisabledWithBlankEmailField()
        {
            homePage.ClickAccountButton()
                .ClickSignInByEmailButton()
                .EnterTextToEmailInput(string.Empty)
                .VerifySubmitButtonDisabled();
        }

        // Negative test case
        // When a user removes all items from the cart, cart is disabled
        [Test]
        public void CheckCartDisabledAfterRemovesProductsFromCart()
        {
            homePage.EnterTextToSearchInput(Constants.ExpectedKeyword)
                .SelectFirtsItemFromSearchDropList();

            searchResultPage.SelectFirtsProductFromSearchResult();

            Wait.WaitElementExists(driver, productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton()
                .ClickGoToCartLink()
                .ClickDeleteProductFromCart()
                .ClickConfirmDeleteProduct()
                .ClickClosePopupButton()
                .VerifyCartButtonDisabled();
        }

        [Test]
        public void AllTests()
        {
            // 2. Switch header language and verify that it has been worked;​
            homePage.ChangeLanguageToUa();
            Wait.WaitUrlToBe(driver, Constants.ExpectedCtrsUrl);
            homePage.VerifySelectedUaLanguageDisplayed(Constants.ExpectedCtrsUrl);

            // 2. Switch header city and verify that it has been worked;​
            homePage.ClickCurrentCityLink();
            Wait.WaitVisibilityOfElement(driver, homePage.GetPopupLocator());
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
            Wait.WaitInvisibilityOfELementWithText(driver, productPage.GetProductTitleElement(), oldTitle);
            productPage.VerifySelectedColorDisplayed(Constants.ExpectedColor);

            // 8. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;
            Wait.WaitElementExists(driver, productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton();
            productPage.VerifyPopupCartDisplayed();
            productPage.VerifyPopupCartContainsAppropriatedFields(Constants.ExpectedKeyword);

            // 9. Return to the items search and choose another product;​
            productPage.ClickClosePopupButton();
            NavigateBack();
            NavigateBack();
            searchResultPage.SelectRandomProductFromSearchResult();

            // 10. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;
            Wait.WaitElementExists(driver, productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton();
            productPage.VerifyPopupCartDisplayed();
            productPage.VerifyPopupCartContainsAppropriatedFields(Constants.ExpectedKeyword);

            // 11. Close popup and verify that your bucket contains two products;
            productPage.ClickClosePopupButton();
            Wait.WaitTextToBePresentInElement(driver, productPage.AmountOfProductsInCart.GetElement(), Constants.ExpectedAmountOfProducts.ToString());
            productPage.VerifyCartContainsTwoProducts(Constants.ExpectedAmountOfProducts);
        }

    }
}
