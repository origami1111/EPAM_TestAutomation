using MongoDB.Bson.Serialization.Attributes;

namespace DataBases.Mongo
{
    [BsonIgnoreExtraElements]
    public class Alignment
    {
        [BsonElement("_id")]
        public int ID { get; set; }

        [BsonElement("alignment_name")]
        public string AlignmentName { get; set; }
    }
}
