using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Test
{
    public abstract class BasePage
    {
        protected WebDriver driver;

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickElement(By element)
        {
            driver.FindElement(element).Click();
        }

        public void ClickElementByJs(By element)
        {
            var el = driver.FindElement(element);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", el);
        }

        public string GetElementText(By element)
        {
            return driver.FindElement(element).Text;
        }

        public bool IsElementEnabled(By element)
        {
            return driver.FindElement(element).Enabled;
        }

        public bool IsElementDisplayed(By element)
        {
            return driver.FindElement(element).Displayed;
        }

        public void WaitInvisibilityOfELementWithText(By locator, string text, int timeToWait = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.InvisibilityOfElementWithText(locator, text));
        }

        public void WaitTextToBePresentInElement(By locator, string text, int timeToWait = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        public void WaitVisibilityOfElement(By locator, int timeToWait = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitElementExists(By locator, int timeToWait = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.ElementExists(locator));
        }

        public void WaitUrlToBe(string url, int timeToWait = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.UrlToBe(url));
        }

    }
}
