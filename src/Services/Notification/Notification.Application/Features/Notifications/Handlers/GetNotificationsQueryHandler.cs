using MediatR;
using Notification.Application.Features.Notifications.Queries;
using Notification.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Features.Notifications.Handlers
{
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, List<Domain.Entities.Notification>>
    {
        private readonly INotificationRepository _repository;

        public GetNotificationsQueryHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Entities.Notification>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByCustomerIdAsync(request.CustomerId);
        }
    }
}
