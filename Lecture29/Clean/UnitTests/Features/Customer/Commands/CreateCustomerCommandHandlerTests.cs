using Application.Exceptions;
using Application.Features.Customer.Commands.CreateCustomer;
using Application.Interfaces.Persistence;
using Application.Logging;
using Application.MappingProfiles;
using AutoMapper;
using Moq;
using Shouldly;
using UnitTests.Mocks;

namespace UnitTests.Features.Customer.Commands
{
    public class CreateCustomerCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mapper;
        private readonly Mock<IAppLogger<CreateCustomerCommandHandler>> _mockLogger;

        public CreateCustomerCommandHandlerTests()
        {
            // Initialize the mock UnitOfWork
            _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();

            // Configure AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<CustomerProfile>();
            });

            _mapper = mappingConfig.CreateMapper();

            // Initialize the mock logger
            _mockLogger = new Mock<IAppLogger<CreateCustomerCommandHandler>>();
        }

        [Fact]
        public async Task Handle_ValidCustomer_ShouldAddCustomerAndReturnId()
        {
            // Arrange
            var handler = new CreateCustomerCommandHandler(_mapper, _mockUnitOfWork.Object, _mockLogger.Object);
            var command = new CreateCustomerCommand { Name = "John Doe", Email = "john.doe@example.com" };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.ShouldBeGreaterThan(0); // Ensure the returned ID is valid

            // Verify the customer was added to the database
            var customers = await _mockUnitOfWork.Object.Customers.GetAllAsync();
            customers.Count.ShouldBe(4); // Ensure the new customer is added (initial count is 3)

            // Verify the logger was called
            _mockLogger.Verify(
                logger => logger.LogInformation("Creating a new customer with name: {Name}", command.Name),
                Times.Once);

            _mockLogger.Verify(
                logger => logger.LogInformation("Customer created successfully with ID: {Id}", result),
                Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidCustomer_ShouldThrowBadRequestException()
        {
            // Arrange
            var handler = new CreateCustomerCommandHandler(_mapper, _mockUnitOfWork.Object, _mockLogger.Object);
            var command = new CreateCustomerCommand { Name = string.Empty, Email = "invalid-email" };

            // Act & Assert
            await Should.ThrowAsync<BadRequestException>(async () =>
            {
                await handler.Handle(command, CancellationToken.None);
            });

            // Verify the logger was called for validation errors
            _mockLogger.Verify(
                logger => logger.LogWarning(It.IsAny<string>(), It.IsAny<object[]>()),
                Times.Once);
        }
    }
}