using Loan.Domain.Enums;
using MediatR;

namespace Loan.Application.Features.Loans.Commands
{
    public record CreateLoanCommand(decimal LoanAmount, LoanType LoanType, decimal InterestRate, int TermMonths): IRequest<Guid>;
}
