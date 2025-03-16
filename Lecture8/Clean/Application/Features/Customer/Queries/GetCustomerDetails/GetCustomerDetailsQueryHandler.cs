using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Customer.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailsDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomerDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerDetailsDTO> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            // Fetch single record
            var customer = await _unitOfWork.Customers.GetFirstOrDefaultAsync(c => c.Id == request.Id);

            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }

            // Map data to DTO
            var data = _mapper.Map<CustomerDetailsDTO>(customer);

            return data;
        }
    }
}
