using Application.Interfaces.Persistence;
using Moq;

namespace UnitTests.Mocks
{
    public class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetMockUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();

            // Mock the CustomerRepository property
            var mockCustomerRepository = MockCustomerRepository.GetMockCustomerRepository();
            mockUow.Setup(uow => uow.Customers).Returns(mockCustomerRepository.Object);

            // Mock the OrderRepository property
            var mockOrderRepository = MockOrderRepository.GetMockOrderRepository();
            mockUow.Setup(uow => uow.Orders).Returns(mockOrderRepository.Object);

            // Mock the Save method
            mockUow.Setup(uow => uow.Save()).Returns(Task.CompletedTask);

            // Mock the Dispose method
            mockUow.Setup(uow => uow.Dispose()).Callback(() => { });

            return mockUow;
        }
    }
}
