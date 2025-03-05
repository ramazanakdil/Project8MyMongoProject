using MyMongoProject.Dtos.DiscountDtos;

namespace MyMongoProject.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountDto>> GetAllDiscountAsync();
        Task CreateDiscountAsync(CreateDiscountDto createDiscountDto);
        Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto);
        Task DeleteDiscountAsync(string id);
        Task<GetByIdDiscountDto> GetByIdDiscountAsync(string id);
    }
}
