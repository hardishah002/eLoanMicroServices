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
    public class MarkNotificationReadCommandHandler : IRequestHandler<MarkNotificationReadCommand, Unit>
    {
        private readonly INotificationRepository _repository;

        public MarkNotificationReadCommandHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(MarkNotificationReadCommand request, CancellationToken cancellationToken)
        {
            var notification = await _repository.GetByIdAsync(request.NotificationId);

            if (notification == null) throw new KeyNotFoundException("Notification not found");

            notification.Status = "Read";

            await _repository.UpdateAsync(notification);

            return Unit.Value;
        }

        //Task IRequestHandler<MarkNotificationReadCommand>.Handle(MarkNotificationReadCommand request, CancellationToken cancellationToken)
        //{
        //    return Handle(request, cancellationToken);
        //}
    }
}
