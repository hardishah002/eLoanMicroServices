using MediatR;

namespace Loan.Application.Features.Loans.Queries
{
    public record GetLoanByIdQuery(Guid LoanId) : IRequest<Domain.Entities.Loan?>;
}
