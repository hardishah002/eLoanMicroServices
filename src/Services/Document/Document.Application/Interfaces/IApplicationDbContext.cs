using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Document> Documents { get; }

        Task<int> SaveChangeAsync(CancellationToken cancellationToken);
    }
}
