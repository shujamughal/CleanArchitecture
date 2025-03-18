using WebApp.Models;

namespace WebApp.Interfaces
{
    public interface ICustomerServices
    {
        Task<List<CustomerViewModel>> GetCustomers();
        Task<CustomerDetailsViewModel> GetCustomerDetails(int id);
    }
}
