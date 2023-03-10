using OpenQA.Selenium.Chrome;
using Pages.Entities;
using Pages.Pages.Lesson8Pages;
using System;

namespace Lesson8
{
    public class BaseTest
    {
        protected ChromeDriver driver;
        protected HomePage homePage;

        protected void InitDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-sandbox", "start-maximized", "--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.DefaultTimeToWait);
            driver.Navigate().GoToUrl(Constants.XUnitUrl);

            homePage = new HomePage(driver);
        }

        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
