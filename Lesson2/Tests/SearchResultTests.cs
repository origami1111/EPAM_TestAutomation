using NUnit.Framework;

namespace Lesson2
{
    [TestFixture]
    public class SearchResultTests : BaseTest
    {
        private HomePage homePage;
        private SearchResultPage searchResultPage;

        [SetUp]
        public void SetupPage()
        {
            homePage = new HomePage(driver);
            searchResultPage = new SearchResultPage(driver);
        }

        // 3. Enter 2 appropriated letters in the search bar, for example, “lg” and select the first item of the popup list;
        // 4. Verify that items list for first page contains elements with appropriate title;
        [TestCase("iphone")]
        public void ChechThatSearchResultProductsContainsSearchKeyword(string keyword)
        {
            homePage.EnterTextToSearchInput(keyword);
            homePage.SelectFirtsItemFromSearchDropList();

            foreach (var product in searchResultPage.GetSearchResultProductsTextList())
            {
                Assert.IsTrue(product.ToLower().Contains(keyword));
            }
        }

    }
}
