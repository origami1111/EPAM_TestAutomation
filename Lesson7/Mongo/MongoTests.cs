using NUnit.Framework;

namespace Lesson7
{
    [TestFixture]
    public class MongoTests
    {

        /// <summary>
        /// 
        /// - Validate that user �Harris� has alignment �Evil�
        /// - Validate that All Alignments have at least one user that uses them
        /// - Validate that there are �Neutral� Alignments born after 1900 (Should Fail
        /// 
        /// </summary>
        /// 

        [TestCase("Harris", "Evil")]
        public void ValidateThatUserHasAlignment(string lastName, string alignment)
        {
            bool IsUserHasAlignment = new MongoHelper().IsUserHasAlignment(lastName, alignment);

            Assert.IsTrue(IsUserHasAlignment);
        }

        [Test]
        [Ignore("Not implemented yet")]
        public void ValidateThatAllAlignmentsHaveAtLeastOneUserThatUsesThem()
        {
            bool IsAllAlignmentsHaveAtLeastOneUserThatUsesThem = new MongoHelper().IsAllAlignmentsHaveAtLeastOneUserThatUsesThem();

            Assert.IsTrue(IsAllAlignmentsHaveAtLeastOneUserThatUsesThem);
        }

        [TestCase("Neutral", 1900)]
        public void ValidateThatThereAreAligmentsBornAfterYear(string alignment, int year)
        {
            bool IsThereAreAligmentsBornAfterYear = new MongoHelper().IsThereAreAligmentsBornAfterYear(alignment, year);

            Assert.IsTrue(IsThereAreAligmentsBornAfterYear);
        }
    }
}