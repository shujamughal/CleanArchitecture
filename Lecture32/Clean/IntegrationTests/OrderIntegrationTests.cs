using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using Persistence.Repositories;
using Shouldly;

namespace IntegrationTests
{
    public class OrderIntegrationTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public OrderIntegrationTests()
        {
            // Configure in-memory database options
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        private void SeedTestData(ApplicationDbContext context)
        {
            // Add dummy orders to the in-memory database
            context.Orders.AddRange(
                new Order { Id = 1, OrderNumber = "ORD001", TotalAmount = 100.50m, CustomerId = 1 },
                new Order { Id = 2, OrderNumber = "ORD002", TotalAmount = 200.75m, CustomerId = 2 }
            );
            context.SaveChanges();
        }

        [Fact]
        public async Task Can_AddOrder()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                // Seed test data
                SeedTestData(context);

                var repository = new OrderRepository(context);
                var newOrder = new Order { OrderNumber = "ORD003", TotalAmount = 300.00m, CustomerId = 1 };

                // Act
                await repository.AddAsync(newOrder);
                await context.SaveChangesAsync();

                // Assert
                var addedOrder = await repository.GetFirstOrDefaultAsync(o => o.Id == newOrder.Id);
                addedOrder.ShouldNotBeNull();
                addedOrder.OrderNumber.ShouldBe("ORD003"); // Use ShouldBe for assertions
            }
        }

        [Fact]
        public async Task Can_GetOrder()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                // Seed test data
                SeedTestData(context);

                var repository = new OrderRepository(context);

                // Act
                var order = await repository.GetFirstOrDefaultAsync(o => o.Id == 1);

                // Assert
                order.ShouldNotBeNull();
                order.OrderNumber.ShouldBe("ORD001");
            }
        }
    }
}
