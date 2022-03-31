using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Controls;
using System.Linq;

namespace Pages.Pages.Lesson2Pages
{
    public class ProductPage : BasePage
    {
        private By buyButton = By.XPath("//button[contains(@class, 'buyButton')]");
        private By productTitle = By.XPath("//h1[contains(@class, 'title')]");
        private By productColorsList = By.XPath("//div[contains(@class, 'color')]/a");

        public Label amountOfProductsInCart => FindControl<Label>(By.XPath("//div[@class='pr']/div[contains(@class, 'badge')]"));
        public Text popupProductContent => FindControl<Text>(By.XPath("//div[contains(@class, 'content')]/p"));
        public Popup popup => FindControl<Popup>(By.XPath("//div[contains(@class, 'popup')]"));
        public Label productPriceLabel => FindControl<Label>(By.XPath("//div[contains(@class, 'priceContainer')]/div[contains(@class, 'price')]"));
        public Link goToCartLink => FindControl<Link>(By.XPath("//a[contains(@class, 'link-dashed')]"));
        public Button deleteProductFromCartButton => FindControl<Button>(By.XPath("//div[contains(@class, 'linkBlock')]/div/div"));
        public Button cartButton => FindControl<Button>(By.XPath("//div[contains(@class, 'basket')]//button"));
        public Button confirmDeleteProductButton => FindControl<Button>(By.XPath("//button/span[text()='Да']"));
        public Button closePopupButton => FindControl<Button>(By.XPath("//div[contains(@class, 'close')]"));

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public void VerifyCartContainsTwoProducts(int expected)
        {
            int actual = GetAmountOfProductsInCart();

            Assert.AreEqual(expected, actual, "Verify that cart contains two products");
        }

        public void VerifyPopupCartContainsAppropriatedFields(string expected)
        {
            string actual = popupProductContent.GetText().ToLower();

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
            int actualPrice = GetEditedProductPrice(productPriceLabel.GetText());

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
            bool actual = popup.IsDisplayed();

            Assert.AreEqual(expected, actual, "Verify that popup cart is displayed");
        }

        public void VerifyCartButtonDisabled(bool expected = true)
        {
            bool actual = cartButton.IsEnabled();

            Assert.AreEqual(expected, actual, "Verify that cart button disabled");
        }

        public ProductPage ClickConfirmDeleteProduct()
        {
            confirmDeleteProductButton.Click();
            return this;
        }

        public ProductPage ClickDeleteProductFromCart()
        {
            deleteProductFromCartButton.Click();
            return this;
        }

        public ProductPage ClickGoToCartLink()
        {
            goToCartLink.Click();
            return this;
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
            return int.Parse(amountOfProductsInCart.GetText());
        }

        public string GetProductTitle()
        {
            return GetElementText(productTitle);
        }

        public ProductPage ClickClosePopupButton()
        {
            closePopupButton.ClickJs();
            return this;
        }

        public ProductPage ClickBuyButton()
        {
            ClickElementByJs(buyButton);
            return this;
        }

    }
}
