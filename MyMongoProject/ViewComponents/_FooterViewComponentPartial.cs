using Microsoft.AspNetCore.Mvc;

namespace MyMongoProject.ViewComponents
{
    public class _FooterViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
