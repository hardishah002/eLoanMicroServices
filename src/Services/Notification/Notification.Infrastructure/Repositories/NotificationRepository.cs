using Microsoft.EntityFrameworkCore;
using Notification.Application.Interfaces;
using Notification.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationDbContext _context;

        public NotificationRepository(NotificationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Entities.Notification notification)
        {
            await _context.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Domain.Entities.Notification>> GetByCustomerIdAsync(Guid customerId)
        {
            return await _context.Notifications
                .Where(a => a. CustomerId == customerId)
                .OrderByDescending(a => a.CreatedDate)
                .ToListAsync();
        }

        public async Task<Domain.Entities.Notification?> GetByIdAsync(Guid id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task<List<Domain.Entities.Notification>> GetUnreadByCustomerIdAsync(Guid customerId)
        {
            return await _context.Notifications
                .Where(a => a.CustomerId == customerId && a.Status == "Unread")
                .OrderByDescending(a => a.CreatedDate)
                .ToListAsync();
        }

        public async Task UpdateAsync(Domain.Entities.Notification notification)
        {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }
    }
}
