using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MyMongoProject.Dtos.ProductDtos;
using MyMongoProject.Entities;
using MyMongoProject.Settings;

namespace MyMongoProject.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productsCollection;
        private readonly IMongoCollection<Category> _categoriesCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productsCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoriesCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            var category = await _categoriesCollection.Find(c => c.CategoryId == product.CategoryId).FirstOrDefaultAsync();


            await _productsCollection.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(string id)
        {
            var result = await _productsCollection.DeleteOneAsync(p => p.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var products = await _productsCollection.Find(x => true).ToListAsync();
            foreach (var product in products)
            {
                product.Category = await _categoriesCollection.Find(c => c.CategoryId == product.CategoryId).FirstOrDefaultAsync();
            }

            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var product = await _productsCollection.Find(p => p.ProductId == id).FirstOrDefaultAsync();



            product.Category = await _categoriesCollection.Find(c => c.CategoryId == product.CategoryId).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdProductDto>(product);
        }

        public async Task<List<ResultProductDto>> GetLastTenProductsAsync()
        {
            var products = await _productsCollection.Find(FilterDefinition<Product>.Empty)
                .SortByDescending(p => p.ProductId)
                .Limit(10)
                .ToListAsync();
            var productDtos = _mapper.Map<List<ResultProductDto>>(products);
            return productDtos;
        }

        public async Task<List<Product>> SearchProductsAsync(string searchTerm)
        {
            var filter = Builders<Product>.Filter.Regex(p => p.ProductName, new BsonRegularExpression(searchTerm, "i"));
            var result = await _productsCollection.Find(filter).ToListAsync();
            return result;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            var category = await _categoriesCollection.Find(c => c.CategoryId == product.CategoryId).FirstOrDefaultAsync();
            var result = await _productsCollection.ReplaceOneAsync(p => p.ProductId == product.ProductId, product);


        }
    }
}
