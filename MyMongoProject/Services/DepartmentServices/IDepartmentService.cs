using MyMongoProject.Dtos.DepartmentDtos;

namespace MyMongoProject.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<List<ResultDepartmentDto>> GetAllDepartmentAsync();
        Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
        Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
        Task DeleteDepartmentAsync(string departmentId);
        Task<GetByIdDepartmentDto> GetByIdDepartmentAsync(string departmentId);
    }
}
