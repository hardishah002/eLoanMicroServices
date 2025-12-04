using Customer.Application.Interfaces;
using Customer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Entities.Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Domain.Entities.Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);

            if (customer == null) return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Domain.Entities.Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Domain.Entities.Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
        }
        
        public async Task<Domain.Entities.Customer?> GetByCreatedByAsync(string createdBy)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.CreatedBy == createdBy);
        }
    }
}
