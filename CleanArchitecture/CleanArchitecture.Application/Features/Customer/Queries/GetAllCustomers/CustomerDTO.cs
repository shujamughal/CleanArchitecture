namespace CleanArchitecture.Application.Features.Customer.Queries.GetAllCustomers
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
