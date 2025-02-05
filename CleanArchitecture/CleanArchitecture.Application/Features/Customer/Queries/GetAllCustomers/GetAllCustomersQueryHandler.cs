using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCustomersQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            // 1. Fetch data from the database using the Unit of Work.
            var customerList = await _unitOfWork.Customer.GetAllAsync();

            // 2. Map the data to DTOs.
            var data = _mapper.Map<List<CustomerDTO>>(customerList);

            // 3. Return the mapped data.
            return data;
        }
    }
}
