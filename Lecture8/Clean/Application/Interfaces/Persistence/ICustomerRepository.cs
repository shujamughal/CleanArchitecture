
using Domain;

namespace Application.Interfaces.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        // Additional methods specific to customers
        void Update(Customer customer);
    }

}
