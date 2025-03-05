using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MyMongoProject.Dtos.ProductDtos;
using MyMongoProject.Services.CategoryServices;
using MyMongoProject.Services.ProductServices;

namespace MyMongoProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _categoryService.GetAllCategoryAsync();

            ViewBag.Categories = categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            var categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.Categories = categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId
            }).ToList();
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var value = await _productService.GetByIdProductAsync(id);
            var categories = await _categoryService.GetAllCategoryAsync();

            ViewBag.Categories = categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId
            }).ToList();


            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);

            var categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.Categories = categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId
            }).ToList();

            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> ProductList()
        {
            var value = await _productService.GetAllProductsAsync();
            return View(value);
        }
    }
}
