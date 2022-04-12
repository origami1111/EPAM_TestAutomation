using JDI.Light.Attributes;
using JDI.Light.Elements.Common;
using JDI.Light.Elements.Composite;

namespace JDIProject.Pages
{
    public class ProductPage : WebPage
    {
        [FindBy(XPath = "//a[text()='Купить']")]
        public Button BuyProductButton;
    }
}
