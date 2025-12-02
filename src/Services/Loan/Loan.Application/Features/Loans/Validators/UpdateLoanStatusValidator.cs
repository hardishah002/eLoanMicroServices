using FluentValidation;
using Loan.Application.Features.Loans.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
