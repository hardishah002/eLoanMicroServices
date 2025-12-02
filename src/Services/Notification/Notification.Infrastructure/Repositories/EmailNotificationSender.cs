using Notification.Application.Interfaces;

namespace Notification.Infrastructure.Repositories
{
    internal class EmailNotificationSender : INotificationSender
    {
        public Task SendAsync(string recipient, string message)
        {
            Console.WriteLine($"Email sent to {recipient}: {message}");
            return Task.CompletedTask;
        }
    }
}
