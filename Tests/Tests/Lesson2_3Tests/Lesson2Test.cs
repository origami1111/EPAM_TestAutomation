using Lesson3.Pages;
using NUnit.Framework;
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
            driver.Navigate().GoToUrl(Constants.CtrsUrl);
            homePage = new HomePage(driver);
            searchResultPage = new SearchResultPage(driver);
            productPage = new ProductPage(driver);
        }

        // negative test case
        [Test]
        public void CheckSubmitButtonIsNotClickableWithBlankEmailField()
        {
            homePage.ClickAccountButton()
                .ClickSignInByEmailButton()
                .EnterTextToEmailInput(string.Empty)
                .VerifySubmitButtonIsNotClickable();
        }

        // Negative test case
        // When a user removes all items from the cart, cart is empty
        [Test]
        public void CheckCartIsEmptyAfterRemovesProductsFromCart()
        {
            #region Expected results

            const string ExpectedKeyword = "iphone";
            const string ExpectedMessage = "Ваша корзина пуста";

            #endregion

            homePage.EnterTextToSearchInput(ExpectedKeyword)
                .SelectFirtsItemFromSearchDropList();

            searchResultPage.SelectFirtsProductFromSearchResult();

            Wait.WaitElementExists(driver, productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton()
                .ClickGoToCartLink()
                .ClickDeleteProductFromCart()
                .ClickConfirmDeleteProduct()
                .ClickClosePopupButton()
                .VerifyCartButtonIsEmpty(ExpectedMessage);
        }

        [Test]
        public void AllTests()
        {
            #region Expected results

            const string ExpectedCtrsUrl = "https://www.ctrs.com.ua/uk/";
            const string ExpectedCity = "Дніпро";
            const string ExpectedKeyword = "iphone";
            const int ExpectedPrice = 30000;
            const string ExpectedColor = "midnight";
            const int ExpectedAmountOfProducts = 2;

            #endregion

            // 2. Switch header language and verify that it has been worked;​
            homePage.ChangeLanguageToUa();
            Wait.WaitUrlToBe(driver, ExpectedCtrsUrl);
            homePage.VerifySelectedUaLanguageDisplayed(ExpectedCtrsUrl);

            // 2. Switch header city and verify that it has been worked;​
            homePage.ClickCurrentCityLink();
            Wait.WaitVisibilityOfElement(driver, homePage.GetPopupLocator());
            homePage.ChangeCityTo(ExpectedCity);
            homePage.VerifySelectedCityDisplayed(ExpectedCity);

            // 3. Enter 2 appropriated letters in the search bar, for example,
            //    “lg” and select the first item of the popup list;
            homePage.EnterTextToSearchInput(ExpectedKeyword)
                .SelectFirtsItemFromSearchDropList();

            // 4. Verify that items list for first page contains elements with appropriate title;
            searchResultPage.VerifySearchResultProductsContainsSearchKeyword(ExpectedKeyword);

            // 5. Filter items (price, manufacturer, discount);​
            searchResultPage.SetFilterPriceRangeToField(ExpectedPrice)
                .ClickSubmitButton();

            // 6. Click on first element and verify headers and description;​
            searchResultPage.SelectFirtsProductFromSearchResult();
            productPage.VerifyFilteredProductsContainsKeywords(ExpectedKeyword, ExpectedPrice);

            // 7. Choose the color of device and verify that it has been changed;
            var oldTitle = productPage.GetProductTitle();
            productPage.SelectProductColor(ExpectedColor);
            Wait.WaitInvisibilityOfELementWithText(driver, productPage.GetProductTitleElement(), oldTitle);
            productPage.VerifySelectedColorDisplayed(ExpectedColor);

            // 8. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;
            Wait.WaitElementExists(driver, productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton();
            productPage.VerifyPopupCartDisplayed();
            productPage.VerifyPopupCartContainsAppropriatedFields(ExpectedKeyword);

            // 9. Return to the items search and choose another product;​
            productPage.ClickClosePopupButton();
            NavigateBack();
            NavigateBack();
            searchResultPage.SelectRandomProductFromSearchResult();

            // 10. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;
            Wait.WaitElementExists(driver, productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton();
            productPage.VerifyPopupCartDisplayed();
            productPage.VerifyPopupCartContainsAppropriatedFields(ExpectedKeyword);

            // 11. Close popup and verify that your bucket contains two products;
            productPage.ClickClosePopupButton();
            Wait.WaitTextToBePresentInElement(driver, productPage.AmountOfProductsInCart.GetElement(), ExpectedAmountOfProducts.ToString());
            productPage.VerifyCartContainsTwoProducts(ExpectedAmountOfProducts);
        }

    }
}
