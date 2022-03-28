using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Lesson9
{
    public abstract class BasePage
    {
        protected WebDriver driver;

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitAlertIsPresent(TimeSpan timeToWait)
        {
            new WebDriverWait(driver, timeToWait)
               .Until(ExpectedConditions.AlertIsPresent());
        }

        public void WaitVisibilityOfElement(TimeSpan timeToWait, By locator)
        {
            new WebDriverWait(driver, timeToWait)
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
