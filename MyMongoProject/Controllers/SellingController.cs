using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyMongoProject.Dtos.SellingDtos;
using MyMongoProject.Services.CategoryServices;
using MyMongoProject.Services.ProductServices;
using MyMongoProject.Services.SellingServices;

namespace MyMongoProject.Controllers
{
    public class SellingController : Controller
    {
        private readonly ISellingService _sellingService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public SellingController(ISellingService sellingService, ICategoryService categoryService, IProductService productService)
        {
            _sellingService = sellingService;
            _categoryService = categoryService;
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> CreateSelling()
        {
            var product = await _productService.GetAllProductsAsync();
            ViewBag.Products = product.Select(x => new SelectListItem
            {
                Text = x.ProductName,
                Value = x.ProductId
            }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSelling(CreateSellingDto createSellingDto)
        {
            await _sellingService.CreateSellingAsync(createSellingDto);
            var product = await _productService.GetAllProductsAsync();
            ViewBag.Products = product.Select(x => new SelectListItem
            {
                Text = x.ProductName,
                Value = x.ProductId
            }).ToList();
            return RedirectToAction("SellingList");
        }

        public async Task<IActionResult> SellingList()
        {
            var value = await _sellingService.GetResultSellingsAsync();
            return View(value);
        }

        public async Task<IActionResult> DeleteSelling(string id)
        {
            await _sellingService.RemoveSellingAsync(id);
            return RedirectToAction("SellingList");
        }
    }
}
