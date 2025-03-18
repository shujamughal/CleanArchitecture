using Domain;

namespace Application.Interfaces.Persistence
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        // Additional methods specific to orders
        void Update(Order order);
        Task<bool> IsOrderNumberUniqueAsync(string orderNumber);
        Task<bool> ExistsAsync(int orderId);
    }
}