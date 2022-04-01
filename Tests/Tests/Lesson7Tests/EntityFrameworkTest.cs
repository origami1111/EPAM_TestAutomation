using DataBases.EntityFramework;
using NUnit.Framework;

namespace Tests.Tests.Lesson7Tests
{
    [TestFixture]
    public class EntityFrameworkTest
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
            bool IsThereArePersonsWhoBoughtCarsNotInTheirHomeCity = new EFHelper().IsThereArePersonsWhoBoughtCarsNotInTheirHomeCity();

            Assert.IsTrue(IsThereArePersonsWhoBoughtCarsNotInTheirHomeCity);
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