using NUnit.Framework;
using System;

namespace Lesson2.Tests
{
    [TestFixture]
    public class ProductTests : BaseTest
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

        // Negative test case
        // When a user removes all items from the cart, cart is disabled
        [TestCase("iphone")]
        public void CheckThatCartIsDisabledAfterRemovesProductsFromCart(string keyword)
        {
            homePage.EnterTextToSearchInput(keyword);
            homePage.SelectFirtsItemFromSearchDropList();

            searchResultPage.SelectFirtsProductFromSearchResult();

            productPage.WaitElementExists(TimeSpan.FromSeconds(10), productPage.GetBuyButtonLocator());
            productPage.ClickBuyButtonJs();

            productPage.ClickGoToCartLink();
            productPage.ClickDeleteProductFromCart();
            productPage.ClickConfirmDeleteProduct();
            productPage.ClickClosePopupButtonJs();

            productPage.VerifyThatCartButtonDisabled();
        }

    }
}
