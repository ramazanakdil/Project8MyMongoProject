using Microsoft.AspNetCore.Mvc;
using MyMongoProject.Services.DiscountServices;

namespace MyMongoProject.ViewComponents
{
    public class _FeatureAndDiscountViewComponentPartial : ViewComponent
    {
        private readonly IDiscountService _discountService;

        public _FeatureAndDiscountViewComponentPartial(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _discountService.GetAllDiscountAsync();

            return View(value);
        }
    }
}
