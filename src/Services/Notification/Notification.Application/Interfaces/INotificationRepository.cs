using Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Interfaces
{
    public interface INotificationRepository
    {
        Task AddAsync(Domain.Entities.Notification notification);
        Task <List<Domain.Entities.Notification>> GetByCustomerIdAsync(Guid customerId);
        Task <List<Domain.Entities.Notification>> GetUnreadByCustomerIdAsync(Guid customerId);
        Task <Domain.Entities.Notification?> GetByIdAsync(Guid id);
        Task UpdateAsync(Domain.Entities.Notification notification);
    }
}
