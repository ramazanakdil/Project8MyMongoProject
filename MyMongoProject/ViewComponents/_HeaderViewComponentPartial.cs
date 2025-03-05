using Microsoft.AspNetCore.Mvc;

namespace MyMongoProject.ViewComponents
{
    public class _HeaderViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
