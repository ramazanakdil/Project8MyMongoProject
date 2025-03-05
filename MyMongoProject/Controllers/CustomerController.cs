using Microsoft.AspNetCore.Mvc;
using MyMongoProject.Dtos.CustomerDtos;
using MyMongoProject.Services;

namespace MyMongoProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            await _customerService.CreateCustomerAsync(createCustomerDto);
            return RedirectToAction("CustomerList");
        }

        public async Task<IActionResult> CustomerList()
        {
            var values = await _customerService.GetAllCustomerWithCategoryAsync();
            return View(values);
        }

        public async Task<IActionResult> CustomerDelete(string id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(string id)
        {
            var value = await _customerService.GetByIdCustomerAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            await _customerService.UpdateCustomerAsync(updateCustomerDto);
            return RedirectToAction("CustomerList");
        }


    }
}
