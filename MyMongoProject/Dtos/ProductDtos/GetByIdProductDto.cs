namespace MyMongoProject.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string CategoryId { get; set; }
    }
}
