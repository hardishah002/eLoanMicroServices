namespace Document.Application.Services
{
    public interface ILoanServiceClient
    {
        Task<bool> ValidateLoanAsync(Guid loanId, CancellationToken cancellationToken);
    }
}
