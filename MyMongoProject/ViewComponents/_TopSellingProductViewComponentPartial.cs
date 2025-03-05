using Microsoft.AspNetCore.Mvc;
using MyMongoProject.Services.SellingServices;

namespace MyMongoProject.ViewComponents
{
    public class _TopSellingProductViewComponentPartial : ViewComponent
    {
        private readonly ISellingService _sellingService;

        public _TopSellingProductViewComponentPartial(ISellingService sellingService)
        {
            _sellingService = sellingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _sellingService.GetTopSixSellingProductAsync();
            return View(products);
        }
    }
}
