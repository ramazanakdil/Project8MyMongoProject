using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMongoProject.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string CategoryId { get; set; }
    }
}
