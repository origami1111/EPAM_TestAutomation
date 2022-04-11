using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages.Entities;
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.DefaultTimeToWait);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Constants.DefaultTimeToWait);
            driver.Navigate().GoToUrl(Constants.DemoblazeUrl);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
