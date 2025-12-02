namespace Customer.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Domain.Entities.Customer customer);
        Task<bool> UpdateAsync(Domain.Entities.Customer customer);
        Task<bool> DeleteAsync(Guid customerId);
        Task<IEnumerable<Domain.Entities.Customer>> GetAllAsync();
        Task<Domain.Entities.Customer?> GetByIdAsync(Guid id);
    }
}
