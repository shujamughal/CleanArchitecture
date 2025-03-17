using Application.Interfaces.Persistence;
using FluentValidation;

namespace Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.OrderNumber)
                .NotEmpty().WithMessage("Order number is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("Order number must not exceed 50 characters.");

            RuleFor(x => x.TotalAmount)
                .NotEmpty().WithMessage("Total amount is required.")
                .GreaterThan(0).WithMessage("Total amount must be greater than 0.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.")
                .MustAsync(BeValidCustomerId).WithMessage("The specified Customer does not exist.");

            RuleFor(x => x)
                .MustAsync(BeUniqueOrderNumber).WithMessage("Order number already exists.");
        }

        private async Task<bool> BeValidCustomerId(int customerId, CancellationToken cancellationToken)
        {
            // Check if the CustomerId exists in the database
            return await _unitOfWork.Customers.ExistsAsync(customerId);
        }

        private async Task<bool> BeUniqueOrderNumber(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            // Check if the Order number is unique
            return await _unitOfWork.Orders.IsOrderNumberUniqueAsync(command.OrderNumber);
        }
    }
}