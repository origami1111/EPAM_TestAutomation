using JDI.Light;
using Lesson4;
using NUnit.Framework;

namespace JDIProject.Lesson4Tests
{
    public class BaseTest
    {
        public static SiteAvic SiteAvic { get; set; }

        [SetUp]
        public void SetUpTest()
        {
            Jdi.Timeouts.WaitElementMSec = 5000;
            Jdi.Timeouts.WaitPageLoadMSec = 5000;
            Jdi.Init();

            SiteAvic = Jdi.InitSite<SiteAvic>();
            SiteAvic.HomePage.Open();
        }

        [TearDown]
        public void TearDownTest()
        {
            SiteAvic.WebDriver.Quit();
        }
    }
}
