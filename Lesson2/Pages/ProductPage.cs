using OpenQA.Selenium;

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
        private By cartButton = By.XPath("//div[contains(@class, 'basket')]/div/button");

        public ProductPage(WebDriver driver) : base(driver) { }

        public By GetProductTitleElement()
        {
            return productTitle;
        }

        public void SelectProductColor(string color)
        {
            var elements = driver.FindElements(productColorsList);

            foreach (var element in elements)
            {
                if (element.GetAttribute("href").Contains(color))
                {
                    element.Click();
                }
            }
        }

        public bool IsCartButtonDisabled()
        {
            return driver.FindElement(cartButton).Enabled;
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

        public void ClickClosePopupButton()
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

        public void ClickBuyButton()
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
