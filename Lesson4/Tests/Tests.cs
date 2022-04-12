using NUnit.Framework;
using System.Threading;

namespace JDIProject.Lesson4Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test, Description("Test 1")]
        public void CheckRedirectToContacts()
        {
            string expected = SiteAvic.ContactsPage.Url;

            SiteAvic.HomePage.ContactsLink.Click();
            Assert.AreEqual(expected, SiteAvic.Url);
        }

        [Test, Description("Test 2")]
        public void CheckImpossibilityOfActionWhenCartEmpty()
        {
            string expected = "Корзина пустая!";

            SiteAvic.HomePage.CartButton.Click();
            SiteAvic.CartPage.PlaceOrderButton.Click();
            Assert.AreEqual(expected, SiteAvic.ModalAlert.CartTitle.GetText());
        }

        [Test, Description("Test 3-4")]
        public void CheckChangingNumberItemAndPriceInCart()
        {
            string keyword = "iphone 13";
            int expectedAmountOfProducts = 2;

            SiteAvic.HomePage.SearchInput.Input(keyword);
            SiteAvic.HomePage.SearchButton.Click();
            SiteAvic.SearchResultPage.SearchResult.Click();
            SiteAvic.ProductPage.BuyProductButton.Click();
            SiteAvic.CartPage.CountPlusButton.Click();

            Thread.Sleep(500);
            int expectedPrice = SiteAvic.CartPage.GetPriceForOneProduct() * expectedAmountOfProducts;
            int actualPrice = SiteAvic.CartPage.GetTotalPrice();

            Assert.AreEqual(expectedAmountOfProducts, SiteAvic.CartPage.GetAmountOfProductInCart());
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test, Description("Test 5")]
        public void CheckDeleteItemFromCart()
        {
            string keyword = "iphone 13";
            string expected = "Корзина пустая!";

            SiteAvic.HomePage.SearchInput.Input(keyword);
            SiteAvic.HomePage.SearchButton.Click();
            SiteAvic.SearchResultPage.SearchResult.Click();
            SiteAvic.ProductPage.BuyProductButton.Click();
            SiteAvic.CartPage.DeleteProductFromCartButton.Click();
            SiteAvic.HomePage.CartButton.Click();
            SiteAvic.CartPage.PlaceOrderButton.Click();

            Assert.AreEqual(expected, SiteAvic.ModalAlert.CartTitle.GetText());
        }

        [Test, Description("Test 6")]
        public void CheckThatUrlContainsSearchWord()
        {
            string keyword = "iphone 13";
            string expected = "iphone+13";

            SiteAvic.HomePage.SearchInput.Input(keyword);
            SiteAvic.HomePage.SearchButton.Click();

            Assert.IsTrue(SiteAvic.Url.Contains(expected));
        }

        [Test, Description("Test 7")]
        public void CheckErrorMessageWithInvalidCredentialsData()
        {
            string login = "qwerty@gmail.com";
            string password = "qwerty";
            string expected = "Неверные данные авторизации.";

            SiteAvic.HomePage.UserIcon.Click();
            SiteAvic.SignInPage.LoginField.Input(login);
            SiteAvic.SignInPage.PasswordField.Input(password);
            SiteAvic.SignInPage.SubmitButton.Click();
            Assert.IsTrue(SiteAvic.ModalAlert.SignInTitle.GetText().Contains(expected));
        }

    }
}
