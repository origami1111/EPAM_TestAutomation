using NUnit.Framework;
using OpenQA.Selenium;

namespace Lesson9
{
    public class ProductPage : BasePage
    {
        private By addToCartButton = By.XPath("//a[contains(text(), 'Add to cart')]");

        public ProductPage(WebDriver driver) : base(driver)
        {
        }

        public void ClickAddToCartButton()
        {
            driver.FindElement(addToCartButton).Click();
        }

        public void VerifyThatProductAdded(string expected)
        {
            string actual = driver.SwitchTo().Alert().Text;

            Assert.AreEqual(expected, actual, "Verify that product added");
        }

    }
}
