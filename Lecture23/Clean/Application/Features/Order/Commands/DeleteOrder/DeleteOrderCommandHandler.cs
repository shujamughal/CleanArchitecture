using Application.Exceptions;
using Application.Interfaces.Persistence;
using MediatR;

namespace Application.Features.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            // Find the order to delete
            var orderToDelete = await _unitOfWork.Orders.GetFirstOrDefaultAsync(o => o.Id == request.Id);

            if (orderToDelete == null)
            {
                // Throw NotFoundException if the Order is not found
                throw new NotFoundException(nameof(Order), request.Id);
            }

            // Remove the order from the database
            await _unitOfWork.Orders.RemoveAsync(orderToDelete);

            // Save changes to the database
            await _unitOfWork.Save();

            // Return Unit.Value to indicate success
            return Unit.Value;
        }
    }
}