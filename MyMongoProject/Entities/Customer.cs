using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoProject.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string DepartmentId { get; set; }
        [BsonIgnore]
        public Department Department { get; set; }
    }
}
