namespace Domain
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }

        // Foreign key
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}

