using MediatR;

namespace Application.Features.Customer.Queries.GetCustomerDetails
{
    public record GetCustomerDetailsQuery(int Id) : IRequest<CustomerDetailsDTO>;
}
