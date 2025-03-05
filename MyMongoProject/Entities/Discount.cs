using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoProject.Entities
{
    public class Discount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DiscountId { get; set; }
        public string DiscountRate { get; set; }
        public string DiscountTitle { get; set; }
        public string Button { get; set; }
        public string ImageUrl { get; set; }
    }
}
