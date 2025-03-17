using MediatR;

namespace Application.Features.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; } // Foreign key to associate with a Customer
    }
}