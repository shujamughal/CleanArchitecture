using Application.Exceptions;
using Application.Interfaces.Persistence;
using Application.Logging;
using AutoMapper;
using MediatR;

namespace Application.Features.Customer.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailsDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetCustomerDetailsQueryHandler> _logger;

        public GetCustomerDetailsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAppLogger<GetCustomerDetailsQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomerDetailsDTO> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            // Fetch single record
            var customerDetails = await _unitOfWork.Customers.GetFirstOrDefaultAsync(c => c.Id == request.Id);

            if (customerDetails == null)
            {
                // Throw NotFoundException if the Customer is not found
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            // Map data to DTO
            var data = _mapper.Map<CustomerDetailsDTO>(customerDetails);

            // Log the successful retrieval of customer details
            _logger.LogInformation("Customer details retrieved successfully for ID: {Id}", request.Id);

            return data;
        }
    }


}
