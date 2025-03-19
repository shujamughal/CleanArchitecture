using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Order.Queries.GetAllOrders
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<OrderDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OrderDTO>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            // Fetch data from the database
            var orderList = await _unitOfWork.Orders.GetAllAsync();

            // Map data to DTO
            var data = _mapper.Map<List<OrderDTO>>(orderList);

            // Return the data
            return data;
        }
    }
}