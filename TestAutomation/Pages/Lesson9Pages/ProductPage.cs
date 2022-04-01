using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Controls;

namespace Pages.Pages.Lesson9Pages
{
    public class ProductPage : BasePage
    {
        public Button addToCartButton => FindControl<Button>(By.XPath("//a[contains(text(), 'Add to cart')]"));

        public ProductPage(WebDriver driver) : base(driver)
        {
        }

        public void ClickAddToCartButton()
        {
            addToCartButton.Click();
        }

        public void VerifyProductAdded(string expected)
        {
            string actual = driver.SwitchTo().Alert().Text;

            Assert.AreEqual(expected, actual, "Verify that product added");
        }

    }
}
