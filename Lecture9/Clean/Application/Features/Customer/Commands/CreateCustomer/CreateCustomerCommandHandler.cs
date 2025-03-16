using Application.Exceptions;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // Validate that Name is not empty or null
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new BadRequestException("Customer name cannot be empty or null.");
            }

            // Validate that Email is not empty or null
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new BadRequestException("Customer email cannot be empty or null.");
            }

            // Map the request to a Customer entity
            var customerToCreate = _mapper.Map<Customer>(request);

            // Add the Customer to the database
            await _unitOfWork.Customers.AddAsync(customerToCreate);

            // Save changes
            await _unitOfWork.Save();

            // Return the ID of the newly created Customer
            return customerToCreate.Id;
        }
    }

}
