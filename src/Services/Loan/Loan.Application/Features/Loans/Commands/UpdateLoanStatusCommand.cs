using Loan.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Application.Features.Loans.Commands
{
    public record UpdateLoanStatusCommand(Guid LoanId, LoanStatus Status, string? Remarks): IRequest<bool>;
}
