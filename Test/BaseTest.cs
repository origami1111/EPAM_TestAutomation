using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Test
{
    [SetUpFixture]
    public abstract class BaseTest
    {
        protected WebDriver driver;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-sandbox", "start-maximized", "--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
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
