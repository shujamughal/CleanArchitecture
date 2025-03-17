using MediatR;

namespace Application.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
