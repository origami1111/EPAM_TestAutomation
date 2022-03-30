using NUnit.Framework;
using Test;

namespace Lesson2.Tests
{
    [TestFixture]
    public class ProductTests : BaseTest
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

        // Negative test case
        // When a user removes all items from the cart, cart is disabled
        [Test]
        public void CheckCartDisabledAfterRemovesProductsFromCart()
        {
            homePage.EnterTextToSearchInput(Constants.ExpectedKeyword)
                .SelectFirtsItemFromSearchDropList();

            searchResultPage.SelectFirtsProductFromSearchResult();

            productPage.WaitElementExists(productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton()
                .ClickGoToCartLink()
                .ClickDeleteProductFromCart()
                .ClickConfirmDeleteProduct()
                .ClickClosePopupButton()
                .VerifyCartButtonDisabled();
        }

    }
}
