using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;
namespace Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomersQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CustomerDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            // 1. Fetch data from the database  
            var customerList = await _unitOfWork.Customers.GetAllAsync();

            // 2. Map data to DTO  
            var data = _mapper.Map<List<CustomerDTO>>(customerList);

            // 3. Return  
            return data;
        }
    }
}
