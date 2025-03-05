using MyMongoProject.Dtos.ProductDtos;
using MyMongoProject.Dtos.SellingDtos;

namespace MyMongoProject.Services.SellingServices
{
    public interface ISellingService
    {
        Task<List<ResultSellingDto>> GetResultSellingsAsync();
        Task RemoveSellingAsync(string id);
        Task CreateSellingAsync(CreateSellingDto createSellingDto);
        Task<GetByIdSellingDto> GetByIdSellingAsync(string id);
        Task<List<ResultProductDto>> GetTopSixSellingProductAsync();
    }
}
