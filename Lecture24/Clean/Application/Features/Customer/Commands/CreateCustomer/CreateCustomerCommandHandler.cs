using Application.Exceptions;
using Application.Interfaces.Persistence;
using Application.Logging;
using AutoMapper;
using MediatR;

namespace Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IAppLogger<CreateCustomerCommandHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // Log the start of the operation
            _logger.LogInformation("Creating a new customer with name: {Name}", request.Name);

            // Fluent Validation
            var validator = new CreateCustomerCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                // Log validation errors
                _logger.LogWarning("Validation failed for customer creation. Errors: {Errors}", validationResult.Errors);
                throw new BadRequestException("Invalid Customer data.", validationResult);
            }

            // Map the request to a Customer entity
            var customerToCreate = _mapper.Map<Domain.Customer>(request);

            // Add the Customer to the database
            await _unitOfWork.Customers.AddAsync(customerToCreate);

            // Save changes
            await _unitOfWork.Save();

            // Log the successful creation of the customer
            _logger.LogInformation("Customer created successfully with ID: {Id}", customerToCreate.Id);

            // Return the ID of the newly created Customer
            return customerToCreate.Id;
        }
    }
}
