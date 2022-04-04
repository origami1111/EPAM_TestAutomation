using OpenQA.Selenium;
using Pages.Controls;
using System;

namespace Pages.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public T FindControl<T>(By selector) where T : BaseControl
        {
            IWebElement webElement = driver.FindElement(selector);
            var control = (T)Activator.CreateInstance(typeof(T), webElement, driver);
            return control;
        }

        //public List<T> FindControls<T>(By selector) where T : BaseControl
        //{
        //    var webElements = driver.FindElements(selector);
        //    var controls = (List<T>)Activator.CreateInstance(typeof(List<T>), webElements, driver);
        //    return controls;
        //}

        public void ClickElementByJs(By element)
        {
            var el = driver.FindElement(element);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", el);
        }

        public string GetElementText(By element)
        {
            return driver.FindElement(element).Text;
        }

    }
}
