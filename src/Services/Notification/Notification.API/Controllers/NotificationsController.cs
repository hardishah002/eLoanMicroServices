using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Features.Notifications.Commands;
using Notification.Application.Features.Notifications.Queries;


namespace Notification.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController: ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetNotifications(Guid customerId)
        {
            var result = await _mediator.Send(new GetNotificationsQuery(customerId));
            return Ok(result);
        }

        [HttpPatch("{id}/mark-read")]
        public async Task<IActionResult> MarkAsRead(Guid id)
        {
            await _mediator.Send(new MarkNotificationReadCommand(id));
            return NoContent();
        }

        [HttpGet("{customerId}/unread")]
        public async Task<IActionResult> GetUnreadNotificatrions(Guid customerId)
        { 
            var result = await _mediator.Send(new GetUnreadNotificationsQuery(customerId));
            return Ok(result);
        }
    }
}
