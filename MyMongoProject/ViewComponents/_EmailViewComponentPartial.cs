using Microsoft.AspNetCore.Mvc;
using MyMongoProject.Services;

namespace MyMongoProject.ViewComponents
{
    public class _EmailViewComponentPartial : ViewComponent
    {
        private readonly EmailService _emailService;

        public _EmailViewComponentPartial(EmailService emailService)
        {
            _emailService = emailService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
