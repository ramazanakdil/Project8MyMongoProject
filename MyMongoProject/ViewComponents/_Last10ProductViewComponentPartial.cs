using Microsoft.AspNetCore.Mvc;
using MyMongoProject.Services.CategoryServices;
using MyMongoProject.Services.ProductServices;

namespace MyMongoProject.ViewComponents
{
    public class _Last10ProductViewComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public _Last10ProductViewComponentPartial(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _productService.GetLastTenProductsAsync();
            return View(value);
        }
    }
}
