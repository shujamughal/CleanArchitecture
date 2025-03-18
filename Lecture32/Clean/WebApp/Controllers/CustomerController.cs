using Microsoft.AspNetCore.Mvc;
using WebApp.Interfaces;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        public async Task<IActionResult> CustomerList()
        {
            var customers = await _customerServices.GetCustomers();
            return View(customers);
        }

        public async Task<IActionResult> CustomerDetails(int id)
        {
            var customerDetails = await _customerServices.GetCustomerDetails(id);
            return View(customerDetails);
        }
    }
}
