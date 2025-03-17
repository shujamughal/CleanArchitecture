using MediatR;

namespace Application.Features.Order.Queries.GetAllOrders
{
    public class GetOrderQuery : IRequest<List<OrderDTO>>
    {
    }
}