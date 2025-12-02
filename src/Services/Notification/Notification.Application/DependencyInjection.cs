using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Common.Behaviors;
using Notification.Application.Features.EventBus.Loans.Events;
using Notification.Application.Features.EventBus.Loans.Handlers;
using Notification.Application.Interfaces;

namespace Notification.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(a => a.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
            services.AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }

        public static void ConfigureEventSubscriptions(this IServiceProvider serviceProvider)
        {
            var eventBus =  serviceProvider.GetRequiredService<IEventBus>();

            var handler = serviceProvider.GetRequiredService<LoanApplicationSubmittedEventHandler>();

            eventBus.Subscribe<LoanApplicationSubmittedEvent>(async (evt) =>
            { 
                await handler.Handle(evt);
            });
        }
    }
}
