using MediatR;

namespace Application.Features.Order.Queries.GetOrderDetails
{
    public record GetOrderDetailsQuery(int Id) : IRequest<OrderDetailsDTO>;
}