using Microsoft.AspNetCore.Mvc;
using MyMongoProject.Dtos.CategoryDtos;
using MyMongoProject.Services.CategoryServices;

namespace MyMongoProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteCategory(string Id)
        {
            await _categoryService.DeleteCategoryAsync(Id);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string Id)
        {
            var values = await _categoryService.GetByIdCategoryAsync(Id);
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("CategoryList");
        }
    }
}
