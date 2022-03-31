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
        public void ValidateThereArePersonsWhoBoughtCarsNotInTheirHomeCity()
        {
            bool IsThereArePersonsWhoBoughtCarsNOTInTheirHomeCity = new EFHelper().IsThereArePersonsWhoBoughtCarsNOTInTheirHomeCity();

            Assert.IsTrue(IsThereArePersonsWhoBoughtCarsNOTInTheirHomeCity);
        }

        [Test]
        public void ValidateAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear()
        {
            bool IsAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear = new EFHelper().IsAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear();

            Assert.IsTrue(IsAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear);
        }

        [Test]
        public void ValidateAllPersonsBoughtCars()
        {
            bool IsAllPersonsBoughtCars = new EFHelper().IsAllPersonsBoughtCars();

            Assert.IsTrue(IsAllPersonsBoughtCars);
        }
    }
}