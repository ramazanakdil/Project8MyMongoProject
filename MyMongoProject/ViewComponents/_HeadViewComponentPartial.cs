using Microsoft.AspNetCore.Mvc;

namespace MyMongoProject.Components
{
    public class _HeadViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
        
    }
}
