using Microsoft.EntityFrameworkCore;

namespace Document.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Document> Documents { get; }

        Task<int> SaveChangeAsync(CancellationToken cancellationToken);
    }
}
