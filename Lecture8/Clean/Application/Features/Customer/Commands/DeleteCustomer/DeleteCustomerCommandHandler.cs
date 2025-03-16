using Application.Interfaces.Persistence;
using MediatR;

namespace Application.Features.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            // Find the customer to delete
            var customerToDelete = await _unitOfWork.Customers.GetFirstOrDefaultAsync(c => c.Id == request.Id);

            if (customerToDelete == null)
            {
                throw new Exception("Customer not found.");
            }

            // Remove the customer from the database
            await _unitOfWork.Customers.RemoveAsync(customerToDelete);

            // Save changes to the database
            await _unitOfWork.Save();

            // Return Unit.Value to indicate success
            return Unit.Value;
        }
    }

}
