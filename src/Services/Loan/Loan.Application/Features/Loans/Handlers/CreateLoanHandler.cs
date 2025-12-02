using Loan.Application.Features.Loans.Commands;
using Loan.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Application.Features.Loans.Handlers
{
    public class CreateLoanHandler : IRequestHandler<CreateLoanCommand, Guid>
    {
        private readonly ILoanRepository _repository;

        public CreateLoanHandler(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = new Domain.Entities.Loan(request.CustomerId, request.LoanAmount, request.LoanType, request.InterestRate, request.TermMonths);
            await _repository.AddAsync(loan);
            return loan.LoanId;
        }
    }
}
