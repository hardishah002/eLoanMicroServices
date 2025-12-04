using FluentValidation;
using Loan.Application.Features.Loans.Commands;

namespace Loan.Application.Features.Loans.Validators
{
    public class UpdateLoanStatusValidator: AbstractValidator<UpdateLoanStatusCommand>
    {
        public UpdateLoanStatusValidator()
        {
            RuleFor(x => x.LoanId).NotEmpty();
            RuleFor(x => x.Status).IsInEnum();
            RuleFor(x => x.Remarks).MaximumLength(250);

        }
    }
}
