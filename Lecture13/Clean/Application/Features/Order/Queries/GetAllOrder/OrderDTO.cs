namespace Application.Features.Order.Queries.GetAllOrders
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; } // Foreign key to associate with a Customer
    }
}