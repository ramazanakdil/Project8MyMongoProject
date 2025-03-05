using Microsoft.AspNetCore.Mvc;
using MyMongoProject.Services;

namespace MyMongoProject.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(string Name, string Email, bool Subscribe)
        {

            if (!string.IsNullOrEmpty(Email))
            {
                string message = $"Merhaba {Name}, Firmamızın 10. yılına özel %10 indirim kuponu hesabınıza tanımlanmıştır.";
                await _emailService.SendEmailAsync(Email, "Özel İndirim Kuponu", message);

                TempData["SuccessMessage"] = "Mail başarıyla gönderildi!";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
