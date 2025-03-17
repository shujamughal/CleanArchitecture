using Application.Interfaces.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsCustomerUniqueAsync(string email)
        {
            // Check if the email is unique
            return await _dbContext.Customers.AnyAsync(c => c.Email == email) == false;
        }

        public async Task<bool> ExistsAsync(int customerId)
        {
            // Check if a customer with the specified ID exists
            return await _dbContext.Customers.AnyAsync(c => c.Id == customerId);
        }

        public void Update(Customer customer)
        {
            // Update the customer entity
            _dbContext.Update(customer);
        }
    }
}