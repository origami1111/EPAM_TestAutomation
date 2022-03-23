using NUnit.Framework;

namespace Lesson7
{
    [TestFixture]
    public class DapperTests
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
        public void ValidateThatThereArePersonsWhoBoughtCarsNOTInTheirHomeCity()
        {
            var result = new DapperHelper().IsThereArePersonsWhoBoughtCarsNOTInTheirHomeCity();

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateThatAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear()
        {
            var result = new DapperHelper().IsAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear();

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateThatAllPersonsBoughtCars()
        {
            var result = new DapperHelper().IsAllPersonsBoughtCars();

            Assert.IsTrue(result);
        }
    }
}