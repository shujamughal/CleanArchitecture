using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Navigation property: A customer can have multiple orders.
        public List<Order> Orders { get; set; } = new List<Order>();
    }

}
