using Loan.Domain.Enums;
using MediatR;

namespace Loan.Application.Features.Loans.Commands
{
    public record UpdateLoanStatusCommand(Guid LoanId, LoanStatus Status, string? Remarks): IRequest<bool>;
}
