using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

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

        public ProductPage(WebDriver driver) : base(driver) { }

        public void VerifyThatCartContainsTwoProducts(int expected)
        {
            int actual = GetAmountOfProductsInCart();

            Assert.AreEqual(expected, actual, "Verify that cart contains two products");
        }

        public void VerifyThatPopupCartIsDisplayedAndContainsAppropriatedFields(string expected)
        {
            string actual = GetPopupProductContent().ToLower();

            Assert.IsTrue(IsPopupDisplayed());
            Assert.IsTrue(actual.Contains(expected), "Verify that popup cart is displayed and contains appropriated fields");
        }

        public void VerifyThatSelectedColorIsPresent(string expected)
        {
            string actual = GetProductTitle().ToLower();

            Assert.IsTrue(actual.Contains(expected), "Verify that selected color is present");
        }

        public void VerifyThatFilteredProductsContainsKeywords(string expectedKeyword, int expectedPrice)
        {
            string actualKeyword = GetProductTitle().ToLower();
            int actualPrice = GetEditedProductPrice(GetProductPrice());

            Assert.IsTrue(actualKeyword.Contains(expectedKeyword), "Verify that filtered products contain keyword");
            Assert.GreaterOrEqual(expectedPrice, actualPrice, "Verify that filtered products price is greater or equal");
        }

        private static int GetEditedProductPrice(string priceString)
        {
            string newPriceString = priceString.Replace("₴", "").Replace(" ", "");
            return int.Parse(newPriceString);
        }

        ///////////////////////////////////////////////////////////////////////////////////////

        public By GetProductTitleElement()
        {
            return productTitle;
        }

        public void SelectProductColor(string color)
        {
            var elements = driver.FindElements(productColorsList);

            elements.First(el => el.GetAttribute("href").Contains(color))
                .Click();
        }

        public void VerifyThatCartButtonDisabled(bool expected = true)
        {
            bool actual = driver.FindElement(cartButton).Enabled;

            Assert.IsTrue(actual);
        }

        public void ClickConfirmDeleteProduct()
        {
            driver.FindElement(confirmDeleteProduct).Click();
        }

        public void ClickDeleteProductFromCart()
        {
            driver.FindElement(deleteProductFromCart).Click();
        }

        public void ClickGoToCartLink()
        {
            driver.FindElement(goToCartLink).Click();
        }

        public By GetAmountOfProductsInCartLocator()
        {
            return amountOfProductsInCart;
        }

        public int GetAmountOfProductsInCart()
        {
            return int.Parse(driver.FindElement(amountOfProductsInCart).Text);
        }

        public void ClickClosePopupButtonJs()
        {
            var element = driver.FindElement(closePopupButton);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public string GetPopupProductContent()
        {
            return driver.FindElement(popupProductContent).Text;
        }

        public bool IsPopupDisplayed()
        {
            return driver.FindElement(popup).Displayed;
        }

        public By GetBuyButtonLocator()
        {
            return buyButton;
        }

        public void ClickBuyButtonJs()
        {
            var element = driver.FindElement(buyButton);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public string GetProductPrice()
        {
            return driver.FindElement(productPrice).Text;
        }

        public string GetProductTitle()
        {
            return driver.FindElement(productTitle).Text;
        }
    }
}
