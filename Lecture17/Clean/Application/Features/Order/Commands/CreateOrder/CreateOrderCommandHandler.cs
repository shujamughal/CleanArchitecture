using Application.Exceptions;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new CreateOrderCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid Order data.", validationResult);
            }

            // Map the request to an Order entity
            var orderToCreate = _mapper.Map<Domain.Order>(request);

            // Add the Order to the database
            await _unitOfWork.Orders.AddAsync(orderToCreate);

            // Save changes
            await _unitOfWork.Save();

            // Return the ID of the newly created Order
            return orderToCreate.Id;
        }
    }
}