using Application.Models.Identity;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Identity
{
    public interface IUserService
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(string userId);
    }
}
