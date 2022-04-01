using OpenQA.Selenium;
using Pages.Controls;
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

        //public List<T> FindControls<T>(By selector) where T : BaseControl
        //{
        //    var webElements = driver.FindElements(selector);
        //    var controls = (List<T>)Activator.CreateInstance(typeof(List<T>), webElements, driver);
        //    return controls;
        //}

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

        //public void WaitInvisibilityOfELementWithText(By locator, string text, int timeToWait = 10)
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
        //        .Until(ExpectedConditions.InvisibilityOfElementWithText(locator, text));
        //}

        //public void WaitTextToBePresentInElement(IWebElement element, string text, int timeToWait = 10)
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
        //        .Until(ExpectedConditions.TextToBePresentInElement(element, text));
        //}

        //public void WaitVisibilityOfElement(By locator, int timeToWait = 10)
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
        //        .Until(ExpectedConditions.ElementIsVisible(locator));
        //}

        //public void WaitElementExists(By locator, int timeToWait = 10)
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
        //        .Until(ExpectedConditions.ElementExists(locator));
        //}

        //public void WaitUrlToBe(string url, int timeToWait = 10)
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
        //        .Until(ExpectedConditions.UrlToBe(url));
        //}

        //public void WaitAlertIsPresent(int timeToWait = 3)
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
        //       .Until(ExpectedConditions.AlertIsPresent());
        //}

    }
}
