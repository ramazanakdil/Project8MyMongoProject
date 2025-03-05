using MyMongoProject.Dtos.ProductDtos;
using MyMongoProject.Entities;

namespace MyMongoProject.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductDto>> GetLastTenProductsAsync();
        Task<List<Product>> SearchProductsAsync(string searchTerm);
    }
}
