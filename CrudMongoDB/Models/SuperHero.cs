using MongoDB.Bson.Serialization.Attributes;

namespace CrudMongoDB.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class SuperHero
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("firstname")]
        public string FirstName { get; set; }
        [BsonElement("lastname")]
        public string LastName { get; set; }
    }
}
