using JDI.Light.Attributes;
using JDI.Light.Elements.Common;
using JDI.Light.Elements.Composite;

namespace JDIProject.Pages
{
    public class ModalAlert : WebPage
    {
        [FindBy(XPath = "//div[contains(@class, 'js_title')]")]
        public TextArea CartTitle;

        [FindBy(XPath = "//div[contains(@class, 'js_message')]")]
        public TextArea SignInTitle;
    }
}
