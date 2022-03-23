using NUnit.Framework;

namespace Lesson7
{
    [TestFixture]
    public class EntityFrameworkTests
    {

        /// <summary>
        /// 
        /// Import Entity Framework Models for Master DB
        /// Create Same tests for Entity Framework as you did for Dapper
        /// 
        /// </summary>

        [Test]
        public void ValidateThatThereArePersonsWhoBoughtCarsNOTInTheirHomeCity()
        {
            bool IsThereArePersonsWhoBoughtCarsNOTInTheirHomeCity = new EFHelper().IsThereArePersonsWhoBoughtCarsNOTInTheirHomeCity();

            Assert.IsTrue(IsThereArePersonsWhoBoughtCarsNOTInTheirHomeCity);
        }

        [Test]
        public void ValidateThatAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear()
        {
            bool IsAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear = new EFHelper().IsAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear();

            Assert.IsTrue(IsAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear);
        }

        [Test]
        public void ValidateThatAllPersonsBoughtCars()
        {
            bool IsAllPersonsBoughtCars = new EFHelper().IsAllPersonsBoughtCars();

            Assert.IsTrue(IsAllPersonsBoughtCars);
        }
    }
}