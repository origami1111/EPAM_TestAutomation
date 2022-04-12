using JDI.Light.Attributes;
using JDI.Light.Elements.Composite;
using OpenQA.Selenium;

namespace JDIProject.Pages
{
    public class SearchResultPage : WebPage
    {
        //[FindBy(XPath = "//div[contains(@class, 'item-prod')]")]
        [FindBy(XPath = "//*[@id='js_category_filter']/div/div[2]/div/div[3]/div[1]/div")]
        public IWebElement SearchResult;
    }
}
