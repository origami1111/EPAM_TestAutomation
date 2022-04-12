using JDI.Light.Attributes;
using JDI.Light.Elements.Composite;
using JDIProject.Pages;

namespace Lesson4
{
    [Site(Domain = "https://avic.ua/")]
    public class SiteAvic : WebSite
    {
        [Page]
        public HomePage HomePage;

        [Page(Url = "/kontaktyi")]
        public ContactsPage ContactsPage;

        [Page]
        public CartPage CartPage;

        [Page]
        public ModalAlert ModalAlert;

        [Page]
        public SearchResultPage SearchResultPage;

        [Page]
        public ProductPage ProductPage;

        [Page(Url = "/sign-in")]
        public SignInPage SignInPage;
    }
}
