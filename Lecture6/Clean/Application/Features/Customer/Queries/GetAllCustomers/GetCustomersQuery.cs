using MediatR;
namespace Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetCustomersQuery : IRequest<List<CustomerDTO>>
    {
    }
}
