using Application.Identity;
using Application.Models.Identity;
using Domain;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _userManager.GetUsersInRoleAsync("Customer");
            return customers.Select(x => new Customer
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            }).ToList();
        }

        public async Task<Customer> GetCustomerById(string userId)
        {
            var customer = await _userManager.FindByIdAsync(userId);
            return new Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };
        }
    }
}
