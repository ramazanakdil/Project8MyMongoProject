using MyMongoProject.Dtos.CategoryDtos;

namespace MyMongoProject.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryCto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string CategoryId);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string CategoryId);
    }
}
