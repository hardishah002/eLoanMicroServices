using Customer.Application.Features.Customers.Commands;
using FluentValidation;

namespace Customer.Application.Features.Customers.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().Matches(@"^\+?\d{10,15}$");
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
