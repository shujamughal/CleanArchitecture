using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        // Add methods specific to Customer operations if needed.
        // Get a customer by email address. Task<Customer?> GetCustomerByEmailAsync(string email); 
        // Get customers who have placed orders since a specific date. Task<List<Customer>> GetCustomersWithRecentOrdersAsync(DateTime fromDate); 
    }
}
