using Application.Exceptions;
using Application.Interfaces.Persistence;
using MediatR;

namespace Application.Features.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            // Find the order to update
            var orderToUpdate = await _unitOfWork.Orders.GetFirstOrDefaultAsync(o => o.Id == request.Id);

            if (orderToUpdate == null)
            {
                // Throw NotFoundException if the Order is not found
                throw new NotFoundException(nameof(Order), request.Id);
            }

            // Update the order details
            orderToUpdate.OrderNumber = request.OrderNumber.Trim();
            orderToUpdate.TotalAmount = request.TotalAmount;
            orderToUpdate.CustomerId = request.CustomerId;

            // Update the order in the database
            _unitOfWork.Orders.Update(orderToUpdate);

            // Save changes to the database
            await _unitOfWork.Save();

            // Return the ID of the updated order
            return orderToUpdate.Id;
        }
    }
}