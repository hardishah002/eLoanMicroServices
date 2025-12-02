using MediatR;
using Notification.Application.Features.Notifications.Commands;
using Notification.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Handlers
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, Guid>
    {
        private readonly INotificationRepository _repository;

        public CreateNotificationCommandHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Domain.Entities.Notification
            {
                NotificationId = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                Message = request.Message,
                Status = "Unread",
                CreatedDate = DateTime.UtcNow,
            };

            await _repository.AddAsync(notification);
            return notification.NotificationId;
        }
    }
}
