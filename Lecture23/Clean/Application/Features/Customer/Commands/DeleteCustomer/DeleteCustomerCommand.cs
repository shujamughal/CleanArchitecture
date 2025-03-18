using MediatR;

namespace Application.Features.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

}
