using NUnit.Framework;

namespace DataBases.Dapper
{
    [TestFixture]
    public class DapperTest
    {
        /// <summary>
        /// 
        /// Use Dapper to create 3 Automation Tests (NUnit or XUnit):
        /// - Validate that there are Persons who bought Cars NOT in their home City
        /// - Validate that All Persons who bought cars are older than their BuyersInfo year
        /// - Validate that All Persons bought Cars (Should Fail)
        /// 
        /// </summary>

        [Test]
        public void ValidateThereArePersonsWhoBoughtCarsNotInTheirHomeCity()
        {
            var result = new DapperHelper().IsThereArePersonsWhoBoughtCarsNotInTheirHomeCity();

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear()
        {
            var result = new DapperHelper().IsAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear();

            Assert.IsTrue(result);
        }

        [Test, Description("should fail")]
        public void ValidateAllPersonsBoughtCars()
        {
            var result = new DapperHelper().IsAllPersonsBoughtCars();

            Assert.IsTrue(result);
        }
    }
}
