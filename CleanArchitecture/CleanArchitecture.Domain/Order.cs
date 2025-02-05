using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }

        // Foreign key and navigation property: Each order belongs to a customer.
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }

}
