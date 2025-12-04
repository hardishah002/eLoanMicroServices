using Loan.Application.Features.Loans.Commands;
using Loan.Application.Interfaces;
using Loan.Application.Service;
using MediatR;

namespace Loan.Application.Features.Loans.Handlers
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Guid>
    {
        private readonly ILoanRepository _repository;
        private readonly ICurrentUserService _service;
        private readonly ICustomerServiceCLient _serviceCLient;

        public CreateLoanCommandHandler(ILoanRepository repository, ICurrentUserService service, ICustomerServiceCLient serviceCLient)
        {
            _repository = repository;
            _service = service;
            _serviceCLient = serviceCLient;
        }

        public async Task<Guid> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var customerId = _service.GetCustomerId();

            var isValidCustomer = await _serviceCLient.ValidateCustomerAsync(customerId);

            if (!isValidCustomer) throw new InvalidOperationException("Customer does not exist.");

            var loan = new Domain.Entities.Loan(customerId, request.LoanAmount, request.LoanType, request.InterestRate, request.TermMonths);
            await _repository.AddAsync(loan);
            return loan.LoanId;
        }
    }
}