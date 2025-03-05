using Microsoft.AspNetCore.Mvc;

namespace MyMongoProject.ViewComponents
{
    public class _BannerViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
