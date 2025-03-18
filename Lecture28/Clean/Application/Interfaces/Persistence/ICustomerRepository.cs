using Domain;

namespace Application.Interfaces.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        // Additional methods specific to customers
        void Update(Customer customer);
        Task<bool> IsCustomerUniqueAsync(string email);
        Task<bool> ExistsAsync(int customerId);
    }
}