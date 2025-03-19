using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using Persistence.Repositories;
using Shouldly;

namespace IntegrationTests
{
    public class CustomerIntegrationTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public CustomerIntegrationTests()
        {
            // Configure in-memory database options
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        private void SeedTestData(ApplicationDbContext context)
        {
            // Add dummy customers to the in-memory database
            context.Customers.AddRange(
                new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
                new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
            );
            context.SaveChanges();
        }

        [Fact]
        public async Task Can_AddCustomer()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                // Seed test data
                SeedTestData(context);

                var repository = new CustomerRepository(context);
                var newCustomer = new Customer { Name = "Alice Johnson", Email = "alice.johnson@example.com" };

                // Act
                await repository.AddAsync(newCustomer);
                await context.SaveChangesAsync();

                // Assert
                var addedCustomer = await repository.GetFirstOrDefaultAsync(c => c.Id == newCustomer.Id);
                addedCustomer.ShouldNotBeNull();
                addedCustomer.Name.ShouldBe("Alice Johnson"); // Use ShouldBe for assertions
            }
        }

        [Fact]
        public async Task Can_GetCustomer()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                // Seed test data
                SeedTestData(context);

                var repository = new CustomerRepository(context);

                // Act
                var customer = await repository.GetFirstOrDefaultAsync(c => c.Id == 1);

                // Assert
                customer.ShouldNotBeNull();
                customer.Name.ShouldBe("John Doe");
            }
        }
    }
}
