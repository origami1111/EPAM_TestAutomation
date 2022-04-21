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

        public Text testText => FindControl<Text>(By.XPath("//div[@class='tc']"));

        public Label AmountOfProductsInCart => FindControl<Label>(By.XPath("//div[@class='pr']/div[contains(@class, 'badge')]"));
        public Text PopupProductContent => FindControl<Text>(By.XPath("//div[contains(@class, 'content')]/p"));
        public Popup Popup => FindControl<Popup>(By.XPath("//div[contains(@class, 'popup')]"));
        public Label ProductPriceLabel => FindControl<Label>(By.XPath("//div[contains(@class, 'priceContainer')]/div[contains(@class, 'price')]"));
        public Link GoToCartLink => FindControl<Link>(By.XPath("//a[contains(@class, 'link-dashed')]"));
        public Button DeleteProductFromCartButton => FindControl<Button>(By.XPath("//div[contains(@class, 'linkBlock')]/div/div"));
        public Button CartButton => FindControl<Button>(By.XPath("//div[contains(@class, 'basket')]//button"));
        public Button ConfirmDeleteProductButton => FindControl<Button>(By.XPath("//button/span[text()='Да']"));
        public Button ClosePopupButton => FindControl<Button>(By.XPath("//div[contains(@class, 'close')]"));

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
            string actual = PopupProductContent.GetText().ToLower();
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
            int actualPrice = GetEditedProductPrice(ProductPriceLabel.GetText());

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
            bool actual = Popup.IsDisplayed();
            Assert.AreEqual(expected, actual, "Verify that popup cart is displayed");
        }

        public void VerifyCartButtonIsEmpty(string expected)
        {
            string actual = testText.GetText();
            Assert.IsTrue(actual.Contains(expected));
        }

        public ProductPage ClickConfirmDeleteProduct()
        {
            ConfirmDeleteProductButton.Click();
            return this;
        }

        public ProductPage ClickDeleteProductFromCart()
        {
            DeleteProductFromCartButton.Click();
            return this;
        }

        public ProductPage ClickGoToCartLink()
        {
            GoToCartLink.Click();
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
            return int.Parse(AmountOfProductsInCart.GetText());
        }

        public string GetProductTitle()
        {
            return GetElementText(productTitle);
        }

        public ProductPage ClickClosePopupButton()
        {
            ClosePopupButton.ClickJs();
            return this;
        }

        public ProductPage ClickBuyButton()
        {
            ClickElementByJs(buyButton);
            return this;
        }

    }
}
