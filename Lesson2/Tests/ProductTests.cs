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

        // 5. Filter items (price, manufacturer, discount);​
        // 6. Click on first element and verify headers and description;​
        [TestCase("iphone", 30000)]
        public void CheckThatFilteredProductsContainsKeywords(string keyword, int price)
        {
            homePage.EnterTextToSearchInput(keyword);
            homePage.SelectFirtsItemFromSearchDropList();

            searchResultPage.SetFilterPriceRangeToField(price);
            searchResultPage.ClickSubmitButton();

            searchResultPage.SelectFirtsProductFromSearchResult();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(productPage.GetProductTitle().ToLower().Contains(keyword));
                Assert.GreaterOrEqual(price, GetEditedProductPrice(productPage.GetProductPrice()));
            });
        }

        // 7. Choose the color of device and verify that it has been changed;
        [TestCase("iphone", "midnight")]
        public void CheckThatSelectedColorIsPresent(string keyword, string color)
        {
            homePage.EnterTextToSearchInput(keyword);
            homePage.SelectFirtsItemFromSearchDropList();

            searchResultPage.SelectFirtsProductFromSearchResult();

            var oldTitle = productPage.GetProductTitle();
            productPage.SelectProductColor(color);

            productPage.WaitInvisibilityOfELementWithText(TimeSpan.FromSeconds(10), productPage.GetProductTitleElement(), oldTitle);
            Assert.IsTrue(productPage.GetProductTitle().ToLower().Contains(color));
        }

        // 8. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;
        [TestCase("iphone")]
        public void CheckThatPopupCartIsDisplayedAndContainsAppropriatedFields(string keyword)
        {
            homePage.EnterTextToSearchInput(keyword);
            homePage.SelectFirtsItemFromSearchDropList();

            searchResultPage.SelectFirtsProductFromSearchResult();

            productPage.WaitElementExists(TimeSpan.FromSeconds(10), productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(productPage.IsPopupDisplayed());
                Assert.IsTrue(productPage.GetPopupProductContent().ToLower().Contains(keyword));
            });
        }

        // 9. Return to the items search and choose another product;​
        // 10. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;
        [TestCase("iphone")]
        public void CheckThatPopupCartIsDisplayedAndContainsAppropriatedFieldsWithTwoProducts(string keyword)
        {
            homePage.EnterTextToSearchInput(keyword);
            homePage.SelectFirtsItemFromSearchDropList();

            searchResultPage.SelectFirtsProductFromSearchResult();

            productPage.WaitElementExists(TimeSpan.FromSeconds(10), productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton();
            productPage.ClickClosePopupButton();
            Back();

            searchResultPage.SelectRandomProductFromSearchResult();

            productPage.WaitElementExists(TimeSpan.FromSeconds(10), productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(productPage.IsPopupDisplayed());
                Assert.IsTrue(productPage.GetPopupProductContent().ToLower().Contains(keyword));
            });
        }

        // 11. Close popup and verify that your bucket contains two products;
        [TestCase("iphone", 2)]
        public void CheckThatCartContainsTwoProducts(string keyword, int expectedResult)
        {
            homePage.EnterTextToSearchInput(keyword);
            homePage.SelectFirtsItemFromSearchDropList();

            searchResultPage.SelectFirtsProductFromSearchResult();

            productPage.WaitElementExists(TimeSpan.FromSeconds(10), productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton();
            productPage.ClickClosePopupButton();
            Back();

            searchResultPage.SelectRandomProductFromSearchResult();

            productPage.WaitElementExists(TimeSpan.FromSeconds(10), productPage.GetBuyButtonLocator());
            productPage.ClickBuyButton();
            productPage.ClickClosePopupButton();

            productPage.WaitTextToBePresentInElement(TimeSpan.FromSeconds(10), productPage.GetAmountOfProductsInCartLocator(), expectedResult.ToString());
            Assert.AreEqual(expectedResult, productPage.GetAmountOfProductsInCart());
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
            productPage.ClickBuyButton();

            productPage.ClickGoToCartLink();
            productPage.ClickDeleteProductFromCart();
            productPage.ClickConfirmDeleteProduct();
            productPage.ClickClosePopupButton();

            Assert.IsTrue(productPage.IsCartButtonDisabled());
        }

        private static int GetEditedProductPrice(string priceString)
        {
            string newPriceString = priceString.Replace("₴", "").Replace(" ", "");
            return int.Parse(newPriceString);
        }
    }
}
