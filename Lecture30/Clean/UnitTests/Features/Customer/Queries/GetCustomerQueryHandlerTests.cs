using Application.Features.Customer.Queries.GetAllCustomers;
using Application.Interfaces.Persistence;
using Application.Logging;
using Application.MappingProfiles;
using AutoMapper;
using Moq;
using Shouldly;
using UnitTests.Mocks;

namespace UnitTests.Features.Customer.Queries
{
    public class GetCustomerQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mapper;
        private readonly Mock<IAppLogger<GetCustomersQueryHandler>> _mockAppLogger;

        public GetCustomerQueryHandlerTests()
        {
            // Initialize the mock UnitOfWork
            _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();

            // Configure AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<CustomerProfile>();
            });

            _mapper = mappingConfig.CreateMapper();

            // Initialize the mock logger (if needed)
            _mockAppLogger = new Mock<IAppLogger<GetCustomersQueryHandler>>();
        }

        [Fact]
        public async Task Handle_ShouldReturnListOfCustomerDTOs()
        {
            // Arrange
            var handler = new GetCustomersQueryHandler(_mapper, _mockUnitOfWork.Object);
            var query = new GetCustomersQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<CustomerDTO>>();
            result.Count.ShouldBe(3); // Ensure the correct number of customers is returned
        }
    }
}
