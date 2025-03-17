using Application.Interfaces.Persistence;
using FluentValidation;

namespace Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Customer name is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("Customer name must not exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Customer email is required.")
                .NotNull()
                .EmailAddress().WithMessage("Customer email must be a valid email address.")
                .MaximumLength(100).WithMessage("Customer email must not exceed 100 characters.");

            RuleFor(x => x)
                .MustAsync(BeUniqueEmail).WithMessage("Customer email already exists.");
        }

        private async Task<bool> BeUniqueEmail(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Customers.IsCustomerUniqueAsync(command.Email);
        }
    }
}


}
