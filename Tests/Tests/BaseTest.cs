using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages.Entities;
using System;

namespace Tests.Tests
{
    [SetUpFixture]
    public abstract class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-sandbox", "start-maximized", "--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.DefaultTimeToWait);
        }

        public void NavigateBack()
        {
            driver.Navigate().Back();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
