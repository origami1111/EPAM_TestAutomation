using OpenQA.Selenium.Chrome;
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(Constants.SiteUrl);

            homePage = new HomePage(driver);
        }

        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
