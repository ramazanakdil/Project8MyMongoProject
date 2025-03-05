using Microsoft.AspNetCore.Mvc;
using MyMongoProject.Dtos.DepartmentDtos;
using MyMongoProject.Services.DepartmentServices;

namespace MyMongoProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> DepartmentList()
        {
            var values = await _departmentService.GetAllDepartmentAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            await _departmentService.CreateDepartmentAsync(createDepartmentDto);
            return RedirectToAction("DepartmentList");
        }

        public async Task<IActionResult> DeleteDepartment(string id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return RedirectToAction("DepartmentList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDepartment(string id)
        {
            var value = await _departmentService.GetByIdDepartmentAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            await _departmentService.UpdateDepartmentAsync(updateDepartmentDto);
            return RedirectToAction("DepartmentList");
        }
    }
}
