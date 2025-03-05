using AutoMapper;
using MongoDB.Driver;
using MyMongoProject.Dtos.CategoryDtos;
using MyMongoProject.Dtos.CustomerDtos;
using MyMongoProject.Entities;
using MyMongoProject.Settings;

namespace MyMongoProject.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoriesCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoriesCollection= database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoriesCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string CategoryId)
        {
            await _categoriesCollection.DeleteOneAsync(x=>x.CategoryId==CategoryId);
        }

        public async Task<List<ResultCategoryCto>> GetAllCategoryAsync()
        {
            var value = await _categoriesCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultCategoryCto>>(value);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string CategoryId)
        {
            var value = await _categoriesCollection.Find(x=>x.CategoryId== CategoryId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoriesCollection.FindOneAndReplaceAsync(x=>x.CategoryId == updateCategoryDto.CategoryId, values);
        }
    }
}
