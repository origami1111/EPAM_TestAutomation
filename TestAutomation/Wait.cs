using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages.Entities;
using SeleniumExtras.WaitHelpers;
using System;

namespace Lesson3.Pages
{
    public static class Wait
    {
        public static void WaitInvisibilityOfELementWithText(IWebDriver driver, By locator, string text, int timeToWait = Constants.DefaultTimeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.InvisibilityOfElementWithText(locator, text));
        }

        public static void WaitTextToBePresentInElement(IWebDriver driver, IWebElement element, string text, int timeToWait = Constants.DefaultTimeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        public static void WaitVisibilityOfElement(IWebDriver driver, By locator, int timeToWait = Constants.DefaultTimeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitElementExists(IWebDriver driver, By locator, int timeToWait = Constants.DefaultTimeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.ElementExists(locator));
        }

        public static void WaitUrlToBe(IWebDriver driver, string url, int timeToWait = Constants.DefaultTimeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
                .Until(ExpectedConditions.UrlToBe(url));
        }

        public static void WaitAlertIsPresent(IWebDriver driver, int timeToWait = Constants.DefaultTimeToWait)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait))
               .Until(ExpectedConditions.AlertIsPresent());
        }
    }
}
