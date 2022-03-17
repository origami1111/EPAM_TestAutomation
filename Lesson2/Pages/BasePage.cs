using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Lesson2
{
    public abstract class BasePage
    {
        protected WebDriver driver;

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitInvisibilityOfELementWithText(TimeSpan timeToWait, By locator, string text)
        {
            new WebDriverWait(driver, timeToWait)
                .Until(ExpectedConditions.InvisibilityOfElementWithText(locator, text));
        }

        public void WaitTextToBePresentInElement(TimeSpan timeToWait, By locator, string text)
        {
            new WebDriverWait(driver, timeToWait)
                .Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        public void WaitVisibilityOfElement(TimeSpan timeToWait, By locator)
        {
            new WebDriverWait(driver, timeToWait)
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitElementExists(TimeSpan timeToWait, By locator)
        {
            new WebDriverWait(driver, timeToWait)
                .Until(ExpectedConditions.ElementExists(locator));
        }

        public void WaitUrlToBe(TimeSpan timeToWait, string url)
        {
            new WebDriverWait(driver, timeToWait)
                .Until(ExpectedConditions.UrlToBe(url));
        }

    }
}