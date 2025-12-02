using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Application.Features.Loans.Queries
{
    public record GetLoanByIdQuery(Guid LoanId) : IRequest<Domain.Entities.Loan?>;
}
