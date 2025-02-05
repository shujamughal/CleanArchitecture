using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        // Add methods specific to Order operations if needed.
        // Get all orders for a specific customer. Task<List<Order>> GetOrdersByCustomerIdAsync(int customerId); 
        // Get an order using its unique order number. Task<Order?> GetOrderByOrderNumberAsync(string orderNumber); 
        // Get orders within a specified date range. Task<List<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate); 
    }
}
