using Loan.Application.Features.Loans.Commands;
using Loan.Application.Interfaces;
using MediatR;

namespace Loan.Application.Features.Loans.Handlers
{
    public class UpdateLoanStatusCommandHandler : IRequestHandler<UpdateLoanStatusCommand, bool>
    {
        private readonly ILoanRepository _repository;

        public UpdateLoanStatusCommandHandler(ILoanRepository repository, IMediator mediator)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateLoanStatusCommand request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetByIdAsync(request.LoanId);

            if (loan == null) return false;

            loan.UpdateStatus(request.Status, request.Remarks);
            await _repository.UpdateAsync(loan);

            return true;
        }
    }
}
