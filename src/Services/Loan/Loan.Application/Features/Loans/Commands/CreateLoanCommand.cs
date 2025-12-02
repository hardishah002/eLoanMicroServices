using Loan.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Application.Features.Loans.Commands
{
    public record CreateLoanCommand(Guid CustomerId, decimal LoanAmount, LoanType LoanType, decimal InterestRate, int TermMonths): IRequest<Guid>;
}
