using OpenQA.Selenium;

namespace Lesson8
{
    public abstract class BasePage
    {
        protected WebDriver driver;

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }

    }
}
