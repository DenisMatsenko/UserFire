using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserFire
{
    [BsonIgnoreExtraElements]
    class Address
    {
        [BsonElement("country")]
        public string Country { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
    }
}
