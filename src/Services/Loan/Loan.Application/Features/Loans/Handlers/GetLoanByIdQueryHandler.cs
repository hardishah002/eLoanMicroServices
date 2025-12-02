using Loan.Application.Features.Loans.Queries;
using Loan.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Application.Features.Loans.Handlers
{
    public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, Domain.Entities.Loan?>
    {
        private readonly ILoanRepository _repository;

        public GetLoanByIdQueryHandler(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Loan?> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.LoanId);
        }
    }
}
