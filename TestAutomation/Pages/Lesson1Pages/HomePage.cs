using OpenQA.Selenium;
using Pages.Controls;

namespace Pages.Pages.Lesson1Pages
{
    public class HomePage : BasePage
    {
        public Link DocumentationLink => FindControl<Link>(By.XPath("//span[text() = 'Documentation']"));

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

    }
}
