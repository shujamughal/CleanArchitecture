using Application.Exceptions;
using Application.Features.Order.Commands.CreateOrder;
using Application.Interfaces.Persistence;
using Application.MappingProfiles;
using AutoMapper;
using Moq;
using Shouldly;
using UnitTests.Mocks;

namespace UnitTests.Features.Order.Commands
{
    public class CreateOrderCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandlerTests()
        {
            // Initialize the mock UnitOfWork
            _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();

            // Configure AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<OrderProfile>();
            });

            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidOrder_ShouldAddOrderAndReturnId()
        {
            // Arrange
            var handler = new CreateOrderCommandHandler(_mapper, _mockUnitOfWork.Object);
            var command = new CreateOrderCommand { OrderNumber = "ORD123", TotalAmount = 100.50m, CustomerId = 1 };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.ShouldBeGreaterThan(0); // Ensure the returned ID is valid
            var orders = await _mockUnitOfWork.Object.Orders.GetAllAsync();
            orders.Count.ShouldBe(4); // Ensure the new order is added (initial count is 3)
        }

        [Fact]
        public async Task Handle_InvalidOrder_ShouldThrowBadRequestException()
        {
            // Arrange
            var handler = new CreateOrderCommandHandler(_mapper, _mockUnitOfWork.Object);
            var command = new CreateOrderCommand { OrderNumber = string.Empty, TotalAmount = -1, CustomerId = 0 };

            // Act & Assert
            await Should.ThrowAsync<BadRequestException>(async () =>
            {
                await handler.Handle(command, CancellationToken.None);
            });
        }
    }
}
