using Application.Interfaces.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsOrderNumberUniqueAsync(string orderNumber)
        {
            // Check if the order number is unique
            return await _dbContext.Orders.AnyAsync(o => o.OrderNumber == orderNumber) == false;
        }

        public async Task<bool> ExistsAsync(int orderId)
        {
            // Check if an order with the specified ID exists
            return await _dbContext.Orders.AnyAsync(o => o.Id == orderId);
        }

        public void Update(Order order)
        {
            // Update the order entity
            _dbContext.Update(order);
        }
    }
}