using AutoMapper;
using MongoDB.Driver;
using MyMongoProject.Dtos.ProductDtos;
using MyMongoProject.Dtos.SellingDtos;
using MyMongoProject.Entities;
using MyMongoProject.Services.CategoryServices;
using MyMongoProject.Services.ProductServices;
using MyMongoProject.Settings;

namespace MyMongoProject.Services.SellingServices
{
    public class SellingService : ISellingService
    {
        private readonly IMongoCollection<Selling> _sellingCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public SellingService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _sellingCollection = database.GetCollection<Selling>(_databaseSettings.SellingCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSellingAsync(CreateSellingDto createSellingDto)
        {
            var value = _mapper.Map<Selling>(createSellingDto);
            await _sellingCollection.InsertOneAsync(value);
        }

        public async Task<GetByIdSellingDto> GetByIdSellingAsync(string id)
        {
            var value = await _sellingCollection.Find(x => x.SellingId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSellingDto>(value);
        }

        public async Task<List<ResultSellingDto>> GetResultSellingsAsync()
        {
            var values = await _sellingCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Product = await _productCollection.Find(x => x.ProductId == item.ProductId).FirstAsync();
            }
            return _mapper.Map<List<ResultSellingDto>>(values);
        }

        public async Task<List<ResultProductDto>> GetTopSixSellingProductAsync()
        {
            var sellingGroup = await _sellingCollection
         .Aggregate()
         .Group(s => s.ProductId, g => new
         {
             ProductId = g.Key,
             TotalSelling = g.Count()
         })
         .SortByDescending(g => g.TotalSelling)
         .Limit(6)
         .ToListAsync();

            var productList = new List<ResultProductDto>();

            foreach (var group in sellingGroup)
            {
                var product = await _productCollection
                    .Find(p => p.ProductId == group.ProductId)
                    .FirstOrDefaultAsync();

                if (product != null)
                {
                    var productDto = _mapper.Map<ResultProductDto>(product);
                    productDto.TotalSelling = group.TotalSelling; // Toplam satış sayısını ata
                    productList.Add(productDto);
                }
            }

            return productList;
        }

        public async Task RemoveSellingAsync(string id)
        {
            await _sellingCollection.DeleteOneAsync(x => x.SellingId == id);
        }
    }
}
