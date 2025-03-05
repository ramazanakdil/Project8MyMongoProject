using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMongoProject.Entities
{
    public class Selling
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SellingId { get; set; }
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
