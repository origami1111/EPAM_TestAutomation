using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Lesson9
{
    public class BrowserDriver : IDisposable
    {
        public WebDriver driver;

        public BrowserDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-sandbox", "start-maximized", "--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
