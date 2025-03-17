using Application.Exceptions;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Order.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDetailsDTO> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            // Fetch single record
            var orderDetails = await _unitOfWork.Orders.GetFirstOrDefaultAsync(o => o.Id == request.Id);

            if (orderDetails == null)
            {
                // Throw NotFoundException if the Order is not found
                throw new NotFoundException(nameof(Order), request.Id);
            }

            // Map data to DTO
            var data = _mapper.Map<OrderDetailsDTO>(orderDetails);

            return data;
        }
    }
}