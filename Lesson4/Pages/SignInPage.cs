using JDI.Light.Attributes;
using JDI.Light.Elements.Common;
using JDI.Light.Elements.Composite;

namespace JDIProject.Pages
{
    public class SignInPage : WebPage
    {
        [FindBy(XPath = "//main//input[@name='login']")]
        public TextArea LoginField;

        [FindBy(XPath = "//main//input[@name='password']")]
        public TextArea PasswordField;

        [FindBy(XPath = "//main//button[@type='submit']")]
        public Button SubmitButton;
    }
}
