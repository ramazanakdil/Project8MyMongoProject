using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoProject.Dtos.ProductDtos;
using MyMongoProject.Entities;
using MyMongoProject.Models;
using MyMongoProject.Services;
using MyMongoProject.Services.ProductServices;

namespace MyMongoProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailService _emailService;
        private readonly IProductService _productService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, EmailService emailService, IProductService productService)
        {
            _logger = logger;
            _emailService = emailService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string Name, string Email, bool Subscribe)
        {
            if (Subscribe)
            {
                var subject = "Aboneliğiniz için Teşekkürler!";
                var body = $"Merhaba {Name},<br><br>Abone olduğunuz için teşekkür ederiz!";

                try
                {
                    // Servis aracılığıyla mail gönderimi
                    await _emailService.SendEmailAsync(Email, subject, body);

                    // Başarı mesajını göster
                    TempData["SuccessMessage"] = "Aboneliğiniz başarıyla kaydedildi ve teşekkür maili gönderildi!";
                }
                catch (Exception ex)
                {
                    // Hata mesajı göster
                    TempData["ErrorMessage"] = $"Bir hata oluştu: {ex.Message}";
                }
            }
            else
            {
                // Abone olunmadıysa sadece başarı mesajı
                TempData["SuccessMessage"] = "Aboneliğiniz başarıyla kaydedildi!";
            }

            return RedirectToAction("Index");  // İşlem tamamlandığında kullanıcıyı Index sayfasına yönlendir
        }




        [HttpGet]
        public async Task<IActionResult> SearchProducts(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return View("Index");  // Arama terimi boşsa ana sayfayı döndür
            }

            var products = await _productService.SearchProductsAsync(searchTerm);

            // Arama sonuçlarını DTO'ya dönüştür
            var resultProducts = new List<ResultProductDto>();

            foreach (var product in products)
            {
                resultProducts.Add(new ResultProductDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductImage = product.ProductImage,
                    CategoryId = product.CategoryId
                });
            }

            return View("SearchResults", resultProducts);  // Arama sonuçlarını SearchResults view'ında göster
        }

        public async Task<IActionResult> AllProducts()
        {
            var value = await _productService.GetAllProductsAsync();
            return View(value);
        }

    }
}
