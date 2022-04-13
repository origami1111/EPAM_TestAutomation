using JDI.Light.Attributes;
using JDI.Light.Elements.Composite;
using OpenQA.Selenium;

namespace JDIProject.Pages
{
    public class SearchResultPage : WebPage
    {
        [FindBy(XPath = "//div[contains(@class, 'item-prod')][1]")]
        public IWebElement SearchResult;
    }
}
