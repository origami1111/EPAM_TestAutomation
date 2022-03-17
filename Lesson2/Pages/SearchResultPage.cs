using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson2
{
    public class SearchResultPage : BasePage
    {
        private By searchResultProductsTextList = By.XPath("//a[contains(@class, 'break-word')]");
        private By filterPrice = By.XPath("//form[contains(@class, 'filterPrice')]/div/div/input");
        private By submitButton = By.XPath("//button[@type='submit']");

        public SearchResultPage(WebDriver driver) : base(driver) { }

        public void SelectFirtsProductFromSearchResult()
        {
            driver.FindElements(searchResultProductsTextList)
                .First().Click();
        }

        public void SelectRandomProductFromSearchResult()
        {
            Random rand = new Random();

            driver.FindElements(searchResultProductsTextList)
                .ElementAt(rand.Next(0, driver.FindElements(searchResultProductsTextList).Count)).Click();
        }

        public void ClickSubmitButton()
        {
            driver.FindElement(submitButton).Click();
        }

        public void SetFilterPriceRangeToField(int price)
        {
            var field = driver.FindElements(filterPrice).Last();

            field.Clear();
            field.SendKeys(price.ToString());
        }

        public List<string> GetSearchResultProductsTextList()
        {
            return driver.FindElements(searchResultProductsTextList)
                .Select(product => product.Text).ToList();
        }
    }
}
