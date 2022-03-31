using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pages.Pages.Lesson2Pages
{
    public class SearchResultPage : BasePage
    {
        private By searchResultProductsTextList = By.XPath("//a[contains(@class, 'break-word')]");
        private By filterPrice = By.XPath("//form[contains(@class, 'filterPrice')]//input");

        public Button submitButton => FindControl<Button>(By.XPath("//button[@type='submit']"));

        public SearchResultPage(IWebDriver driver) : base(driver) { }

        public void VerifySearchResultProductsContainsSearchKeyword(string expected)
        {
            foreach (var product in GetSearchResultProductsTextList())
            {
                string actual = product.ToLower();

                Assert.IsTrue(actual.Contains(expected), "Verify that search result products contains search keyword");
            }
        }

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

        public SearchResultPage ClickSubmitButton()
        {
            submitButton.Click();
            return this;
        }

        public SearchResultPage SetFilterPriceRangeToField(int price)
        {
            var field = driver.FindElements(filterPrice).Last();

            field.Clear();
            field.SendKeys(price.ToString());

            return this;
        }

        public List<string> GetSearchResultProductsTextList()
        {
            return driver.FindElements(searchResultProductsTextList)
                .Select(product => product.Text).ToList();
        }
    }
}
