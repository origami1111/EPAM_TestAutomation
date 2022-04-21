using JDI.Light.Attributes;
using JDI.Light.Elements.Common;
using JDI.Light.Elements.Composite;

namespace JDIProject.Pages
{
    public class HomePage : WebPage
    {
        [FindBy(XPath = "//ul[contains(@class,'header-top')]//a[text()='Контакты']")]
        public Link ContactsLink;

        [FindBy(XPath = "//div[contains(@class,'header-bottom')]//i[contains(@class,'icon-cart')]")]
        public Button CartButton;

        [FindBy(Id = "input_search")]
        public TextField SearchInput;

        [FindBy(XPath = "//button[@class='button-reset search-btn']")]
        public Button SearchButton;

        [FindBy(XPath = "//div[contains(@class, 'header')]/i[contains(@class, 'user')]")]
        public Image UserIcon;
    }
}
