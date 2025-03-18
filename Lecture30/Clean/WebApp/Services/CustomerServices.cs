using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Services
{
    public class CustomerServices : ICustomerServices
    {
        public Task<List<CustomerViewModel>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDetailsViewModel> GetCustomerDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
