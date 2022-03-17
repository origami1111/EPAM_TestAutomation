using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Lesson2
{
    [SetUpFixture]
    public abstract class BaseTest
    {
        protected WebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("https://www.ctrs.com.ua/");
        }

        public void Back()
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
