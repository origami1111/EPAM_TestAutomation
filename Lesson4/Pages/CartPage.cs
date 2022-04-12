using JDI.Light.Attributes;
using JDI.Light.Elements.Common;
using JDI.Light.Elements.Composite;
using System;
using System.Linq;

namespace JDIProject.Pages
{
    public class CartPage : WebPage
    {
        [FindBy(XPath = "//a[text()='Оформить заказ']")]
        public Button PlaceOrderButton;

        [FindBy(XPath = "//span[contains(@class, 'btn-count--plus')]")]
        public Button CountPlusButton;

        [FindBy(XPath = "//div[@class='total-h']/span[@class='prise']")]
        public Label PriceForOneProduct;

        [FindBy(XPath = "//input[@class='js-changeAmount count']")]
        public Input AmountOfProductsInCart;

        [FindBy(XPath = "//div[@class='item-total']/span[@class='prise']")]
        public Label TotalPrice;

        [FindBy(XPath = "//i[contains(@class,'btn-close')]")]
        public Button DeleteProductFromCartButton;

        public int GetAmountOfProductInCart()
        {
            return Convert.ToInt32(AmountOfProductsInCart.GetAttribute("value"));
        }

        public int GetTotalPrice()
        {
            return GetProductPrice(TotalPrice);
        }

        public int GetPriceForOneProduct()
        {
            return GetProductPrice(PriceForOneProduct);
        }

        private int GetProductPrice(Label price)
        {
            string f = price.GetText();

            int value;
            int.TryParse(string.Join("", f.Where(c => char.IsDigit(c))), out value);

            return value;
        }
    }
}
