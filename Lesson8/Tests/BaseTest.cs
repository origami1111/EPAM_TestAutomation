using OpenQA.Selenium.Chrome;
using System;

namespace Lesson8
{
    public class BaseTest
    {
        protected ChromeDriver driver;
        protected HomePage homePage;

        protected void InitDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
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
