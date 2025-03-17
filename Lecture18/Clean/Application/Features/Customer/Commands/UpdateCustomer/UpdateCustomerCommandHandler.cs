using Application.Interfaces.Persistence;
using MediatR;

namespace Application.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            // Find the customer to update
            var customerToUpdate = await _unitOfWork.Customers.GetFirstOrDefaultAsync(c => c.Id == request.Id);

            if (customerToUpdate == null)
            {
                throw new Exception("Customer not found.");
            }

            // Update the customer details
            customerToUpdate.Name = request.Name.Trim();
            customerToUpdate.Email = request.Email.Trim();
            _unitOfWork.Customers.Update(customerToUpdate);

            // Save changes to the database
            await _unitOfWork.Save();

            // Return the ID of the updated customer
            return customerToUpdate.Id;
        }
    }

}
