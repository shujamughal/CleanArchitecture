using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDTO>>
    {
        // No parameters are needed for this query.
    }
}
