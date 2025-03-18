using Application.Interfaces.Persistence;
using Domain;
using Moq;

namespace UnitTests.Mocks
{
    public class MockCustomerRepository
    {
        public static Mock<ICustomerRepository> GetMockCustomerRepository()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
                new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" },
                new Customer { Id = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com" }
            };

            var mockRepo = new Mock<ICustomerRepository>();

            // Mock the GetAll method
            mockRepo.Setup(repo => repo.GetAllAsync(null)).ReturnsAsync(customers);

            // Mock the Add method
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Customer>()))
                   .Returns((Customer customer) =>
                   {
                       customers.Add(customer);
                       return Task.CompletedTask;
                   });

            // Mock the IsCustomerUnique method
            mockRepo.Setup(repo => repo.IsCustomerUniqueAsync(It.IsAny<string>()))
                   .ReturnsAsync((string email) =>
                   {
                       return !customers.Any(c => c.Email == email);
                   });

            // Mock the Update method
            mockRepo.Setup(repo => repo.Update(It.IsAny<Customer>()))
                   .Callback((Customer customer) =>
                   {
                       var existingCustomer = customers.FirstOrDefault(c => c.Id == customer.Id);
                       if (existingCustomer != null)
                       {
                           existingCustomer.Name = customer.Name;
                           existingCustomer.Email = customer.Email;
                       }
                   });

            return mockRepo;
        }
    }
}
