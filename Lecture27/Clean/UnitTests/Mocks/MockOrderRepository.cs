using Application.Interfaces.Persistence;
using Domain;
using Moq;

namespace UnitTests.Mocks
{
    public class MockOrderRepository
    {
        public static Mock<IOrderRepository> GetMockOrderRepository()
        {
            var orders = new List<Order>
            {
                new Order { Id = 1, OrderNumber = "ORD001", TotalAmount = 100.50m, CustomerId = 1 },
                new Order { Id = 2, OrderNumber = "ORD002", TotalAmount = 200.75m, CustomerId = 2 },
                new Order { Id = 3, OrderNumber = "ORD003", TotalAmount = 300.00m, CustomerId = 3 }
            };

            var mockRepo = new Mock<IOrderRepository>();

            // Mock the GetAll method
            mockRepo.Setup(repo => repo.GetAllAsync(null)).ReturnsAsync(orders);

            // Mock the Add method
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Order>()))
                   .Returns((Order order) =>
                   {
                       orders.Add(order);
                       return Task.CompletedTask;
                   });

            // Mock the IsOrderNumberUnique method
            mockRepo.Setup(repo => repo.IsOrderNumberUniqueAsync(It.IsAny<string>()))
                   .ReturnsAsync((string orderNumber) =>
                   {
                       return !orders.Any(o => o.OrderNumber == orderNumber);
                   });

            // Mock the Update method
            mockRepo.Setup(repo => repo.Update(It.IsAny<Order>()))
                   .Callback((Order order) =>
                   {
                       var existingOrder = orders.FirstOrDefault(o => o.Id == order.Id);
                       if (existingOrder != null)
                       {
                           existingOrder.OrderNumber = order.OrderNumber;
                           existingOrder.TotalAmount = order.TotalAmount;
                           existingOrder.CustomerId = order.CustomerId;
                       }
                   });

            return mockRepo;
        }
    }
}
