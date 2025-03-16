using FluentValidation;

namespace Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Customer name is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("Customer name must not exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Customer email is required.")
                .NotNull()
                .EmailAddress().WithMessage("Customer email must be a valid email address.")
                .MaximumLength(100).WithMessage("Customer email must not exceed 100 characters.");
        }
    }

}
