using Application.Features.Order.Queries.GetAllOrders;
using Application.Interfaces.Persistence;
using Application.Logging;
using Application.MappingProfiles;
using AutoMapper;
using Moq;
using Shouldly;
using UnitTests.Mocks;

namespace UnitTests.Features.Order.Queries
{
    public class GetOrderQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mapper;
        private readonly Mock<IAppLogger<GetOrderQueryHandler>> _mockAppLogger;

        public GetOrderQueryHandlerTests()
        {
            // Initialize the mock UnitOfWork
            _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();

            // Configure AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<OrderProfile>();
            });

            _mapper = mappingConfig.CreateMapper();

            // Initialize the mock logger (if needed)
            _mockAppLogger = new Mock<IAppLogger<GetOrderQueryHandler>>();
        }

        [Fact]
        public async Task Handle_ShouldReturnListOfOrderDTOs()
        {
            // Arrange
            var handler = new GetOrderQueryHandler(_mapper, _mockUnitOfWork.Object);
            var query = new GetOrderQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<OrderDTO>>();
            result.Count.ShouldBe(3); // Ensure the correct number of orders is returned
        }
    }
}
