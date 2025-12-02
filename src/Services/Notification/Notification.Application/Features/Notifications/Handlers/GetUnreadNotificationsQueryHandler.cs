using MediatR;
using Notification.Application.Features.Notifications.Queries;
using Notification.Application.Interfaces;
using Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Handlers
{
    public class GetUnreadNotificationsQueryHandler : IRequestHandler<GetUnreadNotificationsQuery, List<Domain.Entities.Notification>>
    {
        private readonly INotificationRepository _repository;

        public GetUnreadNotificationsQueryHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Entities.Notification>> Handle(GetUnreadNotificationsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUnreadByCustomerIdAsync(request.CustomerId);
        }
    }
}
