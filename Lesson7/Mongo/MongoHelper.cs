using MongoDB.Driver;
using System;
using System.Linq;

namespace Lesson7
{
    public class MongoHelper
    {
        private string serverAddress = "mongodb://localhost:27017";
        private string dbName = "testDB";

        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<User> userCollection;
        private IMongoCollection<Alignment> alignmentCollection;

        public MongoHelper()
        {
            client = new MongoClient(serverAddress);
            db = client.GetDatabase(dbName);
            userCollection = db.GetCollection<User>("users");
            alignmentCollection = db.GetCollection<Alignment>("alignments");
        }

        public bool IsUserHasAlignment(string lastName, string alignment)
        {
            var alignmentId = alignmentCollection.AsQueryable()
                .Where(a => a.AlignmentName == alignment).First().ID;

            var user = userCollection.AsQueryable()
                .Where(u => u.LastName == lastName).First();

            return user.AlignmentId == alignmentId;
        }

        public bool IsAllAlignmentsHaveAtLeastOneUserThatUsesThem()
        {
            throw new NotImplementedException();
        }

        public bool IsThereAreAligmentsBornAfterYear(string alignment, int year)
        {
            var alignmentId = alignmentCollection.AsQueryable()
                .Where(a => a.AlignmentName == alignment).First().ID;

            var users = userCollection.AsQueryable()
                .Where(u => u.AlignmentId == alignmentId);

            return users.Where(u => u.Year > year).Any();
        }
    }
}
