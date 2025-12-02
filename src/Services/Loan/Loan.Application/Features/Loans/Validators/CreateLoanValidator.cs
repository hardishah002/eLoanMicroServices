using FluentValidation;
using Loan.Application.Features.Loans.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Application.Features.Loans.Validators
{
    public class CreateLoanValidator: AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.LoanAmount).GreaterThan(0);
            RuleFor(x => x.TermMonths).InclusiveBetween(6, 360);
            RuleFor(x => x.InterestRate).InclusiveBetween(1, 30);
        }
    }
}
