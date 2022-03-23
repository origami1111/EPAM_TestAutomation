using MongoDB.Bson.Serialization.Attributes;

namespace Lesson7
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonElement("_id")]
        public int ID { get; set; }

        [BsonElement("first_name")]
        public string FirstName { get; set; }

        [BsonElement("last_name")]
        public string LastName { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("alignment_id")]
        public int AlignmentId { get; set; }

    }
}
