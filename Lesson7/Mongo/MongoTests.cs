using NUnit.Framework;

namespace DataBases.Mongo
{
    [TestFixture]
    public class MongoTests
    {
        /// <summary>
        /// 
        /// - Validate that user ‘Harris’ has alignment ‘Evil’
        /// - Validate that All Alignments have at least one user that uses them
        /// - Validate that there are ‘Neutral’ Alignments born after 1900 (Should Fail)
        /// 
        /// </summary>
        /// 

        [Test]
        public void ValidateUserHasAlignment()
        {
            #region test data

            const string LastName = "Harris";
            const string Alignment = "Evil";

            #endregion

            bool IsUserHasAlignment = new MongoHelper().IsUserHasAlignment(LastName, Alignment);
            Assert.IsTrue(IsUserHasAlignment);
        }

        [Test]
        [Ignore("Not implemented yet")]
        public void ValidateAllAlignmentsHaveAtLeastOneUserThatUsesThem()
        {
            bool IsAllAlignmentsHaveAtLeastOneUserThatUsesThem = new MongoHelper().IsAllAlignmentsHaveAtLeastOneUserThatUsesThem();
            Assert.IsTrue(IsAllAlignmentsHaveAtLeastOneUserThatUsesThem);
        }

        [Test, Description("should fail")]
        public void ValidateThereAreAligmentsBornAfterYear()
        {
            #region test data

            const string Alignment = "Neutral";
            const int Year = 1900;

            #endregion

            bool IsThereAreAligmentsBornAfterYear = new MongoHelper().IsThereAreAligmentsBornAfterYear(Alignment, Year);
            Assert.IsTrue(IsThereAreAligmentsBornAfterYear);
        }
    }
}
