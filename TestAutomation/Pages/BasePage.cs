using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages.Controls;
using SeleniumExtras.WaitHelpers;
using System;

namespace Pages.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public T FindControl<T>(By selector) where T : BaseControl
        {
            IWebElement webElement = driver.FindElement(selector);
            var control = (T)Activator.CreateInstance(typeof(T), webElement, driver);
            return control;
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

        public void WaitTextToBePresentInElement(IWebElement element, string text, int timeToWait = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.TextToBePresentInElement(element, text));
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

        public void WaitAlertIsPresent(TimeSpan timeToWait)
        {
            new WebDriverWait(driver, timeToWait)
               .Until(ExpectedConditions.AlertIsPresent());
        }

    }
}
