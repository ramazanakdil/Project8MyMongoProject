using Microsoft.AspNetCore.Mvc;
using MyMongoProject.Services.CategoryServices;

namespace MyMongoProject.ViewComponents
{
    public class _CategoryListViewComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryListViewComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _categoryService.GetAllCategoryAsync();
            return View(value);
        }
    }
}
