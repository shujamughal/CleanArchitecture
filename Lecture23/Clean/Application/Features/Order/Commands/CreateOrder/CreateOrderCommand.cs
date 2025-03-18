using MediatR;

namespace Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string OrderNumber { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; } // Foreign key to associate with a Customer
    }
}