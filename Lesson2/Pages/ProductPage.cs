using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using Test;

namespace Lesson2
{
    public class ProductPage : BasePage
    {
        private By productTitle = By.XPath("//h1[contains(@class, 'title')]");
        private By productPrice = By.XPath("//div[contains(@class, 'priceContainer')]/div[contains(@class, 'price')]");

        private By productColorsList = By.XPath("//div[contains(@class, 'color')]/a");

        private By buyButton = By.XPath("//button[contains(@class, 'buyButton')]");
        private By popup = By.XPath("//div[contains(@class, 'popup')]");
        private By popupProductContent = By.XPath("//div[contains(@class, 'content')]/p");
        private By closePopupButton = By.XPath("//div[contains(@class, 'close')]");
        private By amountOfProductsInCart = By.XPath("//div[@class='pr']/div[contains(@class, 'badge')]");

        private By goToCartLink = By.XPath("//a[contains(@class, 'link-dashed')]");
        private By deleteProductFromCart = By.XPath("//div[contains(@class, 'linkBlock')]/div/div");
        private By confirmDeleteProduct = By.XPath("//button/span[text()='Да']");
        private By cartButton = By.XPath("//div[contains(@class, 'basket')]//button");

        public ProductPage(WebDriver driver) : base(driver)
        {
        }

        public void VerifyCartContainsTwoProducts(int expected)
        {
            int actual = GetAmountOfProductsInCart();

            Assert.AreEqual(expected, actual, "Verify that cart contains two products");
        }

        public void VerifyPopupCartContainsAppropriatedFields(string expected)
        {
            string actual = GetElementText(popupProductContent).ToLower();

            Assert.IsTrue(actual.Contains(expected), "Verify that popup cart contains appropriated fields");
        }

        public void VerifySelectedColorDisplayed(string expected)
        {
            string actual = GetProductTitle().ToLower();

            Assert.IsTrue(actual.Contains(expected), "Verify that selected color is displayed");
        }

        public void VerifyFilteredProductsContainsKeywords(string expectedKeyword, int expectedPrice)
        {
            string actualKeyword = GetProductTitle().ToLower();
            int actualPrice = GetEditedProductPrice(GetElementText(productPrice));

            Assert.IsTrue(actualKeyword.Contains(expectedKeyword), "Verify that filtered products contain keyword");
            Assert.GreaterOrEqual(expectedPrice, actualPrice, "Verify that filtered products price is greater or equal");
        }

        private static int GetEditedProductPrice(string priceString)
        {
            string newPriceString = priceString.Replace("₴", "").Replace(" ", "");
            return int.Parse(newPriceString);
        }

        public ProductPage SelectProductColor(string color)
        {
            var elements = driver.FindElements(productColorsList);

            elements.First(el => el.GetAttribute("href").Contains(color))
                .Click();

            return this;
        }

        public void VerifyPopupCartDisplayed(bool expected = true)
        {
            bool actual = IsElementDisplayed(popup);

            Assert.AreEqual(expected, actual, "Verify that popup cart is displayed");
        }

        public void VerifyCartButtonDisabled(bool expected = true)
        {
            bool actual = IsElementEnabled(cartButton);

            Assert.AreEqual(expected, actual, "Verify that cart button disabled");
        }

        public ProductPage ClickConfirmDeleteProduct()
        {
            ClickElement(confirmDeleteProduct);
            return this;
        }

        public ProductPage ClickDeleteProductFromCart()
        {
            ClickElement(deleteProductFromCart);
            return this;
        }

        public ProductPage ClickGoToCartLink()
        {
            ClickElement(goToCartLink);
            return this;
        }

        public By GetAmountOfProductsInCartLocator()
        {
            return amountOfProductsInCart;
        }

        public By GetProductTitleElement()
        {
            return productTitle;
        }

        public By GetBuyButtonLocator()
        {
            return buyButton;
        }

        public int GetAmountOfProductsInCart()
        {
            return int.Parse(GetElementText(amountOfProductsInCart));
        }

        public string GetProductTitle()
        {
            return GetElementText(productTitle);
        }

        public ProductPage ClickClosePopupButton()
        {
            ClickElementByJs(closePopupButton);
            return this;
        }

        public ProductPage ClickBuyButton()
        {
            ClickElementByJs(buyButton);
            return this;
        }

    }
}
