﻿using Application.Exceptions;
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
            // Fluent Validation
            var validator = new CreateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid Customer data.", validationResult);
            }

            // Map the request to a Customer entity
            var customerToCreate = _mapper.Map<Domain.Customer>(request);

            // Add the Customer to the database
            await _unitOfWork.Customers.AddAsync(customerToCreate);

            // Save changes
            await _unitOfWork.Save();

            // Return the ID of the newly created Customer
            return customerToCreate.Id;
        }
    }


}
