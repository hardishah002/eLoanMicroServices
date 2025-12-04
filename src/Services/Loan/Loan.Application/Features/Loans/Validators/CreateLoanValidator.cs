using FluentValidation;
using Loan.Application.Features.Loans.Commands;

namespace Loan.Application.Features.Loans.Validators
{
    public class CreateLoanValidator: AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanValidator()
        {
            RuleFor(x => x.LoanAmount).GreaterThan(0);
            RuleFor(x => x.TermMonths).InclusiveBetween(6, 360);
            RuleFor(x => x.InterestRate).InclusiveBetween(1, 30);
        }
    }
}
