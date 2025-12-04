namespace Loan.Application.Interfaces
{
    public interface ICustomerServiceCLient
    {
        Task<bool> ValidateCustomerAsync(Guid customerId);
    }
}
